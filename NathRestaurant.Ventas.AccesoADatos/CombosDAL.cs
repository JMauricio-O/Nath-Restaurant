using Microsoft.EntityFrameworkCore;
using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.AccesoADatos
{
    public class CombosDAL
    {
        public static async Task<int> AgregarAsync(Combos pCombos)
        {
            int resul = 0;
            using (var dbContext = new DBContext())
            {
                pCombos.Estado = (byte)Enums.Estado.ACTIVO;
                pCombos.FechaRegistro = DateTime.Now;
                dbContext.Add(pCombos);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }

        public static async Task<int> ModificarAsync(Combos pCombos)
        {
            int resul = 0;
            using (var dbContext = new DBContext())
            {
                var combos = await dbContext.Combos.FirstOrDefaultAsync(c => c.Id == pCombos.Id);
                combos.IdProducto = pCombos.IdProducto;
                combos.Nombre = pCombos.Nombre;
                combos.Descripcion = pCombos.Descripcion;
                combos.NombreImagen = pCombos.NombreImagen;
                combos.RutaImagen = pCombos.RutaImagen;
                combos.Precio = pCombos.Precio;
                combos.Estado = pCombos.Estado;
                dbContext.Update(combos);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }

        public static async Task<int> EliminarAsync(Combos pCombos)
        {
            int resul = 0;
            using (var dbContext = new DBContext())
            {
                var combos = await dbContext.Combos.FirstOrDefaultAsync(c => c.Id == pCombos.Id);
                dbContext.Remove(combos);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }

        public static async Task<Combos> ObtenerPorIdAsync(Combos pCombos)
        {
            var combos = new Combos();
            using (var dbContext = new DBContext())
            {
                combos = await dbContext.Combos.FirstOrDefaultAsync(c => c.Id == pCombos.Id);
            }
            return combos;
        }

        public static async Task<List<Combos>> ObtenerTodosAsync()
        {
            var combos = new List<Combos>();
            using (var dbContext = new DBContext())
            {
                combos = await dbContext.Combos.ToListAsync();
            }
            return combos;
        }

        internal static IQueryable<Combos> QuerySelect(IQueryable<Combos> pQuery, Combos pCombos)
        {
            if (pCombos.Id > 0)
            {
                pQuery = pQuery.Where(c => c.Id == pCombos.Id);
            }
            if (pCombos.IdProducto > 0)
            {
                pQuery = pQuery.Where(c => c.IdProducto == pCombos.IdProducto);
            }
            if (!string.IsNullOrWhiteSpace(pCombos.Nombre))
            {
                pQuery = pQuery.Where(c => c.Nombre.Contains(pCombos.Nombre));
            }
            if (!string.IsNullOrWhiteSpace(pCombos.Descripcion))
            {
                pQuery = pQuery.Where(c => c.Descripcion.Contains(pCombos.Descripcion));
            }
            if (!string.IsNullOrWhiteSpace(pCombos.NombreImagen))
            {
                pQuery = pQuery.Where(c => c.NombreImagen.Contains(pCombos.NombreImagen));
            }
            if (!string.IsNullOrWhiteSpace(pCombos.RutaImagen))
            {
                pQuery = pQuery.Where(c => c.RutaImagen.Contains(pCombos.RutaImagen));
            }
            if (pCombos.Precio > 0)
            {
                pQuery = pQuery.Where(c => c.Precio == pCombos.Precio);
            }
            if (pCombos.FechaRegistro.Year > 1000)
            {
                DateTime fechaInicial = new DateTime(pCombos.FechaRegistro.Year, pCombos.FechaRegistro.Month, pCombos.FechaRegistro.Day, 0, 0, 0);
                DateTime fechaFinal = fechaInicial.AddDays(1).AddMilliseconds(-1);
                pQuery = pQuery.Where(c => c.FechaRegistro >= fechaInicial && c.FechaRegistro <= fechaFinal);
            }
            if (pCombos.Estado > 0)
            {
                pQuery = pQuery.Where(c => c.Estado == pCombos.Estado);
            }
            pQuery = pQuery.OrderByDescending(u => u.Id).AsQueryable();
            if (pCombos.Top_Aux > 0)
            {
                pQuery = pQuery.Take(pCombos.Top_Aux).AsQueryable();
            }
            return pQuery;
        }

        public static async Task<List<Combos>> BuscarAsync(Combos pCombos)
        {
            var combos = new List<Combos>();
            using (var dbContext = new DBContext())
            {
                var select = dbContext.Combos.AsQueryable();
                select = QuerySelect(select, pCombos);
                combos = await select.ToListAsync();
            }
            return combos;
        }
        public static async Task<List<Combos>> BuscarIncluirProductoAsync(Combos pCombos)
        {
            var combos = new List<Combos>();
            using (var dbContext = new DBContext())
            {
                var select = dbContext.Combos.AsQueryable();
                select = QuerySelect(select, pCombos).Include(c => c.Producto).AsQueryable();
                combos = await select.ToListAsync();
            }
            return combos;
        }
    }
}
