using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Project;

public interface IDao
{
    List<Manufacturers> GetManufacturers();
    List<Cars> GetCars();
    List<IsExpanderExpaned> GetIsExpanderExpaned();
    List<Location> GetLocations();
    List<Users> GetUsers();

}
