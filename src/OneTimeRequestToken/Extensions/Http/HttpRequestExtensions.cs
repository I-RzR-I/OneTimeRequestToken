// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-09-24 23:17
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-09-26 20:13
// ***********************************************************************
//  <copyright file="HttpRequestExtensions.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using Microsoft.AspNetCore.Http;

#endregion

namespace OneTimeRequestToken.Extensions.Http
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A HTTP request extensions.
    /// </summary>
    /// =================================================================================================
    internal static class HttpRequestExtensions
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A HttpRequest extension method that sets access control allow origin.
        /// </summary>
        /// <param name="request">The request to act on.</param>
        /// <param name="origin">(Optional) The origin.</param>
        /// =================================================================================================
        internal static void SetAccessControlAllowOrigin(this HttpRequest request, string origin = "*")
            => request.Headers.Add("Access-Control-Allow-Origin", origin);
    }
}