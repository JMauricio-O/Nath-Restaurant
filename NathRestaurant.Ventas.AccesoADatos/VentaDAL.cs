using Microsoft.EntityFrameworkCore;
using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.AccesoADatos
{
    public class VentaDAL
    {
        public static async Task<int> AgregarAsync(Venta pVenta)
        {
            int resul = 0;
            using (var dbContext = new DBContext())
            {
                pVenta.FechaRegistro = DateTime.Now;
                dbContext.Add(pVenta);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }

        public static async Task<int> ModificarAsync(Venta pVenta)
        {
            int resul = 0;
            using (var dbContext = new DBContext())
            {
                var venta = await dbContext.Venta.FirstOrDefaultAsync(v => v.Id == pVenta.Id);
                venta.IdDetalleVenta = pVenta.IdDetalleVenta;
                venta.IdCliente = pVenta.IdCliente;
                venta.Contacto = pVenta.Contacto;
                venta.TotalProducto = pVenta.TotalProducto;
                venta.Direccion = pVenta.Direccion;
                venta.MontoTotal = pVenta.MontoTotal;
                dbContext.Venta.Update(venta);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }

        public static async Task<int> EliminarAsync(Venta pVenta)
        {
            int resul = 0;
            using (var dbContext = new DBContext())
            {
                var venta = await dbContext.Venta.FirstOrDefaultAsync(v => v.Id == pVenta.Id);
                dbContext.Venta.Remove(venta);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }

        public static async Task<Venta> ObtenerPorIdAsync(Venta pVenta)
        {
            var venta = new Venta();
            using (var dbContext = new DBContext())
            {
                venta = await dbContext.Venta.FirstOrDefaultAsync(v => v.Id == pVenta.Id);
            }
            return venta;
        }

        public static async Task<List<Venta>> ObtenerTodosAsync()
        {
            var venta = new List<Venta>();
            using (var dbContext = new DBContext())
            {
                venta = await dbContext.Venta.ToListAsync();
            }
            return venta;
        }

        internal static IQueryable<Venta> QuerySelect(IQueryable<Venta> pQuery, Venta pVenta)
        {
            if (pVenta.Id > 0)
            {
                pQuery = pQuery.Where(v => v.Id == pVenta.Id);
            }

            if (pVenta.IdDetalleVenta > 0)
            {
                pQuery = pQuery.Where(v => v.IdDetalleVenta == pVenta.IdDetalleVenta);
            }

            if (pVenta.IdCliente > 0)
            {
                pQuery = pQuery.Where(v => v.IdCliente == pVenta.IdCliente);
            }

            if (!string.IsNullOrWhiteSpace(pVenta.Contacto))
            {
                pQuery = pQuery.Where(v => v.Contacto.Contains(pVenta.Contacto));
            }

            if (pVenta.TotalProducto > 0)
            {
                pQuery = pQuery.Where(v => v.TotalProducto == pVenta.TotalProducto);
            }

            if (!string.IsNullOrWhiteSpace(pVenta.Direccion))
            {
                pQuery = pQuery.Where(v => v.Direccion.Contains(pVenta.Direccion));
            }

            if (pVenta.IdTransaccion > 0)
            {
                pQuery = pQuery.Where(v => v.IdTransaccion == pVenta.IdTransaccion);
            }
            if (pVenta.MontoTotal > 0)
            {
                pQuery = pQuery.Where(v => v.MontoTotal == pVenta.MontoTotal);
            }
            if (pVenta.FechaRegistro.Year > 1000)
            {
                DateTime fechaInicial = new DateTime(pVenta.FechaRegistro.Year, pVenta.FechaRegistro.Month, pVenta.FechaRegistro.Day, 0, 0, 0);
                DateTime fechaFinal = fechaInicial.AddDays(1).AddMilliseconds(-1);
                pQuery = pQuery.Where(s => s.FechaRegistro >= fechaInicial && s.FechaRegistro <= fechaFinal);
            }
            pQuery = pQuery.OrderByDescending(v => v.Id).AsQueryable();
            if (pVenta.Top_Aux > 0)
            {
                pQuery = pQuery.Take(pVenta.Top_Aux).AsQueryable();
            }
            return pQuery;
        }

        public static async Task<List<Venta>> BuscarAsync(Venta pVenta)
        {
            var venta = new List<Venta>();
            using (var dbContext = new DBContext())
            {
                var select = dbContext.Venta.AsQueryable();
                select = QuerySelect(select, pVenta);
                venta = await select.ToListAsync();
            }
            return venta;
        }

        public static async Task<List<Venta>> BuscarIncluirTodosAsync(Venta pVenta)
        {
            var venta = new List<Venta>();
            using (var dbContext = new DBContext())
            {
                var select = dbContext.Venta.AsQueryable();
                select = QuerySelect(select, pVenta).Include(v => v.DetalleVenta).AsQueryable()
                                                    .Include(v => v.Cliente).AsQueryable();
                venta = await select.ToListAsync();
            }
            return venta;
        }

    }
}
