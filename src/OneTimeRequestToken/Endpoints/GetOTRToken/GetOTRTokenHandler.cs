// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-09-24 21:06
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-09-26 19:50
// ***********************************************************************
//  <copyright file="GetOTRTokenHandler.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using DomainCommonExtensions.CommonExtensions;
using DomainCommonExtensions.DataTypeExtensions;
using EndpointHostBinder.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OneTimeRequestToken.Endpoints.Common;
using OneTimeRequestToken.Extensions;
using OneTimeRequestToken.Helpers.InternalInfo;
using System;
using System.Net;
using System.Threading.Tasks;
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable InconsistentNaming

#endregion

namespace OneTimeRequestToken.Endpoints.GetOTRToken
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A get otr token handler. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="T:EndpointHostBinder.Abstractions.IEndpointHostRequestHandler"/>
    /// =================================================================================================
    public sealed class GetOTRTokenHandler : IEndpointHostRequestHandler
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the service provider.
        /// </summary>
        /// =================================================================================================
        private readonly IServiceProvider _serviceProvider;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the logger.
        /// </summary>
        /// =================================================================================================
        private readonly ILogger<GetOTRTokenHandler> _logger;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the <see cref="GetOTRTokenHandler"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// =================================================================================================
        public GetOTRTokenHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _logger = serviceProvider.GetRequiredService<ILogger<GetOTRTokenHandler>>();
        }

        /// <inheritdoc/>
        public async Task<IEndpointHostResult> RequestProcessAsync(HttpContext context)
            => await Task.Run(() => RequestProcess(context));

        /// <inheritdoc/>
        public IEndpointHostResult RequestProcess(HttpContext context)
        {
            var validateRequest = ValidateRequest(context);
            if (validateRequest != HttpStatusCode.OK)
                return new StatusCodeResult(validateRequest);

            return new GetOTRTokenResult(_serviceProvider);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Validates the request described by context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>
        ///     A HttpStatusCode.
        /// </returns>
        /// =================================================================================================
        private HttpStatusCode ValidateRequest(HttpContext context)
        {
            try
            {
                if (HttpMethods.IsGet(context.Request.Method).IsFalse())
                    return HttpStatusCode.MethodNotAllowed;
                
                var query = context.Request.Query;
                if (query.IsNull() || query.Count.IsZero())
                    return HttpStatusCode.BadRequest;

                var queryParams = query.AsNameValueCollection();
                var requestPath = queryParams["requestPath"];
                var httpMethod = queryParams["httpMethod"];
                if (requestPath.IsMissing()
                    || httpMethod.IsMissing()
                    || httpMethod.Length > 7)
                    return HttpStatusCode.BadRequest;

                return HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                _logger.LogError(e, DefaultMessagesInfo.ErrorOnInvokeTokenValidHandler);

                return HttpStatusCode.InternalServerError;
            }
        }
    }
}