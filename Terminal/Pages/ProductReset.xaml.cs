using Domain;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using static Terminal.Helpers.NavigationHelper;
using static Terminal.Helpers.SessionHelper;

namespace Terminal.Pages
{
    /// <summary>
    /// Lógica de interacción para ProductReset.xaml
    /// </summary>
    public partial class ProductReset : Page
    {
        public IEnumerable<Product> Products { get; set; }

        public ProductReset()
        {
            Products = new List<Product>();
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Products = await GetProducts();
            DataContext = this;
            UpdateLayout();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
        }

        private async void resetButton_Click(object sender, RoutedEventArgs e)
        {
            ShowLoading();

            try
            {
                Product selected = (this.productsBox.SelectedItem as Product);
                Domain.ProductReset result = await ProductReset(selected.Number);

                if (result != null && result.Error < 0)
                {
                    string errorDescription = result.ErrorDescription;

                    if (errorDescription == "")
                    {
                        throw new Exception("Error irrecuperable");
                    }

                    else
                    {
                        throw new Exception(errorDescription);
                    }
                }

                else
                {
                    NavigateTo("ProductResetResult", new {
                        RemoveBackEntry = true
                    });
                }
            }

            catch (Exception pEx)
            {
                ShowError(new
                {
                    Text = pEx.Message,
                    BackPage = this,
                    RemoveBackEntry = true
                });
            }
        }

    }
}
