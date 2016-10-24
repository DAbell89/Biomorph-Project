using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Biomorph.Common.Test
{
    [TestClass]
    public class BiomorphTests
    {
        [TestMethod]
        public void CreatesNewRandomizedBiomorphWithValuesbetween1And10()
        {
            var bio = new Biomorph();
        }

        [TestMethod]
        public void CombatMethodReturnsTheSumOfTheScoreDifferences()
        {
            var bio = new Biomorph();
            var opponent = new Biomorph();

            var expected = (bio.Strength - opponent.Strength) + (bio.Intel - opponent.Intel) + (bio.Camo - opponent.Camo) + (bio.Vision - opponent.Vision);

            Assert.AreEqual(expected, bio.CombatScore(opponent));
        }
    }
}
