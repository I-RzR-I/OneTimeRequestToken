// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-09-23 16:19
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-09-26 21:05
// ***********************************************************************
//  <copyright file="OTRTService.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using AggregatedGenericResultMessage;
using AggregatedGenericResultMessage.Abstractions;
using AggregatedGenericResultMessage.Enums;
using AggregatedGenericResultMessage.Extensions.Result.Messages;
using AggregatedGenericResultMessage.Models;
using DomainCommonExtensions.CommonExtensions;
using DomainCommonExtensions.CommonExtensions.TypeParam;
using DomainCommonExtensions.DataTypeExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OneTimeRequestToken.Abstractions;
using OneTimeRequestToken.Extensions;
using OneTimeRequestToken.Helpers;
using OneTimeRequestToken.Helpers.AppInfo;
using OneTimeRequestToken.Helpers.InternalInfo;
using OneTimeRequestToken.Models.Internal;
using OneTimeRequestToken.Models.Result;
using System;
using System.Threading;
using System.Threading.Tasks;
// ReSharper disable PossibleInvalidOperationException

#endregion

// ReSharper disable ClassNeverInstantiated.Global

namespace OneTimeRequestToken.Services
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A service for accessing otrt information. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="T:OneTimeRequestToken.Abstractions.IOTRTService"/>
    ///
    /// ### <inheritdoc cref="IOTRTService"/>
    /// =================================================================================================
    public sealed class OTRTService : IOTRTService
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the client browser information service.
        /// </summary>
        /// =================================================================================================
        private readonly IClientBrowserInfoService _clientBrowserInfoService;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the HTTP context accessor.
        /// </summary>
        /// =================================================================================================
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the logger.
        /// </summary>
        /// =================================================================================================
        private readonly ILogger<OTRTService> _logger;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the <see cref="OTRTService" /> class.
        /// </summary>
        /// <param name="clientBrowserInfoService">The client browser information service.</param>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
        /// <param name="logger">The logger.</param>
        /// =================================================================================================
        public OTRTService(
            IClientBrowserInfoService clientBrowserInfoService,
            IHttpContextAccessor httpContextAccessor, ILogger<OTRTService> logger)
        {
            _clientBrowserInfoService = clientBrowserInfoService;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<IResult<GenerateTokenResult>> GenerateTokenAsync(string requestPath, string httpMethod, CancellationToken cancellationToken = default)
        {
            try
            {
                var createdUtc = DateTime.Now.AsUtc();
                var encryptedToken = await BuildClientTokenAsync(requestPath, httpMethod, createdUtc);
                var encryptedHeaderTokenName = await BuildClientTokenHeaderNameAsync(requestPath, httpMethod);

                TokenStore.SetToken(encryptedHeaderTokenName.ResultToken, new TokenStoreInfo(encryptedToken.ClearToken, createdUtc));
                
                //Return data to client
                return await Task.FromResult(
                    Result<GenerateTokenResult>.Success(
                        new GenerateTokenResult(OTRTAppInfo.GetOTRTHeaderVariableName(), encryptedHeaderTokenName.ResultToken)));
            }
            catch (Exception e)
            {
                _logger.LogError(e, DefaultMessagesInfo.ErrorOnTokenGeneration);

                return Result<GenerateTokenResult>.Failure(DefaultMessagesInfo.ErrorOnTokenGeneration);
            }
        }

        /// <inheritdoc/>
        public async Task<IResult<VerifyTokenResult>> ValidateTokenAsync(string token, string httpMethod, string requestPath = null, CancellationToken cancellationToken = default)
        {
            try
            {
                var localRequestPath = requestPath.IsNullOrEmpty()
                    ? _httpContextAccessor.HttpContext?.Request.Path.ToString()
                    : requestPath;
                if (httpMethod.IsNullOrEmpty().IsFalse())
                {
                    var cacheToken = TokenStore.FindTokenValue(token);

                    if (cacheToken.IsNullOrEmpty().IsFalse())
                    {
                        TokenStore.IncrementTick(token);
                        var sourceHeaderToken = token.Replace(OTRTAppInfo.GetOTRTHeaderVariableNameValue(), string.Empty)
                            .AesDecryptString(OTRTAppInfo.GetAppKey()).Split('|');

                        if (Convert.ToDateTime(sourceHeaderToken[0]).IsTokenValid().IsFalse())
                        {
                            TokenStore.ForgetToken(token);

                            return await Task.FromResult(Result<VerifyTokenResult>
                                .Success(new VerifyTokenResult(false))
                                .AddMessage(new MessageDataModel(DefaultMessagesInfo.ErrorInvalidToken)));
                        }

                        var encryptedClientToken = await BuildClientTokenAsync(localRequestPath, httpMethod);

                        var cachedTokenDecrypt = cacheToken.AesDecryptString(OTRTAppInfo.GetAppKey()).Split('|');
                        var tokenDataDecrypt = encryptedClientToken.ClearToken.AesDecryptString(OTRTAppInfo.GetAppKey()).Split('|');

                        if (RequestTokenHelper.IsValidRequest(cachedTokenDecrypt, tokenDataDecrypt, sourceHeaderToken).IsFalse())
                        {
                            return await Task.FromResult(Result<VerifyTokenResult>
                                .Success(new VerifyTokenResult(false))
                                .AddMessage(new MessageDataModel(DefaultMessagesInfo.ErrorInvalidTokenData)));
                        }

                        //Remove from cache key
                        TokenStore.ForgetToken(token);

                        return await Task.FromResult(Result<VerifyTokenResult>
                            .Success(new VerifyTokenResult(true)));
                    }

                    return await Task.FromResult(Result<VerifyTokenResult>
                        .Success(new VerifyTokenResult(false))
                        .AddMessage(new MessageDataModel(DefaultMessagesInfo.ErrorTokenNotFound), MessageType.NotFound));
                }

                return await Task.FromResult(Result<VerifyTokenResult>
                    .Success(new VerifyTokenResult(false))
                    .AddMessage(new MessageDataModel(DefaultMessagesInfo.ErrorNotHttpPostOrInvalid)));
            }
            catch (Exception e)
            {
                _logger.LogError(e, DefaultMessagesInfo.ErrorOnTokenValidation);

                return Result<VerifyTokenResult>
                    .Failure(DefaultMessagesInfo.ErrorOnTokenValidation)
                    .AddError(e);
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Builds client token header name asynchronous.
        /// </summary>
        /// <exception cref="Exception">Thrown when an exception error condition occurs.</exception>
        /// <param name="requestPath">Full pathname of the request file.</param>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <returns>
        ///     The build client token header name.
        /// </returns>
        /// =================================================================================================
        private async Task<TokenInfo> BuildClientTokenHeaderNameAsync(string requestPath, string httpMethod)
        {
            try
            {
                var dayNumber = OTRTAppInfo.GetNumberOfDay();
                var userIdentifierFunc = OTRTAppInfo.GetUserIdentifierFunction();
                var clientInfo = _clientBrowserInfoService.GetClientInfo();

                var clientToken = RequestTokenHelper.BuildHeaderClientToken(DateTime.Now.AsUtc(),
                    userIdentifierFunc.IsNull() ? dayNumber : await userIdentifierFunc.Invoke(),
                    clientInfo.ClientIp, requestPath, httpMethod, clientInfo.ClientAgent);

                var encryptToken = clientToken.AesEncryptString(OTRTAppInfo.GetAppKey());
                var headerToken = $"{OTRTAppInfo.GetOTRTHeaderVariableNameValue()}{encryptToken}"; //.TruncateExactLength(dayNumber)

                return new TokenInfo(encryptToken, headerToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, DefaultMessagesInfo.ErrorOnBuildHeaderToken);

                throw new Exception(DefaultMessagesInfo.ErrorOnBuildHeaderToken);
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Builds client token asynchronous.
        /// </summary>
        /// <exception cref="Exception">Thrown when an exception error condition occurs.</exception>
        /// <param name="requestPath">Full pathname of the request file.</param>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="createdUtc">(Optional) The created UTC.</param>
        /// <returns>
        ///     The build client token.
        /// </returns>
        /// =================================================================================================
        private async Task<TokenInfo> BuildClientTokenAsync(string requestPath, string httpMethod, DateTime? createdUtc = null)
        {
            try
            {
                var dayNumber = OTRTAppInfo.GetNumberOfDay();
                var clientInfo = _clientBrowserInfoService.GetClientInfo();

                var userIdentifierFunc = OTRTAppInfo.GetUserIdentifierFunction();
                var userNameFunc = OTRTAppInfo.GetUserNameFunction();

                var clientToken = RequestTokenHelper.BuildClientToken((DateTime)createdUtc.IfIsNull(DateTime.Now.AsUtc()),
                    userIdentifierFunc.IsNull() ? dayNumber : await userIdentifierFunc.Invoke(),
                    userNameFunc.IsNull() ? $"{dayNumber}#{OTRTAppInfo.GetCurrentAppName()}" : await userNameFunc.Invoke(),
                    clientInfo.ClientIp, requestPath, httpMethod, clientInfo.ClientAgent
                );

                var encryptToken = clientToken.AesEncryptString(OTRTAppInfo.GetAppKey());
                var clientEncToken = $"{OTRTAppInfo.GetOTRTHeaderVariableNameValueEnc()}{encryptToken}";

                return new TokenInfo(encryptToken, clientEncToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, DefaultMessagesInfo.ErrorOnBuildClientToken);

                throw new Exception(DefaultMessagesInfo.ErrorOnBuildClientToken);
            }
        }
    }
}