using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.AccesoADatos.Tests
{

    [TestClass()]
    public class UsuarioDALTests
    {
        private static Usuario usuarioInicial = new Usuario { Id = 20, IdRol = 1,Carnet = "12331o", Contrasenia = "vinny123"   };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var usuario = new Usuario();
            usuario.IdRol = usuarioInicial.IdRol;
            usuario.Nombre = "J-Mauricio";
            usuario.Apellido = "Rivera";
            usuario.Contacto = "4589-5434";
            usuario.Carnet = "12345678";
            string password = "vinny123";
            usuario.Contrasenia = password;
            int result = await UsuarioDAL.CrearAsync(usuario);
            Assert.AreNotEqual(0, result);
            usuarioInicial.Id = usuario.Id;
            usuarioInicial.Contrasenia = password;
            usuarioInicial.Carnet = usuario.Carnet;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var usuario = new Usuario();
            usuario.Id = usuarioInicial.Id;
            usuario.IdRol = usuarioInicial.IdRol;
            usuario.Nombre = "sthefany";
            usuario.Apellido = "min";
            usuario.Contacto = "0095-48485";
            usuario.Carnet = "ww3";
            usuario.Estado = (byte)Enums.Estado.ACTIVO;
            int result = await UsuarioDAL.ModificarAsync(usuario);
            Assert.AreNotEqual(0, result);
            usuarioInicial.Carnet = usuario.Carnet;
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var usuario = new Usuario();
            usuario.Id = usuarioInicial.Id;
            var resultUsuario = await UsuarioDAL.ObtenerPorIdAsync(usuario);
            Assert.AreNotEqual(0, resultUsuario.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultUsuarios = await UsuarioDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultUsuarios.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var usuario = new Usuario();
            usuario.IdRol = usuarioInicial.IdRol;
            usuario.Nombre = "s";
            usuario.Apellido = "s";
            usuario.Contacto = "0";
            usuario.Carnet = "2";
            usuario.Top_Aux = 10;
            var resultUsuarios = await UsuarioDAL.BuscarAsync(usuario);
            Assert.AreNotEqual(0, resultUsuarios.Count);
        }

        [TestMethod()]
        public async Task T6BuscarIncluirRolesTest()
        {
            var usuario = new Usuario();
            usuario.IdRol = usuarioInicial.IdRol;
            usuario.Nombre = "s";
            usuario.Apellido = "s";
            usuario.Contacto = "0";
            usuario.Carnet = "2";
            usuario.Estado = 1;
            usuario.Top_Aux = 10;
            var resultUsuarios = await UsuarioDAL.BuscarIncluirRoles(usuario);
            Assert.AreNotEqual(0, resultUsuarios.Count);
            var ultimoUsuario = resultUsuarios.FirstOrDefault();
            Assert.IsTrue(ultimoUsuario.Rol != null && usuario.IdRol == ultimoUsuario.Rol.Id);
        }


        [TestMethod()]
        public async Task T7CambiarContraseniaTest()
        {
            var usuario = new Usuario();
            usuario.Id = usuarioInicial.Id;
            string passwordNueva = "12345678";
            usuario.Contrasenia = passwordNueva;
            var result = await UsuarioDAL.CambiarContrasenia(usuario, usuarioInicial.Contrasenia);
            Assert.AreNotEqual(0, result);
            usuarioInicial.Contrasenia = passwordNueva;
        }

        [TestMethod()]
        public async Task T8LoginAsyncTest()
        {
            var usuario = new Usuario();
            usuario.Carnet = usuarioInicial.Carnet;
            usuario.Contrasenia = usuarioInicial.Contrasenia;
            var resultUsuario = await UsuarioDAL.Login(usuario);
            Assert.AreEqual(usuario.Carnet, resultUsuario.Carnet);
        }


        [TestMethod()]
        public async Task T9EliminarAsyncTest()
        {
            var usuario = new Usuario();
            usuario.Id = usuarioInicial.Id;
            int result = await UsuarioDAL.EliminarAsync(usuario);
            Assert.AreNotEqual(0, result);
        }

    }
}