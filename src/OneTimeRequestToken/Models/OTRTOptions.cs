// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-09-24 00:45
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-09-25 21:05
// ***********************************************************************
//  <copyright file="OTRTOptions.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using System.Collections.Generic;

// ReSharper disable UnusedAutoPropertyAccessor.Global

#endregion

namespace OneTimeRequestToken.Models
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     An OTRT options.
    /// </summary>
    /// =================================================================================================
    public class OTRTOptions
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the name of the application.
        /// </summary>
        /// <value>
        ///     The name of the application.
        /// </value>
        /// =================================================================================================
        public string AppName { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the application key.
        /// </summary>
        /// <value>
        ///     The application key.
        /// </value>
        /// =================================================================================================
        public string AppKey { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the excluded paths.
        /// </summary>
        /// <value>
        ///     The excluded paths.
        /// </value>
        /// =================================================================================================
        public IEnumerable<string> ExcludedPaths { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the token valid time. Default value => 5 minutes.
        /// </summary>
        /// <value>
        ///     The token valid time.
        /// </value>
        /// =================================================================================================
        public TimeSpan TokenValidTime { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the maximum allowed token attempt.
        /// </summary>
        /// <value>
        ///     The maximum allowed token attempt.
        /// </value>
        /// =================================================================================================
        public short MaxAllowedTokenAttempt { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the automatic clean invalid token.
        /// </summary>
        /// <value>
        ///     The automatic clean invalid token.
        ///     Value in minutes.
        /// </value>
        /// =================================================================================================
        public double AutoCleanInvalidToken { get; set; }
    }
}