using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IApiService
    {
        Task<Client> GetClientInfo(int pClientId, int pPassword);

        Task<List<Product>> GetProductsByClientID(int pClientId);

        Task<AccountBalance> GetBalanceByClientID(int pClientId);

        Task<List<AccountMovement>> GetMovementsByClientID(int pClientId);

        Task<ProductReset> ResetProductByProductNumber(string pProductNumber);
    }
}
