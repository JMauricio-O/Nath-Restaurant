using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.AccesoADatos.Tests
{
    [TestClass()]
    public class ClienteDALTests
    {
        private static Cliente clienteInicial = new Cliente { Id = 7, Correo = "prueba@gmail.com", Contrasenia = "12345678" };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var cliente = new Cliente();
            cliente.Nombre = "Aura";
            cliente.Apellido = "Minero";
            cliente.Correo = "prwuebas@gmail.com";
            string password = "12345678";
            cliente.Contrasenia = password;
            int result = await ClienteDAL.AgregarAsync(cliente);
            Assert.AreNotEqual(0, result);
            clienteInicial.Id = cliente.Id;
            clienteInicial.Contrasenia = password;
            clienteInicial.Correo = cliente.Correo;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var cliente = new Cliente();
            cliente.Id = clienteInicial.Id;
            cliente.Nombre = "AuraSth";
            cliente.Apellido = "Peña Minero";
            cliente.Correo = "prueba011@gmail.com";
            int result = await ClienteDAL.ModificarAsync(cliente);
            Assert.AreNotEqual(0, result);
            clienteInicial.Correo = cliente.Correo;
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var cliente = new Cliente();
            cliente.Id = clienteInicial.Id;
            var resultCliente = await ClienteDAL.ObtenerPorIdAsync(cliente);
            Assert.AreEqual(cliente.Id, resultCliente.Id);
        }
        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultCliente = await ClienteDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultCliente.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var cliente = new Cliente();
            cliente.Nombre = "A";
            cliente.Apellido = "M";
            cliente.Correo = "p";
            cliente.Top_Aux = 10;
            var resultCliente = await ClienteDAL.Buscar(cliente);
            Assert.AreNotEqual(0, resultCliente.Count);
        }

        [TestMethod()]
        public async Task T7CambiarContraseniaTest()
        {
            var cliente = new Cliente();
            cliente.Id = clienteInicial.Id;
            string passwordNueva = "qwertyuiop";
            cliente.Contrasenia = passwordNueva;
            var result = await ClienteDAL.CambiarContrasenia(cliente, clienteInicial.Contrasenia);
            Assert.AreNotEqual(0, result);
            clienteInicial.Contrasenia = passwordNueva;
        }

        [TestMethod()]
        public async Task T8LoginAsyncTest()
        {
            var cliente = new Cliente();
            cliente.Correo = clienteInicial.Correo;
            cliente.Contrasenia = clienteInicial.Contrasenia;
            var resultCliente = await ClienteDAL.Login(cliente);
            Assert.AreEqual(cliente.Correo, resultCliente.Correo);
        }


      
    }
}