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

using DomainCommonExtensions.DataTypeExtensions;
using EndpointHostBinder.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OneTimeRequestToken.Abstractions;
using OneTimeRequestToken.Extensions.Http;
using OneTimeRequestToken.Helpers.InternalInfo;
using OneTimeRequestToken.Helpers.Serializer;
using System;
using System.IO;
using System.Net;
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

            var requestParam = context.Request.ContentType.Contains(AppContentTypeInfo.LikeJson).IsTrue()
                ? JsonObjectSerializer.FromString<Models.VerifyOTRTToken>(body)
                : XmlObjectSerializer.FromString<Models.VerifyOTRTToken>(body);

            var requestPath = requestParam.RequestPath.TrimAndReduceSpace().ReplaceSpecialCharacters();
            var httpMethod = requestParam.HttpMethod.TrimAndReplaceSpecialCharacters().ReplaceSpecialCharacters();
            var token = requestParam.Token.TrimAndReplaceSpecialCharacters().ReplaceSpecialCharacters();

            var isValid = await _otrtService.ValidateTokenAsync(token, httpMethod, requestPath);

            if (isValid.IsSuccess.IsFalse())
                await context.ResponseWithErrorAsync(HttpStatusCode.BadRequest.ToInt(), isValid.GetFirstMessage());

            if ((context.Request.Headers["Accept"].ToString() ?? string.Empty).ToLower().Contains(AppContentTypeInfo.LikeJson))
                await context.WriteJsonAsync(isValid.IsSuccess);
            else
                await context.WriteXmlAsync(isValid.IsSuccess);
        }

        /// <inheritdoc/>
        public void Execute(HttpContext context) => ExecuteAsync(context).GetAwaiter().GetResult();
    }
}