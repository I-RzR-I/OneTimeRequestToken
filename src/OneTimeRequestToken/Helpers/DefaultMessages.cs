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

namespace OneTimeRequestToken.Helpers
{
    internal static class DefaultMessages
    {
        internal const string ErrorOnTokenValidation = "An error occurred on one time request token validation!";
        internal const string ErrorOnTokenGeneration = "An error occurred on one time request token generation!";
        internal const string ErrorNotHttpPostOrInvalid = "The HTTP method is not POST or is invalid!";
        internal const string ErrorTokenNotFound = "For current request, the validation token was not found!";
        internal const string ErrorInvalidToken = "The token is invalid!";
        internal const string ErrorInvalidTokenData = "Invalid token data! Try to get a new one!";
        internal const string ErrorOnBuildHeaderToken = "An error occurred on generate/build token header!";
        internal const string ErrorOnBuildClientToken = "An error occurred on generate/build token client!";
        internal const string ErrorOnInvokeTokenValidHandler = "An error occurred on initialize token validation handler!";
    }
}