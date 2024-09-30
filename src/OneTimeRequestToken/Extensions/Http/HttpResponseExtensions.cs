// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-09-26 20:21
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-09-26 20:25
// ***********************************************************************
//  <copyright file="HttpResponseExtensions.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using DomainCommonExtensions.CommonExtensions.TypeParam;
using DomainCommonExtensions.DataTypeExtensions;
using Microsoft.AspNetCore.Http;
using OneTimeRequestToken.Helpers;
using System.Threading.Tasks;

#endregion

namespace OneTimeRequestToken.Extensions.Http
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A HTTP response extensions.
    /// </summary>
    /// =================================================================================================
    internal static class HttpResponseExtensions
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A HttpResponse extension method that response with bad request asynchronous.
        /// </summary>
        /// <param name="response">The response to act on.</param>
        /// <param name="clearResponse">(Optional) True to clear response.</param>
        /// <returns>
        ///     A Task.
        /// </returns>
        /// =================================================================================================
        internal static async Task ResponseWithBadRequestAsync(this HttpResponse response, bool clearResponse = true)
        {
            if (clearResponse.IsTrue())
                response.Clear();
            response.StatusCode = 400;

            await response.WriteAsync(string.Empty);
            await response.Body.FlushAsync();
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A HttpResponse extension method that response with bad request asynchronous.
        /// </summary>
        /// <param name="response">The response to act on.</param>
        /// <param name="error">The error.</param>
        /// <param name="clearResponse">(Optional) True to clear response.</param>
        /// <returns>
        ///     A Task.
        /// </returns>
        /// =================================================================================================
        internal static async Task ResponseWithBadRequestAsync(this HttpResponse response, string error, bool clearResponse = true)
        {
            if (clearResponse.IsTrue())
                response.Clear();
            response.StatusCode = 400;

            await response.WriteAsync(error);
            await response.Body.FlushAsync();
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A HttpResponse extension method that response with error asynchronous.
        /// </summary>
        /// <param name="response">The response to act on.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="clearResponse">(Optional) True to clear response.</param>
        /// <returns>
        ///     A Task.
        /// </returns>
        /// =================================================================================================
        internal static async Task ResponseWithErrorAsync(this HttpResponse response, int statusCode, bool clearResponse = true)
        {
            if (clearResponse.IsTrue())
                response.Clear();
            response.StatusCode = statusCode;

            await response.WriteAsync(string.Empty);
            await response.Body.FlushAsync();
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A HttpResponse extension method that response with error.
        /// </summary>
        /// <param name="response">The response to act on.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="clearResponse">(Optional) True to clear response.</param>
        /// =================================================================================================
        internal static void ResponseWithError(this HttpResponse response, int statusCode, bool clearResponse = true)
        {
            if (clearResponse.IsTrue())
                response.Clear();
            response.StatusCode = statusCode;

            response.WriteAsync(string.Empty).ConfigureAwait(false);
            response.Body.FlushAsync();
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A HttpResponse extension method that response with error asynchronous.
        /// </summary>
        /// <param name="response">The response to act on.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="error">The error.</param>
        /// <param name="clearResponse">(Optional) True to clear response.</param>
        /// <returns>
        ///     A Task.
        /// </returns>
        /// =================================================================================================
        internal static async Task ResponseWithErrorAsync(this HttpResponse response, int statusCode, string error, bool clearResponse = true)
        {
            if (clearResponse.IsTrue())
                response.Clear();
            response.StatusCode = statusCode;

            await response.WriteAsync(error);
            await response.Body.FlushAsync();
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A HttpResponse extension method that writes a JSON asynchronous.
        /// </summary>
        /// <param name="response">The response to act on.</param>
        /// <param name="data">The data.</param>
        /// <param name="statusCode">(Optional) The status code.</param>
        /// <param name="contentType">(Optional) Type of the content.</param>
        /// <param name="clearResponse">(Optional) True to clear response.</param>
        /// <returns>
        ///     A Task.
        /// </returns>
        /// =================================================================================================
        internal static async Task WriteJsonAsync(this HttpResponse response, object data, int statusCode = 200, string contentType = null, bool clearResponse = true)
        {
            if (clearResponse.IsTrue())
                response.Clear();
            response.StatusCode = statusCode;
            response.ContentType = contentType ?? "application/json; charset=UTF-8";

            await response.WriteAsync(JsonObjectSerializer.ToString(data));
            await response.Body.FlushAsync();
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A HttpResponse extension method that writes an XML asynchronous.
        /// </summary>
        /// <param name="response">The response to act on.</param>
        /// <param name="data">The data.</param>
        /// <param name="statusCode">(Optional) The status code.</param>
        /// <param name="contentType">(Optional) Type of the content.</param>
        /// <param name="clearResponse">(Optional) True to clear response.</param>
        /// <returns>
        ///     A Task.
        /// </returns>
        /// =================================================================================================
        internal static async Task WriteXmlAsync(this HttpResponse response, object data, int statusCode = 200, string contentType = null, bool clearResponse = true)
        {
            if (clearResponse.IsTrue())
                response.Clear();
            response.StatusCode = statusCode;
            response.ContentType = contentType ?? "application/xml; charset=UTF-8";

            await response.WriteAsync(data.SerializeToXmlDoc("OTRTResponse", "OTRTNS").OuterXml);
            await response.Body.FlushAsync();
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A HttpResponse extension method that sets no cache.
        /// </summary>
        /// <param name="response">The response to act on.</param>
        /// =================================================================================================
        internal static void SetNoCache(this HttpResponse response)
        {
            if (response.Headers.ContainsKey("Cache-Control").IsFalse())
                response.Headers.Add("Cache-Control", "no-store, no-cache, max-age=0");
            else
                response.Headers["Cache-Control"] = "no-store, no-cache, max-age=0";

            if (response.Headers.ContainsKey("Pragma").IsFalse())
                response.Headers.Add("Pragma", "no-cache");
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A HttpResponse extension method that sets access control allow origin.
        /// </summary>
        /// <param name="response">The response to act on.</param>
        /// <param name="origin">(Optional) The origin.</param>
        /// =================================================================================================
        internal static void SetAccessControlAllowOrigin(this HttpResponse response, string origin = "*")
            => response.Headers.Add("Access-Control-Allow-Origin", origin);

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     A HttpResponse extension method that clears the response described by response.
        /// </summary>
        /// <param name="response">The response to act on.</param>
        /// <returns>
        ///     A HttpResponse.
        /// </returns>
        /// =================================================================================================
        internal static HttpResponse ClearResponse(this HttpResponse response)
        {
            response.Clear();

            return response;
        }
    }
}