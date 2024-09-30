// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-09-23 17:43
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-09-23 17:43
// ***********************************************************************
//  <copyright file="OTRTInfo.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

using DomainCommonExtensions.CommonExtensions;
using DomainCommonExtensions.CommonExtensions.TypeParam;
using DomainCommonExtensions.DataTypeExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("InternalAppDataStoreTests")]
namespace OneTimeRequestToken.Helpers
{
    internal static class OTRTInfo
    {
        private static string _currentAppName;
        private static IEnumerable<string> _excludedPaths;

        private const string BaseHeaderTokenName = "X-XSRF-TOKEN.";

        private static IEnumerable<string> ExcludedPaths
        {
            get => _excludedPaths.IfIsNull(new List<string>());
            set => _excludedPaths = value;
        }

        private static string CurrentAppName
        {
            get => _currentAppName.IfIsNull("OTRT");
            set => _currentAppName = value;
        }

        private static string AppKey { get; set; }

        private static Func<Task<object>> UserIdentifierFunction { get; set; }

        private static Func<Task<object>> UserNameFunction { get; set; }

        private static TimeSpan TokenValidTime { get; set; }

        internal static int GetNumberOfDay() => GetNumberRelatedToDate(DateTime.Now);

        internal static int GetNumberRelatedToDate(DateTime date)
        {
            var sum = date.FormatDateToString_112().Select(x => x.ToString().ParseToInt()).ToArray().Sum();

            return sum < 5 ? sum + 8 : sum;
        }

        internal static void SetCurrentAppName(string appName) => CurrentAppName = appName;

        internal static string GetCurrentAppName() => CurrentAppName;

        internal static string GetOTRTHeaderVariableName() => $"{BaseHeaderTokenName}{CurrentAppName}";

        internal static string GetOTRTHeaderVariableNameValue() => $"{GetOTRTHeaderVariableName()}.";

        internal static string GetOTRTHeaderVariableNameValueEnc() => $"{GetOTRTHeaderVariableName()}-";

        internal static void SetExcludedPaths(IEnumerable<string> excludePath) => ExcludedPaths = excludePath;

        internal static IEnumerable<string> GetExcludedPaths() => ExcludedPaths;

        internal static void SetAppKey(string appKey) => AppKey = appKey;

        internal static string GetAppKey() => AppKey;

        internal static void SetFunctions(Func<Task<object>> userIdentifierFunction, Func<Task<object>> userNameFunction)
        {
            UserIdentifierFunction = userIdentifierFunction;
            UserNameFunction = userNameFunction;
        }

        internal static Func<Task<object>> GetUserIdentifierFunction() => UserIdentifierFunction;

        internal static Func<Task<object>> GetUserNameFunction() => UserNameFunction;


        internal static void SetTokenValidTime(TimeSpan timeSpan) => TokenValidTime = timeSpan;

        internal static TimeSpan GetTokenValidTime() => TokenValidTime == default ? TimeSpan.FromMinutes(5) : TokenValidTime;
    }
}