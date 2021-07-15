using System;
using System.Windows;
using System.Windows.Controls;

using Terminal.Helpers;

namespace Terminal.Pages
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private readonly NavigationHelper NavigationHelper;
        private readonly AuthHelper AuthHelper;

        public Login(NavigationHelper navigationHelper, AuthHelper authHelper)
        {
            NavigationHelper = navigationHelper;
            AuthHelper = authHelper;
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
                NavigationHelper.ShowLoading();

                bool result = await AuthHelper.Login(id, password);

                if (!result)
                {
                    throw new Exception("Comprobar los datos ingresados");
                }

                NavigationHelper.NavigateTo<Main>();
            }

            catch (Exception pEx)
            {
                NavigationHelper.ShowError(new
                {
                    Text = pEx.Message,
                    BackPage = this,
                    RemoveBackEntry = loading
                });
            }
        }
    }
}
