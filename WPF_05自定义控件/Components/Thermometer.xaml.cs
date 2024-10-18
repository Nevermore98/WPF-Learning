using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace WPF_05自定义控件.Components
{
    /// <summary>
    /// Thermometer.xaml 的交互逻辑
    /// </summary>
    public partial class Thermometer : UserControl
    {
        FontFamily dingdingFont = Application.Current.Resources["Dingding"] as FontFamily;
        public Thermometer()
        {
            InitializeComponent();
        }


        public int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Minimum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(int), typeof(Thermometer), new PropertyMetadata(-20, new PropertyChangedCallback(ValueChanged)));


        public int Maximum
        {
            get { return (int)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Maximum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(int), typeof(Thermometer), new PropertyMetadata(50, new PropertyChangedCallback(ValueChanged)));


        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(Thermometer), new PropertyMetadata(0, new PropertyChangedCallback(ValueChanged)));



        private static void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as Thermometer)!.Update();
        }



        private void Update()
        {
            sectionTick.Children.Clear();

            try
            {
                var TickBorderHeight = 121;
                double RangeInterval = (Maximum - Minimum) / 2;
                double GraduationInterval = TickBorderHeight / RangeInterval;

                for (int i = 0; i <= RangeInterval; i++)
                {
                    Line line = new Line();
                    line.X1 = 2;
                    line.Y1 = i * GraduationInterval;
                    line.X2 = 10;
                    line.Y2 = i * GraduationInterval;
                    Color lineColor = (Color)ColorConverter.ConvertFromString("#BCA258");
                    Brush lineBrush = new SolidColorBrush(lineColor);
                    line.Stroke = lineBrush;
                    line.StrokeThickness = 1;

                    if (i % 2.5 != 0)
                    {
                        line.X2 = 4.5;
                    }
                    else
                    {
                        TextBlock textBlock = new TextBlock
                        {
                            Text = (Maximum - i * 2).ToString(),
                            FontSize = 9,
                            Width = 20,
                            Foreground = lineBrush,
                            TextAlignment = TextAlignment.Right,
                            Margin = new Thickness(10, -5 + i * GraduationInterval, 0, 0)
                        };

                        if (dingdingFont != null)
                        {
                            textBlock.FontFamily = dingdingFont;
                        }

                        sectionTick.Children.Add(textBlock);
                    }

                    sectionTick.Children.Add(line);
                }

                int value;
                value = Value < Minimum ? Minimum : Value;
                value = Value > Maximum ? Maximum : Value;

                var TransHeight = (value - Minimum) * (GraduationInterval / 2) + 10;

                DoubleAnimation doubleAnimation = new DoubleAnimation(TransHeight, TimeSpan.FromMilliseconds(500));
                sectionMercury.BeginAnimation(HeightProperty, doubleAnimation);
            }
            catch
            {

            }

        }
    }
}
