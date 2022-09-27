using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.AccesoADatos.Tests
{
    [TestClass()]
    public class CategoriaDALTests
    {
        private static Categoria categoriaInicial = new Categoria { Id = 2 };

        [TestMethod()]
        public async Task T1AgregarAsyncTest()
        {
            var categoria = new Categoria();
            categoria.Nombre = "Postre";
            int result = await CategoriaDAL.AgregarAsync(categoria);
            Assert.AreNotEqual(0, result);
            categoriaInicial.Id = categoria.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var categoria = new Categoria();
            categoria.Id = categoriaInicial.Id;
            categoria.Nombre = "Postres";
            int result = await CategoriaDAL.ModificarAsync(categoria);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var categoria = new Categoria();
            categoria.Id = categoriaInicial.Id;
            var resulCategoria = await CategoriaDAL.ObtenerPorIdAsync(categoria);
            Assert.AreEqual(categoria.Id, resulCategoria.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resulCategoria = await CategoriaDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resulCategoria.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var categoria = new Categoria();
            categoria.Nombre = "a";
            categoria.Top_Aux = 10;
            var resulCategoria = await CategoriaDAL.BuscarAsync(categoria);
            Assert.AreNotEqual(0, resulCategoria.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var categoria = new Categoria();
            categoria.Id = categoriaInicial.Id;
            int result = await CategoriaDAL.EliminarAsync(categoria);
            Assert.AreNotEqual(0, result);
        }
    }
}