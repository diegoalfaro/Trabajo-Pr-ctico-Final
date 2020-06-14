using System;
using System.Windows.Controls;

namespace Terminal.Helpers
{
    public static class NavigationHelper
    {
        static NavigationHelper()
        {
            var frame = GetNavigationFrame();

            frame.Navigated += (sender, e) => {
                try
                {
                    var extraData = (e.ExtraData as dynamic);

                    if (extraData.RemoveBackEntry)
                    {
                        RemoveBackEntry();
                    }
                }
                catch (Exception) {}
            };
        }

        static public Frame GetNavigationFrame()
        {
            return (App.Current.MainWindow as MainWindow).frame;
        }

        static private string GetPagePath(string pPageName)
        {
            return $"/Pages/{pPageName}.xaml";
        }

        static public void NavigateTo(String pPageName, dynamic pParams = null)
        {
            var frame = GetNavigationFrame();
            var uri = new Uri(GetPagePath(pPageName), UriKind.Relative);

            frame.Navigate(uri, pParams);
        }

        static public void NavigateTo(Page pPageObject, dynamic pParams = null)
        {
            var frame = GetNavigationFrame();

            frame.Navigate(pPageObject, pParams);
        }

        static public void RemoveBackEntry()
        {
            var frame = GetNavigationFrame();
            frame.RemoveBackEntry();
        }

        static public bool CanGoBack()
        {
            return GetNavigationFrame().CanGoBack;
        }

        static public void GoBack()
        {
            GetNavigationFrame().GoBack();
        }

        static public void ShowLoading()
        {
            NavigateTo("Loading");
        }

        static public void ShowError(dynamic pParams)
        {
            var frame = GetNavigationFrame();
            NavigateTo("Error", pParams);
        }
    }
}
