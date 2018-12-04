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

        static public async Task<dynamic> GetJSON(String pURI)
        {
            return await GetJSON("GET", pURI);
        }

        static public async Task<dynamic> GetJSON(String pMethod, String pURI)
        {
            var result = await Connector.SendAsync<API.Components.JsonResponse>(Method: pMethod, URI: pURI);
            return result.ToJson();
        }

        static public async Task<dynamic> GetClientInfo(int pClientId, int pPassword)
        {
            var uri = $"clients?id={pClientId}&pass={pPassword}";
            var json = await GetJSON(uri);

            if (json.Count > 0) return json[0].response.client;
            else return null;
        }

        static public async Task<dynamic> GetProductsByClientID(int pClientId)
        {
            var uri = $"products?id={pClientId}";
            var json = await GetJSON(uri);

            if (json.Count > 0) return json[0].response.product;
            else return null;
        }

        static public async Task<double?> GetBalanceByClientID(int pClientId)
        {
            var uri = $"account-balance?id={pClientId}";
            var json = await GetJSON(uri);

            if (json.Count > 0) return json[0].response.balance;
            else return null;
        }

        static public async Task<dynamic> GetMovementsByClientID(int pClientId)
        {
            var uri = $"account-movements?id={pClientId}";
            var json = await GetJSON(uri);

            if (json.Count > 0) return json[0].response.movements;
            else return null;
        }

        static public async Task<dynamic> ResetProductByProductNumber(string pProductNumber)
        {
            var uri = $"product-reset?number={pProductNumber}";
            var json = await GetJSON(uri);

            if (json.Count > 0) return json[0].response;
            else return null;
        }
    }
}