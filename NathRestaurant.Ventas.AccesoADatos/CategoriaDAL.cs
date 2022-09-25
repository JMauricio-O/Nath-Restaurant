using Microsoft.EntityFrameworkCore;
using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.AccesoADatos
{
    public class CategoriaDAL
    {
        public static async Task<int> AgregarAsync(Categoria pCategoria)
        {
            int resul = 0;
            using (DBContext dbContext = new DBContext())
            {
                dbContext.Add(pCategoria);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }

        public static async Task<int> ModificarAsync(Categoria pCategoria)
        {
            int resul = 0;
            using (var dbContext = new DBContext())
            {
                var categoria = await dbContext.Categoria.FirstOrDefaultAsync(c => c.Id == pCategoria.Id);
                categoria.Nombre = pCategoria.Nombre;
                dbContext.Update(categoria);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }

        public static async Task<int> EliminarAsync(Categoria pCategoria)
        {
            var resul = 0;
            using (DBContext dbContext = new DBContext())
            {
                var categoria = await dbContext.Categoria.FirstOrDefaultAsync(c => c.Id == pCategoria.Id);
                dbContext.Categoria.Remove(categoria);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }

        public static async Task<Categoria> ObtenerPorIdAsync(Categoria pCategoria)
        {
            var categoria = new Categoria();
            using (DBContext dbContext = new DBContext())
            {
                categoria = await dbContext.Categoria.FirstOrDefaultAsync(c => c.Id == pCategoria.Id);
            }
            return categoria;
        }

        public static async Task<List<Categoria>> ObtenerTodosAsync()
        {
            var categoria = new List<Categoria>();
            using (DBContext dbContext = new DBContext())
            {
                categoria = await dbContext.Categoria.ToListAsync();
            }
            return categoria;
        }

        internal static IQueryable<Categoria> QuerySelect(IQueryable<Categoria> pQuery, Categoria pCategoria)
        {
            if (pCategoria.Id > 0)
            {
                pQuery = pQuery.Where(c => c.Id == pCategoria.Id);
            }
            if (!string.IsNullOrWhiteSpace(pCategoria.Nombre))
            {
                pQuery = pQuery.Where(c => c.Nombre.Contains(pCategoria.Nombre));
            }
            pQuery = pQuery.OrderByDescending(c => c.Id).AsQueryable();
            if (pCategoria.Top_Aux > 0)
            {
                pQuery = pQuery.Take(pCategoria.Top_Aux).AsQueryable();
            }
            return pQuery;
        }

        public static async Task<List<Categoria>> BuscarAsync(Categoria pCategoria)
        {
            var categoria = new List<Categoria>();
            using (DBContext dbContext = new DBContext())
            {
                var select = dbContext.Categoria.AsQueryable();
                select = QuerySelect(select, pCategoria);
                categoria = await select.ToListAsync();
            }
            return categoria;
        }
    }
}
