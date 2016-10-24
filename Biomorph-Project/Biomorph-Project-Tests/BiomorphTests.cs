using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biomorph_Project_Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Biomorph_Project_Tests
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ItMustThrowIfTempMinGreaterThanTempMax()
        {
            var bio = new Biomorph(2, 1, 1, 1, 1, 1);
        }
    }
}
