using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPF_05自定义控件.Controls
{
    public class IconButton : Button
    {
        //private Button _button;
        private Path _path;
        private Border _border;
        static IconButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconButton), new FrameworkPropertyMetadata(typeof(IconButton)));
        }


        public Geometry Icon
        {
            get { return (Geometry)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(Geometry), typeof(IconButton), new PropertyMetadata(null));



        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(IconButton));




        public event RoutedEventHandler CustomClick
        {
            add { AddHandler(CustomClickEvent, value); }
            remove { RemoveHandler(CustomClickEvent, value); }
        }

        public static readonly RoutedEvent CustomClickEvent = EventManager.RegisterRoutedEvent
            ("CustomClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(IconButton));


        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            RaiseEvent(new RoutedEventArgs(CustomClickEvent, this));
        }
    }
}
