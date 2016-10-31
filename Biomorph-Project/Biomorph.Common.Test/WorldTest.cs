using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biomorph.Common.Test
{
    [TestClass]
    public class WorldTest
    {
        [TestMethod]
        public void ItInitializesWithBioOpponentAndEnvironment()
        {
            var world = new World();

            Assert.AreNotEqual(null, world.Bio);
            Assert.AreNotEqual(null, world.Opponent);
            Assert.AreNotEqual(null, world.Environment);
        }
    }
}
