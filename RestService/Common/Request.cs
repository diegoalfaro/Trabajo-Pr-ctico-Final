using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestService.Common
{
    public class Request : IRequest
    {
        public Method Method { get; set; }

        public string Path { get; set; }

        public Dictionary<string, IEnumerable<string>> Headers { get; set; }

        public string Body { get; set; }

        public Dictionary<string, string> Params { get; set; }

        internal async Task<HttpRequestMessage> ToHttpRequestMessage()
        {
            HttpRequestMessage request = new HttpRequestMessage();

            request.Method = new HttpMethod(this.Method.ToString());

            if (Body != null)
            {
                request.Content = new StringContent(Body);
            }

            if (Headers != null)
            {
                foreach (var header in Headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            if (Params != null)
            {
                string query;
                using (var content = new FormUrlEncodedContent(Params))
                {
                    query = await content.ReadAsStringAsync();
                }

                Path += $"?{query}";
            }

            request.RequestUri = new Uri(Path, UriKind.RelativeOrAbsolute);

            return request;
        }
    }
}
