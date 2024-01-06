using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MusicBox.Core.Dtos.Album;

namespace MusicBox.API
{
    public class AlbumAPI
    {
        public static async Task<AlbumInfoResponse?> GetAlbumInfoAsync(int albumId)
        {
            string url = Properties.Resources.BackEnd_URL + $"/album/{albumId}/details";
            var client = Program.httpClient;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(UserAPI.authToken);

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                AlbumInfoResponse albumInfoResponse = JsonConvert.DeserializeObject<AlbumInfoResponse>(jsonString);
                // 处理获取的专辑数据
                Debug.WriteLine("Get album data successfully");
                return albumInfoResponse;
            }
            else
            {
                // 处理错误响应
                throw new HttpRequestException($"Error fetching album data: {response.StatusCode}");
            }
        }
    }
}
