using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Biomorph.Common.Test
{
    [TestClass]
    public class BiomorphTests
    {
        [TestMethod]
        public void ItInitializesValues()
        {
            var bio = new Biomorph(75,78,5,6,7,8);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ItMustThrowIfTempMinGreaterThanTempMax()
        {
            var bio = new Biomorph(2, 1, 1, 1, 1, 1);
        }

        [TestMethod]
        public void CombatMethodReturnsTheSumOfTheScoreDifferences()
        {
            var bio = new Biomorph(4, 8, 5, 6, 2, 3);
            var opponent = new Biomorph(4, 8, 4, 5, 1, 2);

            Assert.AreEqual(4, bio.CombatScore(opponent));
        }
    }
}
