using Microsoft.EntityFrameworkCore;
using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.AccesoADatos
{
    public class ProductoDAL
    {
        public static async Task<int> AgregarAsync(Producto pProducto)
        {
            int resul = 0;
            using (var dbContext = new DBContext())
            {
                pProducto.FechaRegistro = DateTime.Now;
                pProducto.Estado = (byte)Enums.Estado.ACTIVO;
                dbContext.Add(pProducto);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }

        public static async Task<int> ModificarAsync(Producto pProducto)
        {
            int resul = 0;
            using (var dbContext = new DBContext())
            {
                var producto = await dbContext.Producto.FirstOrDefaultAsync(p => p.Id == pProducto.Id);
                producto.IdCategoria = pProducto.IdCategoria;
                producto.Nombre = pProducto.Nombre;
                producto.Descripcion = producto.Descripcion;
                producto.NombreImagen = pProducto.NombreImagen;
                producto.RutaImagen = pProducto.RutaImagen;
                producto.Precio = producto.Precio;
                producto.Estado = pProducto.Estado;
                dbContext.Producto.Update(producto);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }

        public static async Task<int> EliminarAsync(Producto pProducto)
        {
            int resul = 0;
            using (var dbContext = new DBContext())
            {
                var producto = await dbContext.Producto.FirstOrDefaultAsync(p => p.Id == pProducto.Id);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }
        public static async Task<Producto> ObtenerPorIdAsync(Producto pProducto)
        {
            var producto = new Producto();
            using (var dbContexto = new DBContext())
            {
                producto = await dbContexto.Producto.FirstOrDefaultAsync(p => p.Id == pProducto.Id);
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
        public static IQueryable<Producto> QuerySelect(IQueryable<Producto> pQuery, Producto pProducto)
        {
            if (pProducto.Id > 0)
            {
                pQuery = pQuery.Where(p => p.Id == pProducto.Id);
            }
            if (pProducto.IdCategoria > 0)
            {
                pQuery = pQuery.Where(p => p.IdCategoria == p.IdCategoria);
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
            if (pProducto.Precio > 0)
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
                pQuery = pQuery.Where(p => p.Estado == pProducto.Estado);
            }
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pProducto.Top_Aux > 0)
            {
                pQuery = pQuery.Take(pProducto.Top_Aux).AsQueryable();
            }
            return pQuery;
        }

        public static async Task<List<Producto>> BuscarAsync(Producto pProducto)
        {
            var producto = new List<Producto>();
            using (var dbContext = new DBContext())
            {
                var select = dbContext.Producto.AsQueryable();
                select = QuerySelect(select, pProducto);
                producto = await select.ToListAsync();
            }
            return producto;
        }

        public static async Task<List<Producto>> BuscarIncluirCategoria(Producto pProducto)
        {
            var producto = new List<Producto>();
            using (var bdContexto = new DBContext())
            {
                var select = bdContexto.Producto.AsQueryable();
                select = QuerySelect(select, pProducto).Include(p => p.Categoria).AsQueryable();
                producto = await select.ToListAsync();
            }
            return producto;
        }
    }
}
