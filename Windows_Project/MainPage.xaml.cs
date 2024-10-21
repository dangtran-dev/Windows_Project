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

        private DispatcherTimer timer;
        public ObservableCollection<string> Pictures { get; set; }
        private bool isReversing = false; // Bi?n theo d�i tr?ng th�i ti?n ho?c l�i
        public MainPage()
        {
            this.InitializeComponent();
            UpdateLoginButtons();

            // Danh s�ch h�nh ?nh
            Pictures = new ObservableCollection<string>
            {
                "Assets/mazda3.jpg",
                "Assets/mercedes.jpg",
                "Assets/honda.jpg",
                "Assets/audi.jpg",
            };

            Gallery.ItemsSource = Pictures; // G�n danh s�ch h�nh ?nh v�o FlipView

            // Kh?i t?o timer v?i kho?ng 1 gi�y
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2.5); // M?i 1 gi�y
            timer.Tick += Timer_Tick; // G�n s? ki?n Timer_Tick cho timer
            timer.Start(); // B?t ??u timer
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

        // Ph??ng th?c Timer_Tick s? ???c g?i m?i gi�y
        private void Timer_Tick(object sender, object e)
        {
            // N?u ?ang kh�ng ch?y ng??c
            if (!isReversing)
            {
                // Ti?n t?i h�nh ti?p theo
                if (Gallery.SelectedIndex < Pictures.Count - 1)
                {
                    Gallery.SelectedIndex++;
                }
                else
                {
                    // ??n ?nh cu?i c�ng th� ??i chi?u
                    isReversing = true;
                    Gallery.SelectedIndex--;
                }
            }
            else
            {
                // ?ang ch?y ng??c
                if (Gallery.SelectedIndex > 0)
                {
                    Gallery.SelectedIndex--;
                }
                else
                {
                    // ??n ?nh ??u ti�n th� ??i chi?u
                    isReversing = false;
                    Gallery.SelectedIndex++;
                }
            }
        }

        private void OnCarOldButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void OnCarNewButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void OnPriceButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void OnSellCarButtonClick(object sender, RoutedEventArgs e)
        {

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

                    // Xử lý đăng nhập ở đây
                    string username = UsernameLogin.Text;
                    string password = PasswordLogin.Password;

                    // Kiểm tra thông tin đăng nhập
                    if (username == "admin" && password == "123")
                    {
                        isLoggedIn = true;
                        loggedInUser = username;

                        // Đổi nội dung của các nút "Đăng nhập" và "Đăng ký"
                        UpdateLoginButtons();

                        // Đóng Dialog đăng nhập
                        break;
                    }
                    else
                    {
                        Noti.Text = "Đăng nhập thất bại, xin thử lại.";
                        await failedDialog.ShowAsync();
                    }
                }
                else
                {
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
                // Hiển thị hộp thoại đăng nhập
                var result = await RegisterDialog.ShowAsync();

                // Kiểm tra kết quả khi người dùng nhấn nút
                if (result == ContentDialogResult.Primary)
                {
                    string username = UsernameRegister.Text;
                    string password = PasswordRegister.Password;
                    string repassword = RepasswordRegister.Password;

                    if(password == repassword && password != "")
                    {
                        break;
                    }
                    else
                    {
                        Noti.Text = "Đăng ký thất bại";
                        await failedDialog.ShowAsync();
                    }

                }
                else
                {
                    // Người dùng nhấn nút "Hủy"
                    break;
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

        private void onLogoutClick(object sender, RoutedEventArgs e)
        {
            isLoggedIn = false;
            UpdateLoginButtons();
        }

        //User click vao ca nhan de chon

    }
}