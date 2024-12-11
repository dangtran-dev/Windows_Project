using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Project;

/// <summary>
/// This class is used to store the car details
/// </summary>
public class Cars : INotifyPropertyChanged
{
    public int CarID { get; set; }
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public int Year { get; set; }
    public string Price { get; set; }
    public string Picture { get; set; }
    public string Condition { get; set; }
    public string Style { get; set; }
    public string Origin { get; set; }
    public int Mileage { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string FuelType { get; set; }
    public string Gear { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;
}
