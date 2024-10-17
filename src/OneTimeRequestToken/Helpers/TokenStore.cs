// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-10-17 17:03
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-10-17 21:15
// ***********************************************************************
//  <copyright file="TokenStore.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using DomainCommonExtensions.CommonExtensions;
using OneTimeRequestToken.Helpers.AppInfo;
using OneTimeRequestToken.Models.Internal;
using System.Collections.Generic;

#endregion

namespace OneTimeRequestToken.Helpers
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A token store.
    /// </summary>
    /// =================================================================================================
    internal static class TokenStore
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the store.
        /// </summary>
        /// =================================================================================================
        private static readonly Dictionary<string, TokenStoreInfo> Store = new Dictionary<string, TokenStoreInfo>();

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Sets a token.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// =================================================================================================
        internal static void SetToken(string key, TokenStoreInfo value) => Store[key] = value;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Searches for the first token.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///     The found token.
        /// </returns>
        /// =================================================================================================
        internal static TokenStoreInfo FindToken(string key)
        {
            try
            {
                Store.TryGetValue(key, out var info);

                return info;
            }
            catch
            {
                return null;
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Searches for the first token value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///     The found token value.
        /// </returns>
        /// =================================================================================================
        internal static string FindTokenValue(string key)
        {
            try
            {
                Store.TryGetValue(key, out var info);

                return info?.Value;
            }
            catch
            {
                return null;
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Increment tick.
        /// </summary>
        /// <param name="key">The key.</param>
        /// =================================================================================================
        internal static void IncrementTick(string key)
        {
            try
            {
                Store.TryGetValue(key, out var info);
                if (info.IsNotNull())
                {
                    if (info!.Ticks > OTRTAppInfo.GetMaxAllowedTokenAttempt())
                        ForgetToken(key);
                    else
                        info!.Ticks++;
                }
            }
            catch
            {
                // ignored
            }
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Forget token.
        /// </summary>
        /// <param name="key">The key.</param>
        /// =================================================================================================
        internal static void ForgetToken(string key) => Store.Remove(key);
    }
}