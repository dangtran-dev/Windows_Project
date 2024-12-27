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
using System.Diagnostics;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Windows_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewDetailPage : Page
    {
        public NewDetailPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is NewsArticle selectedNews)
            {
                this.DataContext = selectedNews;

                TitleNew.Text = selectedNews.Title;
                DescriptionNew.Text = selectedNews.Description;
                ImageNew.Source = new Microsoft.UI.Xaml.Media.Imaging.BitmapImage(new Uri(selectedNews.UrlToImage));
                DateNew.Text = selectedNews.PublishedAt.ToString();
                AuthorNew.Text = selectedNews.Author;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private async void ReadMoreButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Kiểm tra DataContext không null
                if (DataContext == null)
                {
                    await ShowErrorDialog("Không có dữ liệu bài viết.");
                    return;
                }

                // Kiểm tra kiểu dữ liệu của DataContext
                if (DataContext is NewsArticle selectedNews && !string.IsNullOrWhiteSpace(selectedNews.Url))
                {
                    // Tự động thêm https:// nếu thiếu
                    string fixedUrl = selectedNews.Url.StartsWith("http", StringComparison.OrdinalIgnoreCase)
                                      ? selectedNews.Url
                                      : "https://" + selectedNews.Url;

                    // Kiểm tra URL hợp lệ
                    if (Uri.TryCreate(fixedUrl, UriKind.Absolute, out var uri) &&
                        (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
                    {
                        await Windows.System.Launcher.LaunchUriAsync(uri);
                    }
                    else
                    {
                        await ShowErrorDialog($"URL không hợp lệ: {fixedUrl}");
                    }
                }
                else
                {
                    await ShowErrorDialog("Không thể xác định bài viết hoặc URL trống.");
                }
            }
            catch (Exception ex)
            {
                await ShowErrorDialog($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        // Hộp thoại lỗi
        private async Task ShowErrorDialog(string message)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Lỗi",
                Content = message,
                CloseButtonText = "OK",
                XamlRoot = this.XamlRoot // Đảm bảo XamlRoot không null
            };
            await dialog.ShowAsync();
        }

    }
}
