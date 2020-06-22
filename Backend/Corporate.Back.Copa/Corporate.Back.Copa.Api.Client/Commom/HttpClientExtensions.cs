using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Corporate.Back.Copa.Api.Client.Commom
{
    public static class HttpClientExtensions
    {
        public static async Task<TResult> PostJsonAsync<TResult>(this HttpClient client, string url)
        {
            var response = await client.PostAsync(url, new ByteArrayContent(new byte[0]));
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(json);
        }

        public static async Task<HttpResponseMessage> PostJsonAsync(this HttpClient client, string url, object data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data));
            return await client.PostAsync(url, content);
        }

    }
}
