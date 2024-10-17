// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-10-17 18:37
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-10-17 18:59
// ***********************************************************************
//  <copyright file="AppGeneralInfo.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using DomainCommonExtensions.DataTypeExtensions;
using System;
using System.Linq;

#endregion

//[assembly: InternalsVisibleTo("InternalAppDataStoreTests")]

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
        ///     Gets number of day.
        /// </summary>
        /// <returns>
        ///     The number of day.
        /// </returns>
        /// =================================================================================================
        internal static int GetNumberOfDay() => GetNumberRelatedToDate(DateTime.Now);

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets number related to date.
        /// </summary>
        /// <param name="date">The date Date/Time.</param>
        /// <returns>
        ///     The number related to date.
        /// </returns>
        /// =================================================================================================
        internal static int GetNumberRelatedToDate(DateTime date)
        {
            var sum = date.FormatDateToString_112().Select(x => x.ToString().ParseToInt()).ToArray().Sum();

            return sum < 5 ? sum + 8 : sum;
        }
    }
}