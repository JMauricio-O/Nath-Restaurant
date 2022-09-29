using Microsoft.EntityFrameworkCore;
using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.AccesoADatos
{
    public class ProductoDAL
    {
        public static async Task<int> AgregarAsync(Producto pProducto)
        {
            int result = 0;
            using (var dbContext = new DBContext())
            {
                pProducto.FechaRegistro = DateTime.Now;
                pProducto.Estado = (Byte)Enums.Estado.ACTIVO;
                dbContext.Add(pProducto);
                result = await dbContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Producto pProducto)
        {
            int resul = 0;
            using (var dbContext = new DBContext())
            {
                var producto = await dbContext.Producto.FirstOrDefaultAsync(p => p.Id == pProducto.Id);
                producto.IdCategoria = pProducto.IdCategoria;
                pProducto.Nombre = pProducto.Nombre;
                pProducto.Descripcion = pProducto.Descripcion;
                pProducto.NombreImagen=pProducto.NombreImagen;
                producto.RutaImagen=pProducto.RutaImagen;
                producto.Precio = pProducto.Precio;
                producto.Estado = pProducto.Estado;
                dbContext.Update(producto);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }

        public static async Task<int> EliminarAsync(Producto pProducto)
        {
            int resul = 0;
            using (var dbContext = new DBContext())
            {
                var producto = await dbContext.Producto
                    .FirstOrDefaultAsync(p => p.Id == pProducto.Id);
                dbContext.Remove(pProducto);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }

        public static async Task<Producto> ObtenerPorIdAsync(Producto pProducto)
        {
            var producto = new Producto();
            using (var dbContext = new DBContext())
            {
                producto = await dbContext.Producto.
                    FirstOrDefaultAsync(p => p.Id == pProducto.Id);
            }
            return producto;
        }

        public static async Task<List<Producto>> ObtenerTodosAsync()
        {
            var producto = new List<Producto>();
            using (var dbContext = new DBContext())
            {
                producto = await dbContext.Producto.ToListAsync();
            }
            return producto;
        }

        internal static IQueryable<Producto> QurySelect(IQueryable<Producto> pQuery, Producto pProducto)
        {
            if (pProducto.Id > 0)
            {
                pQuery = pQuery.Where(p => p.Id == pProducto.Id);
            }
            if (pProducto.IdCategoria > 0)
            {
                pQuery = pQuery.Where(p => p.IdCategoria == pProducto.IdCategoria);
            }
            if (!string.IsNullOrWhiteSpace(pProducto.Nombre))
            {
                pQuery = pQuery.Where(p => p.Nombre.Contains(pProducto.Nombre));
            }
            if (!string.IsNullOrWhiteSpace(pProducto.Descripcion))
            {
                pQuery = pQuery.Where(p => p.Descripcion.Contains(pProducto.Descripcion));
            }
            if (!string.IsNullOrWhiteSpace(pProducto.NombreImagen))
            {
                pQuery = pQuery.Where(p => p.NombreImagen.Contains(pProducto.NombreImagen));
            }
            if (!string.IsNullOrWhiteSpace(pProducto.RutaImagen))
            {
                pQuery = pQuery.Where(p => p.RutaImagen.Contains(pProducto.RutaImagen));
            }
            if (pProducto.Precio>0)
            {
                pQuery = pQuery.Where(p => p.Precio == pProducto.Precio);
            }
            if (pProducto.FechaRegistro.Year > 1000)
            {
                DateTime fechaInicial = new DateTime(pProducto.FechaRegistro.Year, pProducto.FechaRegistro.Month, pProducto.FechaRegistro.Day, 0, 0, 0);
                DateTime fechaFinal = fechaInicial.AddDays(1).AddMilliseconds(-1);
                pQuery = pQuery.Where(s => s.FechaRegistro >= fechaInicial && s.FechaRegistro <= fechaFinal);
            }
            if (pProducto.Estado > 0)
            {
                pQuery = pQuery.Where(u => u.Estado == pProducto.Estado);
            }

            pQuery = pQuery.OrderByDescending(u => u.Id).AsQueryable();

            if (pProducto.Top_Aux > 0)
            {
                pQuery = pQuery.Take(pProducto.Top_Aux).AsQueryable();
            }
            return pQuery;
        }

        public static async Task<List<Producto>>BuscarAsync(Producto pProducto)
        {
            var producto = new List<Producto>();
            using (var dbContext = new DBContext())
            {
                var select = dbContext.Producto.AsQueryable();
                select = QurySelect(select, pProducto);
                producto = await select.ToListAsync();
            }
            return producto;
        }

        public static async Task<List<Producto>> BuscarIncluirCategoriaAsync(Producto pProducto)
        {
            var producto = new List<Producto>();
            using (var dbContext = new DBContext())
            {
                var select = dbContext.Producto.AsQueryable();
                select = QurySelect(select, pProducto).Include(p=>p.Categoria).AsQueryable();
                producto = await select.ToListAsync();
            }
            return producto;
        }
    }
}
