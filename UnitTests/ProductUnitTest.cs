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
            products.GetEnumerator().Reset();
            products.GetEnumerator().MoveNext();
            var product = products.GetEnumerator().Current;
            var productReset = await ProductProvider.ResetProduct(product.Number);
            Assert.IsInstanceOfType(productReset, typeof(IEnumerable<ProductReset>));
        }
    }
}
