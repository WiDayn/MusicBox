﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MusicBox.Core.Dtos.Song;

namespace MusicBox.API
{
    internal class SongAPI
    {
        public static async Task<LyricsResponse?> GetLyricsAsync(int songId)
        {
            string url = Properties.Resources.BackEnd_URL + $"/song/{songId}/lyrics";
            var client = Program.httpClient;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(UserAPI.authToken);

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                LyricsResponse lyricsResponse = JsonConvert.DeserializeObject<LyricsResponse>(jsonString);
                Debug.WriteLine("Get lyrics data successfully");
                return lyricsResponse;
            }
            else
            {
                // 处理错误响应
                throw new HttpRequestException($"Error fetching lyrics data: {response.StatusCode}");
            }
        }
    }
}
