using Domain;
using Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Terminal.Helpers
{
    public class AccountHelper
    {
        private readonly IApiService ApiService;
        private readonly AuthHelper AuthHelper;

        public AccountHelper(IApiService apiService, AuthHelper authHelper)
        {
            ApiService = apiService;
            AuthHelper = authHelper;
        }

        public async Task<AccountBalance> GetBalance()
        {
            return await ApiService.GetBalanceByClientID(AuthHelper.CurrentClient.ClientId);
        }

        public async Task<List<AccountMovement>> GetMovements()
        {
            return await ApiService.GetMovementsByClientID(AuthHelper.CurrentClient.ClientId);
        }
    }
}
