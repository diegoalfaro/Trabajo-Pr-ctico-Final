using System;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Input;

namespace KeyPad
{
    public partial class Keypad : Window, INotifyPropertyChanged
    {
        public Control Input { get; set; }

        public String Value {
            get
            {
                if (this.Input is TextBox) return (this.Input as TextBox).Text;
                if (this.Input is PasswordBox) return (this.Input as PasswordBox).Password;
                return "";
            }
            set
            {
                if (this.Input is TextBox) (this.Input as TextBox).Text = value;
                if (this.Input is PasswordBox) (this.Input as PasswordBox).Password = value;
            }
        }

        public Keypad(Control pInput)
        {
            InitializeComponent();
            this.Input = pInput;
            this.DataContext = this;
            this.Deactivated += (object sender, EventArgs e) => {
                FocusManager.SetFocusedElement(FocusManager.GetFocusScope(this.Input), null);
                Keyboard.ClearFocus();
            };
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            switch (button.CommandParameter.ToString()) 
            {
                case "ESC":
                    this.Close();
                    break;

                case "BACK":
                    if (this.Value.Length > 0)
                        this.Value = this.Value.Remove(this.Value.Length - 1);
                    break;

                default:
                    this.Value += button.Content.ToString();
                    break;
            }   
        }    

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion

        
       
    }
}
