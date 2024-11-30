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
                // Cập nhật tiêu đề và lọc danh sách xe dựa trên tham số
                if (carType == "old")
                {
                    PageTitle.Text = "Ô TÔ CŨ";
                    ViewModel.FilterCarsByCondition("Xe cũ");
                }
                else if (carType == "new")
                {
                    PageTitle.Text = "Ô TÔ MỚI";
                    ViewModel.FilterCarsByCondition("Xe mới");
                }
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
            var selectedCar = e.ClickedItem as Cars;
            if (selectedCar != null)
            {
                // Chuyển đến trang chi tiết và truyền dữ liệu
                Frame.Navigate(typeof(CarDetailPage), selectedCar);
            }
        }
    }
}
