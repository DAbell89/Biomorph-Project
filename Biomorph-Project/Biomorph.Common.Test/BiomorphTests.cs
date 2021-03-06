﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Biomorph.Common.Test
{
    [TestClass]
    public class BiomorphTests
    {
        [TestMethod]
        public void CreatesNewRandomizedBiomorph()
        {
            var bio = new Biomorph();

            Assert.IsNotNull(bio);
        }

        [TestMethod]
        public void ItGeneratesFiveOffspring()
        {
            var bio = new Biomorph();
            List<Biomorph> nextGen = bio.GenerateNextGen();

            Assert.AreEqual(5, nextGen.Count);
        }

        [TestMethod]
        public void MutationsAreInRange()
        {
            var parent = new Biomorph();
            List<Biomorph> nextGen = parent.GenerateNextGen();

            foreach (var child in nextGen)
            {
                AssertMainStatsInRangeOfParent(parent, child);
            }
        }

        [TestMethod]
        public void CombatMethodReturnsTheSumOfTheScoreDifferences()
        {
            var bio = new Biomorph();
            var opponent = new Biomorph();

            var expected = ScoreCombat(bio, opponent);

            Assert.AreEqual(expected, bio.ScoreCombat(opponent));
        }

        private static int ScoreCombat(Biomorph bio, Biomorph opponent)
        {
            return (bio.Strength - opponent.Strength) + (bio.Intel - opponent.Intel) + (bio.Camo - opponent.Camo) + (bio.Vision - opponent.Vision);
        }

        private static void AssertMainStatsInRangeOfParent(Biomorph parent, Biomorph child)
        {
            Assert.IsTrue((parent.Strength - 5) <= child.Strength && child.Strength <= (parent.Strength + 5));
            Assert.IsTrue((parent.Intel - 5) <= child.Intel && child.Intel <= (parent.Intel + 5));
            Assert.IsTrue((parent.Camo - 5) <= child.Camo && child.Camo <= (parent.Camo + 5));
            Assert.IsTrue((parent.Vision - 5) <= child.Vision && child.Vision <= (parent.Vision + 5));
        }
    }
}
