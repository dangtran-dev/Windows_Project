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
    public sealed partial class OldCar : Page
    {
        private int currentPage = 1;
        private int itemsPerPage = 5;

        public List<Cars> Cars { get; set; }

        public MainViewModel ViewModel { get; set; }

        public OldCar()
        {
            this.InitializeComponent();
            ViewModel = new MainViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is string carType)
            {
                // Lọc danh sách dựa trên tham số
                if (carType == "old")
                {
                    PageTitle.Text = "Ô TÔ CŨ";
                    ViewModel.CreateCarWithUserList("Xe cũ");
                }
                else if (carType == "new")
                {
                    PageTitle.Text = "Ô TÔ MỚI";
                    ViewModel.CreateCarWithUserList("Xe mới");
                }

                // Bắt đầu phân trang từ trang đầu tiên
                currentPage = 1;
                LoadPage(currentPage);
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
            // Lấy thông tin của ô tô được chọn
            var selectedCar = e.ClickedItem as CarWithUserItem;
            if (selectedCar != null)
            {
                // Chuyển đến trang chi tiết và truyền dữ liệu
                Frame.Navigate(typeof(CarDetailPage), selectedCar);
            }
        }


        private void LoadPage(int page)
        {
            int startIndex = (page - 1) * itemsPerPage;
            var carsToDisplay = ViewModel.CarWithUserList.Skip(startIndex).Take(itemsPerPage).ToList();

            PageNumberTextBlock.Text = $"Trang {page}";

            CarListView.ItemsSource = carsToDisplay;


            UpdateNavigationButtons();
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPage(currentPage);
            }
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)ViewModel.CarWithUserList.Count / itemsPerPage);
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadPage(currentPage);
            }
        }

        private void UpdateNavigationButtons()
        {
            int totalPages = (int)Math.Ceiling((double)ViewModel.CarWithUserList.Count / itemsPerPage);
            PreviousPageButton.IsEnabled = currentPage > 1;
            NextPageButton.IsEnabled = currentPage < totalPages;
        }
    }
}
