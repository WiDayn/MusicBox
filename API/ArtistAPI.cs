using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MusicBox.Core.Dtos.Artist;

namespace MusicBox.API
{
    public static class ArtistAPI
    {
        public static async Task<ArtistInfoResponse?> GetArtistInfoAsync(int artistId)
        {
            string url = Properties.Resources.BackEnd_URL + $"/artist/{artistId}/details";
            var client = Program.httpClient;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(UserAPI.authToken);

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                ArtistInfoResponse artistInfoResponse = JsonConvert.DeserializeObject<ArtistInfoResponse>(jsonString);
                // 处理获取的歌手数据
                Debug.WriteLine("Get artist data successfully");
                return artistInfoResponse;
            }
            else
            {
                // 处理错误响应
                throw new HttpRequestException($"Error fetching artist data: {response.StatusCode}");
            }
        }
    }
}
