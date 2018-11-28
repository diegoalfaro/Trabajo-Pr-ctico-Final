using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using API.Connectors;

namespace Terminal.Controllers
{
    static class SessionController
    {
        static private dynamic cClientInfo = null;

        static public dynamic ClientInfo => cClientInfo;

        static public int ClientID => ClientInfo.id;

        static public bool IsLogged()
        {
            return cClientInfo != null;
        }

        static public async Task TryLogin(int pClientId, int pPassword)
        {
            var result = await ApiController.GetClientInfo(pClientId, pPassword);

            if (result != null)
            {
                cClientInfo = new
                {
                    id = pClientId,
                    name = result.name,
                    segment = result.segment
                };
            }
        }

        static public void Logout()
        {
            cClientInfo = null;
        }

        static public async Task<double?> GetBalance()
        {
            var result = await ApiController.GetBalanceByClientID(ClientID);
            return result;
        }

        static public async Task<dynamic> GetProducts()
        {
            var result = await ApiController.GetProductsByClientID(ClientID);
            return result;
        }
    }
}
