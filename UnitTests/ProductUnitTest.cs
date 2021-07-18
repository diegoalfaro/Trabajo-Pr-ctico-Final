using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Linq;
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
        public async Task Initialize()
        {
            await AuthProvider.Login(12345678, 1234);
        }

        [TestMethod]
        public async Task GetProductsTest()
        {
            var products = await ProductProvider.GetProducts();
            Assert.IsInstanceOfType(products, typeof(IEnumerable<Product>));
        }

        [TestMethod]
        public async Task ResetProduct()
        {
            var products = await ProductProvider.GetProducts();
            var product = products.FirstOrDefault();
            var productReset = await ProductProvider.ResetProduct(product.Number);
            Assert.IsInstanceOfType(productReset, typeof(ProductReset));
        }
    }
}
