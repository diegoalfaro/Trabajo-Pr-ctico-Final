using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Interfaces
{
    internal interface IResponse : IHttpMessage
    {
        int Status { get; }
    }
}
