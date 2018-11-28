using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using API.Connectors;
using static Terminal.Properties.Settings;

namespace Terminal.Controllers
{
    static class ApiController
    {
        static private BaseConnector cConnector;

        static ApiController()
        {
            cConnector = new BaseConnector(Default.API_URI);
        }

        static public BaseConnector Connector => cConnector;

        static public async Task<dynamic> GetClientInfo(int pId, int pPassword)
        {
            var method = "GET";
            var uri = $"clients?id={pId}&pass={pPassword}";

            var result = await Connector.SendAsync<API.Components.JsonResponse>(Method: method, URI: uri);
            return result.ToJson();
        }
    }
}
