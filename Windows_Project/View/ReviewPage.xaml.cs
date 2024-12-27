using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
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
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReviewPage : Page
    {
        private int currentPage = 1;
        private int itemsPerPage = 6;
        public MainViewModel ViewModel { get; set; }
        public ReviewPage()
        {
            this.InitializeComponent();
            ViewModel = new MainViewModel();
            Select_Car_Company.ItemsSource = ViewModel.Manufacturers;
            Select_Car_Company.DisplayMemberPath = "ManufacturerName";
            LoadPage(currentPage);
        }
        private void Select_Car_Company_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedManufacturer = Select_Car_Company.SelectedItem as Manufacturers;
            if (selectedManufacturer != null)
            {
                Select_Car_Model.ItemsSource = selectedManufacturer.CarsModels.Select(c => c.ModelName).Distinct().ToList();
            }
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
        private void UpdateNavigationButtons()
        {
            int totalPages = (int)Math.Ceiling((double)ViewModel.Reviews.Count / itemsPerPage);
            PreviousPageButton.IsEnabled = currentPage > 1;
            NextPageButton.IsEnabled = currentPage < totalPages;
        }
        private void LoadPage(int page)
        {
            int startIndex = (page - 1) * itemsPerPage;
            var carsToDisplay = ViewModel.Reviews.Skip(startIndex).Take(itemsPerPage).ToList();
            PageNumberTextBlock.Text = $"Trang {page}";
            ReviewListView.ItemsSource = carsToDisplay;
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
            int totalPages = (int)Math.Ceiling((double)ViewModel.Reviews.Count / itemsPerPage);
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadPage(currentPage);
            }
        }

        private void ReviewListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedReview = e.ClickedItem as Reviews;
            if (selectedReview != null)
            {
                Frame.Navigate(typeof(DetailReviewPage), selectedReview);
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string manufactutrer = Select_Car_Company.SelectedItem != null ? ((Manufacturers)Select_Car_Company.SelectedItem).ManufacturerName : null;
            string model = Select_Car_Model.SelectedItem != null ? Select_Car_Model.SelectedItem.ToString() : null;
            string keyword = manufactutrer + " " + model;
            ViewModel.Search_Review_By_Keyword(keyword);
            LoadPage(currentPage);
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Select_Car_Company.SelectedItem = null;
            Select_Car_Model.SelectedItem = null;
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
