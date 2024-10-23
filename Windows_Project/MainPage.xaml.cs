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
        private bool isReversing = false;
        public MainPage()
        {
            this.InitializeComponent();

            Pictures = new ObservableCollection<string>
            {
                "Assets/mazda_bg.jpg",
                "Assets/mercedes_bg.jpg",
                "Assets/honda_bg.jpg",
                "Assets/audi_bg.jpg",
            };

            Gallery.ItemsSource = Pictures;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2.5);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            if (!isReversing)
            {
                if (Gallery.SelectedIndex < Pictures.Count - 1)
                {
                    Gallery.SelectedIndex++;
                }
                else
                {
                    isReversing = true;
                    Gallery.SelectedIndex--;
                }
            }
            else
            {
                if (Gallery.SelectedIndex > 0)
                {
                    Gallery.SelectedIndex--;
                }
                else
                {
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
            Frame.Navigate(typeof(PricePage));
        }

        private void OnSellCarButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
