using NathRestaurant.Ventas.UI.WebApp.Models;

namespace NathRestaurant.Ventas.UI.WebApp.Services
{
    public class RolService : IRolService
    {
        private readonly HttpClient _httpClient;
        public RolService(HttpClient httpClient)
        {
            _httpClient=httpClient;
        }
        public Task<IEnumerable<Rol>> GetAll(string id)
        {
            throw new NotImplementedException();
        }
    }
}
