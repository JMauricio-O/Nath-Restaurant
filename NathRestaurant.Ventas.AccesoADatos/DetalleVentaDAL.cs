using Microsoft.EntityFrameworkCore;
using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.AccesoADatos
{
    public class DetalleVentaDAL
    {

        public static async Task<int> AgregarAsync(DetalleVenta pDetalleVenta)
        {
            int result = 0;
            using (var dbContext = new DBContext())
            {
                dbContext.Add(pDetalleVenta);
                result = await dbContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(DetalleVenta pDetalleVenta)
        {
            int resul = 0;
            using (var dbContext = new DBContext())
            {
                var detalleVenta = await dbContext.DetalleVenta.FirstOrDefaultAsync(d => d.Id == pDetalleVenta.Id);
                detalleVenta.IdProducto = pDetalleVenta.IdProducto;
                detalleVenta.Cantidad = pDetalleVenta.Cantidad;
                detalleVenta.Subtotal = pDetalleVenta.Subtotal;
                dbContext.Update(detalleVenta);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }

        public static async Task<int> EliminarAsync(DetalleVenta pDetalleVenta)
        {
            int resul = 0;
            using (var dbContext = new DBContext())
            {
                var detalleVenta = await dbContext.DetalleVenta.FirstOrDefaultAsync(d => d.Id == pDetalleVenta.Id);
                dbContext.Remove(detalleVenta);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }

        public static async Task<DetalleVenta> ObtenerPorIdAsync(DetalleVenta pDetalleVenta)
        {
            var detalleVenta = new DetalleVenta();
            using (var dbContext = new DBContext())
            {
                detalleVenta = await dbContext.DetalleVenta.FirstOrDefaultAsync(d => d.Id == pDetalleVenta.Id);
            }
            return detalleVenta;
        }

        public static async Task<List<DetalleVenta>> ObtenerTodosAsync()
        {
            var detalleVenta = new List<DetalleVenta>();
            using (var dbContext = new DBContext())
            {
                detalleVenta = await dbContext.DetalleVenta.ToListAsync();
            }
            return detalleVenta;
        }

        internal static IQueryable<DetalleVenta> QuerySelect(IQueryable<DetalleVenta> pQuery, DetalleVenta pDetalleVenta)
        {
            if (pDetalleVenta.Id > 0)
            {
                pQuery = pQuery.Where(d => d.Id == pDetalleVenta.Id);
            }
            if (pDetalleVenta.IdProducto > 0)
            {
                pQuery = pQuery.Where(d => d.IdProducto == pDetalleVenta.IdProducto);
            }
            if (pDetalleVenta.Cantidad > 0)
            {
                pQuery = pQuery.Where(d => d.Cantidad == pDetalleVenta.Cantidad);
            }
            if (pDetalleVenta.Subtotal > 0)
            {
                pQuery = pQuery.Where(d => d.Subtotal == pDetalleVenta.Subtotal);
            }
            pQuery = pQuery.OrderByDescending(d => d.Id).AsQueryable();
            if (pDetalleVenta.Top_Aux > 0)
            {
                pQuery = pQuery.Take(pDetalleVenta.Top_Aux);
            }
            return pQuery;
        }

        public static async Task<List<DetalleVenta>> BuscarAsync(DetalleVenta pDetalleVenta)
        {
            var detalleVenta = new List<DetalleVenta>();
            using (var dbContext = new DBContext())
            {
                var select = dbContext.DetalleVenta.AsQueryable();
                select = QuerySelect(select, pDetalleVenta);
                detalleVenta = await select.ToListAsync();
            }
            return detalleVenta;
        }

        public static async Task<List<DetalleVenta>> BuscarIncluirProducto(DetalleVenta pDetalleVenta)
        {
            var detalleVenta = new List<DetalleVenta>();
            using (var dbContext = new DBContext())
            {
                var select = dbContext.DetalleVenta.AsQueryable();
                select = QuerySelect(select, pDetalleVenta).Include(d => d.Producto);
                detalleVenta = await select.ToListAsync();
            }
            return detalleVenta;
        }
    }
}
