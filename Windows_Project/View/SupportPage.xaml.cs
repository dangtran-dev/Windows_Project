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
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.Devices.Sms;
using Google.Apis.Auth.OAuth2;
using Grpc.Auth;
using Google.Cloud.Dialogflow.V2;
using System.Windows.Resources;
using Newtonsoft.Json.Linq;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Windows_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SupportPage : Page
    {
        public ObservableCollection<string> Messages { get; set; }
        private readonly HttpClient _httpClient = new HttpClient();
        private const string ApiKey = "AIzaSyA55gFmQWJqCDgXQRzPqSphVxLqjZbe-W8";
        private const string Endpoint = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash-latest:generateContent?key=";
        public SupportPage()
        {
            this.InitializeComponent();
            Messages = new ObservableCollection<string>();
            ConversationList.ItemsSource = Messages;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = InputTextBox.Text;

            if (!string.IsNullOrEmpty(userMessage))
            {
                // Hiển thị tin nhắn của người dùng
                Messages.Add($"You: {userMessage}");
                InputTextBox.Text = string.Empty;

                // Gửi tin nhắn đến DialogFlow
                string botResponse = await SendMessageToDialogflow(userMessage);
                if (string.IsNullOrWhiteSpace(botResponse) || botResponse.Equals("Default Fallback Intent"))
                {
                    botResponse = await SendMessageToGemini(userMessage);
                }

                // Hiển thị tin nhắn của bot
                Messages.Add($"Bot: {botResponse}");

            }
        }

        private async Task<string> SendMessageToGemini(string userMessage)
        {
            try
            {
                var requestBody = new
                {
                    contents = new[]
                    {
                        new { parts = new[] { new { text = userMessage } } }
                    }
                };

                // Chuyển requestBody thành JSON
                var jsonRequest = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                // Gửi yêu cầu HTTP POST
                var response = await _httpClient.PostAsync($"{Endpoint}{ApiKey}", content);
                response.EnsureSuccessStatusCode();

                // Đọc nội dung phản hồi
                var jsonResponse = await response.Content.ReadAsStringAsync();

                // Parse JSON
                var parsedJson = JObject.Parse(jsonResponse);

                // Trích xuất text từ JSON
                var text = parsedJson["candidates"]?[0]?["content"]?["parts"]?[0]?["text"]?.ToString();
                text = Regex.Replace(text, @"\*", "");

                return text;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        private async Task<string> SendMessageToDialogflow(string userMessage)
        {
            try
            {
                // Đường dẫn đến file JSON API Key
                //string jsonPath = @"D:\KHTN\HKI\Windows\Windows_Project\config\windowsproject-444620-753846ed6602.json";
                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config", "windowsproject-444620-753846ed6602.json");
                var credential = GoogleCredential.FromFile(jsonPath).ToChannelCredentials();
                var client = new SessionsClientBuilder { ChannelCredentials = credential }.Build();

                // Thông tin phiên làm việc
                string projectId = "windowsproject-444620";
                string sessionId = Guid.NewGuid().ToString();
                var sessionName = SessionName.FromProjectSession(projectId, sessionId);

                // Gửi yêu cầu đến Dialogflow
                var queryInput = new QueryInput
                {
                    Text = new TextInput
                    {
                        Text = userMessage,
                        LanguageCode = "vi"
                    }
                };

                var response = await client.DetectIntentAsync(sessionName, queryInput);

                // Trả về phản hồi từ chatbot
                return response.QueryResult.FulfillmentText;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }


    }
}
