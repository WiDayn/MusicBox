using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MusicBox.API
{
    internal class UserAPI
    {
        public static bool isLogin = false;
        public static string authToken = "";
        public static UserData userData = new UserData();

        public class LoginResponse
        {
            public int StatusCode { get; set; }
            public string Data { get; set; }
            public string Message { get; set; }
        }
        public class UserInfoResponse
        {
            public int StatusCode { get; set; }
            public UserData Data { get; set; }
            public string Message { get; set; }
        }

        public class UserData
        {
            public int UserID { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Area { get; set; }
            public DateTime DateCreated { get; set; }
            public DateTime LastLogin { get; set; }

            public int FavoriteSongNum {  get; set; }
        }

        public static async Task<String> PostLoginAsync(string username, string password)
        {
            var url = Properties.Resources.BackEnd_URL + "/user/login";
            var loginData = new
            {
                Username = username,
                Password = password
            };

            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(loginData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                client.Timeout = TimeSpan.FromSeconds(5); // Set timeout to 30 seconds
                var response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseString);
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
        }
        public static async void GetUserInfoAsync()
        {
            string url = Properties.Resources.BackEnd_URL + "/user/userinfo";
            using (var client = new HttpClient())
            {
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
        }
    }
}
