using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.AccesoADatos.Tests
{
    [TestClass()]
    public class RolDALTests
    {
        public static Rol rolInicial = new Rol { Id = 4 };

        [TestMethod()]
        public async Task T1AgregarAsyncTest()
        {
            var rol = new Rol();
            rol.Nombre = "AdministradorGeneral";
            int result = await RolDAL.AgregarAsync(rol);
            Assert.AreNotEqual(0, result);
            rolInicial.Id = rol.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var rol = new Rol();
            rol.Id = rolInicial.Id;
            rol.Nombre = "Admin";
            int result = await RolDAL.ModificarAsync(rol);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var rol = new Rol();
            rol.Id = rolInicial.Id;
            var resultRol = await RolDAL.ObtenerPorIdAsync(rol);
            Assert.AreEqual(rol.Id, resultRol.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultRoles = await RolDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultRoles.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var rol = new Rol();
            rol.Nombre = "a";
            rol.Top_Aux = 10;
            var resultRoles = await RolDAL.BuscarAsync(rol);
            Assert.AreNotEqual(0, resultRoles.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var rol = new Rol();
            rol.Id = rolInicial.Id;
            int result = await RolDAL.EliminarAsync(rol);
            Assert.AreNotEqual(0, result);
        }

    }
}