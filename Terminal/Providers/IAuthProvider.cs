using Domain;
using System.Threading.Tasks;

namespace Terminal.Providers
{
    public interface IAuthProvider
    {
        Session CurrentSession { get; }
        Client CurrentClient { get; }
        bool IsLoggedIn();
        Task<bool> Login(int pClientId, int pPassword);
        Task Logout();
    }
}
