// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-10-17 18:47
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-10-17 18:59
// ***********************************************************************
//  <copyright file="AppExcludedPathInfo.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using DomainCommonExtensions.CommonExtensions.TypeParam;
using System.Collections.Generic;

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
        ///     The excluded paths.
        /// </summary>
        /// =================================================================================================
        private static IEnumerable<string> _excludedPaths;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the excluded paths.
        /// </summary>
        /// <value>
        ///     The excluded paths.
        /// </value>
        /// =================================================================================================
        private static IEnumerable<string> ExcludedPaths
        {
            get => _excludedPaths.IfIsNull(new List<string>());
            set => _excludedPaths = value;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Sets excluded paths.
        /// </summary>
        /// <param name="excludePath">Full pathname of the exclude file.</param>
        /// =================================================================================================
        internal static void SetExcludedPaths(IEnumerable<string> excludePath) => ExcludedPaths = excludePath;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the excluded paths in this collection.
        /// </summary>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the excluded paths in this
        ///     collection.
        /// </returns>
        /// =================================================================================================
        internal static IEnumerable<string> GetExcludedPaths() => ExcludedPaths;
    }
}