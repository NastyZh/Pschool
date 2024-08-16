using System.Net.Http.Json;

namespace PschoolFrontEnd.Services
{
    public class ParentService
    {
        private readonly HttpClient _httpClient;

        public ParentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Parent>> GetParentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Parent>>("api/Parents") ?? new List<Parent>();
        }
    }
}