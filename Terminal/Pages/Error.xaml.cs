using System.Windows;
using System.Windows.Controls;
using Terminal.Helpers;

namespace Terminal.Pages
{
    /// <summary>
    /// Lógica de interacción para Error.xaml
    /// </summary>
    public partial class Error : Page
    {
        private readonly NavigationHelper NavigationHelper;

        public bool CanGoBack => NavigationHelper.CanGoBack();

        public Error(NavigationHelper navigationHelper)
        {
            NavigationHelper = navigationHelper;
            InitializeComponent();
            DataContext = new { Text = "Hubo un error" };
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.GoBack();
        }
    }
}
