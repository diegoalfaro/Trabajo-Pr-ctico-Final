using Domain;
using Service;
using System;
using System.Threading.Tasks;
using Terminal.Contexts;

namespace Terminal.Helpers
{
    public class AuthHelper
    {
        public Session CurrentSession { get; private set; }
        public Client CurrentClient => CurrentSession.Client;

        private readonly IApiService ApiService;

        public AuthHelper(IApiService apiService)
        {
            ApiService = apiService;
        }

        public bool IsLoggedIn() => CurrentSession != null;

        public async Task<bool> Login(int pClientId, int pPassword)
        {
            Client client = await ApiService.GetClientInfo(pClientId, pPassword);

            if (client != null) {
                Session session = new Session() {
                    ClientId = client.ClientId,
                    StartDate = DateTime.Now
                };

                using (var context = new DataContext()) {
                    context.Clients.Add(client);
                    context.Sessions.Add(session);
                    await context.SaveChangesAsync();
                }

                CurrentSession = session;

                return true;
            }

            return false;
        }

        public async Task Logout()
        {
            using (var context = new DataContext())
            {
                Session session = await context.Sessions.FindAsync(CurrentSession.SessionId);
                if (session != null) {
                    session.EndDate = DateTime.Now;
                }
                await context.SaveChangesAsync();
            }

            CurrentSession = null;
        }
    }
}
