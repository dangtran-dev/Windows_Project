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
using System.Windows.Forms;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml.Media.Imaging;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Windows_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CarDetailPage : Page
    {
        public CarWithUserItem ViewModel { get; set; }
        public string FullAddress => $"{ViewModel.user.Address}, {ViewModel.car.District}, {ViewModel.car.City}";
        public CarDetailPage()
        {
            this.InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            // Lấy dữ liệu được truyền vào từ trang trước
            ViewModel = e.Parameter as CarWithUserItem;
            DataContext = ViewModel;
            if(ViewModel.car.CarImages.Count == 1)
            {
                UniqueImage.Visibility = Visibility.Visible;
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    var imageControl = (Image)FindName($"Image{i + 1}l");
                    if (i < ViewModel.car.CarImages.Count)
                    {
                        imageControl.Source = new BitmapImage(new Uri(ViewModel.car.CarImages[i].ImageURL));
                        imageControl.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        imageControl.Source = null;
                        imageControl.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }
    }

}
