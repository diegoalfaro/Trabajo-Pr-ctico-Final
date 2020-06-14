using Domain;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using static Terminal.Helpers.NavigationHelper;
using static Terminal.Helpers.SessionHelper;

namespace Terminal.Pages
{
    /// <summary>
    /// Lógica de interacción para Movements.xaml
    /// </summary>
    public partial class Movements : Page
    {
        public IEnumerable<AccountMovement> AccountMovementList { get; set; }

        public Movements()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AccountMovementList = await GetMovements();
            DataContext = this;
            UpdateLayout();
        }
    }
}
