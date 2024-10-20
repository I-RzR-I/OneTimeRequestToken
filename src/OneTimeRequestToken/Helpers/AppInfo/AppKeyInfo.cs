﻿// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-10-17 18:33
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-10-17 18:59
// ***********************************************************************
//  <copyright file="AppKeyInfo.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

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
        ///     Gets or sets the application key.
        /// </summary>
        /// <value>
        ///     The application key.
        /// </value>
        /// =================================================================================================
        private static string AppKey { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Sets application key.
        /// </summary>
        /// <param name="appKey">The application key.</param>
        /// =================================================================================================
        internal static void SetAppKey(string appKey) => AppKey = appKey;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets application key.
        /// </summary>
        /// <returns>
        ///     The application key.
        /// </returns>
        /// =================================================================================================
        internal static string GetAppKey() => AppKey;
    }
}