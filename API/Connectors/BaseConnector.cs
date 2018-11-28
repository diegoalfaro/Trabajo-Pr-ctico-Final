using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.Net.Http;

using API.Components;

namespace API.Connectors
{
    public class BaseConnector
    {
        private readonly Uri iBaseURI;

        public BaseConnector(String pBaseURI)
        {
            this.iBaseURI = new Uri(pBaseURI);
        }

        public async Task<TResponse> SendAsync<TResponse>(String Method = "GET", String URI = "/", IEnumerable<KeyValuePair<string, IEnumerable<string>>> Headers = null, String Body = null) where TResponse : Response
        {
            var request = new Request
            {
                Method = Method,
                URI = URI,
                Headers = Headers,
                Body = Body
            };

            using (HttpClient client = new HttpClient { BaseAddress = this.iBaseURI })
            using (HttpResponseMessage httpResponseMessage = await client.SendAsync(request.ToHttpRequestMessage()))
            using (HttpContent content = httpResponseMessage.Content)
            {
                var headers = new Dictionary<String, IEnumerable<string>>();
                foreach (var header in httpResponseMessage.Headers)
                {
                    headers.Add(header.Key, header.Value);
                }

                var body = await content.ReadAsStringAsync();

                var response = Activator.CreateInstance<TResponse>();
                response.Status = Convert.ToInt16(httpResponseMessage.StatusCode);
                response.Headers = headers;
                response.Body = body;

                return response;
            }
        }

        public async Task<Response> SendAsync(String Method = "GET", String URI = "/", IEnumerable<KeyValuePair<string, IEnumerable<string>>> Headers = null, String Body = null)
        {
            return await this.SendAsync<Response>(Method, URI, Headers, Body);
        }
    }
}
