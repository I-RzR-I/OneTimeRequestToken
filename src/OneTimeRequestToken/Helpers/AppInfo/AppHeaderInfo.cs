// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-10-17 18:42
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-10-17 18:59
// ***********************************************************************
//  <copyright file="AppHeaderInfo.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

namespace OneTimeRequestToken.Helpers.AppInfo
{
    /// -------------------------------------------------------------------------------------------------
    /// <content>
    ///     Information about the OTRT application.
    /// </content>
    /// =================================================================================================
    internal static partial class OTRTAppInfo
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) name of the base header token.
        /// </summary>
        /// =================================================================================================
        private const string BaseHeaderTokenName = "X-XSRF-TOKEN.";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets otrt header variable name.
        /// </summary>
        /// <returns>
        ///     The otrt header variable name.
        /// </returns>
        /// =================================================================================================
        internal static string GetOTRTHeaderVariableName() => $"{BaseHeaderTokenName}{CurrentAppName}";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets otrt header variable name value.
        /// </summary>
        /// <returns>
        ///     The otrt header variable name value.
        /// </returns>
        /// =================================================================================================
        internal static string GetOTRTHeaderVariableNameValue() => $"{GetOTRTHeaderVariableName()}.";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets otrt header variable name value encode.
        /// </summary>
        /// <returns>
        ///     The otrt header variable name value encode.
        /// </returns>
        /// =================================================================================================
        internal static string GetOTRTHeaderVariableNameValueEnc() => $"{GetOTRTHeaderVariableName()}-";
    }
}