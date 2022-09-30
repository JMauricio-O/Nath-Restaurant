using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.AccesoADatos.Tests
{
    [TestClass()]
    public class DetalleVentaDALTests
    {
        private static DetalleVenta dVentaInicial = new DetalleVenta { Id = 8, IdProducto = 1 };

        [TestMethod()]
        public async Task T1AgregarAsyncTest()
        {
            var dVenta = new DetalleVenta();
            dVenta.IdProducto = dVentaInicial.IdProducto;
            dVenta.Cantidad = 2;
            dVenta.Subtotal = 6M;
            int result = await DetalleVentaDAL.AgregarAsync(dVenta);
            Assert.AreNotEqual(0, result);
            dVentaInicial.Id = dVenta.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var dVenta = new DetalleVenta();
            dVenta.Id = dVentaInicial.Id;
            dVenta.IdProducto = dVentaInicial.IdProducto;
            dVenta.Cantidad = 1;
            dVenta.Subtotal = 2.5M;
            int result = await DetalleVentaDAL.ModificarAsync(dVenta);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var dVenta = new DetalleVenta();
            dVenta.Id = dVentaInicial.Id;
            var resultdVenta = await DetalleVentaDAL.ObtenerPorIdAsync(dVenta);
            Assert.AreEqual(dVenta.Id, resultdVenta.Id);
        }
        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultdVenta = await DetalleVentaDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultdVenta.Count);
        }
        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var dVenta = new DetalleVenta();
            dVenta.IdProducto = dVentaInicial.IdProducto;
            dVenta.Cantidad = 2;
            dVenta.Subtotal = 4M;
            dVenta.Top_Aux = 10;
            var resultdVenta = await DetalleVentaDAL.BuscarAsync(dVenta);
            Assert.AreNotEqual(0, resultdVenta.Count);
        }

        [TestMethod()]
        public async Task T6BuscarIncluirProductoTest()
        {
            var dVenta = new DetalleVenta();
            dVenta.IdProducto = dVentaInicial.IdProducto;
            dVenta.Cantidad = 2;
            dVenta.Subtotal = 4M;
            dVenta.Top_Aux = 10;
            var resultdVenta = await DetalleVentaDAL.BuscarIncluirProducto(dVenta);
            Assert.AreNotEqual(0, resultdVenta.Count);
            var ultimadVenta = resultdVenta.FirstOrDefault();
            Assert.IsTrue(ultimadVenta.Producto != null && dVenta.IdProducto == ultimadVenta.Producto.Id);
        }

        [TestMethod()]
        public async Task T7EliminarAsyncTest()
        {
            var dVenta = new DetalleVenta();
            dVenta.Id = dVentaInicial.Id;
            int result = await DetalleVentaDAL.EliminarAsync(dVenta);
            Assert.AreNotEqual(0, result);
        }
    }
}