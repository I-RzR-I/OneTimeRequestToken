// ***********************************************************************
//  Assembly         : RzR.Shared.Services.InternalAppDataStoreTests
//  Author           : RzR
//  Created On       : 2024-09-24 15:38
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-09-24 15:38
// ***********************************************************************
//  <copyright file="DependencyStoreInfoTests.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

using DomainCommonExtensions.DataTypeExtensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneTimeRequestToken;
using OneTimeRequestToken.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
// ReSharper disable PossibleMultipleEnumeration

namespace InternalAppDataStoreTests
{
    [TestClass]
    public class DependencyStoreInfoTests
    {
        [DataRow("app_Name", "App_enc_KEY")]
        [TestMethod]
        public void StoreInfo_Test(string name, string key)
        {
            OTRTInfo.SetAppKey(key);
            OTRTInfo.SetCurrentAppName(name);

            Assert.AreEqual(key, OTRTInfo.GetAppKey());
            Assert.AreEqual(name, OTRTInfo.GetCurrentAppName());
            Assert.AreEqual($"X-XSRF-TOKEN.{name}", OTRTInfo.GetOTRTHeaderVariableName());
            Assert.AreEqual($"X-XSRF-TOKEN.{name}.", OTRTInfo.GetOTRTHeaderVariableNameValue());
            Assert.AreEqual($"X-XSRF-TOKEN.{name}-", OTRTInfo.GetOTRTHeaderVariableNameValueEnc());
        }

        [DataRow("DependencyActionTests", "DependencyActionTests_ENC_KEY")]
        [TestMethod]
        public void AppKeyNameStore_Test(string name, string key)
        {
            var services = new ServiceCollection();
            services.RegisterOTRTService(
                o =>
                {
                    o.AppName = name;
                    o.AppKey = key;
                });

            _ = services.BuildServiceProvider();

            Assert.AreEqual(key, OTRTInfo.GetAppKey());
            Assert.AreEqual(name, OTRTInfo.GetCurrentAppName());
        }

        [DataRow("app_Name")]
        [TestMethod]
        public void HeaderName_Test(string appName)
        {
            OTRTInfo.SetCurrentAppName(appName);

            Assert.AreEqual(appName, OTRTInfo.GetCurrentAppName());
            Assert.AreEqual($"X-XSRF-TOKEN.{appName}", OTRTInfo.GetOTRTHeaderVariableName());
            Assert.AreEqual($"X-XSRF-TOKEN.{appName}.", OTRTInfo.GetOTRTHeaderVariableNameValue());
            Assert.AreEqual($"X-XSRF-TOKEN.{appName}-", OTRTInfo.GetOTRTHeaderVariableNameValueEnc());
        }

        [TestMethod]
        public void ExcludedPaths_Test()
        {
            var path = new List<string>() { "/tst/path/1" };

            OTRTInfo.SetExcludedPaths(path);

            var excludedPaths = OTRTInfo.GetExcludedPaths();

            Assert.IsTrue(excludedPaths.Any());
            Assert.AreEqual(path[0], excludedPaths.First());
        }

        [DataRow("2022-01-12")]
        [DataRow("2022-12-12")]
        [DataRow("2022-12-31")]
        [DataRow("0001-12-31")]
        [DataRow("1001-12-31")]
        [DataRow("0001-01-01")]
        [DataRow("9999-12-31")]
        [TestMethod]
        public void GetTokenLength_Test(string date)
        {
            var sourceDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var rnd = OTRTInfo.GetNumberRelatedToDate(sourceDate);

            Assert.IsTrue(rnd > 0);
            Assert.IsTrue(rnd > 1);
        }
    }
}