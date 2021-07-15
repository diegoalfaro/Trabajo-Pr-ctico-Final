using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Terminal.Helpers;
using Terminal.Pages;
using static Terminal.Properties.Settings;

namespace Terminal
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static void CreateKeyPad(Control pControl)
        {
            var keypad = new KeyPad.Keypad(pControl);

            keypad.Show();

            Point position = pControl.PointToScreen(new Point(0d, 0d));
            keypad.Top = position.Y + pControl.ActualHeight;
        }

        private readonly NavigationHelper NavigationHelper;

        public MainWindow(NavigationHelper navigationHelper)
        {
            NavigationHelper = navigationHelper;
            InitializeComponent();
            Keyboard.DefaultRestoreFocusMode = RestoreFocusMode.None;
            Keyboard.PrimaryDevice.DefaultRestoreFocusMode = RestoreFocusMode.None;
        }

        private void frame_Navigated(object sender, NavigationEventArgs e)
        {
            if (e.ExtraData != null)
            {
                dynamic data = e.ExtraData;
                ((Page) this.frame.Content).DataContext = data;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                App.Current.Shutdown();
            }
        }

        private void Window_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (Default.SHOW_KEYPAD && (e.NewFocus is TextBox || e.NewFocus is PasswordBox)) {
                e.Handled = true;
                CreateKeyPad(e.NewFocus as Control);
            }
        }

        private void frame_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationHelper.ConfigureNavigationFrame();
            NavigationHelper.NavigateTo<Login>();
        }
    }
}
