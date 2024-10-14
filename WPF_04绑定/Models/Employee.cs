using System.ComponentModel;

namespace WPF_04绑定.Models
{
    internal class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                if (_id == value) return;
                _id = value; OnPropertyChanged(nameof(Id));
            }
        }


        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value) return;
                _name = value; OnPropertyChanged(nameof(Name));
            }
        }
    }
}
