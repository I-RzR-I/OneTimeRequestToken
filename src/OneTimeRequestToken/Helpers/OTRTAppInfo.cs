// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-09-23 17:43
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-10-11 21:19
// ***********************************************************************
//  <copyright file="OTRTAppInfo.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using DomainCommonExtensions.CommonExtensions.TypeParam;
using DomainCommonExtensions.DataTypeExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#endregion

[assembly: InternalsVisibleTo("InternalAppDataStoreTests")]

namespace OneTimeRequestToken.Helpers
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     Information about the otrt application.
    /// </summary>
    /// =================================================================================================
    internal static class OTRTAppInfo
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) name of the base header token.
        /// </summary>
        /// =================================================================================================
        private const string BaseHeaderTokenName = "X-XSRF-TOKEN.";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     The current application name.
        /// </summary>
        /// =================================================================================================
        private static string _currentAppName;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     The excluded paths.
        /// </summary>
        /// =================================================================================================
        private static IEnumerable<string> _excludedPaths;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the excluded paths.
        /// </summary>
        /// <value>
        ///     The excluded paths.
        /// </value>
        /// =================================================================================================
        private static IEnumerable<string> ExcludedPaths
        {
            get => _excludedPaths.IfIsNull(new List<string>());
            set => _excludedPaths = value;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the current application name.
        /// </summary>
        /// <value>
        ///     The name of the current application.
        /// </value>
        /// =================================================================================================
        private static string CurrentAppName
        {
            get => _currentAppName.IfIsNull("OTRT");
            set => _currentAppName = value;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the application key.
        /// </summary>
        /// <value>
        ///     The application key.
        /// </value>
        /// =================================================================================================
        private static string AppKey { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the user identifier function.
        /// </summary>
        /// <value>
        ///     A function delegate that yields a Task&lt;object&gt;
        /// </value>
        /// =================================================================================================
        private static Func<Task<object>> UserIdentifierFunction { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the user name function.
        /// </summary>
        /// <value>
        ///     A function delegate that yields a Task&lt;object&gt;
        /// </value>
        /// =================================================================================================
        private static Func<Task<object>> UserNameFunction { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets or sets the token valid time.
        /// </summary>
        /// <value>
        ///     The token valid time.
        /// </value>
        /// =================================================================================================
        private static TimeSpan TokenValidTime { get; set; }

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

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Sets current application name.
        /// </summary>
        /// <param name="appName">Name of the application.</param>
        /// =================================================================================================
        internal static void SetCurrentAppName(string appName) => CurrentAppName = appName;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets current application name.
        /// </summary>
        /// <returns>
        ///     The current application name.
        /// </returns>
        /// =================================================================================================
        internal static string GetCurrentAppName() => CurrentAppName;

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

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Sets excluded paths.
        /// </summary>
        /// <param name="excludePath">Full pathname of the exclude file.</param>
        /// =================================================================================================
        internal static void SetExcludedPaths(IEnumerable<string> excludePath) => ExcludedPaths = excludePath;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets the excluded paths in this collection.
        /// </summary>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the excluded paths in this
        ///     collection.
        /// </returns>
        /// =================================================================================================
        internal static IEnumerable<string> GetExcludedPaths() => ExcludedPaths;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Sets application key.
        /// </summary>
        /// <param name="appKey">The application key.</param>
        /// =================================================================================================
        internal static void SetAppKey(string appKey) => AppKey = appKey;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets application key.
        /// </summary>
        /// <returns>
        ///     The application key.
        /// </returns>
        /// =================================================================================================
        internal static string GetAppKey() => AppKey;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Sets the functions.
        /// </summary>
        /// <param name="userIdentifierFunction">The user identifier function.</param>
        /// <param name="userNameFunction">The user name function.</param>
        /// =================================================================================================
        internal static void SetFunctions(Func<Task<object>> userIdentifierFunction, Func<Task<object>> userNameFunction)
        {
            UserIdentifierFunction = userIdentifierFunction;
            UserNameFunction = userNameFunction;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets user identifier function.
        /// </summary>
        /// <returns>
        ///     A function delegate that yields a Task&lt;object&gt;
        /// </returns>
        /// =================================================================================================
        internal static Func<Task<object>> GetUserIdentifierFunction() => UserIdentifierFunction;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets user name function.
        /// </summary>
        /// <returns>
        ///     A function delegate that yields a Task&lt;object&gt;
        /// </returns>
        /// =================================================================================================
        internal static Func<Task<object>> GetUserNameFunction() => UserNameFunction;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Sets token valid time.
        /// </summary>
        /// <param name="timeSpan">The time span.</param>
        /// =================================================================================================
        internal static void SetTokenValidTime(TimeSpan timeSpan) => TokenValidTime = timeSpan;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets token valid time.
        /// </summary>
        /// <returns>
        ///     The token valid time.
        /// </returns>
        /// =================================================================================================
        internal static TimeSpan GetTokenValidTime() => TokenValidTime == default ? TimeSpan.FromMinutes(5) : TokenValidTime;
    }
}