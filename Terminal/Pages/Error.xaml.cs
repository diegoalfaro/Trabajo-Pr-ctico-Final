using System.Windows;
using System.Windows.Controls;

using static Terminal.Helpers.NavigationHelper;

namespace Terminal.Pages
{
    /// <summary>
    /// Lógica de interacción para Error.xaml
    /// </summary>
    public partial class Error : Page
    {
        public bool CanGoBack => CanGoBack();

        public Error()
        {
            InitializeComponent();
            DataContext = new { Text = "Hubo un error" };
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
        }
    }
}
