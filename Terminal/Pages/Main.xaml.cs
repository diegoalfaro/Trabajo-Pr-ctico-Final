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
    /// Lógica de interacción para Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public string WelcomeText => $"Bienvenido, {ClientInfo.name}";

        public Main()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void pinButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo("ProductReset");
        }

        private void balanceButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo("Balance");
        }

        private void movementsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo("Movements");
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            Logout();
            NavigateTo("Login");
        }
    }
}
