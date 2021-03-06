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
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtonVPN.Common.Extensions;

namespace ProtonVPN.Common.Test.Extensions
{
    [TestClass]
    public class TimeSpanExtensionsTest
    {
        [TestMethod]
        public void RandomizedWithDeviation_ShouldBe_Value_WhenDeviation_IsZero()
        {
            // Arrange
            var expected = TimeSpan.FromSeconds(20);

            // Act
            var result = expected.RandomizedWithDeviation(0.0);

            // Assert
            result.Should().BeCloseTo(expected);
        }

        [TestMethod]
        public void RandomizedWithDeviation_ShouldBe_WithinDeviation()
        {
            // Arrange
            var interval = TimeSpan.FromSeconds(20);
            const double deviation = 0.2;
            var minValue = interval;
            var maxValue = interval;
            var sumValue = TimeSpan.Zero;

            // Act
            for (var i = 0; i < 1000; i++)
            {
                var result = interval.RandomizedWithDeviation(deviation);
                if (result < minValue) minValue = result;
                if (result > maxValue) maxValue = result;
                sumValue += result;
            }

            var medianValue = TimeSpan.FromMilliseconds(sumValue.TotalMilliseconds / 1000.0);

            // Assert
            minValue.Should().BeCloseTo(TimeSpan.FromSeconds(16), TimeSpan.FromMilliseconds(100));
            medianValue.Should().BeCloseTo(interval, TimeSpan.FromMilliseconds(300));
            maxValue.Should().BeCloseTo(TimeSpan.FromSeconds(24), TimeSpan.FromMilliseconds(100));
        }
    }
}
