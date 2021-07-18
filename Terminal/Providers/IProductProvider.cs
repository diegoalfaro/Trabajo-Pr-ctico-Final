using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Terminal.Providers
{
    public interface IProductProvider
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<ProductReset> ResetProduct(string pProductNumber);
    }
}
