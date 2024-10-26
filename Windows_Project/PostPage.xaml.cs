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


        private void Post_News_Click(object sender, RoutedEventArgs e)
        {

        }

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

        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {

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

        private void ccomboboxCitySeller_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ccomboboxCitySeller.SelectedIndex == -1)
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
    }
}
