using Domain;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Terminal.Helpers;

namespace Terminal.Pages
{
    /// <summary>
    /// Lógica de interacción para Movements.xaml
    /// </summary>
    public partial class Movements : Page
    {
        private readonly NavigationHelper NavigationHelper;
        private readonly AccountHelper AccountHelper;

        public IEnumerable<AccountMovement> AccountMovementList { get; set; }

        public Movements(NavigationHelper navigationHelper, AccountHelper accountHelper)
        {
            NavigationHelper = navigationHelper;
            AccountHelper = accountHelper;
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.GoBack();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AccountMovementList = await AccountHelper.GetMovements();
            DataContext = this;
            UpdateLayout();
        }
    }
}
