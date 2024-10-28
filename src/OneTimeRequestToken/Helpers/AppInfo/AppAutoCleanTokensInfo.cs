// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-10-20 23:36
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-10-20 23:43
// ***********************************************************************
//  <copyright file="AppAutoCleanTokensInfo.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using DomainCommonExtensions.CommonExtensions.TypeParam;

#endregion

namespace OneTimeRequestToken.Helpers.AppInfo
{
    /// -------------------------------------------------------------------------------------------------
    /// <content>
    ///     Information about the otrt application.
    /// </content>
    /// =================================================================================================
    internal static partial class OTRTAppInfo
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the automatic clean interval.
        /// </summary>
        /// <value>
        ///     The automatic clean interval.
        /// </value>
        /// =================================================================================================
        private static double AutoCleanInterval { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Sets automatic clean token interval.
        /// </summary>
        /// <param name="interval">The interval.</param>
        /// =================================================================================================
        internal static void SetAutoCleanTokenInterval(double interval) => AutoCleanInterval = interval;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets automatic clean token interval.
        /// </summary>
        /// <returns>
        ///     The automatic clean token interval.
        /// </returns>
        /// =================================================================================================
        internal static double GetAutoCleanTokenInterval() => AutoCleanInterval.IfIsNull(0.0);
    }
}