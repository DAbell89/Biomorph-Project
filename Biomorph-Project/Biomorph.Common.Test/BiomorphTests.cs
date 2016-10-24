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
    }
}
