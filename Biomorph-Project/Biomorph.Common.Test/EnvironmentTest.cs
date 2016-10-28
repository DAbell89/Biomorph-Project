using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Biomorph.Common.Test
{
    [TestClass]
    public class EnvironmnentTest
    {
        [TestMethod]
        public void ItGeneratedNewEnvironmentWithTempInRange()
        {
            var environment = new Environment();

            Assert.IsTrue(environment.Temp >= 0 && environment.Temp <= 10);
        }

        [TestMethod]
        public void AdvancedEnvironmentInRangeOfPrevious()
        {
            var environment = new Environment();

            var oldTemp = environment.Temp;

            environment.AdvanceEnvironment();

            Assert.IsTrue(oldTemp <= (environment.Temp + 3) && oldTemp >= (environment.Temp - 3));
        }
    }
}
