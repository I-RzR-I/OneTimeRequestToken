// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-09-23 19:37
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-09-23 22:35
// ***********************************************************************
//  <copyright file="IClientBrowserInfoService.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using OneTimeRequestToken.Models;


#endregion

namespace OneTimeRequestToken.Abstractions
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     Interface for client browser information service.
    /// </summary>
    /// =================================================================================================
    public interface IClientBrowserInfoService
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Get user real IP.
        /// </summary>
        /// <returns>
        ///     The client IP.
        /// </returns>
        /// =================================================================================================
        string GetClientIp();

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets user client (browser) info.
        /// </summary>
        /// <returns>
        ///     The client information.
        /// </returns>
        /// =================================================================================================
        ClientInfo GetClientInfo();

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Get client platform.
        /// </summary>
        /// <returns>
        ///     The client platform.
        /// </returns>
        /// =================================================================================================
        string GetClientPlatform();
    }
}