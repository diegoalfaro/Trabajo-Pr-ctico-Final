using System.Collections.Generic;

namespace RestService.Common
{
    public interface IRequest : IHttpMessage
    {
        Method Method { get; }

        string Path { get; }

        Dictionary<string, string> Params { get; set; }
    }
}
