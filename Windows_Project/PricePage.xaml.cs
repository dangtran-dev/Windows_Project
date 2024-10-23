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
using Microsoft.UI.Xaml.Media.Animation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Windows_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PricePage : Page
    {
        public MainViewModel ViewModel { get; set; }
        public PricePage()
        {
            this.InitializeComponent();
            ViewModel = new MainViewModel();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private void TipsGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedManufacturer = e.ClickedItem as Manufacturers;
            if (selectedManufacturer != null)
            {
                Frame.Navigate(typeof(CarPricePage), selectedManufacturer);
            }
        }

    }
}
