using Domain;
using System;
using System.Threading.Tasks;

namespace Terminal.Providers
{
    public class UserActionProvider : IUserActionProvider
    {
        private readonly IAuthProvider AuthProvider;
        private readonly IDataManagementProvider DataManagementProvider;

        public UserActionProvider(IAuthProvider authProvider, IDataManagementProvider dataManagementProvider)
        {
            AuthProvider = authProvider;
            DataManagementProvider = dataManagementProvider;
        }

        public async Task LogUserAction(string description)
        {
            var userAction = new UserAction()
            {
                SessionId = AuthProvider.CurrentSession.SessionId,
                Description = description,
                Date = DateTime.Now
            };

            using (DataManagementProvider)
            {
                await DataManagementProvider.Insert(userAction);
                await DataManagementProvider.SaveAsync();
            }
        }
    }
}
