using System;
using System.Threading.Tasks;

using System.Net.Http;

namespace RestService.Common
{
    public class Connector: IConnector
    {
        private readonly Uri BaseURI;

        public Connector(string baseURI)
        {
            BaseURI = new Uri(baseURI);
        }

        public async Task<TResponse> SendAsync<TResponse>(Request request) where TResponse : Response
        {
            using (HttpClient client = new HttpClient { BaseAddress = this.BaseURI })
            using (HttpResponseMessage httpResponseMessage = await client.SendAsync(await request.ToHttpRequestMessage()))
            {
                return await Response.FromHttpReponseMessage<TResponse>(httpResponseMessage);
            }
        }
    }
}
