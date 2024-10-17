// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-10-17 15:18
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-10-17 15:18
// ***********************************************************************
//  <copyright file="TokenStoreInfo.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

// ReSharper disable ClassNeverInstantiated.Global
// 
namespace OneTimeRequestToken.Models.Internal
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     Information about the token store.
    /// </summary>
    /// =================================================================================================
    internal class TokenStoreInfo
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the ticks.
        /// </summary>
        /// <value>
        ///     The ticks.
        /// </value>
        /// =================================================================================================
        public short Ticks { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        /// =================================================================================================
        public string Value { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the <see cref="TokenStoreInfo"/> class.
        /// </summary>
        /// <param name="ticks">The ticks.</param>
        /// <param name="value">The value.</param>
        /// =================================================================================================
        public TokenStoreInfo(short ticks, string value)
        {
            Ticks = ticks;
            Value = value;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the <see cref="TokenStoreInfo"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// =================================================================================================
        public TokenStoreInfo(string value)
        {
            Ticks = 0;
            Value = value;
        }
    }
}