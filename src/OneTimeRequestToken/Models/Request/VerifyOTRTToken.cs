// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-10-11 19:34
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-10-11 19:40
// ***********************************************************************
//  <copyright file="VerifyOTRTToken.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace OneTimeRequestToken.Models.Request
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A verify otrt token.
    /// </summary>
    /// =================================================================================================
    public class VerifyOTRTToken
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the full pathname of the request file.
        /// </summary>
        /// <value>
        ///     The full pathname of the request file.
        /// </value>
        /// =================================================================================================
        public string RequestPath { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the HTTP method.
        /// </summary>
        /// <value>
        ///     The HTTP method.
        /// </value>
        /// =================================================================================================
        public string HttpMethod { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the token.
        /// </summary>
        /// <value>
        ///     The token.
        /// </value>
        /// =================================================================================================
        public string Token { get; set; }
    }
}