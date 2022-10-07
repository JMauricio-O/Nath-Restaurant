

using NathRestaurant.Ventas.UI.WebApp.Models;

namespace NathRestaurant.Ventas.UI.WebApp.Services
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> GetAll();
    }
}
