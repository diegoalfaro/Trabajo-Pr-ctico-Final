using System.Windows;
using System.Windows.Controls;

using Terminal.Helpers;

namespace Terminal.Pages
{
    /// <summary>
    /// Lógica de interacción para Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        private readonly NavigationHelper NavigationHelper;
        private readonly AuthHelper AuthHelper;

        public string WelcomeText => $"Bienvenido, {AuthHelper.CurrentClient.Name}";

        public Main(NavigationHelper navigationHelper, AuthHelper authHelper)
        {
            NavigationHelper = navigationHelper;
            AuthHelper = authHelper;
            InitializeComponent();
            DataContext = this;
        }

        private void pinButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.NavigateTo<ProductReset>();
        }

        private void balanceButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.NavigateTo<Balance>();
        }

        private void movementsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.NavigateTo<Movements>();
        }

        private async void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            await AuthHelper.Logout();
            NavigationHelper.NavigateTo<Login>();
        }
    }
}
