using Domain;
using System.Threading.Tasks;

namespace Services
{
    public interface IClientService
    {
        Task<Client> GetClient(int clientId);
    }
}
