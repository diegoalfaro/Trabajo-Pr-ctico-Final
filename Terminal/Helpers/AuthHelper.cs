using Domain;
using Repository;
using Service;
using System;
using System.Threading.Tasks;

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

                using (var unitOfWork = new DataUnitOfWork()) {
                    unitOfWork.ClientRepository.Upsert(client);
                    unitOfWork.SessionRepository.Insert(session);
                    await unitOfWork.SaveAsync();
                }

                CurrentSession = session;

                return true;
            }

            return false;
        }

        public async Task Logout()
        {
            using (var unitOfWork = new DataUnitOfWork()) {
                CurrentSession.EndDate = DateTime.Now;
                unitOfWork.SessionRepository.Update(CurrentSession);
                await unitOfWork.SaveAsync();
            }

            CurrentSession = null;
        }
    }
}
