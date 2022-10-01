using NathRestaurant.Ventas.AccesoADatos;
using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.LogicaDeNegocio
{
    public class CategoriaBL
    {
        public async Task<int> AgregarAsync(Categoria pCategoria)
        {
            return await CategoriaDAL.AgregarAsync(pCategoria);
        }
        public async Task<int> ModificarAsync(Categoria pCategoria)
        {
            return await CategoriaDAL.ModificarAsync(pCategoria);
        }
        public async Task<int> EliminarAsync(Categoria pCategoria)
        {
            return await CategoriaDAL.EliminarAsync(pCategoria);
        }
        public async Task<Categoria> ObtenerPorIdAsync(Categoria pCategoria)
        {
            return await CategoriaDAL.ObtenerPorIdAsync(pCategoria);
        }
        public async Task<List<Categoria>> ObtenerTodosAsync()
        {
            return await CategoriaDAL.ObtenerTodosAsync();
        }
        public async Task<List<Categoria>> BuscarAsync(Categoria pCategoria)
        {
            return await CategoriaDAL.BuscarAsync(pCategoria);
        }
    }
}
