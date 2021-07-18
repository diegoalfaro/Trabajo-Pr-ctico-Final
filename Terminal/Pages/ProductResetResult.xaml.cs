using System.Windows;
using System.Windows.Controls;
using Terminal.Providers;

namespace Terminal.Pages
{
    /// <summary>
    /// Lógica de interacción para ProductResetResult.xaml
    /// </summary>
    public partial class ProductResetResult : Page
    {
        private readonly INavigationProvider NavigationProvider;

        public ProductResetResult(INavigationProvider navigationProvider)
        {
            NavigationProvider = navigationProvider;

            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationProvider.GoBack();
        }
    }
}
