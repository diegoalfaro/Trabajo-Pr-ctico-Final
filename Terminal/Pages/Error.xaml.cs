﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using static Terminal.Controllers.NavigationController;

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
            this.DataContext = new { Text = "Hubo un error" };
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
            /*
            var dataContext = this.DataContext as dynamic;
            NavigateTo(dataContext.BackPage);
            */
        }
    }
}
