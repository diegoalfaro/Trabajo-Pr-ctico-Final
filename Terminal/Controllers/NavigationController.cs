using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            ((MainWindow)App.Instance.MainWindow).frame.Navigate(uri, pParams);
        }

        static public void GoBack()
        {
            ((MainWindow)App.Current.MainWindow).frame.GoBack();
        }

        static public void ShowError(String pError)
        {
            NavigateTo("Error", new
            {
                text = pError
            });
        }
    }
}
