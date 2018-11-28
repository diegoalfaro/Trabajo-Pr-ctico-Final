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
        private int CurrentId
        {
            get
            {
                int value;
                Int32.TryParse(this.usernameBox.Text, out value);
                return value;
            }
        }
        private int CurrentPassword
        {
            get
            {
                int value;
                Int32.TryParse(this.passwordBox.Password, out value);
                return value;
            }
        }

        public Login()
        {
            InitializeComponent();
        }

        private async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            var login = await TryLogin(this.CurrentId, this.CurrentPassword);

            if (IsLogged())
            {
                NavigateTo("Main");
            }

            else
            {
                ShowError("Comprobar los datos ingresados");
            }
        }
    }
}
