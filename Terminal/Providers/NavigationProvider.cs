using System;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using Terminal.Pages;

namespace Terminal.Providers
{
    public class NavigationProvider: INavigationProvider
    {
        private Frame _NavigationFrame;
        public Frame NavigationFrame {
            get => _NavigationFrame;
            set {
                value.Navigated += (sender, e) => {
                    try
                    {
                        var extraData = (e.ExtraData as dynamic);

                        if (extraData.RemoveBackEntry)
                        {
                            RemoveBackEntry();
                        }
                    }
                    catch { }
                };
                _NavigationFrame = value;
            }
        }

        private readonly IServiceProvider ServiceProvider;

        public NavigationProvider(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public void NavigateTo<TPage>(dynamic pParams = null) where TPage : Page
        {
            var page = ServiceProvider.GetRequiredService<TPage>();
            NavigateTo(page, pParams);
        }

        public void NavigateTo(Page pPageObject, dynamic pParams = null) => NavigationFrame.Navigate(pPageObject, pParams);

        private void RemoveBackEntry() => NavigationFrame.RemoveBackEntry();

        public bool CanGoBack() => NavigationFrame.CanGoBack;

        public void GoBack() => NavigationFrame.GoBack();

        public void ShowLoading() => NavigateTo<Loading>();

        public void ShowError(dynamic pParams) => NavigateTo<Error>(pParams);
    }
}
