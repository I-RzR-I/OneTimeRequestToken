// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-09-23 16:05
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-09-23 19:04
// ***********************************************************************
//  <copyright file="IOTRTService.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using AggregatedGenericResultMessage.Abstractions;
using OneTimeRequestToken.Models.Result;
using System.Threading;
using System.Threading.Tasks;

#endregion

namespace OneTimeRequestToken.Abstractions
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     Interface for OTRT(One Time Request Token) service.
    /// </summary>
    /// =================================================================================================
    public interface IOTRTService
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Generates a one time access/request token asynchronous.
        /// </summary>
        /// <param name="requestPath">Full pathname of the request file.</param>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="cancellationToken">
        ///     (Optional) A token that allows processing to be cancelled.
        /// </param>
        /// <returns>
        ///     The generate token.
        /// </returns>
        /// =================================================================================================
        Task<IResult<GenerateTokenResult>> GenerateTokenAsync(string requestPath, string httpMethod, CancellationToken cancellationToken = default);

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Validates the token asynchronous.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="requestPath">(Optional) Full pathname of the request file.</param>
        /// <param name="cancellationToken">
        ///     (Optional) A token that allows processing to be cancelled.
        /// </param>
        /// <returns>
        ///     The validate token.
        /// </returns>
        /// =================================================================================================
        Task<IResult<VerifyTokenResult>> ValidateTokenAsync(string token, string httpMethod, string requestPath = null, CancellationToken cancellationToken = default);
    }
}