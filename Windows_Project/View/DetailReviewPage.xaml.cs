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
    public sealed partial class DetailReviewPage : Page
    {
        public Reviews Review { get; set; }
        public DetailReviewPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Review = e.Parameter as Reviews;
            DataContext = Review;
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
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
