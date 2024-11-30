using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    // Thêm danh sách xe đã lọc
    public ObservableCollection<Cars> FilteredCars { get; set; }
    public MainViewModel()
    {
        IDao dao = new MockDao();
        Manufacturers = dao.GetManufacturers();
        Locations = dao.GetLocations();
        IsExpanderExpaneds = dao.GetIsExpanderExpaned();
        Users = dao.GetUsers();

        // Khởi tạo danh sách xe lọc
        FilteredCars = new ObservableCollection<Cars>();
    }

    // Thêm phương thức để lọc xe dựa vào Condition
    public void FilterCarsByCondition(string condition)
    {
        // Xóa danh sách hiện tại
        FilteredCars.Clear();

        // Lọc dữ liệu từ danh sách Manufacturers
        var cars = Manufacturers
            .SelectMany(m => m.Cars) // Lấy tất cả xe từ các hãng sản xuất
            .Where(c => c.Condition == condition) // Lọc theo điều kiện
            .ToList();

        // Thêm xe đã lọc vào danh sách
        foreach (var car in cars)
        {
            FilteredCars.Add(car);
        }
    }
}
