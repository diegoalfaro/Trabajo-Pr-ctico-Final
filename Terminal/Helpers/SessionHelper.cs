using Domain;
using Service;
using RestService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Terminal.Contexts;
using static Terminal.Properties.Settings;

namespace Terminal.Helpers
{
    static class SessionHelper
    {
        static public IApiService ApiService { get; private set; }

        static public Session CurrentSession { get; private set; }
        static public Client CurrentClient => CurrentSession.Client;

        static SessionHelper()
        {
            ApiService = new RestApiService(Default.API_URI);
        }

        static public bool IsLogged()
        {
            return CurrentSession != null;
        }

        static public async Task TryLogin(int pClientId, int pPassword)
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
                    CurrentSession = session;
                }
            }
        }

        static public async void Logout()
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

        static public async Task<AccountBalance> GetBalance()
        {
            return await ApiService.GetBalanceByClientID(CurrentClient.ClientId);
        }

        static public async Task<List<Product>> GetProducts()
        {
            return await ApiService.GetProductsByClientID(CurrentClient.ClientId);
        }

        static public async Task<List<AccountMovement>> GetMovements()
        {
            return await ApiService.GetMovementsByClientID(CurrentClient.ClientId);
        }

        static public async Task<ProductReset> ProductReset(string pProductNumber)
        {
            return await ApiService.ResetProductByProductNumber(pProductNumber);
        }
    }
}
