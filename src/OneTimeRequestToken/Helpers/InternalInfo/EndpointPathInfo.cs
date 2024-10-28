// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-10-11 16:04
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-10-11 16:04
// ***********************************************************************
//  <copyright file="EndpointPathHelper.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

namespace OneTimeRequestToken.Helpers.InternalInfo
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     An endpoint path helper.
    /// </summary>
    /// =================================================================================================
    internal static class EndpointPathInfo
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the root.
        /// </summary>
        /// =================================================================================================
        private const string Root = "/otrt";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) full pathname of the get token file.
        /// </summary>
        /// =================================================================================================
        internal static readonly string GetTokenPath = $"{Root}/token";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) full pathname of the verify token file.
        /// </summary>
        /// =================================================================================================
        internal static readonly string VerifyTokenPath = $"{Root}/verify-token";
    }
}