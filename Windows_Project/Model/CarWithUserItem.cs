using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows_Project;

namespace Windows_Project
{
    public class CarWithUserItem : INotifyPropertyChanged
    {
        public Cars car { get; set; }
        public Users user { get; set; }
        public Listings listing { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
