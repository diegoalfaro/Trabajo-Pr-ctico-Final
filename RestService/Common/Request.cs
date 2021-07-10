using System;
using System.Collections.Generic;

using System.Net.Http;
using RestService.Interfaces;

namespace RestService.Common
{
    public class Request : IRequest
    {
        public Method Method { get; set; }

        public string Path { get; set; }

        public IEnumerable<KeyValuePair<string, IEnumerable<string>>> Headers { get; set; }

        public string Body { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Params { get; set; }

        internal HttpRequestMessage ToHttpRequestMessage()
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
                    query = content.ReadAsStringAsync().Result;
                }

                Path += $"?{query}";
            }

            request.RequestUri = new Uri(Path, UriKind.Relative);

            return request;
        }
    }
}
