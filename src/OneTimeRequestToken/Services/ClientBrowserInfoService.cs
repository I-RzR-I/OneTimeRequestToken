// ***********************************************************************
//  Assembly         : RzR.Shared.Services.OneTimeRequestToken
//  Author           : RzR
//  Created On       : 2024-09-23 19:37
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-09-23 22:34
// ***********************************************************************
//  <copyright file="ClientBrowserInfoService.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using DomainCommonExtensions.DataTypeExtensions;
using Microsoft.AspNetCore.Http;
using OneTimeRequestToken.Abstractions;
using OneTimeRequestToken.Models;

// ReSharper disable ClassNeverInstantiated.Global

#endregion

namespace OneTimeRequestToken.Services
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    ///     A service for accessing client browser information.
    /// </summary>
    /// <seealso cref="T:OneTimeRequestToken.Abstractions.IClientBrowserInfoService" />
    /// =================================================================================================
    public sealed class ClientBrowserInfoService : IClientBrowserInfoService
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (Immutable) the HTTP context accessor.
        /// </summary>
        /// =================================================================================================
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Initializes a new instance of the <see cref="ClientBrowserInfoService" /> class.
        /// </summary>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
        /// =================================================================================================
        public ClientBrowserInfoService(IHttpContextAccessor httpContextAccessor)
            => _httpContextAccessor = httpContextAccessor;

        /// <inheritdoc />
        public ClientInfoDto GetClientInfo()
            => new ClientInfoDto()
            {
                ClientIp = GetClientIp(),
                ClientAgent = _httpContextAccessor.HttpContext?.Request.Headers["User-Agent"],
                ClientSecChUa = _httpContextAccessor.HttpContext?.Request.Headers["Sec-CH-UA"],
                ClientSecChUaMobile = _httpContextAccessor.HttpContext?.Request.Headers["Sec-CH-UA-Mobile"],
                ClientSecChUaFullVersion = _httpContextAccessor.HttpContext?.Request.Headers["Sec-CH-UA-Full-Version"],
                ClientSecChUaPlatform = GetClientPlatform(),
                ClientSecChUaPlatformVersion =
                    _httpContextAccessor.HttpContext?.Request.Headers["Sec-CH-UA-Platform-Version"],
                ClientSecChUaArch = _httpContextAccessor.HttpContext?.Request.Headers["Sec-CH-UA-Arch"],
                ClientSecChUaBitness = _httpContextAccessor.HttpContext?.Request.Headers["Sec-CH-UA-Bitness"],
                ClientSecChUaModel = _httpContextAccessor.HttpContext?.Request.Headers["Sec-CH-UA-Model"]
            };

        /// <inheritdoc />
        public string GetClientIp()
        {
            var ip = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.MapToIPv4().ToString();
            var xForwardFor = _httpContextAccessor.HttpContext?.Request.Headers["X-Forwarded-For"].ToString();
            var xForwardIp = _httpContextAccessor.HttpContext?.Request.Headers["X-Forwarded-IP"].ToString();

            var clientIp = xForwardFor.IsNullOrEmpty()
                ? xForwardIp.IsNullOrEmpty()
                    ? ip
                    : xForwardIp
                : xForwardFor;

            return clientIp;
        }

        /// <inheritdoc />
        public string GetClientPlatform()
        {
            var platform = string.Empty;
            var contextPlatform = _httpContextAccessor.HttpContext?.Request.Headers["Sec-CH-UA-Platform"].ToString()
                .Replace("\"", "");
            if (contextPlatform.IsNullOrEmpty())
            {
                var agent = _httpContextAccessor.HttpContext?.Request.Headers["User-Agent"].ToString();
                if (agent.IsNullOrEmpty().IsFalse())
                {
                    var startIdx = agent!.IndexOf('(');
                    var endIdx = agent.IndexOf(')');
                    if (startIdx > -1 && endIdx > -1 && startIdx != endIdx)
                    {
                        startIdx = startIdx != 0 ? startIdx + 1 : startIdx;

                        platform = agent.Substring(startIdx, endIdx - startIdx);
                    }
                }
            }
            else
            {
                platform = contextPlatform;
            }

            return platform;
        }
    }
}