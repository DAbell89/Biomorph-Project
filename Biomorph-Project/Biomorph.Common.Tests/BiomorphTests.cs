using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;

namespace Biomorph.Common.Tests
{
    [TestClass]
    public class BiomorphTests
    {
        [TestMethod]
        public void ItInitializesValues()
        {
            var bio = new Biomorph.Common.Biomorph(75,78,5,6,7,8);
        }

        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ItMustThrowIfTempMinGreaterThanTempMax()
        {
            var bio = new Biomorph(2, 1, 1, 1, 1, 1);
        }
    }
}
