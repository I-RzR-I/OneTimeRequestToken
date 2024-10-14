// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-10-11 18:18
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-10-11 19:39
// ***********************************************************************
//  <copyright file="AppContentTypeHelper.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System.Collections.Generic;

// ReSharper disable MemberCanBePrivate.Global

#endregion

namespace OneTimeRequestToken.Helpers.InternalInfo
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     An application content type helper.
    /// </summary>
    /// =================================================================================================
    internal static class AppContentTypeInfo
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the like JSON.
        /// </summary>
        /// =================================================================================================
        internal const string LikeJson = "/json";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the application JSON.
        /// </summary>
        /// =================================================================================================
        internal const string AppJson = "application/json";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the application XML.
        /// </summary>
        /// =================================================================================================
        internal const string AppXml = "application/xml";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the text XML.
        /// </summary>
        /// =================================================================================================
        internal const string TxtXml = "text/xml";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) type of the allowed content.
        /// </summary>
        /// =================================================================================================
        internal static readonly IEnumerable<string> AllowedContentType = new List<string> { AppJson, AppXml, TxtXml };
    }
}