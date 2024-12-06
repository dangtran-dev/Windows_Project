using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Windows_Project.Model;

namespace Windows_Project;

public class MainViewModel : INotifyPropertyChanged
{
    public List<Manufacturers> Manufacturers { get; set; }
    public List<Cars> Cars { get; set; }
    public List<Location> Locations { get; set; }
    public List<IsExpanderExpaned> IsExpanderExpaneds { get; set; }
    public List<Users> Users { get; set; }
    public List<Listings> Listings { get; set; }
    // Danh sách chứa thông tin xe và người bán đã lọc theo điều kiện
    public ObservableCollection<CarWithUserItem> CarWithUserList { get; set; }
    // Danh sách chứa thông tin xe và người bán ban đầu
    public ObservableCollection<CarWithUserItem> CarWithUserListOriginal { get; set; }
    // Thêm danh sách xe đã chọn để so sánh
    public ObservableCollection<Cars> SelectedCars { get; set; }
    // Thêm thuộc tính để kiểm tra danh sách SelectedCars có hiển thị hay không
    private bool _isSelectedCarsVisible;
    public bool IsSelectedCarsVisible
    {
        get => _isSelectedCarsVisible;
        set
        {
            _isSelectedCarsVisible = value;
            OnPropertyChanged(nameof(IsSelectedCarsVisible));
        }
    }

