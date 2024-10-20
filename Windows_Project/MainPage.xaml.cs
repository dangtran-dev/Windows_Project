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

namespace Windows_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private DispatcherTimer timer;
        public ObservableCollection<string> Pictures { get; set; }
        private bool isReversing = false; // Bi?n theo dõi tr?ng thái ti?n ho?c lùi
        public MainPage()
        {
            this.InitializeComponent();

            // Danh sách hình ?nh
            Pictures = new ObservableCollection<string>
            {
                "Assets/mazda3.jpg",
                "Assets/mercedes.jpg",
                "Assets/honda.jpg",
                "Assets/audi.jpg",
            };

            Gallery.ItemsSource = Pictures; // Gán danh sách hình ?nh vào FlipView

            // Kh?i t?o timer v?i kho?ng 1 giây
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2.5); // M?i 1 giây
            timer.Tick += Timer_Tick; // Gán s? ki?n Timer_Tick cho timer
            timer.Start(); // B?t ??u timer
        }

        // Ph??ng th?c Timer_Tick s? ???c g?i m?i giây
        private void Timer_Tick(object sender, object e)
        {
            // N?u ?ang không ch?y ng??c
            if (!isReversing)
            {
                // Ti?n t?i hình ti?p theo
                if (Gallery.SelectedIndex < Pictures.Count - 1)
                {
                    Gallery.SelectedIndex++;
                }
                else
                {
                    // ??n ?nh cu?i cùng thì ??i chi?u
                    isReversing = true;
                    Gallery.SelectedIndex--;
                }
            }
            else
            {
                // ?ang ch?y ng??c
                if (Gallery.SelectedIndex > 0)
                {
                    Gallery.SelectedIndex--;
                }
                else
                {
                    // ??n ?nh ??u tiên thì ??i chi?u
                    isReversing = false;
                    Gallery.SelectedIndex++;
                }
            }
        }

        private void OnCarOldButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void OnCarNewButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void OnPriceButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void OnSellCarButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
