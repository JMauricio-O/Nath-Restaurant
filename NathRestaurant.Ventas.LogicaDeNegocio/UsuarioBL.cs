using NathRestaurant.Ventas.AccesoADatos;
using NathRestaurant.Ventas.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NathRestaurant.Ventas.LogicaDeNegocio
{
    public class UsuarioBL
    {
        public async Task<int> AgregarAsync(Usuario pUsuario)
        {
            return await UsuarioDAL.CrearAsync(pUsuario);
        }
        public async Task<int> ModificarAsync(Usuario pUsuario)
        {
            return await UsuarioDAL.ModificarAsync(pUsuario);
        }
        public async Task<int> EliminarAsync(Usuario pUsuario)
        {
            return await UsuarioDAL.EliminarAsync(pUsuario);
        }
        public async Task<Usuario> ObtenerPorIdAsync(Usuario pUsuario)
        {
            return await UsuarioDAL.ObtenerPorIdAsync(pUsuario);
        }
        public async Task<List<Usuario>> ObtenerTodosAsync()
        {
            return await UsuarioDAL.ObtenerTodosAsync();
        }
        public async Task<List<Usuario>> BuscarAsync(Usuario pUsuario)
        {
            return await UsuarioDAL.BuscarAsync(pUsuario);
        }
        public async Task<Usuario> Login(Usuario pUsuario)
        {
            return await UsuarioDAL.Login(pUsuario);
        }

        public async Task<int> CambiarContrasenia(Usuario pUsuario, string pContraseña)
        {
            return await UsuarioDAL.CambiarContrasenia(pUsuario, pContraseña);
        }

    }
}
