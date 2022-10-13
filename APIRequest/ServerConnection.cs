using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace APIRequest
{
    public static class ServerConnection
    {
        static string baseAddress = "https://localhost:7230/";
        static HttpClient client;

        public static async Task<List<T>> GetRequest<T>(string apiRoute)
        {
            RenewClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage responseMessage = await client.GetAsync(apiRoute);
            responseMessage.EnsureSuccessStatusCode();

#pragma warning disable CS8603
            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadFromJsonAsync<List<T>>();
            }
            else
            {
                return null;
            }
        }
#pragma warning restore CS8603
        public static async Task PostRequest<T>(string apiRoute, T obj)
        {
            RenewClient();
            await client.PostAsJsonAsync<T>(apiRoute, obj);
        }

        public static async Task DeleteRequest(string apiRoute)
        {
            RenewClient();
            await client.SendAsync(new HttpRequestMessage(HttpMethod.Delete, apiRoute));
        }

        public static async Task PutRequest<T>(string apiRoute, T obj)
        {
            RenewClient();
            await client.PutAsJsonAsync<T>(apiRoute, obj);
        }     

        public static async Task<string> GetString(string apiRoute)
        {
            RenewClient();                     
            HttpResponseMessage res = await client.GetAsync(apiRoute);
            var resString = await res.Content.ReadAsStringAsync();
            return resString.Trim();
        }
      
        public static void SetBaseUrlDebug()
        {
            baseAddress = DeviceInfo.Platform == DevicePlatform.Android? "http://10.0.2.2:5209" : "https://localhost:7230/";
        }

        /// <summary>
        /// default url = 192.168.100.6/
        /// </summary>
        /// <param name="url"></param>
        public static void SetUrl(string url)
        {
            baseAddress = url;
        }

        static void RenewClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
        }
    }

    public interface IAPIService
    {
        Task<List<T>> GetRequest<T>(string apiRoute);
        Task PostRequest<T>(string apiRoute, T obj);
        Task DeleteRequest(string apiRoute);
        Task PutRequest<T>(string apiRoute, T obj);
        
    }
}