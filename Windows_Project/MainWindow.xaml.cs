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
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        public ObservableCollection<string> Pictures { get; set; }
        private bool isReversing = false; // Biến theo dõi trạng thái tiến hoặc lùi
        public MainWindow()
        {
            this.InitializeComponent();

            // Danh sách hình ảnh
            Pictures = new ObservableCollection<string>
            {
                "Assets/mazda3.jpg",
                "Assets/mercedes.jpg",
                "Assets/honda.jpg",
                "Assets/audi.jpg",
            };

            Gallery.ItemsSource = Pictures; // Gán danh sách hình ảnh vào FlipView

            // Khởi tạo timer với khoảng 1 giây
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2.5); // Mỗi 1 giây
            timer.Tick += Timer_Tick; // Gán sự kiện Timer_Tick cho timer
            timer.Start(); // Bắt đầu timer
        }

        // Phương thức Timer_Tick sẽ được gọi mỗi giây
        private void Timer_Tick(object sender, object e)
        {
            // Nếu đang không chạy ngược
            if (!isReversing)
            {
                // Tiến tới hình tiếp theo
                if (Gallery.SelectedIndex < Pictures.Count - 1)
                {
                    Gallery.SelectedIndex++;
                }
                else
                {
                    // Đến ảnh cuối cùng thì đổi chiều
                    isReversing = true;
                    Gallery.SelectedIndex--;
                }
            }
            else
            {
                // Đang chạy ngược
                if (Gallery.SelectedIndex > 0)
                {
                    Gallery.SelectedIndex--;
                }
                else
                {
                    // Đến ảnh đầu tiên thì đổi chiều
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

        private void Post_News_Click(object sender, RoutedEventArgs e)
        {
            var screen = new PostWindow();
            screen.Activate();
            this.Close();
        }
    }
}
