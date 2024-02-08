using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppPub3.Models
{
    public class Beer : INotifyPropertyChanged
    {

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        private double _price;
        public double Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(); }
        }

        private double _volume;
        public double Volume
        {
            get { return _volume; }
            set { _volume = value; OnPropertyChanged(); }
        }

        private int _count;
        public int Count
        {
            get { return _count; }
            set { _count=value; OnPropertyChanged(); }
        }

        private string _image;
        public string Image
        {
            get { return _image; }
            set { _image = value; OnPropertyChanged(); }
        }

        public double Total
        {
            get { return Count * Price; }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler? handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
