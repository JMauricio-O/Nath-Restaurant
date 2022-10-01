using NathRestaurant.Ventas.AccesoADatos;
using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.LogicaDeNegocio
{
    public class CarritoBL
    {
        public async Task<int> AgregarAsync(Carrito pCarrito)
        {
            return await CarritoDAL.AgregarAsync(pCarrito);
        }
        public async Task<int> ModificarAsync(Carrito pCarrito)
        {
            return await CarritoDAL.ModificarAsync(pCarrito);
        }
        public async Task<int> EliminarAsync(Carrito pCarrito)
        {
            return await CarritoDAL.EliminarAsync(pCarrito);
        }
        public async Task<Carrito> ObtenerPorIdAsync(Carrito pCarrito)
        {
            return await CarritoDAL.ObtenerPorIdAsync(pCarrito);
        }
        public async Task<List<Carrito>> ObtenerTodosAsync()
        {
            return await CarritoDAL.ObtenerTodosAsync();
        }
        public async Task<List<Carrito>> BuscarAsync(Carrito pCarrito)
        {
            return await CarritoDAL.BuscarAsync(pCarrito);
        }
    }
}
