using Domain;
using Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Terminal.Providers
{
    public class AccountProvider: IAccountProvider
    {
        private readonly IAccountService AccountService;
        private readonly IAuthProvider AuthProvider;
        private readonly IUserActionProvider UserActionProvider;

        public AccountProvider(IAccountService accountService, IAuthProvider authProvider, IUserActionProvider userActionProvider)
        {
            AccountService = accountService;
            AuthProvider = authProvider;
            UserActionProvider = userActionProvider;
        }

        public async Task<AccountBalance> GetAccountBalance()
        {
            await UserActionProvider.LogUserAction($"El cliente {AuthProvider.CurrentClient.ClientId} pidió un balance de la cuenta");
            return await AccountService.GetAccountBalance(AuthProvider.CurrentClient.ClientId);
        }

        public async Task<IEnumerable<AccountMovement>> GetAccountMovements()
        {
            await UserActionProvider.LogUserAction($"El cliente {AuthProvider.CurrentClient.ClientId} pidió los movimientos de cuenta");
            return await AccountService.GetAccountMovements(AuthProvider.CurrentClient.ClientId);
        }
    }
}
