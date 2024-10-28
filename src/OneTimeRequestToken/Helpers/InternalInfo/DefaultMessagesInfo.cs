// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-09-23 18:10
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-09-23 18:10
// ***********************************************************************
//  <copyright file="DefaultMessages.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

namespace OneTimeRequestToken.Helpers.InternalInfo
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A default messages.
    /// </summary>
    /// =================================================================================================
    internal static class DefaultMessagesInfo
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the error on token validation.
        /// </summary>
        /// =================================================================================================
        internal const string ErrorOnTokenValidation = "An error occurred on OTRT validation!";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the error on token generation.
        /// </summary>
        /// =================================================================================================
        internal const string ErrorOnTokenGeneration = "An error occurred on OTRT generation!";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the error not HTTP post or invalid.
        /// </summary>
        /// =================================================================================================
        internal const string ErrorNotHttpPostOrInvalid = "The HTTP method is not POST or is invalid!";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the error token not found.
        /// </summary>
        /// =================================================================================================
        internal const string ErrorTokenNotFound = "For current request, the validation token (OTRT) was not found!";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the error invalid token.
        /// </summary>
        /// =================================================================================================
        internal const string ErrorInvalidToken = "The token (OTRT) is invalid!";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) information describing the error invalid token.
        /// </summary>
        /// =================================================================================================
        internal const string ErrorInvalidTokenData = "Invalid token (OTRT) data! Try to get a new one!";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the error on build header token.
        /// </summary>
        /// =================================================================================================
        internal const string ErrorOnBuildHeaderToken = "An error occurred on generate/build token (OTRT) header!";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the error on build client token.
        /// </summary>
        /// =================================================================================================
        internal const string ErrorOnBuildClientToken = "An error occurred on generate/build token (OTRT) client!";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the error on invoke token valid handler.
        /// </summary>
        /// =================================================================================================
        internal const string ErrorOnInvokeTokenValidHandler = "An error occurred on initialize token (OTRT) validation handler!";
    }
}