    // Thêm danh sách xe lọc theo phương thức tìm kiếm
    public ObservableCollection<Cars> FilteredSearchCars { get; set; }
    public MainViewModel()
    {
        IDao dao = new MockDao();
        Manufacturers = dao.GetManufacturers();
        Cars = dao.GetCars();
        Locations = dao.GetLocations();
        IsExpanderExpaneds = dao.GetIsExpanderExpaned();
        Users = dao.GetUsers();
        Listings = dao.GetListings();

        // Khởi tạo danh sách xe đã chọn
        SelectedCars = new ObservableCollection<Cars>();
        SelectedCars.CollectionChanged += SelectedCars_CollectionChanged;

        // Ban đầu ẩn danh sách SelectedCarListView
        IsSelectedCarsVisible = false;

        // Khởi tạo danh sách xe lọc theo phương thức tìm kiếm
        FilteredSearchCars = new ObservableCollection<Cars>();
        foreach (var car in Cars)
        {
            FilteredSearchCars.Add(car);
        }

        // Khởi tạo danh sách xe và người bán theo điều kiện xe
        CarWithUserList = new ObservableCollection<CarWithUserItem>();
        // Khởi tạo danh sách xe và người bán ban đầu
        CarWithUserListOriginal = new ObservableCollection<CarWithUserItem>();
    }
    // phương thức tạo một list chứa thông tin xe và người bán ban đầu
    public void CreateCarWithUserListOriginal(string condition)
    {
        var newList = new ObservableCollection<CarWithUserItem>();

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
                            if (c.CarID == listing.CarID)
                            {
                                result = c;
                                break;
                            }
                        }
                    }
                    newList.Add(new CarWithUserItem
                    {
                        car = result,
                        user = Users[i]
                    });
                    break;
                }
            }
        }
        // đảo ngược danh sách để hiển thị bài đăng mới nhất
        newList = new ObservableCollection<CarWithUserItem>(newList.Reverse());
        // Lọc danh sách xe theo điều kiện
        if (condition != null)
        {
            newList = new ObservableCollection<CarWithUserItem>(
                 newList.Where(c => c.car.Condition == condition)
            );
        }
        CarWithUserListOriginal = newList;
    }
    //phương thức tạo một list chứa thông tin xe và người bán thông qua bài đăng
    public void CreateCarWithUserList(string condition, string manufacturer, string model)
    {
        var newList = new ObservableCollection<CarWithUserItem>();

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
                            if (c.CarID == listing.CarID)
                            {
                                result = c;
                                break;
                            }
                        }
                    }
                    newList.Add(new CarWithUserItem
                    {
                        car = result,
                        user = Users[i],
                        listing = listing
                    });
                    break;
                }
            }
        }
        // đảo ngược danh sách để hiển thị bài đăng mới nhất
        newList = new ObservableCollection<CarWithUserItem>(newList.Reverse());
        // Lọc danh sách xe theo điều kiện
        if (condition != null)
        {
            newList = new ObservableCollection<CarWithUserItem>(
                 newList.Where(c => c.car.Condition == condition)
            );
        }
        // Nếu manufacturer không rỗng, lọc theo nhà sản xuất
        if (!string.IsNullOrEmpty(manufacturer))
        {
            newList = new ObservableCollection<CarWithUserItem>(
                newList.Where(c => c.car.Manufacturer == manufacturer)
            );
        }
        // Nếu model không rỗng, lọc theo dòng xe
        if (!string.IsNullOrEmpty(model))
        {
            newList = new ObservableCollection<CarWithUserItem>(
                newList.Where(c => c.car.Model == model)
            );
        }

        CarWithUserList = newList; // Gán danh sách mới
        OnPropertyChanged(nameof(CarWithUserList)); // Thông báo UI cập nhật
    }

    private void SelectedCars_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        // Hiển thị hoặc ẩn SelectedCarListView dựa trên số lượng xe trong SelectedCars
        IsSelectedCarsVisible = SelectedCars.Count > 0;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void FilterSearchCars(string search)
    {
        var filteredCars = Cars
            .Where(c => c.Model != null && c.Model.ToLower().Contains(search.ToLower())) // Loại bỏ các xe có Model là null
            .ToList();

        FilteredSearchCars.Clear();
        foreach (var car in filteredCars)
        {
            FilteredSearchCars.Add(car);
        }
    }
    // Phương thức hỗ trợ để chuyển chuỗi giá thành số
    private long ParsePrice(string price)
    {
        // Loại bỏ phần "VNĐ" và dấu chấm, sau đó chuyển thành số
        string cleanedPrice = price.Replace(" VNĐ", "").Replace(".", "");

        // Bỏ đi 6 số 0 cuối cùng
        if (cleanedPrice.Length > 6)
        {
            cleanedPrice = cleanedPrice.Substring(0, cleanedPrice.Length - 6);
        }

        return long.Parse(cleanedPrice);
    }

    public void Search_Car_By_Filter(string manufacturer, string model, string year, string style, string minPrice, string maxPrice,
        string origin, string fuel, string gear, string city, string district)
    {
        var filteredLists = CarWithUserListOriginal
             .Where(c => c.car != null && (string.IsNullOrEmpty(manufacturer) || c.car.Manufacturer == manufacturer))
             .Where(c => c.car != null && (string.IsNullOrEmpty(model) || c.car.Model == model))
             .Where(c => c.car != null && (string.IsNullOrEmpty(year) || c.car.Year.ToString() == year))
             .Where(c => c.car != null && (string.IsNullOrEmpty(style) || c.car.Style == style))
             .Where(c => c.car != null && (string.IsNullOrEmpty(minPrice) || ParsePrice(c.car.Price) >= long.Parse(minPrice)))
             .Where(c => c.car != null && (string.IsNullOrEmpty(maxPrice) || ParsePrice(c.car.Price) <= long.Parse(maxPrice)))
             .Where(c => c.car != null && (string.IsNullOrEmpty(origin) || c.car.Origin == origin))
             .Where(c => c.car != null && (string.IsNullOrEmpty(fuel) || c.car.FuelType == fuel))
             .Where(c => c.car != null && (string.IsNullOrEmpty(gear) || c.car.Gear == gear))
             .Where(c => c.user != null && (string.IsNullOrEmpty(city) || c.car.City == city))
             .Where(c => c.user != null && (string.IsNullOrEmpty(district) || c.car.District == district))
            .ToList();
        CarWithUserList.Clear();
        foreach (var car in filteredLists)
        {
            CarWithUserList.Add(car);
        }
        OnPropertyChanged(nameof(CarWithUserList));
    }
}