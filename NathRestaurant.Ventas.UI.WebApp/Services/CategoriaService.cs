
using NathRestaurant.Ventas.UI.WebApp.Models;
using System.Text.Json;

namespace NathRestaurant.Ventas.UI.WebApp.Services
{
    public class CategoriaService : ICategoriaService
    {
        private HttpClient _httpClient;

        public CategoriaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string resp = await _httpClient.GetStringAsync($"Categoria");
            return JsonSerializer.Deserialize<IEnumerable<Categoria>>(resp, option);
        }
    }
}
