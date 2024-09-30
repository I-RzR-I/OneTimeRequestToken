// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-09-24 21:55
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-09-25 21:25
// ***********************************************************************
//  <copyright file="CollectionExtensions.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

#endregion

namespace OneTimeRequestToken.Extensions
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A collection extensions.
    /// </summary>
    /// =================================================================================================
    internal static class CollectionExtensions
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     An IEnumerable&lt;KeyValuePair&lt;string,StringValues&gt;&gt; extension method that
        ///     converts a collection to a name value collection.
        /// </summary>
        /// <param name="collection">The collection to act on.</param>
        /// <returns>
        ///     A NameValueCollection.
        /// </returns>
        /// =================================================================================================
        internal static NameValueCollection AsNameValueCollection(this IEnumerable<KeyValuePair<string, StringValues>> collection)
        {
            var result = new NameValueCollection();

            foreach (var field in collection)
                result.Add(field.Key, field.Value.First());

            return result;
        }
    }
}