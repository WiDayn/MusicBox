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
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var memoryStream = new MemoryStream();
                    await responseStream.CopyToAsync(memoryStream);
                    memoryStream.Position = 0; // 将流的位置重置为开始处
                    return Image.FromStream(memoryStream);
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
