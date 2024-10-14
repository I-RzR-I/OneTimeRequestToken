// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-10-11 18:41
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-10-11 19:32
// ***********************************************************************
//  <copyright file="XmlObjectSerializer.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System.IO;
using System.Xml.Serialization;

#endregion

namespace OneTimeRequestToken.Helpers.Serializer
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     An object for persisting XML object data.
    /// </summary>
    /// =================================================================================================
    internal static class XmlObjectSerializer
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Creates a new object from the given string.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="serializedResult">The serialized result.</param>
        /// <returns>
        ///     A T.
        /// </returns>
        /// =================================================================================================
        internal static T FromString<T>(string serializedResult) where T : class
        {
            var ser = new XmlSerializer(typeof(T));

            using var sr = new StringReader(serializedResult);

            return (T)ser.Deserialize(sr);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Convert this object into a string representation.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="unSerializedResult">The un serialized result.</param>
        /// <returns>
        ///     UnSerializedResult as a string.
        /// </returns>
        /// =================================================================================================
        internal static string ToString<T>(T unSerializedResult)
        {
            var xmlSerializer = new XmlSerializer(unSerializedResult.GetType());

            using var textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, unSerializedResult);

            return textWriter.ToString();
        }
    }
}