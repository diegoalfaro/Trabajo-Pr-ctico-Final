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
        public MainWindow()
        {
            InitializeComponent();
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
            if (e.NewFocus as TextBox == null && e.NewFocus as PasswordBox == null) return;

            e.KeyboardDevice.ClearFocus();

            var keypad = new KeyPad.Keypad(e.NewFocus);

            keypad.Show();

            Point position = (e.NewFocus as Control).PointToScreen(new Point(0d, 0d));
            keypad.Top = position.Y + (e.NewFocus as Control).ActualHeight;

            e.NewFocus.LostKeyboardFocus += (a, b) => {
                keypad.Close();
            };
        }
    }
}
