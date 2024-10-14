// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-09-24 23:20
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-09-26 20:15
// ***********************************************************************
//  <copyright file="HttpContextExtensions.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using AggregatedGenericResultMessage.Abstractions;
using DomainCommonExtensions.DataTypeExtensions;
using Microsoft.AspNetCore.Http;
using OneTimeRequestToken.Helpers.InternalInfo;
using System.Threading.Tasks;

#endregion

namespace OneTimeRequestToken.Extensions.Http
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A HTTP context extensions.
    /// </summary>
    /// =================================================================================================
    internal static class HttpContextExtensions
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A HttpContext extension method that sets access control allow origin.
        /// </summary>
        /// <param name="context">The context to act on.</param>
        /// <param name="origin">(Optional) The origin.</param>
        /// <returns>
        ///     A HttpContext.
        /// </returns>
        /// =================================================================================================
        internal static HttpContext SetAccessControlAllowOrigin(this HttpContext context, string origin = "*")
        {
            context.Request.SetAccessControlAllowOrigin(origin);
            context.Response.SetAccessControlAllowOrigin(origin);

            return context;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A HttpContext extension method that response with bad request asynchronous.
        /// </summary>
        /// <param name="context">The context to act on.</param>
        /// <returns>
        ///     A Task.
        /// </returns>
        /// =================================================================================================
        internal static async Task ResponseWithBadRequestAsync(this HttpContext context)
        {
            context.Response.ClearResponse();
            context.SetAccessControlAllowOrigin();

            await context.Response.ResponseWithBadRequestAsync(false);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A HttpContext extension method that response with bad request asynchronous.
        /// </summary>
        /// <param name="context">The context to act on.</param>
        /// <param name="error">The error.</param>
        /// <returns>
        ///     A Task.
        /// </returns>
        /// =================================================================================================
        internal static async Task ResponseWithBadRequestAsync(this HttpContext context, string error)
        {
            context.Response.ClearResponse();
            context.SetAccessControlAllowOrigin();

            await context.Response.ResponseWithBadRequestAsync(error, false);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A HttpContext extension method that response with error asynchronous.
        /// </summary>
        /// <param name="context">The context to act on.</param>
        /// <param name="statusCode">The status code.</param>
        /// <returns>
        ///     A Task.
        /// </returns>
        /// =================================================================================================
        internal static async Task ResponseWithErrorAsync(this HttpContext context, int statusCode)
        {
            context.Response.ClearResponse();
            context.SetAccessControlAllowOrigin();

            await context.Response.ResponseWithErrorAsync(statusCode, false);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A HttpContext extension method that response with error.
        /// </summary>
        /// <param name="context">The context to act on.</param>
        /// <param name="statusCode">The status code.</param>
        /// =================================================================================================
        internal static void ResponseWithError(this HttpContext context, int statusCode)
        {
            context.Response.ClearResponse();
            context.SetAccessControlAllowOrigin();

            context.Response.ResponseWithError(statusCode, false);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A HttpContext extension method that response with error asynchronous.
        /// </summary>
        /// <param name="context">The context to act on.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="error">The error.</param>
        /// <returns>
        ///     A Task.
        /// </returns>
        /// =================================================================================================
        internal static async Task ResponseWithErrorAsync(this HttpContext context, int statusCode, string error)
        {
            context.Response.ClearResponse();
            context.SetAccessControlAllowOrigin();

            await context.Response.ResponseWithErrorAsync(statusCode, error, false);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A HttpContext extension method that writes a JSON asynchronous.
        /// </summary>
        /// <param name="context">The context to act on.</param>
        /// <param name="data">The data.</param>
        /// <param name="statusCode">(Optional) The status code.</param>
        /// <param name="contentType">(Optional) Type of the content.</param>
        /// <returns>
        ///     A Task.
        /// </returns>
        /// =================================================================================================
        internal static async Task WriteJsonAsync(this HttpContext context, object data, int statusCode = 200, string contentType = null)
        {
            context.Response.ClearResponse();
            context.SetAccessControlAllowOrigin();

            await context.Response.WriteJsonAsync(data, statusCode, contentType, false);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A HttpContext extension method that writes an XML asynchronous.
        /// </summary>
        /// <param name="context">The context to act on.</param>
        /// <param name="data">The data.</param>
        /// <param name="statusCode">(Optional) The status code.</param>
        /// <param name="contentType">(Optional) Type of the content.</param>
        /// <returns>
        ///     A Task.
        /// </returns>
        /// =================================================================================================
        internal static async Task WriteXmlAsync(this HttpContext context, object data, int statusCode = 200, string contentType = null)
        {
            context.Response.ClearResponse();
            context.SetAccessControlAllowOrigin();

            await context.Response.WriteXmlAsync(data, statusCode, contentType, false);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A HttpContext extension method that writes a response asynchronous.
        /// </summary>
        /// <param name="context">The context to act on.</param>
        /// <param name="data">The data.</param>
        /// <param name="statusCode">(Optional) The status code.</param>
        /// <param name="contentType">(Optional) Type of the content.</param>
        /// <returns>
        ///     A Task.
        /// </returns>
        /// =================================================================================================
        internal static async Task WriteResponseAsync(this HttpContext context, object data, int statusCode = 200, string contentType = null)
        {
            var isAcceptJsonResult = (context.Request.Headers["Accept"].ToString() ?? string.Empty).ToLower().Contains(AppContentTypeInfo.LikeJson);
            //context.Response.ClearResponse();
            context.SetAccessControlAllowOrigin();

            if (isAcceptJsonResult.IsTrue())
                await context.Response.WriteJsonAsync(data, statusCode, contentType, false);
            else
                await context.Response.WriteXmlAsync(data, statusCode, contentType, false);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A HttpContext extension method that writes a response asynchronous.
        /// </summary>
        /// <param name="context">The context to act on.</param>
        /// <param name="data">The data.</param>
        /// <param name="contentType">(Optional) Type of the content.</param>
        /// <returns>
        ///     A Task.
        /// </returns>
        /// =================================================================================================
        internal static async Task WriteResponseAsync(this HttpContext context, IResult data, string contentType = null)
        {
            var isAcceptJsonResult = (context.Request.Headers["Accept"].ToString() ?? string.Empty).ToLower().Contains(AppContentTypeInfo.LikeJson);
            var statusCode = data.IsSuccess ? StatusCodes.Status204NoContent : StatusCodes.Status400BadRequest;

            //context.Response.ClearResponse();
            context.SetAccessControlAllowOrigin();

            if (isAcceptJsonResult.IsTrue())
                await context.Response.WriteJsonAsync(data, statusCode, contentType, false);
            else
                await context.Response.WriteXmlAsync(data.ToSoapResult(), statusCode, contentType, false);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A HttpContext extension method that writes a response asynchronous.
        /// </summary>
        /// <param name="context">The context to act on.</param>
        /// <param name="data">The data.</param>
        /// <param name="contentType">(Optional) Type of the content.</param>
        /// <returns>
        ///     A Task.
        /// </returns>
        /// =================================================================================================
        internal static async Task WriteResponseAsync<T>(this HttpContext context, IResult<T> data, string contentType = null)
        {
            var isAcceptJsonResult = (context.Request.Headers["Accept"].ToString() ?? string.Empty).ToLower().Contains(AppContentTypeInfo.LikeJson);
            var statusCode = data.IsSuccess ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest;

            //context.Response.ClearResponse();
            context.SetAccessControlAllowOrigin();

            if (isAcceptJsonResult.IsTrue())
                await context.Response.WriteJsonAsync(data, statusCode, contentType, false);
            else
                await context.Response.WriteXmlAsync(data.ToSoapResult(), statusCode, contentType, false);
        }
    }
}