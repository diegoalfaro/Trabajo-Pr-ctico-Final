using System;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;

namespace KeyPad
{
    public partial class Keypad : Window,INotifyPropertyChanged
    {
        public object Input { get; set; }

        public String Value {
            get
            {
                if (this.Input as TextBox != null) return ((TextBox)this.Input).Text;
                if (this.Input as PasswordBox != null) return ((PasswordBox)this.Input).Password;
                return "";
            }
            set
            {
                if (this.Input as TextBox != null) ((TextBox)this.Input).Text = value;
                if (this.Input as PasswordBox != null) ((PasswordBox)this.Input).Password = value;
            }
        }

        public Keypad(object pInput)
        {
            InitializeComponent();
            this.Input = pInput;
            this.DataContext = this;
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
