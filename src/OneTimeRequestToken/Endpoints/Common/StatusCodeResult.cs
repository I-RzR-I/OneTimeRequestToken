// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-09-24 21:10
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-09-24 21:27
// ***********************************************************************
//  <copyright file="StatusCodeResult.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using EndpointHostBinder.Abstractions;
using Microsoft.AspNetCore.Http;
using OneTimeRequestToken.Extensions.Http;
using System.Net;
using System.Threading.Tasks;
// ReSharper disable MemberCanBePrivate.Global

#endregion

namespace OneTimeRequestToken.Endpoints.Common
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     Encapsulates the result of the status code.
    /// </summary>
    /// <seealso cref="T:EndpointHostBinder.Abstractions.IEndpointHostResult" />
    /// =================================================================================================
    public class StatusCodeResult : IEndpointHostResult
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the status code.
        /// </summary>
        /// <value>
        ///     The status code.
        /// </value>
        /// =================================================================================================
        public int StatusCode { get; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the <see cref="StatusCodeResult" /> class.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// =================================================================================================
        public StatusCodeResult(HttpStatusCode statusCode)
            => StatusCode = (int)statusCode;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the <see cref="StatusCodeResult" /> class.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// =================================================================================================
        public StatusCodeResult(int statusCode)
            => StatusCode = statusCode;

        /// <inheritdoc />
        public async Task ExecuteAsync(HttpContext context) 
            => await context.ResponseWithErrorAsync(StatusCode);

        /// <inheritdoc />
        public void Execute(HttpContext context)
            => context.ResponseWithError(StatusCode);
    }
}