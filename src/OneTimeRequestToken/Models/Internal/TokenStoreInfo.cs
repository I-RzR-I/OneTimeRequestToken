// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-10-18 00:14
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-10-21 00:12
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

#region U S A G E S

using DomainCommonExtensions.CommonExtensions.TypeParam;
using DomainCommonExtensions.DataTypeExtensions;
using System;

#endregion

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
        ///     Gets or sets the Date/Time of the created UTC.
        /// </summary>
        /// <value>
        ///     The created UTC.
        /// </value>
        /// =================================================================================================
        public DateTime CreatedUtc { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the <see cref="TokenStoreInfo" /> class.
        /// </summary>
        /// <param name="ticks">The ticks.</param>
        /// <param name="value">The value.</param>
        /// <param name="createdUtc">The created UTC Date/Time.</param>
        /// =================================================================================================
        public TokenStoreInfo(short ticks, string value, DateTime createdUtc)
        {
            Ticks = ticks;
            Value = value;
            CreatedUtc = createdUtc.IfIsNull(DateTime.Now.AsUtc());
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the <see cref="TokenStoreInfo" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="createdUtc">The created UTC Date/Time.</param>
        /// =================================================================================================
        public TokenStoreInfo(string value, DateTime createdUtc)
        {
            Ticks = 0;
            Value = value;
            CreatedUtc = createdUtc.IfIsNull(DateTime.Now.AsUtc());
        }
    }
}