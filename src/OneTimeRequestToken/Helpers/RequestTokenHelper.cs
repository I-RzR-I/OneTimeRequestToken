// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-09-25 23:35
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-09-26 21:03
// ***********************************************************************
//  <copyright file="RequestTokenHelper.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using DomainCommonExtensions.DataTypeExtensions;
using OneTimeRequestToken.Extensions;
using System;

#endregion

namespace OneTimeRequestToken.Helpers
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A request token helper.
    /// </summary>
    /// =================================================================================================
    internal static class RequestTokenHelper
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Query if 'cachedTokenDecrypt' is valid request.
        /// </summary>
        /// <param name="cachedTokenDecrypt">The cached token decrypt.</param>
        /// <param name="tokenDataDecrypt">The token data decrypt.</param>
        /// <param name="sourceHeaderToken">Source header token.</param>
        /// <returns>
        ///     True if valid request, false if not.
        /// </returns>
        /// =================================================================================================
        internal static bool IsValidRequest(string[] cachedTokenDecrypt, string[] tokenDataDecrypt, string[] sourceHeaderToken)
        {
            if (Convert.ToDateTime(cachedTokenDecrypt[0]).IsTokenValid().IsFalse()
                || cachedTokenDecrypt[1] != tokenDataDecrypt[1] || cachedTokenDecrypt[1] != sourceHeaderToken[1] || // user identifier
                cachedTokenDecrypt[2] != tokenDataDecrypt[2] ||                                                     // user name
                cachedTokenDecrypt[3] != tokenDataDecrypt[3] || cachedTokenDecrypt[3] != sourceHeaderToken[2] ||    // client IP
                cachedTokenDecrypt[4] != tokenDataDecrypt[4] || cachedTokenDecrypt[4] != sourceHeaderToken[3] ||    // request path
                cachedTokenDecrypt[5] != tokenDataDecrypt[5] || cachedTokenDecrypt[5] != sourceHeaderToken[4] ||    // HTTP method
                cachedTokenDecrypt[6] != tokenDataDecrypt[6] || cachedTokenDecrypt[6] != sourceHeaderToken[5]       // client Agent
               )
                return false;
            return true;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Builds header client token.
        /// </summary>
        /// <param name="utcDate">The UTC date.</param>
        /// <param name="userIdentifier">Identifier for the user.</param>
        /// <param name="clientIp">The client IP.</param>
        /// <param name="requestPath">Full pathname of the request file.</param>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="agent">The agent.</param>
        /// <returns>
        ///     A string.
        /// </returns>
        /// =================================================================================================
        internal static string BuildHeaderClientToken(DateTime utcDate, object userIdentifier, string clientIp, string requestPath, string httpMethod, string agent)
            => $"{utcDate}|{userIdentifier}|{clientIp}|{requestPath}|{httpMethod.ToUpper()}|{agent}";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Builds client token.
        /// </summary>
        /// <param name="utcDate">The UTC date.</param>
        /// <param name="userIdentifier">Identifier for the user.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="clientIp">The client IP.</param>
        /// <param name="requestPath">Full pathname of the request file.</param>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="agent">The agent.</param>
        /// <returns>
        ///     A string.
        /// </returns>
        /// =================================================================================================
        internal static string BuildClientToken(DateTime utcDate, object userIdentifier, object userName, string clientIp, string requestPath, string httpMethod, string agent)
            => $"{utcDate}|{userIdentifier}|{userName}|{clientIp}|{requestPath}|{httpMethod.ToUpper()}|{agent}";
    }
}