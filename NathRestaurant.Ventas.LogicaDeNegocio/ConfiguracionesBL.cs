using NathRestaurant.Ventas.AccesoADatos;
using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.LogicaDeNegocio
{
    public class ConfiguracionesBL
    {
        public async Task<int> AgregarAsync(Configuracion pConfiguracion)
        {
            return await ConfiguracionesDAL.AgregarAsync(pConfiguracion);
        }
        public async Task<int> ModificarAsync(Configuracion pConfiguracion)
        {
            return await ConfiguracionesDAL.ModificarAsync(pConfiguracion);
        }
        public async Task<int> EliminarAsync(Configuracion pConfiguracion)
        {
            return await ConfiguracionesDAL.EliminarAsync(pConfiguracion);
        }
        public async Task<Configuracion> ObtenerPorIdAsync(Configuracion pConfiguracion)
        {
            return await ConfiguracionesDAL.ObtenerPorIdAsync(pConfiguracion);
        }
        public async Task<List<Configuracion>> ObtenerTodosAsync()
        {
            return await ConfiguracionesDAL.ObtenerTodosAsync();
        }
        public async Task<List<Configuracion>> BuscarAsync(Configuracion pConfiguracion)
        {
            return await ConfiguracionesDAL.BuscarAsync(pConfiguracion);
        }
    }
}
