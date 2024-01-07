using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MusicBox.Core.Dtos;
using Newtonsoft.Json;

namespace MusicBox.API
{
    internal class UserAPI
    {
        public static bool isLogin = false;
        public static string authToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiIxIiwibmJmIjoxNzA0MjM2NzM0LCJleHAiOjE3MDQ4NDE1MzQsImlhdCI6MTcwNDIzNjczNH0.bUpfOViTYGG5k_1F0AhVIHEnc6KeRV8K8lLsbSEvWlI";
        public static UserData userData = new UserData();
        public static FavoriteResponse favoriteResponse = new();

        public static async Task<String> PostLoginAsync(string username, string password)
        {
            var url = Properties.Resources.BackEnd_URL + "/user/login";
            var loginData = new
            {
                Username = username,
                Password = password
            };

            var client = Program.httpClient;
            var json = JsonConvert.SerializeObject(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            client.Timeout = TimeSpan.FromSeconds(30); // Set timeout to 30 seconds
            var response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<DefaultResponse>(responseString);
                isLogin = true;
                authToken = loginResponse.Data;
                GetUserInfoAsync();
                return "success";
            }
            else
            {
                Debug.WriteLine("Error: " + response.StatusCode);
                return response.StatusCode.ToString();
            }
        }
        public static async void GetUserInfoAsync()
        {
            string url = Properties.Resources.BackEnd_URL + "/user/userinfo";
            var client = Program.httpClient;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(authToken);
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                UserInfoResponse userInfoResponse = JsonConvert.DeserializeObject<UserInfoResponse>(jsonString);
                userData = userInfoResponse.Data;
                Debug.WriteLine("Get userData successfully");
            }
            else
            {
                // 处理错误响应
                throw new HttpRequestException($"Error fetching user data: {response.StatusCode}");
            }
        }
        public static async Task RemoveFavoriteSongAsync(int songId)
        {
            string url = Properties.Resources.BackEnd_URL + $"/favorite/removeSong/{songId}";
            var client = Program.httpClient;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(authToken);

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var responseObj = JsonConvert.DeserializeObject<ApiResponse>(jsonString);
                if (responseObj.StatusCode == 200)
                {
                    Debug.WriteLine(responseObj.Data); // "Remove song successfully"
                }
            }
            else
            {
                // 处理错误响应
                throw new HttpRequestException($"Error removing song: {response.StatusCode}");
            }
        }

        public static async Task AddFavoriteSongAsync(int songId)
        {
            string url = Properties.Resources.BackEnd_URL + $"/favorite/addSong/{songId}";
            var client = Program.httpClient;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(authToken);

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var responseObj = JsonConvert.DeserializeObject<ApiResponse>(jsonString);
                if (responseObj.StatusCode == 200)
                {
                    Debug.WriteLine(responseObj.Data); // "Add song successfully"
                }
            }
            else
            {
                // 处理错误响应
                throw new HttpRequestException($"Error adding song: {response.StatusCode}");
            }
        }
    }
}
