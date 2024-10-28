// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-10-18 00:14
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-10-21 00:14
// ***********************************************************************
//  <copyright file="VerifyTokenResult.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

#endregion

namespace OneTimeRequestToken.Models.Result
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     Encapsulates the result of a verify token.
    /// </summary>
    /// =================================================================================================
    [DataContract(Name = "VerifyTokenResult")]
    public class VerifyTokenResult
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets a value indicating whether this object is valid.
        /// </summary>
        /// <value>
        ///     True if this object is valid, false if not.
        /// </value>
        /// =================================================================================================
        [DataMember(Name = "IsValid")]
        [JsonPropertyName("isValid")]
        public bool IsValid { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the <see cref="VerifyTokenResult" /> class.
        /// </summary>
        /// <param name="isValid">
        ///     (Optional)
        ///     True if this object is valid, false if not.
        /// </param>
        /// =================================================================================================
        public VerifyTokenResult(bool isValid) => IsValid = isValid;
    }
}