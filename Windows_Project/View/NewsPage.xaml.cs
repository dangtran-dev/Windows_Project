using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows_Project.Model;
using Windows_Project.View;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Windows_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewsPage : Page
    {
        public List<NewsArticle> NewsArticles { get; set; } = new List<NewsArticle>();
        public NewsPage()
        {
            this.InitializeComponent();
            GetNews();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private async void GetNews()
        {
            try
            {
                await Task.Run(async () =>
                {
                    var newsApiClient = new NewsApiClient("d0b12da0414e4d7da17495e7763cd4b9");

                    var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
                    {
                        Q = "vinfast",
                        SortBy = SortBys.PublishedAt,
                        Language = Languages.VI,
                        From = new DateTime(2024, 11, 27)
                    });

                    DispatcherQueue.TryEnqueue(() =>
                    {
                        if (articlesResponse.Status == Statuses.Ok)
                        {
                            foreach (var article in articlesResponse.Articles)
                            {
                                NewsSource newssource = new NewsSource
                                {
                                    Id = article.Source.Id,
                                    Name = article.Source.Name
                                };

                                NewsArticle newsarticle = new NewsArticle
                                {
                                    Source = newssource,
                                    Author = article.Author,
                                    Title = article.Title,
                                    Description = article.Description,
                                    Url = article.Url,
                                    UrlToImage = article.UrlToImage,
                                    PublishedAt = article.PublishedAt,
                                    Content = article.Content
                                };

                                NewsArticles.Add(newsarticle);
                            }
                            NewsListView.ItemsSource = NewsArticles;
                        }
                        else
                        {
                            ShowDialog("Lỗi tải tin tức", "Không thể lấy dữ liệu từ API.");
                        }
                    });
                });
            }
            catch (Exception ex)
            {
                await ShowDialog("Lỗi", $"Lỗi xảy ra: {ex.Message}");
            }
        }

        private async Task ShowDialog(string title, string content)
        {
            ContentDialog dialog = new ContentDialog()
            {
                XamlRoot = this.Content.XamlRoot,
                Title = title,
                Content = content,
                CloseButtonText = "OK"
            };
            await dialog.ShowAsync();
        }

        private void OnNewItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedNews = e.ClickedItem as NewsArticle;

            if (selectedNews != null)
            {
                Frame.Navigate(typeof(NewDetailPage), selectedNews);
            }
        }
    }
}
