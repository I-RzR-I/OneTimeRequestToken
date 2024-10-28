// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-10-17 18:44
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-10-17 18:59
// ***********************************************************************
//  <copyright file="AppTokenLifeTimeInfo.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;

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
        ///     Gets or sets the token valid time.
        /// </summary>
        /// <value>
        ///     The token valid time.
        /// </value>
        /// =================================================================================================
        private static TimeSpan TokenValidTime { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Sets token valid time.
        /// </summary>
        /// <param name="timeSpan">The time span.</param>
        /// =================================================================================================
        internal static void SetTokenValidTime(TimeSpan timeSpan) => TokenValidTime = timeSpan;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets token valid time.
        /// </summary>
        /// <returns>
        ///     The token valid time.
        /// </returns>
        /// =================================================================================================
        internal static TimeSpan GetTokenValidTime() => TokenValidTime == default ? TimeSpan.FromMinutes(5) : TokenValidTime;
    }
}