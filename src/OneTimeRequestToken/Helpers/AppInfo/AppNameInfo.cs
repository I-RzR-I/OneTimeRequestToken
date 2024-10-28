// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-10-17 18:39
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-10-17 18:59
// ***********************************************************************
//  <copyright file="AppNameInfo.cs" company="">
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
    ///     Information about the OTRT application.
    /// </content>
    /// =================================================================================================
    internal static partial class OTRTAppInfo
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     The current application name.
        /// </summary>
        /// =================================================================================================
        private static string _currentAppName;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the current application name.
        /// </summary>
        /// <value>
        ///     The name of the current application.
        /// </value>
        /// =================================================================================================
        private static string CurrentAppName
        {
            get => _currentAppName.IfIsNull("OTRT");
            set => _currentAppName = value;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Sets current application name.
        /// </summary>
        /// <param name="appName">Name of the application.</param>
        /// =================================================================================================
        internal static void SetCurrentAppName(string appName) => CurrentAppName = appName;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets current application name.
        /// </summary>
        /// <returns>
        ///     The current application name.
        /// </returns>
        /// =================================================================================================
        internal static string GetCurrentAppName() => CurrentAppName;
    }
}