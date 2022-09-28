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

        public static async Task<int> EliminarAsync(Producto pProducto)
        {
            int resul = 0;
            using (var dbContext = new DBContext())
            {
                var producto = await dbContext.Producto.FirstOrDefaultAsync(p => p.Id == pProducto.Id);
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
                producto = await dbContext.Producto.FirstOrDefaultAsync(p => p.Id == pProducto.Id);
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

    }
}
