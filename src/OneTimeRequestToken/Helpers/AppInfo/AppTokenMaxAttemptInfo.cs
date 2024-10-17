// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-10-17 18:28
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-10-17 18:59
// ***********************************************************************
//  <copyright file="AppTokenMaxAttemptInfo.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using DomainCommonExtensions.CommonExtensions;

#endregion

namespace OneTimeRequestToken.Helpers.AppInfo
{
    /// -------------------------------------------------------------------------------------------------
    /// <content>
    ///     Information about the OTRT application.
    /// </content>
    /// =================================================================================================
    internal static partial class OTRTAppInfo
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the maximum allowed token attempt.
        /// </summary>
        /// <value>
        ///     The maximum allowed token attempt.
        /// </value>
        /// =================================================================================================
        private static short MaxAllowedTokenAttempt { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Sets maximum allowed token attempt.
        /// </summary>
        /// <param name="maxAllowedTokenAttempt">The maximum allowed token attempt.</param>
        /// =================================================================================================
        internal static void SetMaxAllowedTokenAttempt(short maxAllowedTokenAttempt)
            => MaxAllowedTokenAttempt = maxAllowedTokenAttempt;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets maximum allowed token attempt.
        /// </summary>
        /// <returns>
        ///     The maximum allowed token attempt.
        /// </returns>
        /// =================================================================================================
        internal static short GetMaxAllowedTokenAttempt() 
            => (short)(MaxAllowedTokenAttempt.IsNull() || MaxAllowedTokenAttempt == 0 ? 5 : MaxAllowedTokenAttempt);
    }
}