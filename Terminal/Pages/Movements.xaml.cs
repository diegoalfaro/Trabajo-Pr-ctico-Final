using Domain;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Terminal.Providers;

namespace Terminal.Pages
{
    /// <summary>
    /// Lógica de interacción para Movements.xaml
    /// </summary>
    public partial class Movements : Page
    {
        private readonly INavigationProvider NavigationProvider;
        private readonly IAccountProvider AccountProvider;

        public IEnumerable<AccountMovement> AccountMovementList { get; set; }

        public Movements(INavigationProvider navigationProvider, IAccountProvider accountProvider)
        {
            NavigationProvider = navigationProvider;
            AccountProvider = accountProvider;

            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationProvider.GoBack();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AccountMovementList = await AccountProvider.GetAccountMovements();
            DataContext = this;
            UpdateLayout();
        }
    }
}
