using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using API.Components;

namespace API.Interfaces
{
    internal interface IHttpMessage
    {
        IEnumerable<KeyValuePair<String, IEnumerable<String>>> Headers { get; }
        String Body { get; }
    }
}
