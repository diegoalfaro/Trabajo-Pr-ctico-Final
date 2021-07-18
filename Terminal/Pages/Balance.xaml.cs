using Domain;
using System.Windows;
using System.Windows.Controls;
using Terminal.Providers;

namespace Terminal.Pages
{
    /// <summary>
    /// Lógica de interacción para Balance.xaml
    /// </summary>
    public partial class Balance : Page
    {
        private readonly INavigationProvider NavigationProvider;
        private readonly IAccountProvider AccountProvider;

        public double CurrentBalance { get; set; }

        public Balance(INavigationProvider navigationProvider, IAccountProvider accountProvider)
        {
            NavigationProvider = navigationProvider;
            AccountProvider = accountProvider;

            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AccountBalance result = await AccountProvider.GetAccountBalance();

            if (result != null)
            {
                this.CurrentBalance = result.Balance;
                this.DataContext = this;
                this.UpdateLayout();
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationProvider.GoBack();
        }
    }
}
