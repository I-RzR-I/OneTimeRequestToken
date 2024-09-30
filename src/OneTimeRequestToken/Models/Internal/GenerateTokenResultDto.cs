// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-09-23 16:06
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-09-23 16:06
// ***********************************************************************
//  <copyright file="GenerateTokenResultDto.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// 

using System.Runtime.Serialization;

namespace OneTimeRequestToken.Models.Internal
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A generate token result data transfer object.
    /// </summary>
    /// =================================================================================================
    [DataContract]
    public class GenerateTokenResultDto
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the name of the token header.
        /// </summary>
        /// <value>
        ///     The name of the token header.
        /// </value>
        /// =================================================================================================
        [DataMember]
        public string TokenHeaderName { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the token header value.
        /// </summary>
        /// <value>
        ///     The token header value.
        /// </value>
        /// =================================================================================================
        [DataMember]
        public string TokenHeaderValue { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the <see cref="GenerateTokenResultDto"/> class.
        /// </summary>
        /// <param name="tokenHeaderName">Name of the token header.</param>
        /// <param name="tokenHeaderValue">The token header value.</param>
        /// =================================================================================================
        public GenerateTokenResultDto(string tokenHeaderName, string tokenHeaderValue)
        {
            TokenHeaderName = tokenHeaderName;
            TokenHeaderValue = tokenHeaderValue;
        }
    }
}