// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-09-24 21:06
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-09-26 19:50
// ***********************************************************************
//  <copyright file="GetOTRTokenResult.cs" company="">
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
using OneTimeRequestToken.Extensions;
using OneTimeRequestToken.Extensions.Http;
using System;
using System.Threading.Tasks;
// ReSharper disable InconsistentNaming

#endregion

namespace OneTimeRequestToken.Endpoints.GetOTRToken
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     Encapsulates the result of a get otr token. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="T:EndpointHostBinder.Abstractions.IEndpointHostResult"/>
    /// =================================================================================================
    public sealed class GetOTRTokenResult : IEndpointHostResult
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the otrt service.
        /// </summary>
        /// =================================================================================================
        private readonly IOTRTService _otrtService;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the <see cref="GetOTRTokenResult"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// =================================================================================================
        public GetOTRTokenResult(IServiceProvider serviceProvider) => _otrtService = serviceProvider.GetRequiredService<IOTRTService>();

        /// <inheritdoc/>
        public async Task ExecuteAsync(HttpContext context)
        {
            var queryParams = context.Request.Query.AsNameValueCollection();
            var requestPath = queryParams["requestPath"].TrimAndReduceSpace().ReplaceSpecialCharacters();
            var httpMethod = queryParams["httpMethod"].TrimAndReplaceSpecialCharacters().ReplaceSpecialCharacters();

            var token = await _otrtService.GenerateTokenAsync(requestPath, httpMethod);
            await context.WriteResponseAsync(token);
        }

        /// <inheritdoc/>
        public void Execute(HttpContext context) => ExecuteAsync(context).GetAwaiter().GetResult();
    }
}