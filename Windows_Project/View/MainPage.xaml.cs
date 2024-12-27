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
using System.Collections.ObjectModel;
using Windows.Storage;
using Windows_Project.View;
using Windows_Project.Service.DataAccess;
using System.Threading.Tasks;
using System.Diagnostics;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Windows_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private bool isLoggedIn = false;
        private string loggedInUser = "";

        public MainViewModel ViewModel { get; set; }

        private DispatcherTimer timer;
        public ObservableCollection<string> Pictures { get; set; }
        private bool isReversing = false;

        // Tạo đối tượng SqlDao
        private readonly SqlDao _sqlDao = new SqlDao("Server=localhost,1433;Database=demoshop;User Id=sa;Password=SqlServer@123;TrustServerCertificate=True;");
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled; // khong tai lai trang khi quay lai MainPage

            ViewModel = new MainViewModel();

            Select_Car_Company.ItemsSource = ViewModel.Manufacturers;
            Select_Car_Company.DisplayMemberPath = "ManufacturerName";

            UpdateLoginButtons();

            // Danh sách hình ảnh
            Pictures = new ObservableCollection<string>
            {
                "../../Assets/mazda_bg.jpg",
                "../../Assets/mercedes_bg.jpg",
                "../../Assets/honda_bg.jpg",
                "../../Assets/audi_bg.jpg",
            };

            Gallery.ItemsSource = Pictures;

            // Khởi tạo timer với khoảng 1 giây
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2.5);
            timer.Tick += Timer_Tick;
            timer.Start();
        }


        //mo lai khi tat ung dung
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var localSettings = ApplicationData.Current.LocalSettings;

            if (localSettings.Values.ContainsKey("Username"))
            {
                UsernameLogin.Text = localSettings.Values["Username"].ToString();
            }

            if (localSettings.Values.ContainsKey("Password"))
            {
                PasswordLogin.Password = localSettings.Values["Password"].ToString(); // Lưu ý: Mật khẩu nên được mã hóa
            }

            // Tải trạng thái của checkbox
            if (localSettings.Values.ContainsKey("RememberMe"))
            {
                rememberCheckBox.IsChecked = (bool)localSettings.Values["RememberMe"];
            }
        }

        private void Timer_Tick(object sender, object e)
        {
            // Nếu đang không chạy ngược
            if (!isReversing)
            {
                // Tiến tới hình tiếp theo
                if (Gallery.SelectedIndex < Pictures.Count - 1)
                {
                    Gallery.SelectedIndex++;
                }
                else
                {
                    // Đến ảnh cuối cùng thì đổi chiều
                    isReversing = true;
                    Gallery.SelectedIndex--;
                }
            }
            else
            {
                // Đang chạy ngược
                if (Gallery.SelectedIndex > 0)
                {
                    Gallery.SelectedIndex--;
                }
                else
                {
                    // Đến ảnh đầu tiên thì đổi chiều
                    isReversing = false;
                    Gallery.SelectedIndex++;
                }
            }
        }
        private void SupportButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SupportPage));
        }
        private void OnCarOldButtonClick(object sender, RoutedEventArgs e)
        {
            // Lấy thông tin người dùng đã đăng nhập
            var user = ViewModel.Users.FirstOrDefault(u => u.Username == loggedInUser);

            string carCondition = "old";
            string selectedManufacturer = Select_Car_Company.SelectedItem != null ? ((Manufacturers)Select_Car_Company.SelectedItem).ManufacturerName : null;
            string selectedModel = Select_Car_Model.SelectedItem != null ? Select_Car_Model.SelectedItem.ToString() : null;
            string userName = user?.Username ?? string.Empty;
            string data = $"{carCondition}|{selectedManufacturer}|{selectedModel}|{userName}";

            //Frame.Navigate(typeof(OldCar), "old");
            Frame.Navigate(typeof(OldCar), data);
        }

        private void OnCarNewButtonClick(object sender, RoutedEventArgs e)
        {
            // Lấy thông tin người dùng đã đăng nhập
            var user = ViewModel.Users.FirstOrDefault(u => u.Username == loggedInUser);

            string carCondition = "new";
            string selectedManufacturer = Select_Car_Company.SelectedItem != null ? ((Manufacturers)Select_Car_Company.SelectedItem).ManufacturerName : null;
            string selectedModel = Select_Car_Model.SelectedItem != null ? Select_Car_Model.SelectedItem.ToString() : null;
            string userName = user?.Username ?? string.Empty;
            string data = $"{carCondition}|{selectedManufacturer}|{selectedModel}|{userName}";

            Frame.Navigate(typeof(OldCar), data);
        }

        private void OnPriceButtonClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PricePage), this.ViewModel);
        }

        private async void OnSellCarButtonClick(object sender, RoutedEventArgs e)
        {
            // nếu chưa đăng nhập thì yêu cầu đăng nhập
            if (!isLoggedIn)
            {
                failedDialog.Content = new TextBlock()
                {
                    Text = "Bạn cần đăng nhập/đăng kí để thực hiện chức năng này.",
                    TextWrapping = TextWrapping.WrapWholeWords
                };
                await failedDialog.ShowAsync();
                return;
            }
            // lấy thông tin người dùng đăng nhập
            var user = ViewModel.Users.FirstOrDefault(u => u.Username == loggedInUser);
            Frame.Navigate(typeof(PostPage), user);
        }

        private void OnComparisonButtonClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ComparisonPage));
        }

        private void OnReviewButtonClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ReviewPage));
        }

        private void OnNewsButtonClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NewsPage));
        }

        private async void onLoginButtonClick(object sender, RoutedEventArgs e)
            {
                while (true)
                {
                    // Hiển thị hộp thoại đăng nhập
                    var result = await LoginDialog.ShowAsync();

                    // Kiểm tra kết quả khi người dùng nhấn nút
                    if (result == ContentDialogResult.Primary)
                    {
                        string username = UsernameLogin.Text;
                        string password = PasswordLogin.Password;

                        // Lấy danh sách người dùng từ cơ sở dữ liệu
                        var users = await Task.Run(() => _sqlDao.GetUsers());

                        // Kiểm tra thông tin đăng nhập trong danh sách người dùng
                        var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

                        if (user != null)
                        {
                            // Nếu đăng nhập thành công
                            isLoggedIn = true;
                            loggedInUser = username;
                            UpdateLoginButtons();
                            Noti.Text = "Đăng nhập thành công!";
                            break; // Đóng Dialog
                        }
                        else
                        {
                            // Nếu đăng nhập thất bại
                            Noti.Text = "Đăng nhập thất bại, xin thử lại.";
                            await failedDialog.ShowAsync();
                        }
                    }
                    else
                    {
                        // Người dùng nhấn nút "Hủy"
                        // Người dùng nhấn nút "Hủy"
                        break;
                    }
                }
            }

        private void LoginDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var localSettings = ApplicationData.Current.LocalSettings;

            // Lưu thông tin đăng nhập và trạng thái của checkbox nếu được chọn
            if (rememberCheckBox.IsChecked == true)
            {
                // Lưu tên đăng nhập
                localSettings.Values["Username"] = UsernameLogin.Text;

                localSettings.Values["Password"] = PasswordLogin.Password; // Lưu mật khẩu

                localSettings.Values["RememberMe"] = true;  // Lưu trạng thái checkbox
            }
            else
            {
                // Nếu không nhớ, xóa thông tin đăng nhập
                localSettings.Values.Remove("Username");
                localSettings.Values.Remove("Password");
                // Xóa trạng thái checkbox
                localSettings.Values.Remove("RememberMe");
            }
        }

        private void LoginDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            // Xử lý khi nhấn nút "Hủy"
        }

        private void UpdateLoginButtons()
        {
            if (isLoggedIn)
            {
                UnLoginPanel.Visibility = Visibility.Collapsed;
                InfoName.Text = loggedInUser;
                LoginPanel.Visibility = Visibility.Visible;
            }
            else
            {
                UnLoginPanel.Visibility = Visibility.Visible;
                LoginPanel.Visibility = Visibility.Collapsed;
            }
        }

        private async void onRegisterButtonClick(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                var result = await RegisterDialog.ShowAsync();

                if (result == ContentDialogResult.Primary)
                {
                    string username = UsernameRegister.Text;
                    string password = PasswordRegister.Password;
                    string repassword = RepasswordRegister.Password;

                    if (password == repassword && !string.IsNullOrEmpty(password))
                    {
                        // Gọi phương thức SaveUserAsync từ Dao
                        bool isSaved = await _sqlDao.SaveUserAsync(username, password);
                        if (isSaved)
                        {
                            // Thêm người dùng mới vào danh sách Users của ViewModel
                            ViewModel.Users.Add(new Users
                            {
                                Username = username,
                                Password = password // (Nếu cần bảo mật, không nên lưu mật khẩu dưới dạng plaintext)
                            });
                            Noti.Text = "Đăng ký thành công";
                            await successDialog.ShowAsync();
                            break;
                        }
                        else
                        {
                            Noti.Text = "Lỗi khi lưu vào cơ sở dữ liệu";
                            await failedDialog.ShowAsync();
                        }
                    }
                    else
                    {
                        Noti.Text = "Đăng ký thất bại. Mật khẩu không khớp.";
                        await failedDialog.ShowAsync();
                    }
                }
                else
                {
                    break; // Người dùng nhấn nút "Hủy"
                }
            }
        }

        private void RegisterDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }


        private void RegisterDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }
        private void FailLogin_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }

        private void SuccessLogin_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }

        private void onLogoutClick(object sender, RoutedEventArgs e)
        {
            isLoggedIn = false;
            UpdateLoginButtons();
        }
        private void Old_Car_Checked(object sender, RoutedEventArgs e)
        {
            New_Car.IsChecked = false;
        }
        private void New_Car_Checked(object sender, RoutedEventArgs e)
        {
            Old_Car.IsChecked = false;
        }
        private void Select_Car_Company_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedManufacturer = Select_Car_Company.SelectedItem as Manufacturers;
            if (selectedManufacturer != null)
            {
                Select_Car_Model.ItemsSource = selectedManufacturer.CarsModels.Select(c => c.ModelName).Distinct().ToList();
            }
        }

        private async void Search_Car_Click(object sender, RoutedEventArgs e)
        {
            // Lấy thông tin người dùng đã đăng nhập
            var user = ViewModel.Users.FirstOrDefault(u => u.Username == loggedInUser);
            
            if (Old_Car.IsChecked == false && New_Car.IsChecked == false)
            {
                failedDialog.Content = new TextBlock()
                {
                    Text = "Vui lòng chọn đầy đủ điều kiện",
                    TextWrapping = TextWrapping.WrapWholeWords
                };
                await failedDialog.ShowAsync();
                return;
            }
            string carCondition = Old_Car.IsChecked == true ? "old" : "new";
            string selectedManufacturer = Select_Car_Company.SelectedItem != null ? ((Manufacturers)Select_Car_Company.SelectedItem).ManufacturerName : null;
            string selectedModel = Select_Car_Model.SelectedItem != null ? Select_Car_Model.SelectedItem.ToString() : null;
            string userName = user.Username;
            string data = $"{carCondition}|{selectedManufacturer}|{selectedModel}|{userName}";
            Frame.Navigate(typeof(OldCar), data);
        }
        private void onInfoButtonClick(object sender, RoutedEventArgs e)
        {
            // Lấy thông tin người dùng đã đăng nhập
            var user = ViewModel.Users.FirstOrDefault(u => u.Username == loggedInUser);

            if (user != null)
            {
                // Điều hướng đến InformationPage và truyền thông tin người dùng
                Frame.Navigate(typeof(InfomationPage), user);
            }
            else
            {
                // Nếu không tìm thấy người dùng, hiển thị thông báo
                ContentDialog dialog = new ContentDialog
                {
                    Title = "Lỗi",
                    Content = "Không tìm thấy thông tin người dùng.",
                    CloseButtonText = "OK",
                    XamlRoot = this.XamlRoot
                };
                _ = dialog.ShowAsync();
            }
        }

        private void FavoriteClickButton(object sender, RoutedEventArgs e)
        {
            // Lấy thông tin người dùng đã đăng nhập
            var user = ViewModel.Users.FirstOrDefault(u => u.Username == loggedInUser);
            if (user != null) {
                Frame.Navigate(typeof(FavoritePage), user);
            }
            else
            {
                ContentDialog dialog = new ContentDialog
                {
                    Title = "Lỗi",
                    Content = "Vui lòng đăng nhập để xem danh sách yêu thích!",
                    CloseButtonText = "OK",
                    XamlRoot = this.XamlRoot
                };
                _ = dialog.ShowAsync();
            }
        }
    }

        //User click vao ca nhan de chon
}