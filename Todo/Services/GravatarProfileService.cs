using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Services
{
    public class GravatarProfileService
    {
        private readonly HttpClient _httpClient;

        public GravatarProfileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string?> GetDisplayNameAsync(string emailAdrress)
        {
            var hashCode = Gravatar.GetHash(emailAdrress);
            var url = $"https://www.gravatar.com/{hashCode}.json";

            try
            {
                var response = await _httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode) return null;

                var content = await response.Content.ReadAsStringAsync();
                var profile = JsonSerializer.Deserialize<GravatarProfile>(content);

                return profile?.entry?.FirstOrDefault()?.DisplayName;
            }
            catch
            {
                return null;
            }
        }
    }
}
