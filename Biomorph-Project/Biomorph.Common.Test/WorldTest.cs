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
            world.GenerateWorld();

            Assert.AreNotEqual(null, world.Bio);
            Assert.AreNotEqual(null, world.Opponent);
            Assert.AreNotEqual(null, world.Environment);
        }

        [TestMethod]
        public void NextGenerationPutsOffspringsInTheOffspringListAndReturnOffspring()
        {
            var world = new World();
            world.GenerateWorld();
            var result = world.NextGeneration();

            Assert.IsInstanceOfType(result, typeof(List<Biomorph>));
            Assert.IsNotNull(result);
            Assert.IsNotNull(world.Offspring);
        }

        [TestMethod]
        public void ArtificalySelectedBio()
        {
            var world = new World();
            world.GenerateWorld();
            var result = world.NextGeneration();

            world.ArtificalySelectedBio(result.Where(x => x.Alive).FirstOrDefault());

            Assert.AreSame(result.Where(x => x.Alive).FirstOrDefault(), world.Bio);
        }
    }
}
