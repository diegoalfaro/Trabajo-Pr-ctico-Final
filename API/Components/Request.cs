using System;
using System.Collections.Generic;

using System.Net.Http;

using API.Interfaces;

namespace API.Components
{
    public class Request : IRequest
    {
        public IEnumerable<KeyValuePair<string, IEnumerable<string>>> Headers { get; set; }

        public string Body { get; set; }

        public string Method { get; set; }

        public string URI { get; set; }

        internal HttpRequestMessage ToHttpRequestMessage()
        {
            HttpRequestMessage request = new HttpRequestMessage();

            request.Method = new HttpMethod(this.Method);
            request.RequestUri = new Uri(this.URI, UriKind.Relative);

            if (Body != null)
            {
                request.Content = new StringContent(this.Body);
            }

            if (Headers != null)
            {
                foreach (var header in this.Headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            return request;
        }
    }
}
