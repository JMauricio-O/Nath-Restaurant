using NathRestaurant.Ventas.AccesoADatos;
using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.LogicaDeNegocio
{
    public class ClienteBL
    {
        public async Task<int> AgregarAsync(Cliente pCliente)
        {
            return await ClienteDAL.AgregarAsync(pCliente);
        }
        public async Task<int> ModificarAsync(Cliente pCliente)
        {
            return await ClienteDAL.ModificarAsync(pCliente);
        }
        public async Task<int> EliminarAsync(Cliente pCliente)
        {
            return await ClienteDAL.EliminarAsync(pCliente);
        }
        public async Task<Cliente> ObtenerPorIdAsync(Cliente pCliente)
        {
            return await ClienteDAL.ObtenerPorIdAsync(pCliente);
        }
        public async Task<List<Cliente>> ObtenerTodosAsync()
        {
            return await ClienteDAL.ObtenerTodosAsync();
        }
        public async Task<List<Cliente>> BuscarAsync(Cliente pCliente)
        {
            return await ClienteDAL.Buscar(pCliente);
        }
        public async Task<Cliente> Login(Cliente pCliente)
        {
            return await ClienteDAL.Login(pCliente);
        }

        public async Task<int> CambiarContrasenia(Cliente pCliente, string pContraseña)
        {
            return await ClienteDAL.CambiarContrasenia(pCliente, pContraseña);
        }
    }
}
