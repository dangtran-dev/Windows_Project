using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Project
{
    public class Reviews : INotifyPropertyChanged
    {
        public int ReviewID { get; set; }
        public string Title { get; set; }
        public string Advantages { get; set; }
        public string Disadvantages { get; set; }
        public string Content { get; set; }
        public string ImageURL { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
