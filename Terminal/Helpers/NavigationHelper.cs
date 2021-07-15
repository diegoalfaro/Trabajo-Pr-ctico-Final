using System;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using Terminal.Pages;

namespace Terminal.Helpers
{
    public class NavigationHelper
    {
        private readonly IServiceProvider ServiceProvider;

        public NavigationHelper(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public void ConfigureNavigationFrame()
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
                catch (Exception) { }
            };
        }

        public Frame GetNavigationFrame()
        {
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
            return mainWindow.frame;
        }

        public void NavigateTo<TPage>(dynamic pParams = null) where TPage : Page
        {
            var page = ServiceProvider.GetRequiredService<TPage>();
            NavigateTo(page, pParams);
        }

        public void NavigateTo(Page pPageObject, dynamic pParams = null)
        {
            var frame = GetNavigationFrame();
            frame.Navigate(pPageObject, pParams);
        }

        public void RemoveBackEntry()
        {
            var frame = GetNavigationFrame();
            frame.RemoveBackEntry();
        }

        public bool CanGoBack()
        {
            return GetNavigationFrame().CanGoBack;
        }

        public void GoBack()
        {
            GetNavigationFrame().GoBack();
        }

        public void ShowLoading()
        {
            NavigateTo<Loading>();
        }

        public void ShowError(dynamic pParams)
        {
            var frame = GetNavigationFrame();
            NavigateTo<Error>(pParams);
        }
    }
}
