using NathRestaurant.Ventas.AccesoADatos;
using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.LogicaDeNegocio
{
    public class VentaBL
    {
        public async Task<int> AgregarAsync(Venta pVenta)
        {
            return await VentaDAL.AgregarAsync(pVenta);
        }
        public async Task<int> ModificarAsync(Venta pVenta)
        {
            return await VentaDAL.ModificarAsync(pVenta);
        }
        public async Task<int> EliminarAsync(Venta pVenta)
        {
            return await VentaDAL.EliminarAsync(pVenta);
        }
        public async Task<Venta> ObtenerPorIdAsync(Venta pVenta)
        {
            return await VentaDAL.ObtenerPorIdAsync(Venta pVenta)
        }
        public async Task<List<Venta>> ObtenerTodosAsync()
        {
            return await VentaDAL.ObtenerTodosAsync();
        }
        public async Task<List<Venta>> BuscarAsync(Venta pVenta)
        {
            return await VentaDAL.BuscarAsync(pVenta);
        }
        public async Task<List<Venta>> BuscarIncluirTodosAsync(Venta pVenta)
        {
            return await VentaDAL.BuscarIncluirTodosAsync(pVenta);
        }
    }
}
