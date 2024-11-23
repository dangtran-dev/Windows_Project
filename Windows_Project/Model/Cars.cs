using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Project;
public class Cars : INotifyPropertyChanged
{
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public string Year { get; set; }
    public string Price { get; set; }
    public string Picture { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;
}
