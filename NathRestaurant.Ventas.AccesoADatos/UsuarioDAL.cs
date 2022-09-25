﻿using Microsoft.EntityFrameworkCore;
using NathRestaurant.Ventas.EntidadesDeNegocio;
using System.Security.Cryptography;
using System.Text;

namespace NathRestaurant.Ventas.AccesoADatos
{
    public class UsuarioDAL
    {
        public static void EncriptarMD5(Usuario pUsuario)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(pUsuario.Contrasenia));
                var strEncriptar = "";
                for (int i = 0; i < result.Length; i++)
                    strEncriptar += result[i].ToString("x2").ToLower();
                pUsuario.Contrasenia = strEncriptar;
            }
        }

        private static async Task<bool> ExisteCarnet(Usuario pUsuario, DBContext pDbContext)
        {
            bool result = false;
            var carnetUsuarioExiste = await pDbContext.Usuario.FirstOrDefaultAsync(u => u.Carnet == pUsuario.Carnet && u.Id != pUsuario.Id);
            if (carnetUsuarioExiste != null && carnetUsuarioExiste.Id > 0 && carnetUsuarioExiste.Carnet == pUsuario.Carnet)
            {
                result = true;
            }
            return result;
        }

        #region CRUD


        public async Task<int> CrearAsync(Usuario pUsuario)
        {
            int resul = 0;
            using (var dbContext = new DBContext())
            {
                bool existeCarnet = await ExisteCarnet(pUsuario, dbContext);
                if (existeCarnet == false)
                {
                    pUsuario.FechaRegistro = DateTime.Now;
                    pUsuario.Estado = (byte)Enums.Estado.ACTIVO;
                    EncriptarMD5(pUsuario);
                    dbContext.Add(pUsuario);
                    resul = await dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Carnet Ya existe");
                }
                return resul;
            }
        }

        public static async Task<int> ModificarAsync(Usuario pUsuario)
        {
            int resul = 0;
            using (var dbContext = new DBContext())
            {
                bool existeCarnet = await ExisteCarnet(pUsuario, dbContext);
                if (existeCarnet == false)
                {
                    var usuario = await dbContext.Usuario.FirstOrDefaultAsync(u => u.Id == pUsuario.Id);
                    usuario.IdRol = pUsuario.IdRol;
                    usuario.Nombre = pUsuario.Nombre;
                    usuario.Apellido = pUsuario.Nombre;
                    usuario.Contacto = pUsuario.Contacto;
                    usuario.Carnet = pUsuario.Carnet;
                    usuario.Estado = pUsuario.Estado;
                    dbContext.Usuario.Update(usuario);
                    resul = await dbContext.SaveChangesAsync();
                }
                return resul;
            }
        }

        public static async Task<int> EliminarAsync(Usuario pUsuario)
        {
            int resul = 0;
            using (var dbContext = new DBContext())
            {
                var usuario = await dbContext.Usuario.FirstOrDefaultAsync(u => u.Id == pUsuario.Id);
                dbContext.Remove(usuario);
                resul = await dbContext.SaveChangesAsync();
            }
            return resul;
        }

        public static async Task<Usuario> ObtenerPorIdAsync(Usuario pUsuario)
        {
            var usuario = new Usuario();
            using (var dbContext = new DBContext())
            {
                usuario = await dbContext.Usuario.FirstOrDefaultAsync(u => u.Id == pUsuario.Id);
            }
            return usuario;
        }

        public static async Task<List<Usuario>> ObtenerTodosAsync()
        {
            var usuario = new List<Usuario>();
            using (var dbContext = new DBContext())
            {
                usuario = await dbContext.Usuario.ToListAsync();
            }
            return usuario;
        }

        internal static IQueryable<Usuario> QuerySelect(IQueryable<Usuario> pQuery, Usuario pUsuario)
        {
            if (pUsuario.IdRol > 0)
            {
                pQuery = pQuery.Where(u => u.IdRol == pUsuario.IdRol);
            }
            if (!string.IsNullOrWhiteSpace(pUsuario.Nombre))
            {
                pQuery = pQuery.Where(u => u.Nombre.Contains(pUsuario.Nombre));
            }
            if (!string.IsNullOrEmpty(pUsuario.Apellido))
            {
                pQuery = pQuery.Where(u => u.Apellido.Contains(pUsuario.Apellido));
            }
            if (!string.IsNullOrWhiteSpace(pUsuario.Carnet))
            {
                pQuery = pQuery.Where(u => u.Carnet.Contains(pUsuario.Carnet));
            }
            if (!string.IsNullOrWhiteSpace(pUsuario.Contacto))
            {
                pQuery = pQuery.Where(u => u.Contacto.Contains(pUsuario.Contacto));
            }
            if (pUsuario.FechaRegistro.Year > 1000)
            {
                DateTime fechaInicial = new DateTime(pUsuario.FechaRegistro.Year, pUsuario.FechaRegistro.Month, pUsuario.FechaRegistro.Day, 0, 0, 0);
                DateTime fechaFinal = fechaInicial.AddDays(1).AddMilliseconds(-1);
                pQuery = pQuery.Where(s => s.FechaRegistro >= fechaInicial && s.FechaRegistro <= fechaFinal);
            }
            if (pUsuario.Estado > 0)
            {
                pQuery = pQuery.Where(u => u.Id == pUsuario.Id);
            }

            pQuery = pQuery.OrderByDescending(u => u.Id).AsQueryable();

            if (pUsuario.Top_Aux > 0)
            {
                pQuery = pQuery.Take(pUsuario.Top_Aux).AsQueryable();
            }
            return pQuery;
        }
        public static async Task<List<Usuario>> BuscarAsync(Usuario pUsuario)
        {
            var usuarios = new List<Usuario>();
            using (var bdContext = new DBContext())
            {
                var select = bdContext.Usuario.AsQueryable();
                select = QuerySelect(select, pUsuario);
                usuarios = await select.ToListAsync();
            }
            return usuarios;
        }
        public static async Task<List<Usuario>> BuscarIncluirRoles(Usuario pUsuario)
        {
            var usuarios = new List<Usuario>();
            using (var bdContext = new DBContext())
            {
                var select = bdContext.Usuario.AsQueryable();
                select = QuerySelect(select, pUsuario).Include(s => s.Rol).AsQueryable();
                usuarios = await select.ToListAsync();
            }
            return usuarios;
        }
        #endregion
        public static async Task<Usuario> Login(Usuario pUsuario)
        {
            var usuario = new Usuario();
            using (var bdContext = new DBContext())
            {
                EncriptarMD5(pUsuario);
                usuario = await bdContext.Usuario.FirstOrDefaultAsync(s => s.Carnet == pUsuario.Carnet &&
                s.Contrasenia == pUsuario.Contrasenia && s.Estado == (byte)Enums.Estado.ACTIVO); 
            }
            return usuario;
        }

        public static async Task<int> CambiarContrasenia(Usuario pUsuario, string pContrasenia)
        {
            int result = 0;
            var usuarioPassAnt = new Usuario { Contrasenia = pContrasenia };
            EncriptarMD5(usuarioPassAnt);
            using (var bdContext = new DBContext())
            {
                var usuario = await bdContext.Usuario.FirstOrDefaultAsync(s => s.Id == pUsuario.Id);
                if (usuarioPassAnt.Contrasenia == usuario.Contrasenia)
                {
                    EncriptarMD5(pUsuario);
                    usuario.Contrasenia = pUsuario.Contrasenia;
                    bdContext.Update(usuario);
                    result = await bdContext.SaveChangesAsync();
                }
                else
                    throw new Exception("Contraseña incorrecta");
            }
            return result;
        }
    }
}
