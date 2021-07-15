using System.Windows;
using System.Windows.Controls;
using Terminal.Helpers;
using static Terminal.Helpers.NavigationHelper;

namespace Terminal.Pages
{
    /// <summary>
    /// Lógica de interacción para ProductResetResult.xaml
    /// </summary>
    public partial class ProductResetResult : Page
    {
        private readonly NavigationHelper NavigationHelper;

        public ProductResetResult(NavigationHelper navigationHelper)
        {
            NavigationHelper = navigationHelper;
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.GoBack();
        }
    }
}
