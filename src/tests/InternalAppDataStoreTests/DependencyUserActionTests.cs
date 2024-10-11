// ***********************************************************************
//  Assembly         : RzR.Shared.Services.InternalAppDataStoreTests
//  Author           : RzR
//  Created On       : 2024-09-24 16:58
// 
//  Last Modified By : RzR
//  Last Modified On : 2024-09-24 16:58
// ***********************************************************************
//  <copyright file="DependencyUserActionTests.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneTimeRequestToken;
using OneTimeRequestToken.Helpers;
using System.Threading.Tasks;

namespace InternalAppDataStoreTests
{
    [TestClass]
    public class DependencyUserActionTests
    {
        [TestMethod]
        public async Task SetUserIdName_Test()
        {
            var services = new ServiceCollection();
            services.RegisterOTRTService(
                o =>
                {
                    o.AppName = "Test_Name";
                    o.AppKey = "Test_KEY";
                }, 
                userIdentifierFunction: async () => await UserIdFuncAsync(),
                userNameFunction: async () => await UserNameFuncAsync()
                );

            _ = services.BuildServiceProvider();

            Assert.AreEqual(1, await OTRTInfo.GetUserIdentifierFunction().Invoke());
            Assert.AreEqual("UserName", await OTRTInfo.GetUserNameFunction().Invoke());
        }

        private async Task<int> UserIdFuncAsync() => await Task.FromResult(1);

        private async Task<string> UserNameFuncAsync() => await Task.FromResult("UserName");
    }
}