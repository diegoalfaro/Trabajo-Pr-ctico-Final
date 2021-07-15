using Domain;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Terminal.Helpers;

namespace Terminal.Pages
{
    /// <summary>
    /// Lógica de interacción para ProductReset.xaml
    /// </summary>
    public partial class ProductReset : Page
    {
        private readonly NavigationHelper NavigationHelper;
        private readonly ProductHelper ProductHelper;

        public IEnumerable<Product> Products { get; set; }

        public ProductReset(NavigationHelper navigationHelper, ProductHelper productHelper)
        {
            NavigationHelper = navigationHelper;
            ProductHelper = productHelper;
            Products = new List<Product>();
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Products = await ProductHelper.GetProducts();
            DataContext = this;
            UpdateLayout();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.GoBack();
        }

        private async void resetButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.ShowLoading();

            try
            {
                Product selected = (this.productsBox.SelectedItem as Product);
                Domain.ProductReset result = await ProductHelper.ProductReset(selected.Number);

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
                    NavigationHelper.NavigateTo<ProductResetResult>(new {
                        RemoveBackEntry = true
                    });
                }
            }

            catch (Exception pEx)
            {
                NavigationHelper.ShowError(new
                {
                    Text = pEx.Message,
                    BackPage = this,
                    RemoveBackEntry = true
                });
            }
        }

    }
}
