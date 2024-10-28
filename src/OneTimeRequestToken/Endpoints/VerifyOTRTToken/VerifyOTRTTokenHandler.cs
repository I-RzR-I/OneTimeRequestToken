// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-10-11 16:09
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-10-11 19:31
// ***********************************************************************
//  <copyright file="VerifyOTRTTokenHandler.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using DomainCommonExtensions.CommonExtensions.TypeParam;
using DomainCommonExtensions.DataTypeExtensions;
using EndpointHostBinder.Abstractions;
using Microsoft.AspNetCore.Http;
using OneTimeRequestToken.Endpoints.Common;
using OneTimeRequestToken.Helpers.InternalInfo;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
// ReSharper disable ClassNeverInstantiated.Global

#endregion

namespace OneTimeRequestToken.Endpoints.VerifyOTRTToken
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A verify otrt token handler. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="T:EndpointHostBinder.Abstractions.IEndpointHostRequestHandler" />
    /// =================================================================================================
    public sealed class VerifyOTRTTokenHandler : IEndpointHostRequestHandler
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the service provider.
        /// </summary>
        /// =================================================================================================
        private readonly IServiceProvider _serviceProvider;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the <see cref="VerifyOTRTTokenHandler" /> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// =================================================================================================
        public VerifyOTRTTokenHandler(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        /// <inheritdoc />
        public async Task<IEndpointHostResult> RequestProcessAsync(HttpContext context)
            => await Task.Run(() => RequestProcess(context));

        /// <inheritdoc />
        public IEndpointHostResult RequestProcess(HttpContext context)
        {
            if (HttpMethods.IsPost(context.Request.Method).IsFalse())
                return new StatusCodeResult(HttpStatusCode.MethodNotAllowed);

            if (context.Request.ContentLength.IsZero())
                return new StatusCodeResult(HttpStatusCode.BadRequest);

            if (AppContentTypeInfo.AllowedContentType.Any(x => context.Request.ContentType.IfIsNull(string.Empty).Contains(x)).IsFalse())
                return new StatusCodeResult(HttpStatusCode.BadRequest);

            return new VerifyOTRTTokenResult(_serviceProvider);
        }
    }
}