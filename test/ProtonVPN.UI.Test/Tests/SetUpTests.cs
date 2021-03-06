/*
 * Copyright (c) 2020 Proton Technologies AG
 *
 * This file is part of ProtonVPN.
 *
 * ProtonVPN is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * ProtonVPN is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with ProtonVPN.  If not, see <https://www.gnu.org/licenses/>.
 */

using System;
using System.IO;
using NUnit.Framework;
using ProtonVPN.UI.Test.ApiClient;
using ProtonVPN.UI.Test.TestsHelper;
using System.Reflection;

namespace ProtonVPN.UI.Test.Tests
{
    [SetUpFixture]
    public class SetUpTests : UITestSession
    {
        private readonly string _testRailUrl = "https://proton.testrail.io/";

        [OneTimeSetUp]
        public void TestInitialize()
        {
            var dir = Path.GetDirectoryName(typeof(SetUpTests).Assembly.Location);
            Directory.SetCurrentDirectory(dir);

            TestRailClient = new TestRailAPIClient(_testRailUrl,
                   TestUserData.GetTestrailUser().Username, TestUserData.GetTestrailUser().Password);
            var asm = Assembly.GetExecutingAssembly();
            var path = System.IO.Path.GetDirectoryName(asm.Location) + "/ProtonVpn.exe";
            var version = Assembly.LoadFile(path).GetName().Version.ToString();
            version = version.Substring(0, version.Length - 2);
            if (!TestEnvironment.AreTestsRunningLocally())
            {
                TestRailClient.CreateTestRun(version + " test run " + DateTime.Now);
            }
        }
    }
}