using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml.Media.Imaging;
using static Windows_Project.View.OldCar;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Windows_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CarDetailPage : Page
    {
        public CarWithUserItem ViewModel { get; set; }
        public MainViewModel MainViewModel { get; set; }

        public Users users { get; set; }
        public string FullAddress => $"{ViewModel.user.Address}, {ViewModel.car.District}, {ViewModel.car.City}";
        public CarDetailPage()
        {
            this.InitializeComponent();
            MainViewModel = new MainViewModel();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Lấy dữ liệu được truyền vào từ trang trước
            var parameter = e.Parameter as Tuple<CarWithUserItem, Users>;

            if (parameter != null)
            {
                // Gán dữ liệu từ parameter vào ViewModel
                var selectedCar = parameter.Item1;
                users = parameter.Item2;

                ViewModel = selectedCar;
                // Cập nhật DataContext nếu cần
                DataContext = ViewModel;

                // Kiểm tra số lượng hình ảnh của xe và hiển thị chúng
                if (selectedCar.car.CarImages.Count == 1)
                {
                    UniqueImage.Visibility = Visibility.Visible;
                }
                else
                {
                    for (int i = 0; i < 6; i++)
                    {
                        var imageControl = (Image)FindName($"Image{i + 1}l");
                        var placeholderControl = (Image)FindName($"PlaceholderImage{i + 1}");
                        if (i < selectedCar.car.CarImages.Count)
                        {
                            imageControl.Source = new BitmapImage(new Uri(selectedCar.car.CarImages[i].ImageURL));
                            imageControl.Visibility = Visibility.Collapsed;
                            if (placeholderControl != null)
                            {
                                placeholderControl.Visibility = Visibility.Visible;
                            }
                            imageControl.ImageOpened += (s, e) =>
                            {
                                if (placeholderControl != null)
                                {
                                    placeholderControl.Visibility = Visibility.Collapsed;
                                }
                                imageControl.Visibility = Visibility.Visible;
                            };
                        }
                        else
                        {
                            imageControl.Source = null;
                            imageControl.Visibility = Visibility.Collapsed;
                            if (placeholderControl != null)
                            {
                                placeholderControl.Visibility = Visibility.Collapsed;
                            }
                        }
                    }
                }
            }
            else
            {
                // Xử lý trường hợp không nhận được dữ liệu hợp lệ
                Debug.WriteLine("Không nhận được dữ liệu từ trang trước.");
            }
        }

        private void FavoriteClick(object sender, RoutedEventArgs e)
        {
            if (users != null)
            {
                var listingID = ViewModel.listing.ListingID;
                bool check = MainViewModel.checkFavoriteCar(users.UserID, listingID);
                if (check) {
                    MainViewModel.addFavoriteCar(users.UserID, listingID);

                    var dialog = new ContentDialog
                    {
                        Title = "Thông báo",
                        Content = "Lưu xe yêu thích thành công!",
                        CloseButtonText = "Đóng",
                        XamlRoot = this.Content.XamlRoot
                    };

                    _ = dialog.ShowAsync();
                }
                else
                {
                    var dialog = new ContentDialog
                    {
                        Title = "Thông báo",
                        Content = "Xe đã có trong danh sách xe yêu thích!",
                        CloseButtonText = "Đóng",
                        XamlRoot = this.Content.XamlRoot
                    };
                    _ = dialog.ShowAsync();
                }
                
            }
            else
            {
                var dialog = new ContentDialog
                {
                    Title = "Thông báo",
                    Content = "Vui lòng đăng nhập để thêm yêu thích xe!",
                    CloseButtonText = "Đóng",
                    XamlRoot = this.Content.XamlRoot
                };

                _ = dialog.ShowAsync();
            }

        }

        private async void ZaloButton_Click(object sender, RoutedEventArgs e)
        {
            string zaloUrl = $"https://zalo.me/{ViewModel.user.Phone}";

            // Mở trình duyệt hoặc ứng dụng Zalo
            var success = await Windows.System.Launcher.LaunchUriAsync(new Uri(zaloUrl));

            if (!success)
            {
                ContentDialog errorDialog = new ContentDialog
                {
                    XamlRoot = this.XamlRoot,
                    Title = "Lỗi",
                    Content = "Không thể mở Zalo. Vui lòng kiểm tra lại!",
                    CloseButtonText = "OK"
                };
                await errorDialog.ShowAsync();
            }
        }
    }
}
