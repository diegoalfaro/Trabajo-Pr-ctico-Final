using Domain;
using System.Windows;
using System.Windows.Controls;
using Terminal.Helpers;

namespace Terminal.Pages
{
    /// <summary>
    /// Lógica de interacción para Balance.xaml
    /// </summary>
    public partial class Balance : Page
    {
        private readonly NavigationHelper NavigationHelper;
        private readonly AccountHelper AccountHelper;

        public double CurrentBalance { get; set; }

        public Balance(NavigationHelper navigationHelper, AccountHelper accountHelper)
        {
            NavigationHelper = navigationHelper;
            AccountHelper = accountHelper;
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AccountBalance result = await AccountHelper.GetBalance();

            if (result != null)
            {
                this.CurrentBalance = result.Balance;
                this.DataContext = this;
                this.UpdateLayout();
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.GoBack();
        }
    }
}
