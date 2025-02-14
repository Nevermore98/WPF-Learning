using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace WPF_05自定义控件与用户控件.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public virtual void OnPropertyChanged(string? propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private int _temperature = 26;
        public int Temperature
        {
            get { return _temperature; }
            set
            {
                if (_temperature == value) return;
                _temperature = value; OnPropertyChanged(nameof(Temperature));
            }
        }

        private int _maximumTemperature = 100;
        public int MaximumTemperature
        {
            get { return _maximumTemperature; }
            set
            {
                if (_maximumTemperature == value) return;
                _maximumTemperature = value; OnPropertyChanged(nameof(MaximumTemperature));
            }
        }

        private int _minimumTemperature = -30;
        public int MinimumTemperature
        {
            get { return _minimumTemperature; }
            set
            {
                if (_minimumTemperature == value) return;
                _minimumTemperature = value; OnPropertyChanged(nameof(MinimumTemperature));
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void CloseButton_CustomClick(object sender, RoutedEventArgs e)
        {
            var messageBoxResult = MessageBox.Show("是否确认关闭应用？", "关闭应用", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes) Close();

        }

        private void ControlPanel_CurrentTempChanged(object sender, RoutedEventArgs e)
        {
            // 绑定的时候默认双向绑定，所以 Temperature 也会跟着变化
            var ev = e;
            var s = sender;
        }

        private void ControlPanel_AlarmMinChanged(object sender, RoutedEventArgs e)
        {
        }

        private void ControlPanel_AlarmMaxChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}