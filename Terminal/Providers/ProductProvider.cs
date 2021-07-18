using Domain;
using Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Terminal.Providers
{
    public class ProductProvider: IProductProvider
    {
        private readonly IProductService ProductService;
        private readonly IAuthProvider AuthProvider;
        private readonly IUserActionProvider UserActionProvider;

        public ProductProvider(IProductService productService, IAuthProvider authProvider, IUserActionProvider userActionProvider)
        {
            ProductService = productService;
            AuthProvider = authProvider;
            UserActionProvider = userActionProvider;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            await UserActionProvider.LogUserAction($"El cliente {AuthProvider.CurrentClient.ClientId} obtuvo la lista de productos");
            return await ProductService.GetProducts(AuthProvider.CurrentClient.ClientId);
        }

        public async Task<ProductReset> ResetProduct(string productNumber)
        {
            await UserActionProvider.LogUserAction($"El cliente {AuthProvider.CurrentClient.ClientId} blanqueó el PIN del producto {productNumber}");
            return await ProductService.ResetProduct(productNumber);
        }
    }
}
