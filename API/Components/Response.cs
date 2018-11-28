using System;
using System.Collections.Generic;

using API.Interfaces;

namespace API.Components
{
    public class Response : IResponse
    {
        public int Status { get; set; }
        public IEnumerable<KeyValuePair<string, IEnumerable<string>>> Headers { get; set; }
        public String Body { get; set; }
    }
}
