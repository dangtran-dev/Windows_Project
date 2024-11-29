using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows_Project.Model;

namespace Windows_Project;

public class MainViewModel
{
    public List<Manufacturers> Manufacturers { get; set; }
    public List<Location> Locations { get; set; }
    public List<IsExpanderExpaned> IsExpanderExpaneds { get; set; }
    public List<Users> Users { get; set; }
    public List<Listings> Listings { get; set; }
    // Danh sách chứa thông tin xe và người bán đã lọc theo điều kiện
    public ObservableCollection<CarWithUserItem> CarWithUserList { get; set; }
    public MainViewModel()
    {
        IDao dao = new MockDao();
        Manufacturers = dao.GetManufacturers();
        Locations = dao.GetLocations();
        IsExpanderExpaneds = dao.GetIsExpanderExpaned();
        Users = dao.GetUsers();
        Listings = dao.GetListings();
        // Khởi tạo danh sách xa và người bán theo điều kiện xe
        CarWithUserList = new ObservableCollection<CarWithUserItem>();
    }

    //phương thức tạo một list chứa thông tin xe và người bán thông qua bài đăng
    public void CreateCarWithUserList(string condition)
    {
        // xóa danh sách hiện tại
        CarWithUserList.Clear();
        // lấy thông tin xe và người bán thông qua bài đăng
        foreach (var listing in Listings)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (listing.UserID == (i + 1))
                {
                    Cars result = new Cars();
                    foreach (var m in Manufacturers)
                    {
                        foreach (var c in m.Cars)
                        {
                            if (c.ID == listing.CarID)
                            {
                                result = c;
                                break;
                            }
                        }
                    }
                    CarWithUserList.Add(new CarWithUserItem
                    {
                        car = result,
                        user = Users[i]
                    });
                    break;
                }
            }
        }
        //lọc danh sách xe theo điều kiện
        if (condition != null)
        {
            var items = CarWithUserList
                .Where(c => c.car.Condition == condition)
                .ToList();
            CarWithUserList.Clear();
            foreach (var item in items)
            {
                CarWithUserList.Add(item);
            }
        }
    }
}
