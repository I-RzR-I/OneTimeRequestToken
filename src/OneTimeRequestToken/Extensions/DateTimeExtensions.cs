// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-09-25 22:44
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-09-26 20:14
// ***********************************************************************
//  <copyright file="DateTimeExtensions.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using DomainCommonExtensions.DataTypeExtensions;
using OneTimeRequestToken.Helpers;
using System;

#endregion

namespace OneTimeRequestToken.Extensions
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A date time extensions.
    /// </summary>
    /// =================================================================================================
    internal static class DateTimeExtensions
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A DateTime extension method that queries if a token is valid.
        /// </summary>
        /// <param name="sourceDate">The sourceDate to act on.</param>
        /// <returns>
        ///     True if the token is valid, false if not.
        /// </returns>
        /// =================================================================================================
        internal static bool IsTokenValid(this DateTime sourceDate)
        {
            var currentDateTimeUtc = DateTime.Now.AsUtc();
            var tokenValidTime = OTRTInfo.GetTokenValidTime();

            if (currentDateTimeUtc > sourceDate && currentDateTimeUtc <= sourceDate.Add(tokenValidTime)) 
                return true;

            return false;
        }
    }
}