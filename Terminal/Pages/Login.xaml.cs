using System;
using System.Windows;
using System.Windows.Controls;

using static Terminal.Helpers.NavigationHelper;
using static Terminal.Helpers.SessionHelper;

namespace Terminal.Pages
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
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
                ShowLoading();
                await TryLogin(id, password);

                if (!IsLogged())
                {
                    throw new Exception("Comprobar los datos ingresados");
                }

                NavigateTo("Main");
            }

            catch (Exception pEx)
            {
                ShowError(new
                {
                    Text = pEx.Message,
                    BackPage = this,
                    RemoveBackEntry = loading
                });
            }
        }
    }
}
