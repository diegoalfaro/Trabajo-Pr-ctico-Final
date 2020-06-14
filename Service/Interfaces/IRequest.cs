using Service.Common;
using System.Collections.Generic;

namespace Service.Interfaces
{
    internal interface IRequest : IHttpMessage
    {
        Method Method { get; }

        string Path { get; }

        IEnumerable<KeyValuePair<string, string>> Params { get; set; }
    }
}
