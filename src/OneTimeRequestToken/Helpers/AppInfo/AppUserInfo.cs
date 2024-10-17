// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-10-17 18:41
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-10-17 18:59
// ***********************************************************************
//  <copyright file="AppUserInfo.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using System.Threading.Tasks;

#endregion

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
    }
}