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

namespace Windows_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CarPricePage : Page
    {
        public List<Cars> Cars { get; set; }
        private int currentPage = 1;
        private int itemsPerPage = 8;
        public CarPricePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is Manufacturers selectedManufacturer)
            {
                Cars = selectedManufacturer.Cars;
                ManufacturerNameTextBlock.Text = selectedManufacturer.ManufacturerName;

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
            int totalPages = (int)Math.Ceiling((double)Cars.Count / itemsPerPage);
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadPage(currentPage);
            }
        }

        private void LoadPage(int currentPage)
        {
            int startIndex = (currentPage - 1) * itemsPerPage;
            var carsToDisplay = Cars.Skip(startIndex).Take(itemsPerPage).ToList();
            PageNumberTextBlock.Text = $"Trang {currentPage}";
            CarsListGridView.ItemsSource = carsToDisplay;


        }

        private void UpdateNavigationButtons()
        {
            int totalPages = (int)Math.Ceiling((double)Cars.Count / itemsPerPage);
            PreviousPageButton.IsEnabled = currentPage > 1;
            NextPageButton.IsEnabled = currentPage < totalPages;
        }

        private void MainImage_ImageOpened(object sender, RoutedEventArgs e)
        {
            var mainImage = sender as Image;
            if (mainImage != null)
            {
                var parentGrid = mainImage.Parent as Grid;
                if (parentGrid != null)
                {
                    var placeholderImage = parentGrid.FindName("PlaceholderImage") as Image;
                    if (placeholderImage != null)
                    {
                        placeholderImage.Visibility = Visibility.Collapsed;
                    }
                    var MainImage = parentGrid.FindName("MainImage") as Image;
                    if (MainImage != null)
                    {
                        MainImage.Visibility = Visibility.Visible;
                    }
                }
            }
        }
    }
}
