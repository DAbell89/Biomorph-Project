using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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

        [TestMethod]
        public void TestNewGenReturnsExpectedDeaths()
        {
            var bio = new Biomorph();
            var nextGen = bio.GenerateNextGen();

            var environment = new Environment();
            environment.AdvanceEnvironment();

            var expectedDead = DetermineExpectedKilledByEnvironment(nextGen, environment);

            var environmenttTestResults = environment.TestNewGen(nextGen);

            Assert.AreEqual(expectedDead.Where(x => x.Alive).Count(), environmenttTestResults.Where(x => x.Alive).Count());
        }

        private List<Biomorph> DetermineExpectedKilledByEnvironment(List<Biomorph> nextGen, Environment environment)
        {
            foreach (var child in nextGen)
            {
                if (!child.TempRange.Contains(environment.Temp))
                {
                    child.Alive = false;
                }
            }

            return nextGen;
        }
    }
}
