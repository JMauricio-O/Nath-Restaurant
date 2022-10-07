using NathRestaurant.Ventas.UI.WebApp.Models;
using System.Data.SqlTypes;

namespace NathRestaurant.Ventas.UI.WebApp.Services
{
    public interface IRolService
    {
        Task<IEnumerable<Rol>> GetAll(string id);

    }
}
