using Domain;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Terminal.Providers;

namespace Terminal.Pages
{
    /// <summary>
    /// Lógica de interacción para ProductReset.xaml
    /// </summary>
    public partial class ProductReset : Page
    {
        private readonly INavigationProvider NavigationProvider;
        private readonly IProductProvider ProductProvider;

        public IEnumerable<Product> Products { get; set; }

        public ProductReset(INavigationProvider navigationProvider, IProductProvider productProvider)
        {
            NavigationProvider = navigationProvider;
            ProductProvider = productProvider;
            Products = new List<Product>();

            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Products = await ProductProvider.GetProducts();
            DataContext = this;
            this.productsBox.SelectionChanged += (_sender, _e) => {
                this.resetButton.Visibility = Visibility.Visible;
            };
            UpdateLayout();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationProvider.GoBack();
        }

        private async void resetButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationProvider.ShowLoading();

            try
            {
                Product selected = (this.productsBox.SelectedItem as Product);
                Domain.ProductReset result = await ProductProvider.ResetProduct(selected.Number);

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
                    NavigationProvider.NavigateTo<ProductResetResult>(new {
                        RemoveBackEntry = true
                    });
                }
            }

            catch (Exception pEx)
            {
                NavigationProvider.ShowError(new
                {
                    Text = pEx.Message,
                    BackPage = this,
                    RemoveBackEntry = true
                });
            }
        }

    }
}
