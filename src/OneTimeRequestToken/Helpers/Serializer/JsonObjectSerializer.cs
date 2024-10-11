// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-09-24 22:48
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-09-25 21:05
// ***********************************************************************
//  <copyright file="JsonObjectSerializer.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System.Text.Json;
using System.Text.Json.Serialization;

#endregion

namespace OneTimeRequestToken.Helpers.Serializer
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     An object for persisting JSON object data.
    /// </summary>
    /// =================================================================================================
    internal static class JsonObjectSerializer
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) options for controlling the operation.
        /// </summary>
        /// =================================================================================================
        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNameCaseInsensitive = true
        };

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Convert this object into a string representation.
        /// </summary>
        /// <param name="o">An object to process.</param>
        /// <returns>
        ///     A string that represents this object.
        /// </returns>
        /// =================================================================================================
        internal static string ToString(object o) => JsonSerializer.Serialize(o, Options);

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Creates a new object from the given string.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        ///     A T.
        /// </returns>
        /// =================================================================================================
        internal static T FromString<T>(string value) where T : class => JsonSerializer.Deserialize<T>(value, Options);
    }
}