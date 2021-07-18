using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts(int pClientId);
        Task<ProductReset> ResetProduct(string productNumber);
    }
}
