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
using System.Windows.Shapes;
using WPF_04绑定.Models;

namespace WPF_04绑定.Windows
{
    /// <summary>
    /// BackBinding.xaml 的交互逻辑
    /// </summary>
    public partial class BackBindingWindow : Window
    {
        private Employee _employee = new Employee() { Id = 1, Name = "Nevermore"};

        public BackBindingWindow()
        {
            InitializeComponent();

            InitBinding();
        }

        private void InitBinding()
        {
            var binding = new Binding();
            binding.Source = _employee;
            binding.Path = new PropertyPath("Id");
            binding.Mode = BindingMode.TwoWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;

            txtEmployee.SetBinding(TextBox.TextProperty, binding);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _employee.Id++;
        }
    }
}
