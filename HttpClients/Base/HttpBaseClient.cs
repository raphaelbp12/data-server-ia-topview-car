using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BaseClient.Abstractions
{
    public abstract class HttpBaseClient
    {
        protected readonly HttpClient _httpClient;

        public HttpBaseClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        protected async Task<T> GetAsync<T>(string path)
        {
            var response = await _httpClient.GetAsync(path);
            
            response.EnsureSuccessStatusCode();
            
            var apiResponse = await response.Content.ReadAsStringAsync();
            var pureJson = Regex.Replace(apiResponse, @"^.+?\(|\)$", "");
            
            return JsonConvert.DeserializeObject<T>(pureJson);
        }
    }
}