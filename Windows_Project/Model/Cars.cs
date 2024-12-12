using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Project;
public class Cars : INotifyPropertyChanged
{
    public int ID { get; set; }
    public int ModelID { get; set; }
    public string CarName { get; set; }
    public int Year { get; set; }
    public string Style { get; set; }
    public string Condition { get; set; }
    public string Origin { get; set; }
    public decimal Mileage { get; set; }
    public string Gear { get; set; }
    public string FuelType { get; set; }
    public decimal Price { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public List<CarImages> CarImages { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;
}
