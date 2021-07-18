using Domain;
using System.Threading.Tasks;

namespace Services
{
    public interface IAuthService
    {
        Task<Client> Login(int clientId, int password);
    }
}
