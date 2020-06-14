using System.Windows;
using System.Windows.Controls;

using static Terminal.Helpers.NavigationHelper;

namespace Terminal.Pages
{
    /// <summary>
    /// Lógica de interacción para ProductResetResult.xaml
    /// </summary>
    public partial class ProductResetResult : Page
    {
        public ProductResetResult()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
        }
    }
}
