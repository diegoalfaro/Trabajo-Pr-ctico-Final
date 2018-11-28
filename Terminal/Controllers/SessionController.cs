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

        static public bool IsLogged()
        {
            return cClientInfo != null;
        }

        static public async Task<dynamic> TryLogin(int pId, int pPassword)
        {
            var result = await ApiController.GetClientInfo(pId, pPassword);

            if (result.Count > 0)
            {
                cClientInfo = result[0];
            }

            else
            {
                cClientInfo = null;
            }

            return result;
        }

        static public void Logout()
        {
            cClientInfo = null;
        }
    }
}
