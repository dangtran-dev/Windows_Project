using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows_Project;

namespace Windows_Project;

public interface IDao
{
    List<Manufacturers> GetManufacturers();
    List<Cars> GetCars();
    List<IsExpanderExpaned> GetIsExpanderExpaned();
    List<Location> GetLocations();
    List<Users> GetUsers();
    List<Listings> GetListings();
    List<CarModels> GetCarModels();

    // Phương thức lưu người dùng mới vào cơ sở dữ liệu
    Task<bool> SaveUserAsync(string username, string password);
}
