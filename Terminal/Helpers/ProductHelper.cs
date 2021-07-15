using Domain;
using Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Terminal.Helpers
{
    public class ProductHelper
    {
        private readonly IApiService ApiService;
        private readonly AuthHelper AuthHelper;

        public ProductHelper(IApiService apiService, AuthHelper authHelper)
        {
            ApiService = apiService;
            AuthHelper = authHelper;
    }

        public async Task<List<Product>> GetProducts()
        {
            return await ApiService.GetProductsByClientID(AuthHelper.CurrentClient.ClientId);
        }

        public async Task<ProductReset> ProductReset(string pProductNumber)
        {
            return await ApiService.ResetProductByProductNumber(pProductNumber);
        }
    }
}
