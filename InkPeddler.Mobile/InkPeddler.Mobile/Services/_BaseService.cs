using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace InkPeddler.Mobile.Services
{
    public interface IBaseService
    {

    }

    public class BaseService : IBaseService
    {
        internal async Task<string> HttpPost(string url, List<KeyValuePair<string, string>> keyValues)
        {
            try
            {
                var baseUrl = "https://localhost:44374/api/";
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}{url}");
                if (keyValues != null) httpRequestMessage.Content = new FormUrlEncodedContent(keyValues);

                using (var client = new HttpClient())
                {
                    var httpResponseMessage = await client.SendAsync(httpRequestMessage);
                    return await httpResponseMessage.Content.ReadAsStringAsync();
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}