using System.Collections.Generic;

namespace RestService.Common
{
    public interface IHttpMessage
    {
        Dictionary<string, IEnumerable<string>> Headers { get; }
        string Body { get; }
    }
}
