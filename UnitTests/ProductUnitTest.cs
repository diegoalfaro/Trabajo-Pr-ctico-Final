using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Domain;

namespace UnitTests
{
    /// <summary>
    /// Test de productos
    /// </summary>
    [TestClass]
    public class ProductUnitTest: BaseUnitTest
    {
        [TestInitialize]
        public void Initialize()
        {
            AuthProvider.Login(12345678, 1234);
        }

        [TestMethod]
        public async Task GetProductsTest()
        {
            Assert.IsTrue(true);
        }
    }
}
