using Domain;
using Services;
using System;
using System.Threading.Tasks;

namespace Terminal.Providers
{
    public class AuthProvider: IAuthProvider
    {
        public Session CurrentSession { get; private set; }
        public Client CurrentClient => CurrentSession.Client;

        private readonly IAuthService AuthService;
        private readonly IDataManagementProvider DataManagementProvider;

        public AuthProvider(IAuthService authService, IDataManagementProvider dataManagementProvider)
        {
            DataManagementProvider = dataManagementProvider;
            AuthService = authService;
        }

        public bool IsLoggedIn() => CurrentSession != null;

        public async Task<bool> Login(int clientId, int password)
        {
            Client client = await AuthService.Login(clientId, password);

            if (client != null)
            {
                Session session = new Session()
                {
                    ClientId = client.ClientId,
                    StartDate = DateTime.Now
                };

                using (DataManagementProvider)
                {
                    await DataManagementProvider.Upsert(client);
                    await DataManagementProvider.Insert(session);
                    await DataManagementProvider.SaveAsync();
                }

                CurrentSession = session;

                return true;
            }

            return false;
        }

        public async Task Logout()
        {
            CurrentSession.EndDate = DateTime.Now;

            using (DataManagementProvider)
            {
                await DataManagementProvider.Update(CurrentSession);
                await DataManagementProvider.SaveAsync();
            }

            CurrentSession = null;
        }
    }
}
