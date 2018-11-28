using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using static Terminal.Controllers.NavigationController;
using static Terminal.Controllers.SessionController;

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
            try
            {
                var currentId = this.usernameBox.Text;
                var currentPassword = this.passwordBox.Password;

                NavigateTo("Loading");

                if (!Int32.TryParse(currentId, out int id))
                {
                    throw new Exception("Formato de usuario inválido");
                }

                if (!Int32.TryParse(currentPassword, out int password))
                {
                    throw new Exception("Formato de constraseña inválido");
                }

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
                    BackPage = this
                });
            }
        }
    }
}
