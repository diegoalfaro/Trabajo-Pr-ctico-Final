using System;
using System.Threading.Tasks;

using System.Net.Http;

namespace RestService.Common
{
    public class Connector
    {
        private readonly Uri iBaseURI;

        public Connector(String pBaseURI)
        {
            this.iBaseURI = new Uri(pBaseURI);
        }

        public async Task<TResponse> SendAsync<TResponse>(Request request) where TResponse : Response
        {
            using (HttpClient client = new HttpClient { BaseAddress = this.iBaseURI })
            using (HttpResponseMessage httpResponseMessage = await client.SendAsync(request.ToHttpRequestMessage()))
            {
                return await Response.FromHttpReponseMessage<TResponse>(httpResponseMessage);
            }
        }
    }
}
