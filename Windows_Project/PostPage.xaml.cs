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
using System.ComponentModel;
using Microsoft.UI.Xaml.Media.Imaging;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using System.Reflection;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Windows_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PostPage : Page, INotifyPropertyChanged
    {
        public class DashboardViewModel
        {
            public IsExpanderExpaned Current1 { get; set; }
            public IsExpanderExpaned Current2 { get; set; }
            public IsExpanderExpaned Current3 { get; set; }
        }
        public DashboardViewModel ViewModel { get; set; }

        public PostPage()
        {
            this.InitializeComponent();
            ViewModel = new DashboardViewModel()
            {
                Current1 = new IsExpanderExpaned()
                {
                    isExpanderExpanded = true,
                    toggleText = "Thu gọn",
                },
                Current2 = new IsExpanderExpaned()
                {
                    isExpanderExpanded = true,
                    toggleText = "Thu gọn",
                },
                Current3 = new IsExpanderExpaned()
                {
                    isExpanderExpanded = true,
                    toggleText = "Thu gọn",
                }
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void newCar_Checked(object sender, RoutedEventArgs e)
        {
            oldCar.IsChecked = false;
            warningConditionCar.Visibility = Visibility.Collapsed;
            textBox_Km.IsEnabled = false;
            text_Km.IsHitTestVisible = false;
            text_Km.Opacity = 0.5;
        }

        private void oldCar_Checked(object sender, RoutedEventArgs e)
        {
            newCar.IsChecked = false;
            warningConditionCar.Visibility = Visibility.Collapsed;
            textBox_Km.IsEnabled = true;
            text_Km.IsHitTestVisible = true;
            text_Km.Opacity = 1;
        }

        private void internalCar_Checked(object sender, RoutedEventArgs e)
        {
            externalCar.IsChecked = false;
            warningOriginCar.Visibility = Visibility.Collapsed;
        }

        private void externalCar_Checked(object sender, RoutedEventArgs e)
        {
            internalCar.IsChecked = false;
            warningOriginCar.Visibility = Visibility.Collapsed;
        }

        private void Preview_Click(object sender, RoutedEventArgs e)
        {
            var textYear = YearCarTextBox.Text;
            var selectedManufacturer = (comboboxManufacturer.SelectedItem as ComboBoxItem)?.Content.ToString();
            var selectedModel = (comboboxModelCar.SelectedItem as ComboBoxItem)?.Content.ToString();
            var textPrice = texboxPrice.Text;
            var textStyle = (comboboxStyleCar.SelectedItem as ComboBoxItem)?.Content.ToString();
            var textKm = "";
            var textCondition = "";
            var textOrigin = "";
            var textCity = (comboboxCitySeller.SelectedItem as ComboBoxItem)?.Content.ToString();
            var textDistrict = (comboboxDistrictSeller.SelectedItem as ComboBoxItem)?.Content.ToString();
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

            YearCarTextBlock.Text = $"{textYear}";
            CarNameTextBlock.Text = $"{selectedManufacturer} {selectedModel}";
            CarPriceTextBlock.Text = $"{textPrice} triệu";
            StyleCarTextBlock.Text = $"{textStyle}";
            ConditionCarTextBlock.Text = $"{textCondition}";
            OriginCarTextBlock.Text = $"{textOrigin}";
            KmCarTextBlock.Text = $"{textKm}";
            CityCarTextBlock.Text = $"{textCity}";
            DistrictCarTextBlock.Text = $"{textDistrict}";
            GearBoxCarTextBlock.Text = $"{textGearBox}";
            FuelCarTextBlock.Text = $"{textFuel}";
            DescriptionCarTextBlock.Text = $"{textDes}";

            PreviewPopup.HorizontalOffset = 150;
            PreviewPopup.VerticalOffset = 200;
            PreviewPopup.IsOpen = true;
            AllPage.Opacity = 0.5;
        }

        private void ClosePopup_Click(object sender, RoutedEventArgs e)
        {
            PreviewPopup.IsOpen = false;
            AllPage.Opacity = 1;
        }

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
        }

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
        }

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

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private async Task SaveCar(Cars car)
        {
            string assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(assemblyLocation, "Cars.json");

            List<Cars> carList;

            if (File.Exists(filePath))
            {
                string existingJson = await File.ReadAllTextAsync(filePath);
                carList = JsonSerializer.Deserialize<List<Cars>>(existingJson) ?? new List<Cars>();
            }
            else
            {
                carList = new List<Cars>();
            }
            carList.Add(car);

            string newJson = JsonSerializer.Serialize(carList, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(filePath, newJson);
        }

        private async void PostButton_Click(object sender, RoutedEventArgs e)
        {
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
                var car = new Cars()
                {
                    Year = YearCarTextBox.Text,
                    Manufacturer = (comboboxManufacturer.SelectedItem as ComboBoxItem)?.Content.ToString(),
                    Model = (comboboxModelCar.SelectedItem as ComboBoxItem)?.Content.ToString(),
                    Price = texboxPrice.Text,
                    Picture = "",
                };
                await SaveCar(car);
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
        }
    }
}
