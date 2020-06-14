using System.Windows;
using System.Windows.Controls;

using static Terminal.Helpers.NavigationHelper;
using static Terminal.Helpers.SessionHelper;

namespace Terminal.Pages
{
    /// <summary>
    /// Lógica de interacción para Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public string WelcomeText => $"Bienvenido, {CurrentClient.Name}";

        public Main()
        {
            InitializeComponent();
            DataContext = this;
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
