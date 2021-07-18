using System.Threading.Tasks;

namespace RestService.Common
{
    public interface IConnector
    {
        Task<TResponse> SendAsync<TResponse>(Request request) where TResponse : Response;
    }
}
