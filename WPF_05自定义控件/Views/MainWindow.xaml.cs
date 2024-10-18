using System.ComponentModel;
using System.Windows;

namespace WPF_05自定义控件.Views
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
    }
}