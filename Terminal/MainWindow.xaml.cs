using System;
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

            pControl.LostKeyboardFocus += (a, b) => {
                keypad.Close();
            };

            keypad.Deactivated += (a, b) => {
                keypad.Close();
            };
        }

        public MainWindow()
        {
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
            //e.Handled = true;

            //if ((e.NewFocus as TextBox) != null && (e.NewFocus as PasswordBox) != null) return;

            //CreateKeyPad(e.NewFocus as Control);
        }
    }
}
