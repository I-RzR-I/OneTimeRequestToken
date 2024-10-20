// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-09-23 19:02
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-09-23 19:03
// ***********************************************************************
//  <copyright file="OTRTMiddleware.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using DomainCommonExtensions.DataTypeExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OneTimeRequestToken.Abstractions;
using OneTimeRequestToken.Extensions.Http;
using OneTimeRequestToken.Helpers.AppInfo;
using OneTimeRequestToken.Helpers.InternalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// ReSharper disable ClassNeverInstantiated.Global

#endregion

namespace OneTimeRequestToken.Middleware
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     An otrt middleware.
    /// </summary>
    /// =================================================================================================
    public class OTRTMiddleware
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the logger.
        /// </summary>
        /// =================================================================================================
        private readonly ILogger<OTRTMiddleware> _logger;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the next.
        /// </summary>
        /// =================================================================================================
        private readonly RequestDelegate _next;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the otrt service.
        /// </summary>
        /// =================================================================================================
        private readonly IOTRTService _otrtService;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the <see cref="OTRTMiddleware" /> class.
        /// </summary>
        /// <param name="next">The next.</param>
        /// <param name="otrtService">The otrt service.</param>
        /// <param name="logger">The logger.</param>
        /// =================================================================================================
        public OTRTMiddleware(RequestDelegate next, IOTRTService otrtService, ILogger<OTRTMiddleware> logger)
        {
            _next = next;
            _otrtService = otrtService;
            _logger = logger;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Executes the given operation on a different thread, and waits for the result.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>
        ///     A Task.
        /// </returns>
        /// =================================================================================================
        public async Task Invoke(HttpContext context)
        {
            var originalBody = context.Request.Body;
            try
            {
                var xsrfToken = context.Request.Headers[OTRTAppInfo.GetOTRTHeaderVariableName()].ToString();
                if (string.Equals(context.Request.Method, HttpMethods.Get, StringComparison.CurrentCultureIgnoreCase).IsFalse()
                    || (string.Equals(context.Request.Method, HttpMethods.Get, StringComparison.CurrentCultureIgnoreCase) && xsrfToken.IsPresent()))
                {
                    // Add internal endpoints to the excluded paths
                    var excludedPaths = new List<string>() { EndpointPathInfo.GetTokenPath, EndpointPathInfo.VerifyTokenPath };
                    // Add user defined endpoints to the excluded paths
                    excludedPaths.AddRange(OTRTAppInfo.GetExcludedPaths());
                    
                    var isInExcluded = excludedPaths.Any(x => x.StartsWith(context.Request.Path.Value!));
                    if (isInExcluded.Equals(false))
                    {
                        if (xsrfToken.IsNullOrEmpty().IsFalse())
                        {
                            var isValid = await _otrtService.ValidateTokenAsync(xsrfToken, context.Request.Method);
                            if (isValid.IsSuccess.IsFalse() || isValid.Response.IsValid.IsFalse())
                            {
                                await context.ResponseWithBadRequestAsync(isValid.GetFirstMessage()).ConfigureAwait(false);

                                return;
                            }
                        }
                    }
                }

                await _next(context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _logger.LogError(e, DefaultMessagesInfo.ErrorOnTokenValidation);
            }
            finally
            {
                context.Request.Body = originalBody;
            }
        }
    }
}