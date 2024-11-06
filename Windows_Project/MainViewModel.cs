using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Project;

public class MainViewModel
{
    public List<Manufacturers> Manufacturers { get; set; }
    public List<Location> Locations { get; set; }
    public List<IsExpanderExpaned> IsExpanderExpaneds { get; set; }
    public List<Users> Users { get; set; }
    public MainViewModel()
    {
        IDao dao = new MockDao();
        Manufacturers = dao.GetManufacturers();
        Locations = dao.GetLocations();
        IsExpanderExpaneds = dao.GetIsExpanderExpaned(); 
        Users = dao.GetUsers();
    }
}
