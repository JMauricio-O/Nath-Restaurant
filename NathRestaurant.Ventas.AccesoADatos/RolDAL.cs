using Microsoft.EntityFrameworkCore;
using NathRestaurant.Ventas.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NathRestaurant.Ventas.AccesoADatos
{
    public class RolDAL
    {
        public static async Task<int>AgregarAsync(Rol pRol)
        {
            int resul = 0;
            using (var dbContext = new DBContext())
            {
                dbContext.Add(pRol);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }

        public static async Task<int> ModificarAsync(Rol pRol)
        {
            var resul = 0;
            using (var dbContext = new DBContext())
            {
                var rol = await dbContext.Rol.FirstOrDefaultAsync(r => r.Id == pRol.Id);
                rol.Nombre = pRol.Nombre;
                dbContext.Update(rol);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }

        public static async Task<int>EliminarAsync(Rol pRol)
        {
            var resul = 0;
            using (var dbContext = new DBContext())
            {
                var rol = await dbContext.Rol.FirstOrDefaultAsync(r => r.Id == pRol.Id);
                dbContext.Remove(rol);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }
    }
}
