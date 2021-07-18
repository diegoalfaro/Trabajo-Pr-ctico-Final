using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestService.Common
{
    public class Response : IResponse
    {
        public int Status { get; set; }

        public Dictionary<string, IEnumerable<string>> Headers { get; set; }

        public string Body { get; set; }

        internal static async Task<TResponse> FromHttpReponseMessage<TResponse>(HttpResponseMessage httpResponseMessage) where TResponse : Response
        {
            using (HttpContent content = httpResponseMessage.Content)
            {
                var headers = new Dictionary<string, IEnumerable<string>>();
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
    }
}
