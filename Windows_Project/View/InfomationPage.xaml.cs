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
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Windows_Project.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InfomationPage : Page
    {
        private int currentPage = 1;
        private int itemsPerPage = 6;


        private Users CurrentUser;
        private List<Listings> UserListings;

        public List<Cars> Cars { get; set; }
        public MainViewModel ViewModel { get; set; }

        public InfomationPage()
        {
            this.InitializeComponent();
            ViewModel = new MainViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is Users user)
            {
                CurrentUser = user;
                DisplayPersonalInfo();

                // Lọc xe dựa trên UserID và truyền vào ViewModel
                ViewModel.CreateListingsByUserID(user.UserID);
            }
        }

        private void OnPersonalInfoClick(object sender, RoutedEventArgs e)
        {
            DisplayPersonalInfo();
        }

        private void OnListingsClick(object sender, RoutedEventArgs e)
        {
            DisplayListings();
        }

        private void DisplayPersonalInfo()
        {
            // Xóa nội dung cũ
            ContentGrid.Children.Clear();

            // Tạo Button và đăng ký sự kiện Click
            Button saveButton = new Button
            {
                Margin = new Thickness(10),
                HorizontalAlignment = HorizontalAlignment.Right,
                Content = "Lưu",
                Foreground = new SolidColorBrush(Microsoft.UI.Colors.White),
                Background = new SolidColorBrush(Microsoft.UI.Colors.Green),
            };
            saveButton.Click += OnSaveButtonClick; // Gắn sự kiện Click


            // Thêm StackPanel làm khung chính
            ContentGrid.Children.Add(new Border
            {
                BorderBrush = new SolidColorBrush(Microsoft.UI.Colors.Gray),
                BorderThickness = new Thickness(2),
                CornerRadius = new CornerRadius(10),
                Padding = new Thickness(20),
                Margin = new Thickness(20),
                Background = new SolidColorBrush(Microsoft.UI.Colors.WhiteSmoke),
                Child = new StackPanel
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Children =
                    {

                        new FontIcon
                        {
                            Glyph = "\uEA8C",
                            FontSize = 30,
                            Foreground = new SolidColorBrush(Microsoft.UI.Colors.DarkSlateBlue),
                            Margin = new Thickness(0, 0, 10, 10)
                        },

                        new TextBlock
                        {
                            Text = "Thông tin cá nhân",
                            FontSize = 30,
                            FontWeight = Microsoft.UI.Text.FontWeights.Bold,
                            Foreground = new SolidColorBrush(Microsoft.UI.Colors.DarkSlateBlue),
                            Margin = new Thickness(0, 0, 0, 20),
                            HorizontalAlignment = HorizontalAlignment.Center
                        },
                        new StackPanel
                        {
                            Margin = new Thickness(10),
                            Children =
                            {
                                CreateInfoRow("Tên đăng nhập:", CurrentUser.Username, "UsernameTextBox"),
                                CreateInfoRow("Họ tên:", CurrentUser.FullName, "FullNameTextBox"),
                                CreateInfoRow("Địa chỉ:", CurrentUser.Address, "AddressTextBox"),
                                CreateInfoRow("Số điện thoại:", CurrentUser.Phone, "PhoneTextBox"),
                                CreateInfoRow("Email:", CurrentUser.Email, "EmailTextBox")
                            }
                        },

                        saveButton // Thêm nút Lưu
                    }
                }
            });
        }

        // Hàm xử lý sự kiện Click của nút "Lưu"
        private void OnSaveButtonClick(object sender, RoutedEventArgs e)
        {
            // Cập nhật thông tin từ giao diện vào CurrentUser
            CurrentUser.Username = (ContentGrid.FindName("UsernameTextBox") as TextBox)?.Text ?? CurrentUser.Username;
            CurrentUser.FullName = (ContentGrid.FindName("FullNameTextBox") as TextBox)?.Text ?? CurrentUser.FullName;
            CurrentUser.Address = (ContentGrid.FindName("AddressTextBox") as TextBox)?.Text ?? CurrentUser.Address;
            CurrentUser.Phone = (ContentGrid.FindName("PhoneTextBox") as TextBox)?.Text ?? CurrentUser.Phone;
            CurrentUser.Email = (ContentGrid.FindName("EmailTextBox") as TextBox)?.Text ?? CurrentUser.Email;
            // Thực hiện logic lưu thông tin
            ViewModel.SaveUserInfo(CurrentUser);

            // Hiển thị thông báo thành công
            var dialog = new ContentDialog
            {
                Title = "Thông báo",
                Content = "Thông tin người dùng đã được lưu thành công!",
                CloseButtonText = "Đóng",
                XamlRoot = this.Content.XamlRoot
            };

            _ = dialog.ShowAsync();
        }

        // Hàm tạo một hàng thông tin với nhãn và giá trị
        private StackPanel CreateInfoRow(string label, string value, string textBoxName = null)
        {
            return new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 5, 0, 5),
                Children =
                {
                    new TextBlock
                    {
                        Text = label,
                        FontWeight = Microsoft.UI.Text.FontWeights.Bold,
                        Width = 150,
                        Foreground = new SolidColorBrush(Microsoft.UI.Colors.Black)
                    },
                    new TextBox
                    {
                        Text = value,
                        Width = 300,
                        Foreground = new SolidColorBrush(Microsoft.UI.Colors.Black),
                        TextWrapping = TextWrapping.Wrap,
                        Name = textBoxName
                    }
                }
            };
        }


        private void DisplayListings()
        {
            // Xóa nội dung cũ
            ContentGrid.Children.Clear();



            // Tính toán chỉ số bắt đầu và kết thúc của trang hiện tại
            int startIndex = (currentPage - 1) * itemsPerPage;
            var carsToDisplay = ViewModel.FilteredCars.Skip(startIndex).Take(itemsPerPage).ToList();
            int totalPages = (int)Math.Ceiling((double)ViewModel.FilteredCars.Count / itemsPerPage);

            // Tạo ListView và hiển thị danh sách xe
            ListView listView = new ListView();
            listView.ItemsSource = carsToDisplay;
            listView.ItemTemplate = (DataTemplate)this.Resources["ListingsTemplate"];
            ContentGrid.Children.Add(listView);

            // Thêm các nút phân trang (Previous, Next)
            StackPanel paginationPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(20)
            };

            // Nút Previous
            Button previousButton = new Button
            {
                Content = "Previous",
                HorizontalAlignment = HorizontalAlignment.Left,
                Width = 100,
                IsEnabled = currentPage > 1
            };
            previousButton.Click += PreviousPage_Click;

            //So trang/Total
            TextBlock numberPage = new TextBlock
            {
                Text = $"{currentPage}/{totalPages}",
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10),
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 16,
                FontWeight = Microsoft.UI.Text.FontWeights.Bold
            };

            // Nút Next
            Button nextButton = new Button
            {
                Content = "Next",
                HorizontalAlignment = HorizontalAlignment.Right,
                Width = 100,
                IsEnabled = currentPage < Math.Ceiling((double)ViewModel.FilteredCars.Count / itemsPerPage)
            };
            nextButton.Click += NextPage_Click;

            paginationPanel.Children.Add(previousButton);
            paginationPanel.Children.Add(numberPage);
            paginationPanel.Children.Add(nextButton);

            ContentGrid.Children.Add(paginationPanel);
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayListings(); // Hiển thị lại danh sách theo trang mới
            }
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)ViewModel.FilteredCars.Count / itemsPerPage);
            if (currentPage < totalPages)
            {
                currentPage++;
                DisplayListings(); // Hiển thị lại danh sách theo trang mới
            }
        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private void OnDeleteClick(object sender, RoutedEventArgs e)
        {
            // Lấy Button mà người dùng nhấn
            var button = sender as Button;

            // Lấy đối tượng Cars từ DataContext của Button
            var car = button?.DataContext as Cars;

            if (car != null)
            {
                ViewModel.DeleteCarFromFilteredList(car);
                DisplayListings(); // Làm mới giao diện
            }
        }
    }
}
