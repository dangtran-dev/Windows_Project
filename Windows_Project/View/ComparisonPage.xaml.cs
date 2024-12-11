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
    public sealed partial class ComparisonPage : Page
    {
        public MainViewModel ViewModel { get; set; }
        public ComparisonPage()
        {
            this.InitializeComponent();
            ViewModel = new MainViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            SelectedVehicleNumber.Text = "Đã chọn so sánh " + ViewModel.SelectedCars.Count + " xe";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.FilterSearchCars(SearchBox.Text);
        }


        private void Delete_All_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedCars.Clear();
            SelectedVehicleNumber.Text = "Đã chọn so sánh " + ViewModel.SelectedCars.Count + " xe";
        }

        private async void CarListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCar = (Cars)((ListView)sender).SelectedItem;

            if (selectedCar == null)
            {
                return;
            }

            if (!ViewModel.SelectedCars.Contains(selectedCar))
            {
                ViewModel.SelectedCars.Add(selectedCar);
                SelectedVehicleNumber.Text = "Đã chọn so sánh " + ViewModel.SelectedCars.Count + " xe";
            }
            else
            {
                var dialog = new ContentDialog
                {
                    Title = "Thông báo",
                    Content = $"Xe {selectedCar.CarName} đã có trong danh sách so sánh.",
                    CloseButtonText = "Đóng",
                    XamlRoot = this.XamlRoot
                };
                await dialog.ShowAsync();
            }
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedCar = (Cars)((Button)sender).DataContext;
            ViewModel.SelectedCars.Remove(selectedCar);
            SelectedVehicleNumber.Text = "Đã chọn so sánh " + ViewModel.SelectedCars.Count + " xe";
        }

        private async void Compare_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedCars.Count < 2)
            {
                var dialog = new ContentDialog
                {
                    Title = "Thông báo",
                    Content = "Vui lòng chọn ít nhất 2 xe để so sánh",
                    CloseButtonText = "Đóng",
                    XamlRoot = this.XamlRoot
                };
                await dialog.ShowAsync();
            }
            else
            {
                Frame.Navigate(typeof(ComparisonResultPage), ViewModel.SelectedCars);
            }
        }
    }
}