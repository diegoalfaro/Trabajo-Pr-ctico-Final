using System.Windows;
using System.Windows.Controls;
using Terminal.Providers;

namespace Terminal.Pages
{
    /// <summary>
    /// Lógica de interacción para Error.xaml
    /// </summary>
    public partial class Error : Page
    {
        private readonly INavigationProvider NavigationProvider;

        public bool CanGoBack => NavigationProvider.CanGoBack();

        public Error(INavigationProvider navigationProvider)
        {
            NavigationProvider = navigationProvider;

            InitializeComponent();

            DataContext = new { Text = "Hubo un error" };
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationProvider.GoBack();
        }
    }
}
