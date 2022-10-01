using NathRestaurant.Ventas.AccesoADatos;
using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.LogicaDeNegocio
{
    public class DetalleVentaBL
    {
        public async Task<int> AgregarAsync(DetalleVenta pDetalleVenta)
        {
            return await DetalleVentaDAL.AgregarAsync(pDetalleVenta);
        }
        public async Task<int> ModificarAsync(DetalleVenta pDetalleVenta)
        {
            return await DetalleVentaDAL.ModificarAsync(pDetalleVenta);
        }
        public async Task<int> EliminarAsync(DetalleVenta pDetalleVenta)
        {
            return await DetalleVentaDAL.EliminarAsync(pDetalleVenta);
        }
        public async Task<DetalleVenta> ObtenerPorIdAsync(DetalleVenta pDetalleVenta)
        {
            return await DetalleVentaDAL.ObtenerPorIdAsync(pDetalleVenta);
        }
        public async Task<List<DetalleVenta>> ObtenerTodosAsync()
        {
            return await DetalleVentaDAL.ObtenerTodosAsync();
        }
        public async Task<List<DetalleVenta>> BuscarAsync(DetalleVenta pDetalleVenta)
        {
            return await DetalleVentaDAL.BuscarAsync(pDetalleVenta);
        }
        public async Task<List<DetalleVenta>> BuscarIncluirProducto(DetalleVenta pDetalleVenta)
        {
            return await DetalleVentaDAL.BuscarIncluirProducto(pDetalleVenta);
        }
    }
}
