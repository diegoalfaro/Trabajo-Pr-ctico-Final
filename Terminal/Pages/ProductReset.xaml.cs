using System;
using System.Reflection;
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

using static Terminal.Controllers.ApiController;
using static Terminal.Controllers.NavigationController;
using static Terminal.Controllers.SessionController;

namespace Terminal.Pages
{
    /// <summary>
    /// Lógica de interacción para ProductReset.xaml
    /// </summary>
    public partial class ProductReset : Page
    {
        public IEnumerable<dynamic> Products { get; set; }

        public ProductReset()
        {
            this.Products = new List<dynamic>();
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.Products = await GetProducts();
            this.DataContext = this;
            this.UpdateLayout();
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
                string productNumber = (this.productsBox.SelectedItem as dynamic).number;
                var result = await ResetProductByProductNumber(productNumber);

                if (result.error != 0)
                {
                    string errorDescription = result["error-description"];

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
