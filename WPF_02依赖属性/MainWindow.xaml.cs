using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_02依赖属性
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _password = "123456";
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }


        public MainWindow()
        {
            InitializeComponent();
        }


        public class PasswordBoxHelper
        {
            public static readonly DependencyProperty PasswordProperty =
                DependencyProperty.RegisterAttached("Password",
                                       typeof(string), typeof(PasswordBoxHelper),
                                                          new FrameworkPropertyMetadata(string.Empty, OnPasswordChanged));

            public static string GetPassword(DependencyObject dp)
            {
                return (string)dp.GetValue(PasswordProperty);
            }

            public static void SetPassword(DependencyObject dp, string value)
            {
                dp.SetValue(PasswordProperty, value);
            }

            private static void OnPasswordChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
            {
                PasswordBox passwordBox = (PasswordBox)sender;
                passwordBox.PasswordChanged -= PasswordChanged;

                if (e.NewValue != null)
                {
                    passwordBox.Password = e.NewValue.ToString();
                }
                else
                {
                    passwordBox.Password = string.Empty;
                }

                passwordBox.PasswordChanged += PasswordChanged;
            }

            private static void PasswordChanged(object sender, RoutedEventArgs e)
            {
                PasswordBox passwordBox = (PasswordBox)sender;
                SetPassword(passwordBox, passwordBox.Password);
            }
        }



        public class Test : DependencyObject
        {
            public int MyProperty
            {
                get { return (int)GetValue(MyPropertyProperty); }
                set { SetValue(MyPropertyProperty, value); }
            }

            public static readonly DependencyProperty MyPropertyProperty =
                DependencyProperty.Register("MyProperty", typeof(int), typeof(Test), new PropertyMetadata(0));
        }
    }
}