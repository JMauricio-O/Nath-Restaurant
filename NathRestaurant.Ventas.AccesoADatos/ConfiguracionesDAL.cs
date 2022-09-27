using Microsoft.EntityFrameworkCore;
using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.AccesoADatos
{
    public class ConfiguracionesDAL
    {

        public static async Task<int> AgregarAsync(Configuracion pConfiguracion)
        {
            int resul = 0;
            using (var dbContext = new DBContext())
            {
                dbContext.Add(pConfiguracion);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }

        public static async Task<int> ModificarAsync(Configuracion pConfiguracion)
        {
            int resul = 0;
            using (var dbContext = new DBContext())
            {
                var conf = await dbContext.Configuracion.FirstOrDefaultAsync(c => c.Id == pConfiguracion.Id);
                conf.Recurso = pConfiguracion.Recurso;
                conf.Propiedad = pConfiguracion.Propiedad;
                conf.Valor = pConfiguracion.Valor;
                dbContext.Update(conf);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }

        public static async Task<int> EliminarAsync(Configuracion pConfiguracion)
        {
            int resul = 0;
            using (var dbContext = new DBContext())
            {
                var conf = await dbContext.Configuracion.FirstOrDefaultAsync(c => c.Id == pConfiguracion.Id);
                dbContext.Remove(conf);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }

        public static async Task<Configuracion> ObtenerPorIdAsync(Configuracion pConfiguracion)
        {
            var conf = new Configuracion();
            using (var dbContext = new DBContext())
            {
                conf = await dbContext.Configuracion.FirstOrDefaultAsync(c => c.Id == pConfiguracion.Id);
            }
            return conf;
        }

        public static async Task<List<Configuracion>> ObtenerTodosAsync()
        {
            var conf = new List<Configuracion>();
            using (var dbContext = new DBContext())
            {
                conf = await dbContext.Configuracion.ToListAsync();
            }
            return conf;
        }

        internal static IQueryable<Configuracion> QuerySelect(IQueryable<Configuracion> pQuery, Configuracion pConfiguracion)
        {
            if (pConfiguracion.Id > 0)
            {
                pQuery = pQuery.Where(c => c.Id == pConfiguracion.Id);
            }
            if (!string.IsNullOrWhiteSpace(pConfiguracion.Recurso))
            {
                pQuery = pQuery.Where(c => c.Recurso.Contains(pConfiguracion.Recurso));
            }
            if (!string.IsNullOrWhiteSpace(pConfiguracion.Propiedad))
            {
                pQuery = pQuery.Where(c => c.Propiedad.Contains(pConfiguracion.Propiedad));
            }
            if (!string.IsNullOrWhiteSpace(pConfiguracion.Valor))
            {
                pQuery = pQuery.Where(c => c.Valor.Contains(pConfiguracion.Valor));
            }
            return pQuery;
        }

        public static async Task<List<Configuracion>> BuscarAsync(Configuracion pConfiguracion)
        {
            var conf = new List<Configuracion>();
            using (var dbContext = new DBContext())
            {
                var select = dbContext.Configuracion.AsQueryable();
                select = QuerySelect(select, pConfiguracion);
                conf = await select.ToListAsync();
            }
            return conf;
        }
    }
}
