using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

    // Thêm danh sách xe đã lọc
    public ObservableCollection<Cars> FilteredCars { get; set; }

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

        // Khởi tạo danh sách xe lọc
        FilteredCars = new ObservableCollection<Cars>();

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

}