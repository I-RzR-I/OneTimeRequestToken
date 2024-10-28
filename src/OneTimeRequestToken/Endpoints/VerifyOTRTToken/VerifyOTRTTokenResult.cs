// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-10-11 16:09
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-10-11 19:30
// ***********************************************************************
//  <copyright file="VerifyOTRTTokenResult.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using DomainCommonExtensions.CommonExtensions.TypeParam;
using DomainCommonExtensions.DataTypeExtensions;
using EndpointHostBinder.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using OneTimeRequestToken.Abstractions;
using OneTimeRequestToken.Extensions.Http;
using OneTimeRequestToken.Helpers.InternalInfo;
using OneTimeRequestToken.Helpers.Serializer;
using System;
using System.IO;
using System.Threading.Tasks;

#endregion

namespace OneTimeRequestToken.Endpoints.VerifyOTRTToken
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     Encapsulates the result of a verify otrt token. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="T:EndpointHostBinder.Abstractions.IEndpointHostResult"/>
    /// =================================================================================================
    public sealed class VerifyOTRTTokenResult : IEndpointHostResult
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the otrt service.
        /// </summary>
        /// =================================================================================================
        private readonly IOTRTService _otrtService;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the <see cref="VerifyOTRTTokenResult" /> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// =================================================================================================
        public VerifyOTRTTokenResult(IServiceProvider serviceProvider) => _otrtService = serviceProvider.GetRequiredService<IOTRTService>();

        /// <inheritdoc/>
        public async Task ExecuteAsync(HttpContext context)
        {
            using var reader = new StreamReader(context.Request.Body);
            var body = await reader.ReadToEndAsync();

            var requestParam = (context.Request.ContentType.Contains(AppContentTypeInfo.LikeJson).IsTrue()
                        || (context.Request.Headers["Accept"].IfIsNull(new StringValues(string.Empty)).ToString()).Contains(AppContentTypeInfo.LikeJson).IsTrue())
                ? JsonObjectSerializer.FromString<Models.Request.VerifyOTRTToken>(body)
                : XmlObjectSerializer.FromString<Models.Request.VerifyOTRTToken>(body);

            var requestPath = requestParam.RequestPath;
            var httpMethod = requestParam.HttpMethod.IfIsNull(string.Empty).ToUpper()
                .TrimAndReplaceSpecialCharacters().ReplaceSpecialCharacters();
            var token = requestParam.Token;

            var isValid = await _otrtService.ValidateTokenAsync(token, httpMethod, requestPath);

            await context.WriteResponseAsync(isValid);
        }

        /// <inheritdoc/>
        public void Execute(HttpContext context) => ExecuteAsync(context).GetAwaiter().GetResult();
    }
}