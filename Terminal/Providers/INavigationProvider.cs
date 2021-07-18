using System.Windows.Controls;

namespace Terminal.Providers
{
    public interface INavigationProvider
    {
        Frame NavigationFrame { get; set; }
        void NavigateTo<TPage>(dynamic pParams = null) where TPage : Page;
        void NavigateTo(Page pPageObject, dynamic pParams = null);
        bool CanGoBack();
        void GoBack();
        void ShowLoading();
        void ShowError(dynamic pParams);
    }
}
