using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Project
{
    public class Location : INotifyPropertyChanged
    {
        public string City { get; set; }
        public List<string> District { get; set;}
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
