using KeyPad;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Terminal.Providers;
using Terminal.Pages;
using static Terminal.Properties.Settings;

namespace Terminal
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Keypad CreateKeyPad(Control control)
        {
            Point position = control.PointToScreen(new Point(0d, 0d));

            var keypad = new Keypad(control);
            keypad.Show();
            keypad.Top = position.Y + control.ActualHeight;
            keypad.Left = position.X;

            return keypad;
        }

        private readonly INavigationProvider NavigationProvider;

        public MainWindow(INavigationProvider navigationProvider)
        {
            NavigationProvider = navigationProvider;
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
            var component = e.NewFocus;

            if (Default.SHOW_KEYPAD && (component is TextBox || component is PasswordBox)) {
                e.Handled = true;
                CreateKeyPad(component as Control);
            }
        }

        private void frame_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationProvider.NavigationFrame = frame;
            NavigationProvider.NavigateTo<Login>();
        }
    }
}
