using System.ComponentModel;
using System.Windows;
using WPF_04绑定.Windows;

namespace WPF_04绑定
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public MainWindow()
        {
            InitializeComponent();
        }


        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            var window = new BackBindingWindow();
            window.Show();

        }
    }
}