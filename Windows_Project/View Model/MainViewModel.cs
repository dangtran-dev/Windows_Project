using Microsoft.Data.SqlClient;
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
using Windows_Project.Service.DataAccess;

namespace Windows_Project;

public class MainViewModel : INotifyPropertyChanged
{
    public List<Manufacturers> Manufacturers { get; set; }
    public List<Cars> Cars { get; set; }
    public List<Location> Locations { get; set; }
    public List<IsExpanderExpaned> IsExpanderExpaneds { get; set; }
    public List<Users> Users { get; set; }
    public List<Listings> Listings { get; set; }
    public List<CarModels> CarModels { get; set; }
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
        string connectionString = "Server=localhost,1433;Database=demoshop;User Id=sa;Password=SqlServer@123;TrustServerCertificate=True;";
        IDao dao = new SqlDao(connectionString);
        Manufacturers = dao.GetManufacturers();
        Cars = dao.GetCars();
        Locations = dao.GetLocations();
        IsExpanderExpaneds = dao.GetIsExpanderExpaned();
        Users = dao.GetUsers();
        Listings = dao.GetListings();
        CarModels = dao.GetCarModels();

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

    public void SaveUserInfo(Users currentUser)
    {
        // Giả sử CurrentUser là người dùng hiện tại đang chỉnh sửa
        var user = Users.FirstOrDefault(u => u.UserID == currentUser.UserID);
        if (user != null)
        {
            user.FullName = currentUser.FullName;
            user.Address = currentUser.Address;
            user.Phone = currentUser.Phone;
            user.Email = currentUser.Email;

            // Cập nhật vào cơ sở dữ liệu
            using (var connection = new SqlConnection("Server=localhost,1433;Database=demoshop;User Id=sa;Password=SqlServer@123;TrustServerCertificate=True;"))
            {
                connection.Open();
                var query = "UPDATE Users SET FullName = @FullName, Address = @Address, Phone = @Phone, Email = @Email WHERE UserID = @UserID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FullName", currentUser.FullName);
                    command.Parameters.AddWithValue("@Address", currentUser.Address);
                    command.Parameters.AddWithValue("@Phone", currentUser.Phone);
                    command.Parameters.AddWithValue("@Email", currentUser.Email);
                    command.Parameters.AddWithValue("@UserID", currentUser.UserID);
                    command.ExecuteNonQuery();
                }
            }

            // Thông báo cho UI biết dữ liệu đã thay đổi
            OnPropertyChanged(nameof(Users));
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
            .Where(c => c.CarName != null && c.CarName.ToLower().Contains(search.ToLower())) // Loại bỏ các xe có Model là null
            .ToList();

        FilteredSearchCars.Clear();
        foreach (var car in filteredCars)
        {
            FilteredSearchCars.Add(car);
        }
    }

    public void CreateListingsByUserID(int userID)
    {
        // Xóa danh sách hiện tại
        FilteredCars.Clear();

        // Lọc danh sách Listings theo UserID
        var filteredListings = Listings
            .Where(listing => listing.UserID == userID)
            .ToList();

        // Tạo một danh sách Cars từ filteredListings
        var filteredCars = new ObservableCollection<Cars>();

        foreach (var listing in filteredListings)
        {
            // Tìm kiếm xe trong danh sách Cars tương ứng với CarID từ Listings
            var car = Cars.FirstOrDefault(c => c.ID == listing.CarID);
            if (car != null)
            {
                // Lấy ModelName từ CarModels dựa trên ModelID
                var carModel = CarModels.FirstOrDefault(cm => cm.ModelID == car.ModelID);
                if (carModel != null)
                {
                    car.ModelName = carModel.ModelName; // Gán ModelName vào đối tượng Car
                }
                filteredCars.Add(car); // Thêm xe vào danh sách kết quả
            }
        }

        // Cập nhật FilteredCars với danh sách xe đã lọc
        FilteredCars = filteredCars;
        OnPropertyChanged(nameof(FilteredCars)); // Cập nhật UI
    }

}