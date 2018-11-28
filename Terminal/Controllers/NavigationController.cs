using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Terminal.Controllers
{
    static class NavigationController
    {
        static private string GetPagePath(string pPageName)
        {
            return $"/Pages/{pPageName}.xaml";
        }

        static public void NavigateTo(String pPageName, dynamic pParams = null)
        {
            var uri = new Uri(GetPagePath(pPageName), UriKind.Relative);
            var frame = ((MainWindow)App.Instance.MainWindow).frame;

            frame.Navigate(uri, pParams);
        }

        static public void NavigateTo(Page pPageObject, dynamic pParams = null)
        {
            var frame = ((MainWindow)App.Instance.MainWindow).frame;

            frame.Navigate(pPageObject, pParams);
        }

        static public void GoBack()
        {
            ((MainWindow)App.Current.MainWindow).frame.GoBack();
        }

        static public void ShowError(dynamic pParams)
        {
            NavigateTo("Error", pParams);
        }
    }
}
