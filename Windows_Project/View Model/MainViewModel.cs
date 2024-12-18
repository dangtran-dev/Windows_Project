using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Windows_Project;
using Windows_Project.Service.DataAccess;
using Supabase;
using Supabase.Storage;
using Windows.Graphics.Imaging;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Storage.Streams;
using Microsoft.Data.SqlClient;

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
    // Thêm danh sách chứa thông tin xe và người bán ban đầu
    public ObservableCollection<CarWithUserItem> CarWithUserListOriginal { get; set; }
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
    // thêm thuộc tính upload status
    private string _uploadStatus;
    public string UploadStatus
    {
        get => _uploadStatus;
        set
        {
            _uploadStatus = value;
            OnPropertyChanged(nameof(UploadStatus));
        }
    }
    // Thêm danh sách xe lọc theo phương thức tìm kiếm
    public ObservableCollection<Cars> FilteredSearchCars { get; set; }
    // thêm danh sách ảnh đã upload
    public ObservableCollection<BitmapImage> UploadedImages { get; set; }
    // thêm danh sách các URL của ảnh đã upload lên supabase
    public List<string> UploadedImageURLs { get; set; }
    private Supabase.Client _supabaseClient;

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
        // Khởi tạo danh sách xe và người bán ban đầu
        CarWithUserListOriginal = new ObservableCollection<CarWithUserItem>();
        // khởi tạo danh sách ảnh đã upload
        UploadedImages = new ObservableCollection<BitmapImage>();
        // khởi tạo danh sách các URL của ảnh đã upload lên supabase
        UploadedImageURLs = new List<string>();
        _ = InitializeSupabaseClient();
    }
    public void SaveUserInfo(Users currentUser)
    {
        // Giả sử CurrentUser là người dùng hiện tại đang chỉnh sửa
        var user = Users.FirstOrDefault(u => u.Username == currentUser.Username);
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
                var query = "UPDATE Users SET FullName = @FullName, Address = @Address, Phone = @Phone, Email = @Email WHERE Username = @Username";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FullName", currentUser.FullName);
                    command.Parameters.AddWithValue("@Address", currentUser.Address);
                    command.Parameters.AddWithValue("@Phone", currentUser.Phone);
                    command.Parameters.AddWithValue("@Email", currentUser.Email);
                    command.Parameters.AddWithValue("@Username", currentUser.Username);
                    command.ExecuteNonQuery();
                }
            }

            // Thông báo cho UI biết dữ liệu đã thay đổi
            OnPropertyChanged(nameof(Users));
        }
    }

    // kết nối tới supabase
    private async Task InitializeSupabaseClient()
    {
        string url = "https://lxaqtnuuqvsscavvqcxs.supabase.co";
        string apiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Imx4YXF0bnV1cXZzc2NhdnZxY3hzIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MzIxMTcxNTUsImV4cCI6MjA0NzY5MzE1NX0.Im6wZliHFAomrPXXBRZMz9Gd5JUuG9gIkglcRtXmAiYe";
        _supabaseClient = new Supabase.Client(url, apiKey);
        await _supabaseClient.InitializeAsync();
    }
    // phương thức tạo một list danh sách xe với người bán ban đầu
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
                    foreach (var car in Cars)
                    {
                        if (car.ID == listing.CarID)
                        {
                            result = car;
                            break;
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
        // Lọc danh sách xe theo điều kiện
        if (condition != null)
        {
            newList = new ObservableCollection<CarWithUserItem>(
                 newList.Where(c => c.car.Condition == condition)
            );
        }
        CarWithUserListOriginal = newList;
        OnPropertyChanged(nameof(CarWithUserList));
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
    // Phương thức Upload ảnh
    public async Task<bool> UploadImagesAsync(Window window, ContentDialog dialog)
    {
        UploadStatus = "Đang tải ảnh lên...";
        // Kiểm tra nếu đã đạt giới hạn 6 ảnh
        if (UploadedImages.Count >= 6)
        {
            dialog.Title = "Giới hạn ảnh";
            dialog.Content = "Bạn đã tải lên đủ 6 ảnh. Không thể tải thêm.";
            await dialog.ShowAsync();
            return false;
        }

        // Tiếp tục mở picker chỉ khi chưa đủ 6 ảnh
        var openPicker = new FileOpenPicker
        {
            ViewMode = PickerViewMode.Thumbnail,
            SuggestedStartLocation = PickerLocationId.PicturesLibrary
        };
        openPicker.FileTypeFilter.Add(".jpg");
        openPicker.FileTypeFilter.Add(".jpeg");
        openPicker.FileTypeFilter.Add(".png");

        // Lấy handle của cửa sổ để liên kết picker
        var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
        WinRT.Interop.InitializeWithWindow.Initialize(openPicker, hWnd);

        // Chọn nhiều file
        var files = await openPicker.PickMultipleFilesAsync();

        // Nếu có file được chọn
        if (files != null && files.Count > 0)
        {
            // Kiểm tra số lượng ảnh có thể thêm
            int availableSlots = 6 - UploadedImages.Count;

            // Nếu số lượng file được chọn nhiều hơn số ảnh có thể tải lên
            if (files.Count > availableSlots)
            {
                dialog.Title = "Giới hạn ảnh";
                dialog.Content = $"Bạn chỉ có thể tải lên tối đa {availableSlots} ảnh nữa.";
                await dialog.ShowAsync();
                return false;
            }

            foreach (var file in files)
            {
                // Đọc file thành byte array
                byte[] fileBytes;
                using (var stream = await file.OpenStreamForReadAsync())
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await stream.CopyToAsync(memoryStream);
                        fileBytes = memoryStream.ToArray();
                    }
                }
                // tạo name duy nhất cho ảnh tránh việc upload ảnh trùng tên
                string fileName = (file.Name).ToString() + Guid.NewGuid().ToString();
                // Upload ảnh lên Supabase
                bool uploadResult = await UploadToSupabaseAsync(fileBytes, fileName);
                if (uploadResult)
                {
                    // Hiển thị ảnh sau khi tải lên thành công
                    var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                    var bitmapImage = new BitmapImage();
                    await bitmapImage.SetSourceAsync(stream);
                    UploadedImages.Add(bitmapImage);
                }
                else
                {
                    UploadStatus = "Có lỗi xảy ra khi tải ảnh lên!";
                    return false; // Thoát nếu có lỗi
                }
            }
            UploadStatus = "Tải ảnh lên thành công!";
            return true;
        }

        return false;
    }
    // Phương thức Upload ảnh lên Supabase
    private async Task<bool> UploadToSupabaseAsync(byte[] fileBytes, string fileName)
    {
        // Tạo kết nối với Supabase
        var supabaseClient = new Supabase.Client("https://lxaqtnuuqvsscavvqcxs.supabase.co",
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Imx4YXF0bnV1cXZzc2NhdnZxY3hzIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MzIxMTcxNTUsImV4cCI6MjA0NzY5MzE1NX0.Im6wZliHFAomrPXXBRZMz9Gd5JUuG9gIkglcRtXmAiY");
        var storageClient = supabaseClient.Storage;
        var bucket = storageClient.From("images");
        try
        {
            // Tải lên file
            var uploadResult = await bucket.Upload(fileBytes, fileName);
            if (!string.IsNullOrEmpty(uploadResult))
            {
                // Nếu không có thông báo lỗi (uploadResult là null hoặc empty), xử lý thành công
                var publicUrl = bucket.GetPublicUrl(fileName);
                BitmapImage bitmapImage = new BitmapImage(new Uri(publicUrl));
                Debug.WriteLine($"Uploaded image: {publicUrl}");
                UploadedImageURLs.Add(publicUrl);
                return true;
            }
            else
            {
                // Nếu uploadResult là thông báo lỗi
                Debug.WriteLine($"Error uploading image: {fileName}");
                return false;
            }
        }
        catch (Exception ex)
        {
            // Hiển thị thông báo lỗi
            Debug.WriteLine($"Error: {ex.Message}");
            return false;
        }
    }
    // phương thức lấy ManufactuterName từ ModelID của xe
    private string GetManufacturerName(int modelID)
    {
        foreach (var manufacturer in Manufacturers)
        {
            foreach (var car in manufacturer.Cars)
            {
                if (car.ModelID == modelID)
                {
                    return manufacturer.ManufacturerName;
                }
            }
        }
        return "";
    }
    // phương thức lấy ModelName từ ModelID của xe
    private string GetModelName(int modelID)
    {
        foreach (var manufacturer in Manufacturers)
        {
            foreach (var model in manufacturer.CarsModels)
            {
                if (model.ModelID == modelID)
                {
                    return model.ModelName;
                }
            }
        }
        return "";
    }
    // phương thức tìm kiếm xe theo điều kiện
    public void Search_Car_By_Filter(string manufacturer, string model, string year, string style, string minPrice, string maxPrice,
        string origin, string fuel, string gear, string city, string district)
    {
        var filteredLists = CarWithUserListOriginal
             .Where(c => c.car != null && (string.IsNullOrEmpty(manufacturer) || GetManufacturerName(c.car.ModelID) == manufacturer))
             .Where(c => c.car != null && (string.IsNullOrEmpty(model) || GetModelName(c.car.ModelID) == model))
             .Where(c => c.car != null && (string.IsNullOrEmpty(year) || c.car.Year.ToString() == year))
             .Where(c => c.car != null && (string.IsNullOrEmpty(style) || c.car.Style == style))
             .Where(c => c.car != null && (string.IsNullOrEmpty(minPrice) || c.car.Price >= long.Parse(minPrice) * 1000000))
             .Where(c => c.car != null && (string.IsNullOrEmpty(maxPrice) || c.car.Price <= long.Parse(maxPrice) * 1000000))
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


    public bool DeleteCarFromDatabase(int carID)
    {
        try
        {
            using (var connection = new SqlConnection("Server=localhost,1433;Database=demoshop;User Id=sa;Password=SqlServer@123;TrustServerCertificate=True;"))
            {
                connection.Open();

                //Lấy tất cả ListingID có CarID mà bạn muốn xóa
                var getListingIDsCommand = new SqlCommand("SELECT ListingID FROM Listings WHERE CarID = @CarID", connection);
                getListingIDsCommand.Parameters.AddWithValue("@CarID", carID);
                var listingIDs = new List<int>();

                using (var reader = getListingIDsCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listingIDs.Add(reader.GetInt32(0)); // Lưu ListingID vào danh sách
                    }
                }

                //Xóa các bản ghi trong bảng Favorites liên quan đến các ListingID
                foreach (var listingID in listingIDs)
                {
                    var deleteFavoritesCommand = new SqlCommand("DELETE FROM Favorites WHERE ListingID = @ListingID", connection);
                    deleteFavoritesCommand.Parameters.AddWithValue("@ListingID", listingID);
                    deleteFavoritesCommand.ExecuteNonQuery();
                }

                var command = new SqlCommand("DELETE FROM Cars WHERE CarID = @CarID", connection);
                command.Parameters.AddWithValue("@CarID", carID);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0; // Trả về true nếu xóa thành công
            }
        }
        catch (Exception ex)
        {
            // Log lỗi nếu cần
            Console.WriteLine(ex.Message);
            return false;
        }
    }
    public void DeleteCarFromFilteredList(Cars car)
    {

        bool check = DeleteCarFromDatabase(car.ID);
        if (check)
        {
            // Xóa khỏi danh sách FilteredCars
            if (FilteredCars.Contains(car))
            {
                FilteredCars.Remove(car);
            }

            // Xóa khỏi danh sách Cars chính (nếu cần xóa luôn)
            if (Cars.Contains(car))
            {
                Cars.Remove(car);
            }
        }

        // Gửi thông báo cập nhật giao diện
        OnPropertyChanged(nameof(FilteredCars));
    }
}