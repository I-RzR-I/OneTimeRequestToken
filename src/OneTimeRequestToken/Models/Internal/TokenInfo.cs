// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-09-25 18:08
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-09-25 18:08
// ***********************************************************************
//  <copyright file="TokenInfo.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

namespace OneTimeRequestToken.Models.Internal
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A token information data transfer object.
    /// </summary>
    /// =================================================================================================
    internal class TokenInfo
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the clear token.
        /// </summary>
        /// <value>
        ///     The clear token.
        /// </value>
        /// =================================================================================================
        public string ClearToken { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the result token.
        /// </summary>
        /// <value>
        ///     The result token.
        /// </value>
        /// =================================================================================================
        public string ResultToken { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the <see cref="TokenInfo"/> class.
        /// </summary>
        /// <param name="clearToken">The clear token.</param>
        /// <param name="resultToken">The result token.</param>
        /// =================================================================================================
        public TokenInfo(string clearToken, string resultToken)
        {
            ClearToken = clearToken;
            ResultToken = resultToken;
        }
    }
}