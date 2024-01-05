using MusicBox.Core.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.API
{
    public class ListAPI
    {
        public static async Task<FavoriteResponse> GetFavoriteSongsAsync()
        {
            string url = Properties.Resources.BackEnd_URL + "/favorite";

            var httpClient = Program.httpClient;
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(UserAPI.authToken);
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<FavoriteResponse>(jsonString);
            }
            else
            {
                // 处理错误情况
                throw new HttpRequestException($"Error fetching favorite songs: {response.StatusCode}");
            }
        }
    }
}
