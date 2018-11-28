using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Interfaces
{
    internal interface IRequest : IHttpMessage
    {
        String Method { get; }
        String URI { get; }
    }
}
