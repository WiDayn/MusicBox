using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MusicBox.API
{
    internal class UserAPI
    {
        public static bool isLogin = false;
        public static string token = "";
        public class LoginResponse
        {
            public int StatusCode { get; set; }
            public string Data { get; set; }
            public string Message { get; set; }
        }

        public static async Task<String> PostLoginAsync(string username, string password)
        {
            var url = "http://192.168.50.173:5000/user/login";
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
                    token = loginResponse.Data;
                    return "success";
                }
                else
                {
                   Debug.WriteLine("Error: " + response.StatusCode);
                    return response.StatusCode.ToString();
                }
            }
        }
    }
}
