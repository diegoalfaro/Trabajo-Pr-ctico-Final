using System;
using System.Windows;
using System.Windows.Controls;

using Terminal.Providers;

namespace Terminal.Pages
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private readonly INavigationProvider NavigationProvider;
        private readonly IAuthProvider AuthProvider;

        public Login(INavigationProvider navigationProvider, IAuthProvider authProvider)
        {
            NavigationProvider = navigationProvider;
            AuthProvider = authProvider;

            InitializeComponent();
        }

        private async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            bool loading = false;
            try
            {
                var currentId = this.clientIdBox.Text;
                var currentPassword = this.passwordBox.Password;

                if (!Int32.TryParse(currentId, out int id))
                {
                    throw new Exception("Formato de usuario inválido");
                }

                if (!Int32.TryParse(currentPassword, out int password))
                {
                    throw new Exception("Formato de constraseña inválido");
                }

                loading = true;
                NavigationProvider.ShowLoading();

                bool result = await AuthProvider.Login(id, password);

                if (!result)
                {
                    throw new Exception("Comprobar los datos ingresados");
                }

                NavigationProvider.NavigateTo<Main>();
            }

            catch (Exception pEx)
            {
                NavigationProvider.ShowError(new
                {
                    Text = pEx.Message,
                    BackPage = this,
                    RemoveBackEntry = loading
                });
            }
        }
    }
}
