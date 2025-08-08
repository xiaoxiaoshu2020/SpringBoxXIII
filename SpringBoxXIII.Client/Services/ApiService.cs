using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpringBoxXIII.Client.Services
{
    internal class ApiService(HttpClient httpClient) : IApiService
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<string> GetAsync(string endpoint)
        {
            try
            {
                using var response = await _httpClient.GetAsync(endpoint);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"HTTP Error: {(int)response.StatusCode}");
                }
                var json = await response.Content.ReadAsStringAsync();

                return json;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data, string key)
        {
            throw new NotImplementedException();
        }
    }
}
