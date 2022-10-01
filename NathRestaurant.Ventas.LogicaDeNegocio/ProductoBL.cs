using NathRestaurant.Ventas.AccesoADatos;
using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.LogicaDeNegocio
{
    public class ProductoBL
    {
        public async Task<int> AgregarAsync(Producto pProducto)
        {
            return await ProductoDAL.AgregarAsync(pProducto);
        }
        public async Task<int> ModificarAsync(Producto pProducto)
        {
            return await ProductoDAL.ModificarAsync(pProducto);
        }
        public async Task<int> EliminarAsync(Producto pProducto)
        {
            return await ProductoDAL.EliminarAsync(pProducto);
        }
        public async Task<Producto> ObtenerPorIdAsync(Producto pProducto)
        {
            return await ProductoDAL.ObtenerPorIdAsync(pProducto);
        }
        public async Task<List<Producto>> ObtenerTodosAsync()
        {
            return await ProductoDAL.ObtenerTodosAsync();
        }
        public async Task<List<Producto>> BuscarAsync(Producto pProducto)
        {
            return await ProductoDAL.BuscarAsync(pProducto);
        }
        public async Task<List<Producto>> BuscarIncluirCategoriaAsync(Producto pProducto)
        {
            return await ProductoDAL.BuscarIncluirCategoriaAsync(pProducto);
        }
    }
}
