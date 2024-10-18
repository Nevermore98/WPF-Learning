using System.Collections.ObjectModel;
using System.Windows;

namespace WPF_01入门基础
{
    public class Color { 
        public string? ColorCode { get; set; }
    }

    public class Student { 
        public string? Name { get; set; }
        public string? ClassName { get; set; }
    }


    public partial class MainWindow : Window
    {
        // 注意需要初始化 ColorList，否则为 null ComboBox 中无数据。
        // 因为 ObservableCollection 只在集合变化时（Add、 Remove 等）通知 UI 更新，所以需要初始化一个空集合。
        public ObservableCollection<Color> ColorList { get; set; } = new ObservableCollection<Color>();

        // 注意只有属性才能绑定，字段不能绑定
        public ObservableCollection<Student> StudentList { get; set; } = new ObservableCollection<Student>()
        {
            //new Student() { Name = "小明", ClassName = "高一二班" },
            //new Student() { Name = "小王", ClassName = "高二三班" },
            //new Student() { Name = "小张", ClassName = "高一一班" },
        };

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            ColorList.Add(new Color { ColorCode = "Red" });
            ColorList.Add(new Color { ColorCode = "Green" });
            ColorList.Add(new Color { ColorCode = "Blue" });

            StudentList.Add(new Student() { Name = "小明", ClassName = "高一二班" });
            StudentList.Add(new Student() { Name = "小王", ClassName = "高二三班" });
            StudentList.Add(new Student() { Name = "小张", ClassName = "高一一班" });

        }
    }
}