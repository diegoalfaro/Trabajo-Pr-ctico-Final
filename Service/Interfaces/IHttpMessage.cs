using System;
using System.Collections.Generic;

namespace Service.Interfaces
{
    internal interface IHttpMessage
    {
        IEnumerable<KeyValuePair<String, IEnumerable<String>>> Headers { get; }
        String Body { get; }
    }
}
