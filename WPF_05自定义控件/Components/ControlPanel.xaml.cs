using System.Windows;
using System.Windows.Controls;

namespace WPF_05自定义控件.Components
{
    /// <summary>
    /// ControlPanel.xaml 的交互逻辑
    /// </summary>
    public partial class ControlPanel : UserControl
    {
        // 控制面板
        public ControlPanel()
        {
            InitializeComponent();
            InitDefaultValue();
        }


        public int Maximum
        {
            get { return (int)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Maximum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(int), typeof(ControlPanel), new PropertyMetadata(50));


        public int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Minimum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(int), typeof(ControlPanel), new PropertyMetadata(-20));


        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(ControlPanel), new PropertyMetadata(26));



        public event RoutedEventHandler CurrentTempChanged
        {
            add { AddHandler(CurrentTempChangedEvent, value); }
            remove { RemoveHandler(CurrentTempChangedEvent, value); }
        }
        public static readonly RoutedEvent CurrentTempChangedEvent = EventManager.RegisterRoutedEvent
            ("CurrentTempChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ControlPanel));


        public event RoutedEventHandler AlarmMinChanged
        {
            add { AddHandler(AlarmMinChangedEvent, value); }
            remove { RemoveHandler(AlarmMinChangedEvent, value); }
        }
        public static readonly RoutedEvent AlarmMinChangedEvent = EventManager.RegisterRoutedEvent
            ("AlarmMinChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ControlPanel));


        public event RoutedEventHandler AlarmMaxChanged
        {
            add { AddHandler(AlarmMaxChangedEvent, value); }
            remove { RemoveHandler(AlarmMaxChangedEvent, value); }
        }

        public static readonly RoutedEvent AlarmMaxChangedEvent = EventManager.RegisterRoutedEvent
            ("AlarmMaxChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ControlPanel));



        private void InitDefaultValue()
        {
            Value = 26;
            Maximum = 50;
            Minimum = -20;
        }

        private void CurrentTemp_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                Value++;
            }
            else
            {
                Value--;
            }
            ValueChangedEventArgs args = new ValueChangedEventArgs(CurrentTempChangedEvent, Value);
            RaiseEvent(args);
        }

        private void AlarmMin_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                Minimum++;
            }
            else
            {
                Minimum--;
            }
            ValueChangedEventArgs args = new ValueChangedEventArgs(AlarmMinChangedEvent, Minimum);
            RaiseEvent(args);
        }

        private void AlarmMax_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                Maximum++;
            }
            else
            {
                Maximum--;
            }
            ValueChangedEventArgs args = new ValueChangedEventArgs(AlarmMaxChangedEvent, Maximum);
            RaiseEvent(args);
        }
    }

    public class ValueChangedEventArgs : RoutedEventArgs
    {
        public double Value { get; set; }

        public ValueChangedEventArgs(RoutedEvent routedEvent, double value)
            : base(routedEvent)
        {
            Value = value;
        }
    }
}
