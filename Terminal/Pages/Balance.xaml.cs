using Domain;
using System.Windows;
using System.Windows.Controls;

using static Terminal.Helpers.NavigationHelper;
using static Terminal.Helpers.SessionHelper;

namespace Terminal.Pages
{
    /// <summary>
    /// Lógica de interacción para Balance.xaml
    /// </summary>
    public partial class Balance : Page
    {
        public double CurrentBalance { get; set; }

        public Balance()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AccountBalance result = await GetBalance();

            if (result != null)
            {
                this.CurrentBalance = result.Balance;
                this.DataContext = this;
                this.UpdateLayout();
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
        }
    }
}
