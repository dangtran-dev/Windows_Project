using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows_Project.Service.DataAccess;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Windows_Project.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PostPage : Page
    {
        public MainViewModel ViewModel { get; set; }
        public Users user { get; set; }
        //tạo biến boolean để kiểm tra việc nhập thông tin đầy đủ
        bool warning;
        // Tạo đối tượng SqlDao
        private readonly SqlDao _sqlDao = new SqlDao("Server=localhost,1433;Database=demoshop;User Id=sa;Password=SqlServer@123;TrustServerCertificate=True;");
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
                textboxNameSeller.Text = user.FullName;
                warningNameSeller.Visibility = Visibility.Collapsed;
            }
            else
            {
                warningNameSeller.Visibility = Visibility.Visible;
            }
            // Kiểm tra giá trị ban đầu của Phone
            if (!string.IsNullOrEmpty(user.Phone))
            {
                textboxPhoneSeller.Text = user.Phone;
                warningPhoneSeller.Visibility = Visibility.Collapsed;
            }
            else
            {
                warningPhoneSeller.Visibility = Visibility.Visible;
            }
            // Kiểm tra giá trị ban đầu của Address
            if (!string.IsNullOrEmpty(user.Address))
            {
                textboxAddressSeller.Text = user.Address;
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
                comboboxModelCar.ItemsSource = selectedManufacturer.CarsModels.Select(c => c.ModelName).Distinct().ToList();
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
        //xử lý sự kiện cho nút xem trước tin đăng
        private async void Preview_Click(object sender, RoutedEventArgs e)
        {

            UpdateWarningState();
            if (warning)
            {
                var dialog = new ContentDialog()
                {
                    XamlRoot = this.Content.XamlRoot,
                    Content = "Vui lòng điền đầy đủ thông tin!",
                    CloseButtonText = "Đóng",
                };
                var result = await dialog.ShowAsync();
                if (result == ContentDialogResult.None)
                {
                    return;
                }
            }
            UpdateImagePreview();
            if (ViewModel.UploadedImages.Count < 1)
            {
                var dialog = new ContentDialog()
                {
                    XamlRoot = this.Content.XamlRoot,
                    Content = "Vui lòng tải lên ít nhất 1 ảnh!",
                    CloseButtonText = "OK",
                };
                await dialog.ShowAsync();
                return;
            }
            // lấy các dữ liệu từ các textbox, combobox, radiobutton để hiển thị lên popup
            var textYear = YearCarTextBox.Text;
            // Kiểm tra điều kiện cho textYear
            if (!int.TryParse(textYear, out _))
            {
                var dialog = new ContentDialog()
                {
                    XamlRoot = this.Content.XamlRoot,
                    Content = "Năm sản xuất phải là số!",
                    CloseButtonText = "Đóng",
                };
                await dialog.ShowAsync();
                return;
            }

            var selectedManufacturer = comboboxManufacturer.SelectedItem as Manufacturers;
            var textManufacturer = selectedManufacturer?.ManufacturerName;
            var textModel = comboboxModelCar.SelectedItem as string;

            var textPrice = texboxPrice.Text;
            // Kiểm tra điều kiện cho textPrice
            if (!int.TryParse(textPrice, out _))
            {
                var dialog = new ContentDialog()
                {
                    XamlRoot = this.Content.XamlRoot,
                    Content = "Giá xe phải là số!",
                    CloseButtonText = "Đóng",
                };
                await dialog.ShowAsync();
                return;
            }
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
                textKm = textBox_Km.Text;
                // Kiểm tra điều kiện cho textKm (chỉ khi xe cũ)
                if (!int.TryParse(textKm, out _))
                {
                    var dialog = new ContentDialog()
                    {
                        XamlRoot = this.Content.XamlRoot,
                        Content = "Số km đã đi phải là số!",
                        CloseButtonText = "Đóng",
                    };
                    await dialog.ShowAsync();
                    return;
                }
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
            CarNameTextBlock.Text = $"{textManufacturer} {textModel} {textYear}";
            if (int.Parse(texboxPrice.Text) < 1000)
            {
                CarPriceTextBlock.Text = $"{textPrice} triệu VNĐ";
            }
            else
            {
                float price = int.Parse(texboxPrice.Text) / 1000;
                textPrice = price.ToString();
                CarPriceTextBlock.Text = $"{textPrice} tỷ VNĐ";
            }
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
            PreviewPopup.HorizontalOffset = 100;
            PreviewPopup.VerticalOffset = 100;
            PreviewPopup.IsOpen = true;
            AllPage.Opacity = 0.5;
        }
        // đóng popup
        private void ClosePopup_Click(object sender, RoutedEventArgs e)
        {
            PreviewPopup.IsOpen = false;
            AllPage.Opacity = 1;
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
            if (ViewModel.UploadedImages.Count < 1)
            {
                var dialog2 = new ContentDialog()
                {
                    XamlRoot = this.Content.XamlRoot,
                    Content = "Vui lòng tải lên ít nhất 1 ảnh!",
                    CloseButtonText = "OK",
                };
                await dialog2.ShowAsync();
                return;
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
                // lấy các dữ liệu từ các textbox, combobox, radiobutton để lưu vào cơ sở dữ liệu
                var selectedManufacturer = comboboxManufacturer.SelectedItem as Manufacturers;
                var selectedCity = comboboxCitySeller.SelectedItem as Location;
                var car = new Cars()
                {
                    ModelID = selectedManufacturer.CarsModels.FirstOrDefault(c => c.ModelName == comboboxModelCar.SelectedItem.ToString()).ModelID,
                    CarName = $"{selectedManufacturer.ManufacturerName} {comboboxModelCar.SelectedItem.ToString()} {YearCarTextBox.Text.Trim()}",
                    Year = int.Parse(YearCarTextBox.Text.Trim()),
                    Style = (comboboxStyleCar.SelectedItem as ComboBoxItem)?.Content.ToString(),
                    Condition = newCar.IsChecked == true ? "Xe mới" : "Xe cũ",
                    Origin = internalCar.IsChecked == true ? "Trong nước" : "Nhập khẩu",
                    Mileage = textBox_Km.IsEnabled == true ? decimal.Parse(textBox_Km.Text.Trim()) : 0,
                    Gear = (comboboxGearBoxCar.SelectedItem as ComboBoxItem)?.Content.ToString(),
                    FuelType = (comboboxFuelCar.SelectedItem as ComboBoxItem)?.Content.ToString(),
                    Price = decimal.Parse(texboxPrice.Text.Trim()) *1000000,
                    City = (comboboxCitySeller.SelectedItem as Location)?.City,
                    District = comboboxDistrictSeller.SelectedItem as string,
                };
                bool isSavedCar = await _sqlDao.SaveCarAsync(car);
                if (isSavedCar)
                {
                    var listing = new Listings()
                    {
                        UserID = user.UserID,
                        CarID = ViewModel.Cars.Count + 1,
                        Status = texBoxTitle.Text.Trim(),
                        Description = textDescription.Text.Trim(),
                        DatePosted = DateTime.Now,
                    };
                    bool isSavedListing = await _sqlDao.SaveListingAsync(listing);
                    bool isSavedCarImage = false;
                    foreach (var url in ViewModel.UploadedImageURLs)
                    {
                        var image = new CarImages()
                        {
                            CarID = ViewModel.Cars.Count + 1,
                            ImageURL = url,
                        };
                        isSavedCarImage = await _sqlDao.SaveCarImagesAsync(image);
                    }
                    var userChange = new Users()
                    {
                        UserID = user.UserID,
                        FullName = textboxNameSeller.Text.Trim(),
                        Phone = textboxPhoneSeller.Text.Trim(),
                        Address = textboxAddressSeller.Text.Trim(),
                    };
                    bool isUpdatedUser = await _sqlDao.UpdateUserAsync(userChange);
                    if (isSavedListing && isSavedCarImage && isUpdatedUser)
                    {
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
                    else
                    {
                        var faildialog = new ContentDialog()
                        {
                            XamlRoot = this.Content.XamlRoot,
                            Content = "Đăng tin thất bại!",
                            CloseButtonText = "Đóng",
                        };
                        await faildialog.ShowAsync();
                    }
                }
            }
        }
        // nút upload ảnh
        private async void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            // Tạo một ContentDialog để thông báo
            var dialog = new ContentDialog
            {
                XamlRoot = this.Content.XamlRoot,
                CloseButtonText = "OK"
            };

            // Gọi phương thức UploadImagesAsync từ ViewModel
            bool success = await ViewModel.UploadImagesAsync(App.m_window, dialog);
            // Nếu tải ảnh thành công, cập nhật giao diện
            if (success)
            {
                UpdateImageContainer();
            }
        }
        // nút xóa ảnh đã upload
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Lấy index của ảnh cần xóa
            var index = int.Parse(((Button)sender).Tag.ToString());
            // Xóa ảnh khỏi danh sách
            ViewModel.UploadedImages.RemoveAt(index);
            // xóa url ảnh khỏi danh sách
            ViewModel.UploadedImageURLs.RemoveAt(index);
            // Cập nhật giao diện
            UpdateImageContainer();
        }
        // phương thức cập nhật giao diện ảnh đã tải lên
        private void UpdateImageContainer()
        {
            // Hiển thị ImageContainer nếu có ảnh
            ImageContainer.Visibility = ViewModel.UploadedImages.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
            // Cập nhật từng Image trong ImageContainer
            for (int i = 0; i < 6; i++)
            {
                var imageControl = (Image)FindName($"Image{i + 1}");
                var containerControl = (Grid)FindName($"Container{i + 1}");

                if (i < ViewModel.UploadedImages.Count)
                {
                    imageControl.Source = ViewModel.UploadedImages[i];
                    containerControl.Visibility = Visibility.Visible;
                }
                else
                {
                    imageControl.Source = null;
                    containerControl.Visibility = Visibility.Collapsed;
                }
            }
        }
        // phương thức cập nhật giao diện ảnh xem trước
        private void UpdateImagePreview()
        {
            // reset lại danh sách ảnh
            for (int i = 0; i < 6; i++)
            {
                var imageControl = (Image)FindName($"Image{i + 1}p");
                imageControl.Source = null;
                imageControl.Visibility = Visibility.Collapsed;
            }
            for (int i = 0; i < ViewModel.UploadedImages.Count; i++)
            {
                var imageControl = (Image)FindName($"Image{i + 1}p");

                if (i < ViewModel.UploadedImages.Count)
                {
                    // Cập nhật ảnh vào Image control và thay đổi Visibility thành Visible
                    imageControl.Source = ViewModel.UploadedImages[i];
                    imageControl.Visibility = Visibility.Visible;
                }
                else
                {
                    // Nếu không còn ảnh, ẩn Image control
                    imageControl.Source = null;
                    imageControl.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
