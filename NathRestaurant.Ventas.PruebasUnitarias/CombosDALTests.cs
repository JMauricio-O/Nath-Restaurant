using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.AccesoADatos.Tests
{
    [TestClass()]
    public class CombosDALTests
    {
        private static Combos comboInicial = new Combos { Id = 23, IdProducto = 1 };

        [TestMethod()]
        public async Task T1AgregarAsyncTest()
        {
            var combos = new Combos();
            combos.IdProducto = comboInicial.IdProducto;
            combos.Nombre = "Gaseosa";
            combos.Descripcion = "gaseosa coca cola sin azucar";
            combos.NombreImagen = "Img Imagen";
            combos.RutaImagen = "wwe";
            combos.Precio = 1.50M;
            int result = await CombosDAL.AgregarAsync(combos);
            Assert.AreNotEqual(0, result);
            comboInicial.Id = combos.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var combos = new Combos();
            combos.Id = comboInicial.Id;
            combos.IdProducto = comboInicial.IdProducto;
            combos.Nombre = "Jugos";
            combos.Descripcion = "gaseosa";
            combos.NombreImagen = "Imagen";
            combos.RutaImagen = "e";
            combos.Precio = 1.75M;
            combos.Estado = (Byte)Enums.Estado.ACTIVO;
            int result = await CombosDAL.ModificarAsync(combos);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var combos = new Combos();
            combos.Id = comboInicial.Id;
            var resultCombos = await CombosDAL.ObtenerPorIdAsync(combos);
            Assert.AreEqual(combos.Id, resultCombos.Id);
        }
        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultCombos = await CombosDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultCombos.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var combos = new Combos();
            combos.IdProducto = comboInicial.IdProducto;
            combos.Nombre = "G";
            combos.Descripcion = "g";
            combos.NombreImagen = "I";
            combos.RutaImagen = "w";
            combos.Precio = 2M;
            combos.Top_Aux = 10;
            var resultCombos = await CombosDAL.BuscarAsync(combos);
            Assert.AreNotEqual(0, resultCombos.Count);
        }

        [TestMethod()]
        public async Task T6BuscarIncluirProductoTest()
        {
            var combos = new Combos();
            combos.IdProducto = comboInicial.IdProducto;
            combos.Nombre = "G";
            combos.Descripcion = "g";
            combos.NombreImagen = "I";
            combos.RutaImagen = "w";
            combos.Precio = 2M;
            combos.Top_Aux = 10;
            var resultCombos = await CombosDAL.BuscarIncluirProductoAsync(combos);
            Assert.AreNotEqual(0, resultCombos.Count);
            var ultimoCombo = resultCombos.FirstOrDefault();
            Assert.IsTrue(ultimoCombo.Producto != null && combos.IdProducto == ultimoCombo.Producto.Id);
        }

        [TestMethod()]
        public async Task T7EliminarAsyncTest()
        {
            var combos = new Combos();
            combos.Id = comboInicial.Id;
            int result = await CombosDAL.EliminarAsync(combos);
            Assert.AreNotEqual(0, result);
        }
    }
}