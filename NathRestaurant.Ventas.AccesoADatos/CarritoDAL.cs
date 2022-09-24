using Microsoft.EntityFrameworkCore;
using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.AccesoADatos
{
    public class CarritoDAL
    {
        public static async Task<int> AgregarAsync(Carrito pCarrito)
        {
            int resul = 0;
            using (var dbContext = new DBContext())
            {
                dbContext.Add(pCarrito);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }

        public static async Task<int> ModificarAsync(Carrito pCarrito)
        {
            int resul = 0;
            using (var dbContext = new DBContext())
            {
                var carrito = await dbContext.Carrito.FirstOrDefaultAsync(c => c.Id == pCarrito.Id);
                carrito.IdProducto = pCarrito.IdProducto;
                carrito.IdCliente = pCarrito.IdCliente;
                dbContext.Update(carrito);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }

        public static async Task<int> EliminarAsync(Carrito pCarrito)
        {
            int resul = 0;
            using (var dbContext = new DBContext())
            {
                var carrito = await dbContext.Carrito.FirstOrDefaultAsync(c => c.Id == pCarrito.Id);
                dbContext.Remove(carrito);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }

        public static async Task<Carrito> ObtenerPorIdAsync(Carrito pCarrito)
        {
            var carrito = new Carrito();
            using (var dbContext = new DBContext())
            {
                carrito = await dbContext.Carrito.FirstOrDefaultAsync(c => c.Id == pCarrito.Id);
            }
            return carrito;
        }

        public static async Task<List<Carrito>> ObtenerTodosAsync()
        {
            var carrito = new List<Carrito>();
            using (var dbContext = new DBContext())
            {
                carrito = await dbContext.Carrito.ToListAsync();
            }
            return carrito;
        }

        internal static IQueryable<Carrito> QuerySelect(IQueryable<Carrito> pQuery, Carrito pCarrito)
        {
            if (pCarrito.Id > 0)
            {
                pQuery = pQuery.Where(c => c.Id == pCarrito.Id);
            }
            if (pCarrito.IdProducto > 0)
            {
                pQuery = pQuery.Where(c => c.IdProducto == pCarrito.IdProducto);
            }
            if (pCarrito.IdCliente > 0)
            {
                pQuery = pQuery.Where(c => c.IdCliente == pCarrito.IdCliente);
            }
            pQuery = pQuery.OrderByDescending(c => c.Id == pCarrito.Id).AsQueryable();
            if (pCarrito.Top_Aux > 0)
            {
                pQuery = pQuery.Take(pCarrito.Top_Aux).AsQueryable();
            }
            return pQuery;
        }
        public static async Task<List<Carrito>> BuscarAsync(Carrito pCarrito)
        {
            var carrito = new List<Carrito>();
            using (var dbContext = new DBContext())
            {
                var select = dbContext.Carrito.AsQueryable();
                select = QuerySelect(select, pCarrito);
                carrito = await select.ToListAsync();
            }
            return carrito;
        }
        public static async Task<List<Carrito>> BuscarTodosAsync(Carrito pCarrito)
        {
            var carrito = new List<Carrito>();
            using (var bdContext = new DBContext())
            {
                var select = bdContext.Carrito.AsQueryable();
                select = QuerySelect(select, pCarrito).Include(c => c.Producto)
                                                      .Include(c => c.Cliente).AsQueryable();
                carrito = await select.ToListAsync();
            }
            return carrito;
        }

    }
}
