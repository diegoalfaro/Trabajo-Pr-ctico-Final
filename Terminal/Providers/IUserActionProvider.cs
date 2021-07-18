using System.Threading.Tasks;

namespace Terminal.Providers
{
    public interface IUserActionProvider
    {
        Task LogUserAction(string description);
    }
}
