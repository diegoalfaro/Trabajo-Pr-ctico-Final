using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Terminal.Providers
{
    public interface IAccountProvider
    {
        Task<AccountBalance> GetAccountBalance();
        Task<IEnumerable<AccountMovement>> GetAccountMovements();
    }
}
