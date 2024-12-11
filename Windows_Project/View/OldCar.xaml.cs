using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    /// This class is used to display the old car page / new car page
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
            comboboxCitySeller.ItemsSource = ViewModel.Locations;
            comboboxCitySeller.DisplayMemberPath = "City";
            Select_Car_Company.ItemsSource = ViewModel.Manufacturers;
            Select_Car_Company.DisplayMemberPath = "ManufacturerName";
        }
        private void Select_Car_Company_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedManufacturer = Select_Car_Company.SelectedItem as Manufacturers;
            if (selectedManufacturer != null)
            {
                Select_Car_Model.ItemsSource = selectedManufacturer.Cars.Select(car => car.Model).Distinct().ToList();
            }
        }
        private void comboboxCitySeller_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedLocation = comboboxCitySeller.SelectedItem as Location;
            if (selectedLocation != null)
            {
                comboboxDistrictSeller.ItemsSource = selectedLocation.District.Select(district => district).ToList();
            }
        }
        private void internalCar_Checked(object sender, RoutedEventArgs e)
        {
            externalCar.IsChecked = false;
        }

        private void externalCar_Checked(object sender, RoutedEventArgs e)
        {
            internalCar.IsChecked = false;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is string parameter)
            {
                var args = parameter.Split('|'); // Phân tách chuỗi truyền vào

                string condition = args[0];
                string manufacturer = args.Length > 1 ? args[1] : null;
                string model = args.Length > 2 ? args[2] : null;

                // Lọc danh sách dựa trên các tham số
                if (condition == "Xe cũ")
                {
                    PageTitle.Text = "Ô TÔ CŨ";
                }
                else if (condition == "Xe mới")
                {
                    PageTitle.Text = "Ô TÔ MỚI";
                }
                ViewModel.CreateCarWithUserList(condition, manufacturer, model);
                ViewModel.CreateCarWithUserListOriginal(condition);
                // nếu không có kết quả nào phù hợp
                if (ViewModel.CarWithUserList.Count == 0)
                {
                    noResultTextBlock.Visibility = Visibility.Visible;
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

        private void Search_Car_Click(object sender, RoutedEventArgs e)
        {
            string manufactutrer = Select_Car_Company.SelectedItem != null ? ((Manufacturers)Select_Car_Company.SelectedItem).ManufacturerName : null;
            string model = Select_Car_Model.SelectedItem != null ? Select_Car_Model.SelectedItem.ToString() : null;
            string year = string.IsNullOrEmpty(Search_Year.Text) ? null : Search_Year.Text;

            var selectedStyleItem = comboboxStyleCar.SelectedItem as ComboBoxItem;
            string style = selectedStyleItem != null ? selectedStyleItem.Content.ToString() : null;

            string minPrice = string.IsNullOrEmpty(MinPrice.Text) ? null : MinPrice.Text;
            string maxPrice = string.IsNullOrEmpty(MaxPrice.Text) ? null : MaxPrice.Text;

            string origin = null;
            if (internalCar.IsChecked == true)
            {
                origin = "Trong nước";
            }
            else if (externalCar.IsChecked == true)
            {
                origin = "Nhập khẩu";
            }

            var selectedFuelItem = comboboxFuelCar.SelectedItem as ComboBoxItem;
            string fuel = selectedFuelItem != null ? selectedFuelItem.Content.ToString() : null;

            var selectedGearItem = comboboxGearBoxCar.SelectedItem as ComboBoxItem;
            string gear = selectedGearItem != null ? selectedGearItem.Content.ToString() : null;

            string city = comboboxCitySeller.SelectedItem != null ? ((Location)comboboxCitySeller.SelectedItem).City : null;
            string district = comboboxDistrictSeller.SelectedItem != null ? comboboxDistrictSeller.SelectedItem.ToString() : null;

            ViewModel.Search_Car_By_Filter(manufactutrer, model, year, style, minPrice, maxPrice, origin, fuel, gear, city, district);
            // nếu không có kết quả nào phù hợp
            if (ViewModel.CarWithUserList.Count == 0)
            {
                noResultTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                noResultTextBlock.Visibility = Visibility.Collapsed;
            }
            LoadPage(currentPage);
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Select_Car_Company.SelectedItem = null;
            Select_Car_Model.SelectedItem = null;
            Search_Year.Text = "";
            comboboxStyleCar.SelectedItem = null;
            MinPrice.Text = "";
            MaxPrice.Text = "";
            internalCar.IsChecked = false;
            externalCar.IsChecked = false;
            comboboxFuelCar.SelectedItem = null;
            comboboxGearBoxCar.SelectedItem = null;
            comboboxCitySeller.SelectedItem = null;
            comboboxDistrictSeller.SelectedItem = null;
        }
    }
}
