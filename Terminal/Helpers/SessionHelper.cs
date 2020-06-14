using Domain;
using Service;
using Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

using static Terminal.Properties.Settings;

namespace Terminal.Helpers
{
    static class SessionHelper
    {
        static public IApiService ApiService { get; private set; }
        static public Client CurrentClient { get; private set; }

        static SessionHelper()
        {
            ApiService = new ApiService(Default.API_URI);
        }

        static public bool IsLogged()
        {
            return CurrentClient != null;
        }

        static public async Task TryLogin(int pClientId, int pPassword)
        {
            CurrentClient = await ApiService.GetClientInfo(pClientId, pPassword);
        }

        static public void Logout()
        {
            CurrentClient = null;
        }

        static public async Task<AccountBalance> GetBalance()
        {
            return await ApiService.GetBalanceByClientID(CurrentClient.Id);
        }

        static public async Task<List<Product>> GetProducts()
        {
            return await ApiService.GetProductsByClientID(CurrentClient.Id);
        }

        static public async Task<List<AccountMovement>> GetMovements()
        {
            return await ApiService.GetMovementsByClientID(CurrentClient.Id);
        }

        static public async Task<ProductReset> ProductReset(string pProductNumber)
        {
            return await ApiService.ResetProductByProductNumber(pProductNumber);
        }
    }
}
