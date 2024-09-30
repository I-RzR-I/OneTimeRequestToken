// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-09-23 20:11
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-09-23 20:11
// ***********************************************************************
//  <copyright file="ClientInfoDto.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

// ReSharper disable IdentifierTypo
// ReSharper disable UnusedAutoPropertyAccessor.Global
// 
namespace OneTimeRequestToken.Models
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A client information data transfer object.
    /// </summary>
    /// =================================================================================================
    public class ClientInfoDto
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the client IP.
        /// </summary>
        /// <value>
        ///     The client IP.
        /// </value>
        /// =================================================================================================
        public string ClientIp { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the client agent.
        /// </summary>
        /// <value>
        ///     The client agent.
        /// </value>
        /// =================================================================================================
        public string ClientAgent { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the client security ch UA.
        /// </summary>
        /// <value>
        ///     The client security ch UA.
        /// </value>
        /// =================================================================================================
        public string ClientSecChUa { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the client security ch UA mobile.
        /// </summary>
        /// <value>
        ///     The client security ch UA mobile.
        /// </value>
        /// =================================================================================================
        public string ClientSecChUaMobile { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the client security ch UA full version.
        /// </summary>
        /// <value>
        ///     The client security ch UA full version.
        /// </value>
        /// =================================================================================================
        public string ClientSecChUaFullVersion { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the client security ch UA platform.
        /// </summary>
        /// <value>
        ///     The client security ch UA platform.
        /// </value>
        /// =================================================================================================
        public string ClientSecChUaPlatform { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the client security ch UA platform version.
        /// </summary>
        /// <value>
        ///     The client security ch UA platform version.
        /// </value>
        /// =================================================================================================
        public string ClientSecChUaPlatformVersion { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the client security ch UA arch.
        /// </summary>
        /// <value>
        ///     The client security ch UA arch.
        /// </value>
        /// =================================================================================================
        public string ClientSecChUaArch { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the client security ch UA bitness.
        /// </summary>
        /// <value>
        ///     The client security ch UA bitness.
        /// </value>
        /// =================================================================================================
        public string ClientSecChUaBitness { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the client security ch UA model.
        /// </summary>
        /// <value>
        ///     The client security ch UA model.
        /// </value>
        /// =================================================================================================
        public string ClientSecChUaModel { get; set; }
    }
}