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
    /// Lógica de interacción para Balance.xaml
    /// </summary>
    public partial class Balance : Page
    {
        public Balance()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
        }
    }
}