// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-10-14 15:46
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-10-14 15:46
// ***********************************************************************
//  <copyright file="GenerateTokenResult.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// 

#region U S A G E S

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

#endregion

namespace OneTimeRequestToken.Models.Result
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A generate token result data transfer object.
    /// </summary>
    /// =================================================================================================
    [DataContract(Name = "GenerateTokenResult")]
    public class GenerateTokenResult
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the name of the token header.
        /// </summary>
        /// <value>
        ///     The name of the token header.
        /// </value>
        /// =================================================================================================
        [DataMember(Name = "TokenHeaderName")]
        [JsonPropertyName(name: "tokenHeaderName")]
        public string TokenHeaderName { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the token header value.
        /// </summary>
        /// <value>
        ///     The token header value.
        /// </value>
        /// =================================================================================================
        [DataMember(Name = "TokenHeaderValue")]
        [JsonPropertyName(name: "tokenHeaderValue")]
        public string TokenHeaderValue { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the <see cref="GenerateTokenResult" /> class.
        /// </summary>
        /// <param name="tokenHeaderName">Name of the token header.</param>
        /// <param name="tokenHeaderValue">The token header value.</param>
        /// =================================================================================================
        public GenerateTokenResult(string tokenHeaderName, string tokenHeaderValue)
        {
            TokenHeaderName = tokenHeaderName;
            TokenHeaderValue = tokenHeaderValue;
        }
    }
}