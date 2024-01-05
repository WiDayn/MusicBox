using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.API
{
    internal class ImgAPI
    {
        public static async Task<Image> LoadImageFromUrlAsync(string url)
        {
            var httpClient = Program.httpClient;
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    return Image.FromStream(stream);
                }
            }
            else
            {
                // 处理错误，例如抛出异常或返回 null
                throw new HttpRequestException($"Error retrieving image from {url}");
            }
        }
    }
}
