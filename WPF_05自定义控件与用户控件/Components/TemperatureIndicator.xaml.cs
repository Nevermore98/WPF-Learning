using System.Windows;
using System.Windows.Controls;

namespace WPF_05自定义控件与用户控件.Components
{
    /// <summary>
    /// TemperatureIndicator.xaml 的交互逻辑
    /// </summary>
    public partial class TemperatureIndicator : UserControl
    {
        public TemperatureIndicator()
        {
            InitializeComponent();
            // 如果一个用户控件需要使用到父控件的数据，就不能把 DataContext 设置为自己，否则会覆盖父控件的 DataContext，
            // 另外 xaml 中的绑定需要改为相对路径绑定，如 Text="{Binding Value, RelativeSource={RelativeSource AncestorType=TemperatureIndicator}}"
            //DataContext = this;

            // 初始化时更新样式
            UpdateCircleLight();
        }


        public int AlarmMinimum
        {
            get { return (int)GetValue(AlarmMinimumProperty); }
            set { SetValue(AlarmMinimumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AlarmMinimum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AlarmMinimumProperty =
            DependencyProperty.Register("AlarmMinimum", typeof(int), typeof(TemperatureIndicator), new PropertyMetadata(-20, new PropertyChangedCallback(AlarmMinimumChanged)));

        private static void AlarmMinimumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as TemperatureIndicator)?.UpdateCircleLight();
        }



        public int AlarmMaximum
        {
            get { return (int)GetValue(AlarmMaximumProperty); }
            set { SetValue(AlarmMaximumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AlarmMaximum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AlarmMaximumProperty =
            DependencyProperty.Register("AlarmMaximum", typeof(int), typeof(TemperatureIndicator), new PropertyMetadata(50, new PropertyChangedCallback(AlarmMaximumChanged)));

        private static void AlarmMaximumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as TemperatureIndicator)?.UpdateCircleLight();
        }

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(TemperatureIndicator), new PropertyMetadata(26, new PropertyChangedCallback(ValueChanged)));

        private static void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as TemperatureIndicator)?.UpdateCircleLight();
        }

        private void UpdateCircleLight()
        {
            if (Value <= AlarmMinimum)
            {
                labelTemperature.Style = Resources["UnderAlarmTempLabelStyle"] as Style;
                ellipseIndicator.Style = Resources["AlarmTempEllipseStyle"] as Style;
            }
            else if (Value >= AlarmMaximum)
            {
                labelTemperature.Style = Resources["OverAlarmTempLabelStyle"] as Style;
                ellipseIndicator.Style = Resources["AlarmTempEllipseStyle"] as Style;
            }
            else
            {
                labelTemperature.Style = Resources["NormalTempLabelStyle"] as Style;
                ellipseIndicator.Style = Resources["NormalTempEllipseStyle"] as Style;
            }
        }
    }
}
