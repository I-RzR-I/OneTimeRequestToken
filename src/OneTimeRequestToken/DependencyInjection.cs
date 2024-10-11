// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-09-23 15:40
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-09-25 21:24
// ***********************************************************************
//  <copyright file="DependencyInjection.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using DomainCommonExtensions.ArraysExtensions;
using DomainCommonExtensions.CommonExtensions;
using DomainCommonExtensions.DataTypeExtensions;
using EndpointHostBinder;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OneTimeRequestToken.Abstractions;
using OneTimeRequestToken.Endpoints.GetOTRToken;
using OneTimeRequestToken.Endpoints.VerifyOTRTToken;
using OneTimeRequestToken.Helpers;
using OneTimeRequestToken.Helpers.InternalInfo;
using OneTimeRequestToken.Middleware;
using OneTimeRequestToken.Models;
using OneTimeRequestToken.Services;
using System;
using System.Threading.Tasks;
using UniqueServiceCollection;

// ReSharper disable UnusedMethodReturnValue.Local

#endregion

namespace OneTimeRequestToken
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A dependency injection.
    /// </summary>
    /// =================================================================================================
    public static class DependencyInjection
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     An IServiceCollection extension method that registers the otrt service.
        /// </summary>
        /// <param name="serviceCollection">The serviceCollection to act on.</param>
        /// <param name="serviceOptions">Options for controlling the service.</param>
        /// <returns>
        ///     An IServiceCollection.
        /// </returns>
        /// =================================================================================================
        public static IServiceCollection RegisterOTRTService(
            this IServiceCollection serviceCollection,
            Action<OTRTOptions> serviceOptions)
        {
            serviceCollection.RegisterBaseServices(serviceOptions);

            return serviceCollection;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     An IServiceCollection extension method that registers the otrt service.
        /// </summary>
        /// <param name="serviceCollection">The serviceCollection to act on.</param>
        /// <param name="serviceOptions">Options for controlling the service.</param>
        /// <param name="userIdentifierFunction">The user identifier function.</param>
        /// <param name="userNameFunction">The user name function.</param>
        /// <returns>
        ///     An IServiceCollection.
        /// </returns>
        /// =================================================================================================
        public static IServiceCollection RegisterOTRTService(
            this IServiceCollection serviceCollection,
            Action<OTRTOptions> serviceOptions, Func<Task<object>> userIdentifierFunction, Func<Task<object>> userNameFunction)
        {
            serviceCollection.RegisterBaseServices(serviceOptions);
            OTRTAppInfo.SetFunctions(userIdentifierFunction, userNameFunction);

            return serviceCollection;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     An IApplicationBuilder extension method that use otrt middleware.
        /// </summary>
        /// <param name="applicationBuilder">The applicationBuilder to act on.</param>
        /// <returns>
        ///     An IApplicationBuilder.
        /// </returns>
        /// =================================================================================================
        public static IApplicationBuilder UseOTRTMiddleware(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseEndpointHostBuilder();
            applicationBuilder.UseMiddleware<OTRTMiddleware>();

            return applicationBuilder;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     An IServiceCollection extension method that registers the base services.
        /// </summary>
        /// <param name="serviceCollection">The serviceCollection to act on.</param>
        /// <param name="serviceOptions">Options for controlling the service.</param>
        /// <returns>
        ///     An IServiceCollection.
        /// </returns>
        /// =================================================================================================
        private static IServiceCollection RegisterBaseServices(this IServiceCollection serviceCollection, Action<OTRTOptions> serviceOptions)
        {
            StoreServiceKeys(serviceOptions);

            serviceCollection.AddHttpContextAccessor();
            serviceCollection.AddMemoryCache();

            serviceCollection.RegisterEndpointHostBuilder();
            serviceCollection.AddHostEndpoint<GetOTRTokenHandler>("GetOTRToken", EndpointPathInfo.GetTokenPath);
            serviceCollection.AddHostEndpoint<VerifyOTRTTokenHandler>("VerifyOTRTToken", EndpointPathInfo.VerifyTokenPath);

            serviceCollection.AddUnique<IClientBrowserInfoService, ClientBrowserInfoService>();
            serviceCollection.AddUnique<IOTRTService, OTRTService>();

            return serviceCollection;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Stores service keys.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are null.
        /// </exception>
        /// <param name="serviceOptions">Options for controlling the service.</param>
        /// =================================================================================================
        private static void StoreServiceKeys(Action<OTRTOptions> serviceOptions)
        {
            var options = new OTRTOptions();
            serviceOptions(options);

            if (options.AppKey.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(options.AppKey));

            OTRTAppInfo.SetAppKey(options.AppKey);

            if (options.AppName.IsNullOrEmpty().IsFalse())
                OTRTAppInfo.SetCurrentAppName(options.AppName);

            if (options.ExcludedPaths.IsNullOrEmptyEnumerable().IsFalse())
                OTRTAppInfo.SetExcludedPaths(options.ExcludedPaths);

            if (options.TokenValidTime.IsNotNull())
                OTRTAppInfo.SetTokenValidTime(options.TokenValidTime);
        }
    }
}