using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IAccountService
    {
        Task<AccountBalance> GetAccountBalance(int clientId);
        Task<List<AccountMovement>> GetAccountMovements(int clientId);
    }
}
