using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Project;

public class Manufacturers : INotifyPropertyChanged
{
    public int ManufacturerID { get; set; }
    public string ManufacturerName { get; set; }
    public string ManufacturerPicture { get; set; }
    public List<Cars> Cars { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;
}
