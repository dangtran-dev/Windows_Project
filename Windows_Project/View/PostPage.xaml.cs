using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System.ComponentModel;
using Microsoft.UI.Xaml.Media.Imaging;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using System.Reflection;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Provider;
using Windows_Project.Model;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Windows_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PostPage : Page
    {
        public MainViewModel ViewModel { get; set; }
        public Users  user { get; set; }
        //tạo biến boolean để kiểm tra việc nhập thông tin đầy đủ
        bool warning;
        // nhận dữ liệu người dùng đã đăng nhập từ trang chính
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            // Lấy dữ liệu được truyền vào từ trang trước
            user = e.Parameter as Users;
            DataContext = user;
            // Kiểm tra giá trị ban đầu của FullName
            if (!string.IsNullOrEmpty(user.FullName))
            {
                warningNameSeller.Visibility = Visibility.Collapsed;
            }
            else
            {
                warningNameSeller.Visibility = Visibility.Visible;
            }
            // Kiểm tra giá trị ban đầu của Phone
            if (!string.IsNullOrEmpty(user.Phone))
            {
                warningPhoneSeller.Visibility = Visibility.Collapsed;
            }
            else
            {
                warningPhoneSeller.Visibility = Visibility.Visible;
            }
            // Kiểm tra giá trị ban đầu của Address
            if (!string.IsNullOrEmpty(user.Address))
            {
                warningAddressSeller.Visibility = Visibility.Collapsed;
            }
            else
            {
                warningAddressSeller.Visibility = Visibility.Visible;
            }
        }
        private void UpdateWarningState()
        {
            // Kiểm tra từng cảnh báo và cập nhật hasWarning
            warning = warningManufacturerCar.Visibility == Visibility.Visible ||
                         warningModelCar.Visibility == Visibility.Visible ||
                         warningFuelCar.Visibility == Visibility.Visible ||
                         warningGearBoxCar.Visibility == Visibility.Visible ||
                         warningYearCar.Visibility == Visibility.Visible ||
                         warningPriceCar.Visibility == Visibility.Visible ||
                         warningTitleCar.Visibility == Visibility.Visible ||
                         warningDescriptionCar.Visibility == Visibility.Visible ||
                         warningNameSeller.Visibility == Visibility.Visible ||
                         warningPhoneSeller.Visibility == Visibility.Visible ||
                         warningAddressSeller.Visibility == Visibility.Visible ||
                         warningCitySeller.Visibility == Visibility.Visible ||
                         warningDistrictSeller.Visibility == Visibility.Visible;
        }
        public PostPage()
        {
            this.InitializeComponent();
            ViewModel = new MainViewModel();
            //đặt itemsoure cho các combobox lấy dữ liệu từ mockdao
            comboboxCitySeller.ItemsSource = ViewModel.Locations;
            comboboxCitySeller.DisplayMemberPath = "City";
            comboboxManufacturer.ItemsSource = ViewModel.Manufacturers;
            comboboxManufacturer.DisplayMemberPath = "ManufacturerName";
        }
        //kiểm tra chọn xe mới
        private void newCar_Checked(object sender, RoutedEventArgs e)
        {
            oldCar.IsChecked = false;
            warningConditionCar.Visibility = Visibility.Collapsed;
            textBox_Km.IsEnabled = false;
            text_Km.IsHitTestVisible = false;
            text_Km.Opacity = 0.5;
        }
        //kiểm tra chọn xe cũ
        private void oldCar_Checked(object sender, RoutedEventArgs e)
        {
            newCar.IsChecked = false;
            warningConditionCar.Visibility = Visibility.Collapsed;
            textBox_Km.IsEnabled = true;
            text_Km.IsHitTestVisible = true;
            text_Km.Opacity = 1;
        }
        //kiểm tra chọn trong nước
        private void internalCar_Checked(object sender, RoutedEventArgs e)
        {
            externalCar.IsChecked = false;
            warningOriginCar.Visibility = Visibility.Collapsed;
        }
        //kiểm tra chọn nhập khẩu
        private void externalCar_Checked(object sender, RoutedEventArgs e)
        {
            internalCar.IsChecked = false;
            warningOriginCar.Visibility = Visibility.Collapsed;
        }
        //xử lý sự kiện cho nút xem trước tin đăng
        private void Preview_Click(object sender, RoutedEventArgs e)
        {
            // lấy các dữ liệu từ các textbox, combobox, radiobutton để hiển thị lên popup
            var textYear = YearCarTextBox.Text;

            var selectedManufacturer = comboboxManufacturer.SelectedItem as Manufacturers;
            var textManufacturer = selectedManufacturer?.ManufacturerName;
            var textModel = comboboxModelCar.SelectedItem as string;

            var textPrice = texboxPrice.Text;
            var textStyle = (comboboxStyleCar.SelectedItem as ComboBoxItem)?.Content.ToString();
            var textKm = "";
            var textCondition = "";
            var textOrigin = "";

            var selectedCity = comboboxCitySeller.SelectedItem as Location;
            var textCity = selectedCity?.City;
            var textDistrict = comboboxDistrictSeller.SelectedItem as string;

            var textGearBox = (comboboxGearBoxCar.SelectedItem as ComboBoxItem)?.Content.ToString();
            var textFuel = (comboboxFuelCar.SelectedItem as ComboBoxItem)?.Content.ToString();
            var textDes = textDescription.Text;

            if (newCar.IsChecked == true)
            {
                textCondition = "Xe mới";
                textKm = "0 km";
            }
            else
            {
                textCondition = "Xe cũ";
                textKm = $"{textBox_Km.Text} km";
            }

            if (internalCar.IsChecked == true)
            {
                textOrigin = "Trong nước";
            }
            else
            {
                textOrigin = "Nhập khẩu";
            }

            //gán giá trị cho các textblock trong popup
            YearCarTextBlock.Text = $"{textYear}";
            CarNameTextBlock.Text = $"{textModel} {textYear}";
            CarPriceTextBlock.Text = $"{textPrice} triệu";
            StyleCarTextBlock.Text = $"{textStyle}";
            ConditionCarTextBlock.Text = $"{textCondition}";
            OriginCarTextBlock.Text = $"{textOrigin}";
            KmCarTextBlock.Text = $"{textKm}";
            CityCarTextBlock.Text = $"{textCity}";
            DistrictCarTextBlock.Text = $"{textDistrict}";
            GearBoxCarTextBlock.Text = $"{textGearBox}";
            FuelCarTextBlock.Text = $"{textFuel}";
            DescriptionCarTextBlock.Text = $"{textDes}";

            //vị tri hiển thị popup, làm mờ phần còn lại của trang khi popup hiển thị
            PreviewPopup.HorizontalOffset = 150;
            PreviewPopup.VerticalOffset = 200;
            PreviewPopup.IsOpen = true;
            AllPage.Opacity = 0.5;
        }

        // đóng popup
        private void ClosePopup_Click(object sender, RoutedEventArgs e)
        {
            PreviewPopup.IsOpen = false;
            AllPage.Opacity = 1;
        }

        //xử lý sự kiện chọn hãng xe
        private void comboboxManufacturer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboboxManufacturer.SelectedIndex == -1)
            {
                warningManufacturerCar.Visibility = Visibility.Visible;
            }
            else
            {
                warningManufacturerCar.Visibility = Visibility.Collapsed;
            }

            var selectedManufacturer = comboboxManufacturer.SelectedItem as Manufacturers;

            if (selectedManufacturer != null)
            {
                // nếu có nhiều model xuất hiện lại chỉ lấy 1 lần
                comboboxModelCar.ItemsSource = selectedManufacturer.Cars.Select(car => car.Model).Distinct().ToList();
            }
        }

        // xử lý sự kiện chọn dòng xe
        private void comboboxModelCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboboxModelCar.SelectedIndex == -1)
            {
                warningModelCar.Visibility = Visibility.Visible;
            }
            else
            {
                warningModelCar.Visibility = Visibility.Collapsed;
            }
        }

        // xử lý sự kiện chọn nhiên liệu
        private void comboboxFuelCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboboxFuelCar.SelectedIndex == -1)
            {
                warningFuelCar.Visibility = Visibility.Visible;
            }
            else
            {
                warningFuelCar.Visibility = Visibility.Collapsed;
            }
        }

        // xử lý sự kiện chọn loại hộp số
        private void comboboxGearBoxCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboboxGearBoxCar.SelectedIndex == -1)
            {
                warningGearBoxCar.Visibility = Visibility.Visible;
            }
            else
            {
                warningGearBoxCar.Visibility = Visibility.Collapsed;
            }
        }

        // xử lý sự kiện nhập năm sản xuất
        private void YearCarTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(YearCarTextBox.Text))
            {
                warningYearCar.Visibility = Visibility.Visible;
            }
            else
            {
                warningYearCar.Visibility = Visibility.Collapsed;
            }
        }

        // xử lý sự kiện nhập giá xe
        private void texboxPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(texboxPrice.Text))
            {
                warningPriceCar.Visibility = Visibility.Visible;
            }
            else
            {
                warningPriceCar.Visibility = Visibility.Collapsed;
            }
        }

        // xử lý sự kiện nhập tiêu đề
        private void texBoxTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(texBoxTitle.Text))
            {
                warningTitleCar.Visibility = Visibility.Visible;
            }
            else
            {
                warningTitleCar.Visibility = Visibility.Collapsed;
            }
        }

        // xử lý sự kiện nhập mô tả
        private void textDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(textDescription.Text))
            {
                warningDescriptionCar.Visibility = Visibility.Visible;
            }
            else
            {
                warningDescriptionCar.Visibility = Visibility.Collapsed;
            }
        }

        // xử lý sự kiện nhập tên người bán
        private void textboxNameSeller_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(textboxNameSeller.Text))
            {
                warningNameSeller.Visibility = Visibility.Visible;
            }
            else
            {
                warningNameSeller.Visibility = Visibility.Collapsed;
            }
        }

        // xử lý sự kiện nhập số điện thoại người bán
        private void textboxPhoneSeller_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(textboxPhoneSeller.Text))
            {
                warningPhoneSeller.Visibility = Visibility.Visible;
            }
            else
            {
                warningPhoneSeller.Visibility = Visibility.Collapsed;
            }
        }

        // xử lý sự kiện nhập địa chỉ người bán
        private void textboxAddressSeller_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(textboxAddressSeller.Text))
            {
                warningAddressSeller.Visibility = Visibility.Visible;
            }
            else
            {
                warningAddressSeller.Visibility = Visibility.Collapsed;
            }
        }

        // xử lý sự kiện chọn thành phố
        private void comboboxCitySeller_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboboxCitySeller.SelectedIndex == -1)
            {
                warningCitySeller.Visibility = Visibility.Visible;
            }
            else
            {
                warningCitySeller.Visibility = Visibility.Collapsed;
            }

            var selectedLocation = comboboxCitySeller.SelectedItem as Location;
            if (selectedLocation != null)
            {
                comboboxDistrictSeller.ItemsSource = selectedLocation.District.Select(district => district).ToList();
            }
        }

        // xử lý sự kiện chọn quận
        private void comboboxDistrictSeller_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboboxDistrictSeller.SelectedIndex == -1)
            {
                warningDistrictSeller.Visibility = Visibility.Visible;
            }
            else
            {
                warningDistrictSeller.Visibility = Visibility.Collapsed;
            }
        }

        // nút quay lại
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        // lưu thông tin xe vào file json
        private async Task SaveCar(Cars car)
        {
            string assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(assemblyLocation, "Cars.json");

            List<Cars> carList;

            if (File.Exists(filePath))
            {
                string existingJson = await File.ReadAllTextAsync(filePath);
                carList = JsonSerializer.Deserialize<List<Cars>>(existingJson) ?? new List<Cars>();
            }
            else
            {
                carList = new List<Cars>();
            }
            carList.Add(car);

            string newJson = JsonSerializer.Serialize(carList, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping // Hỗ trợ lưu tiếng Việt đúng
            });

            await File.WriteAllTextAsync(filePath, newJson);
        }

        // lưu thông tin bài đăng vào file json
        private async Task SaveListing(Listings listing)
        {
            string assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(assemblyLocation, "Listings.json");

            List<Listings> listingList;
            if (File.Exists(filePath))
            {
                string existingJson = await File.ReadAllTextAsync(filePath);
                listingList = JsonSerializer.Deserialize<List<Listings>>(existingJson) ?? new List<Listings>();
            }
            else
            {
                listingList = new List<Listings>();
            }
            listingList.Add(listing);
            string newJson = JsonSerializer.Serialize(listingList, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping // Hỗ trợ lưu tiếng Việt đúng
            });

            await File.WriteAllTextAsync(filePath, newJson);
        }

        // xử lý sự kiện đăng tin
        private async void PostButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateWarningState();
            if (warning)
            {
                var dialog1 = new ContentDialog()
                {
                    XamlRoot = this.Content.XamlRoot,
                    Content = "Vui lòng điền đầy đủ thông tin!",
                    CloseButtonText = "Đóng",
                };
                var result1 = await dialog1.ShowAsync();
                if (result1 == ContentDialogResult.None)
                {
                    return;
                }
            }
            string message = "Bạn có muốn đăng tin?";
            var dialog = new ContentDialog()
            {
                XamlRoot = this.Content.XamlRoot,
                Content = message,
                PrimaryButtonText = "Đồng ý",
                CloseButtonText = "Hủy",
            };
            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                var selectedManufacturer = comboboxManufacturer.SelectedItem as Manufacturers;
                var car = new Cars()
                {
                    // vì lúc này xe chưa được lưu nên trong data chỉ có X xe, khi lưu thì sẽ có X+1 xe nên ID là X+2
                    ID = ViewModel.Manufacturers.SelectMany(m => m.Cars).Count() + 2,
                    Year = int.Parse(YearCarTextBox.Text),
                    Manufacturer = selectedManufacturer?.ManufacturerName,
                    Model = comboboxModelCar.SelectedItem as string,
                    Price = texboxPrice.Text,
                    Picture = PathText.Text,
                    Condition = newCar.IsChecked == true ? "Xe mới" : "Xe cũ",
                    Style = (comboboxStyleCar.SelectedItem as ComboBoxItem)?.Content.ToString(),
                    Origin = internalCar.IsChecked == true ? "Trong nước" : "Nhập khẩu",
                    Mileage = newCar.IsChecked == true ? 0 : int.Parse(textBox_Km.Text),
                    City = (comboboxCitySeller.SelectedItem as Location)?.City,
                    District = comboboxDistrictSeller.SelectedItem as string,
                    FuelType = (comboboxFuelCar.SelectedItem as ComboBoxItem)?.Content.ToString(),
                    Gear = (comboboxGearBoxCar.SelectedItem as ComboBoxItem)?.Content.ToString(),
                };
                await SaveCar(car);
                
                // load lại mockdao để cập nhật danh sách xe
                ViewModel.Manufacturers = new MockDao().GetManufacturers();
                // lấy tổng số xe có trong mockdao (dù xe vừa thêm nằm ở đâu trong mockdao thì cũng lấy id ở vị trí cuối
                // để khớp với carID trong bài đăng)
                int carIndex = 0;
                for (int i=0;i<ViewModel.Manufacturers.Count;i++)
                {
                    for (int j = 0; j < ViewModel.Manufacturers[i].Cars.Count;j++)
                    {
                        carIndex++;
                    }
                }
                // lấy index của người bán trong mockdao
                int userIndex = ViewModel.Users.FindIndex(u => u.Username == user.Username);
                // lưu thông tin bài đăng
                var listing = new Listings()
                {
                    CarID = carIndex + 1,
                    UserID = userIndex + 1,
                    Status = texBoxTitle.Text,
                    Description = textDescription.Text,
                    CreateAt = DateTime.Now.ToString("dd/MM/yyyy")
                };
                await SaveListing(listing);

                var newdialog = new ContentDialog()
                {
                    XamlRoot = this.Content.XamlRoot,
                    Content = "Đăng tin thành công!",
                    CloseButtonText = "Đóng",
                };
                var result2 = await newdialog.ShowAsync();
                if (result2 == ContentDialogResult.None)
                {
                    ClosePopup_Click(sender, e);
                }
            }
        }

        //lưu ảnh vừa upload vào thư mục Assets của project
        private async Task SaveImage(StorageFile file)
        {
            var folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var newFolder = await folder.GetFolderAsync("Assets");
            var newFile = await file.CopyAsync(newFolder, file.Name, NameCollisionOption.ReplaceExisting);
        }

        //xử lý sự kiện upload ảnh
        private async void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            var openPicker = new Windows.Storage.Pickers.FileOpenPicker();

            var window = App.m_window;

            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);

            WinRT.Interop.InitializeWithWindow.Initialize(openPicker, hWnd);

            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");

            var file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                await SaveImage(file);
                UploadedImage.Visibility = Visibility.Visible;
                var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                var bitmapImage = new BitmapImage();
                bitmapImage.SetSource(stream);
                UploadedImage.Source = bitmapImage;
                PathText.Text = $"../../Assets/{file.Name}";
            }
            else
            {
                //do nothing
            }
        }
    }
}
