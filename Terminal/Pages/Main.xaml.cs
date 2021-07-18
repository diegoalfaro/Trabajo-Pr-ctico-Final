using System.Windows;
using System.Windows.Controls;

using Terminal.Providers;

namespace Terminal.Pages
{
    /// <summary>
    /// Lógica de interacción para Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        private readonly INavigationProvider NavigationProvider;
        private readonly IAuthProvider AuthProvider;

        public string WelcomeText => $"Bienvenido, {AuthProvider.CurrentClient.Name}";

        public Main(INavigationProvider navigationProvider, IAuthProvider authProvider)
        {
            NavigationProvider = navigationProvider;
            AuthProvider = authProvider;

            InitializeComponent();
            DataContext = this;
        }

        private void pinButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationProvider.NavigateTo<ProductReset>();
        }

        private void balanceButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationProvider.NavigateTo<Balance>();
        }

        private void movementsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationProvider.NavigateTo<Movements>();
        }

        private async void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            await AuthProvider.Logout();
            NavigationProvider.NavigateTo<Login>();
        }
    }
}
