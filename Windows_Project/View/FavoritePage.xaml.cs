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
    public sealed partial class FavoritePage : Page
    {
        private int currentPage = 1;
        private int itemsPerPage = 5;

        private Users CurrentUser;
        public MainViewModel ViewModel { get; set; }
        public FavoritePage()
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
                // Lọc xe dựa trên UserID và truyền vào ViewModel
                ViewModel.CreateFavoritesByUserID(user.UserID);

                // Tải trang đầu tiên
                currentPage = 1;
                LoadPagedCars();

            }
        }

        private void UpdatePageInfo()
        {
            int totalPages = (int)Math.Ceiling((double)ViewModel.FilteredCars.Count / itemsPerPage);
            PageInfoTextBlock.Text = $"{currentPage}/{totalPages}";

            // Kiểm tra để vô hiệu hóa nút nếu không thể bấm
            PrevButton.IsEnabled = currentPage > 1;
            NextButton.IsEnabled = currentPage < totalPages;
        }

        public void LoadPagedCars() 
        {
            // Tính toán chỉ số bắt đầu và kết thúc của trang hiện tại
            int startIndex = (currentPage - 1) * itemsPerPage;
            var carsToDisplay = ViewModel.FilteredCars.Skip(startIndex).Take(itemsPerPage).ToList();

            CarListView.ItemsSource = carsToDisplay;
            // Cập nhật thông tin trang
            UpdatePageInfo();
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPagedCars();
            }
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage * itemsPerPage < ViewModel.FilteredCars.Count)
            {
                currentPage++;
                LoadPagedCars();
            }
        }

        private void OnDeleteClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var favoriteCar = button?.DataContext as Cars; // Giả sử Cars là đối tượng xe yêu thích

            if (favoriteCar != null)
            {
                ViewModel.deleteFavoriteCar(favoriteCar.ID, CurrentUser.UserID);

                // Cập nhật lại danh sách xe yêu thích sau khi xóa
                LoadPagedCars();
            }
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private void OnCarItemClick(object sender, ItemClickEventArgs e)
        {
            //var selectedCar = e.ClickedItem as Cars;
            //if (selectedCar != null)
            //{
            //    // Chuyển đến trang chi tiết và truyền dữ liệu
            //    Frame.Navigate(typeof(CarDetailPage), selectedCar);
            //}
        }
    }
}
