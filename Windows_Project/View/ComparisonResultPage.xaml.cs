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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Windows_Project.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ComparisonResultPage : Page
    {
        public MainViewModel ViewModel { get; set; }
        public ObservableCollection<String> TitleList { get; set; } = new ObservableCollection<String>();
        public ComparisonResultPage()
        {
            this.InitializeComponent();
            ViewModel = new MainViewModel();

            TitleList.Add("Giá xe");
            TitleList.Add("Đời xe");
            TitleList.Add("Xuất xứ");
            TitleList.Add("Dáng xe");
            TitleList.Add("Hộp số");

            this.DataContext = this;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var selectedCars = e.Parameter as ObservableCollection<Cars>;
            if (selectedCars != null)
            {
                ViewModel.SelectedCars.Clear();
                foreach (var car in selectedCars)
                {
                    ViewModel.SelectedCars.Add(car);
                }
                SelectedVehicleNumber.Text = ViewModel.SelectedCars.Count + " xe đã được so sánh";
            }
            else
            {
                // Xử lý nếu không có xe nào được truyền đến
                var dialog = new ContentDialog
                {
                    Title = "Thông báo",
                    Content = "Không có xe nào được chọn để so sánh.",
                    CloseButtonText = "Đóng",
                    XamlRoot = this.XamlRoot
                };
                await dialog.ShowAsync();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private async void Add_Car_Click(object sender, RoutedEventArgs e)
        {
            await SearchArea.ShowAsync();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = "";
            SearchArea.Hide();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.FilterSearchCars(SearchBox.Text);
        }

        private void CarListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCar = (Cars)((ListView)sender).SelectedItem;
            if (selectedCar != null)
            {
                // Kiểm tra trùng lặp theo Id (hoặc thuộc tính duy nhất)
                if (!ViewModel.SelectedCars.Any(c => c.CarName == selectedCar.CarName))
                {
                    ViewModel.SelectedCars.Add(selectedCar);
                    SelectedVehicleNumber.Text = ViewModel.SelectedCars.Count + " xe đã được so sánh";
                }
            }
        }
    }
}