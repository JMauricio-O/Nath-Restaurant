using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.AccesoADatos.Tests
{
    [TestClass()]
    public class VentaDALTests
    {
        private static Venta ventaInicial = new Venta { Id = 2, IdCliente =7 , IdDetalleVenta = 8 };

        [TestMethod()]
        public async Task T1AgregarAsyncTest()
        {
            var venta = new Venta();
            venta.IdCliente = ventaInicial.IdCliente;
            venta.IdDetalleVenta = ventaInicial.IdDetalleVenta;
            venta.Contacto = "3984-2323";
            venta.TotalProducto = 2;
            venta.Direccion = "sonsonate";
            venta.IdTransaccion = 2M;
            venta.MontoTotal = 12.8M;
            int result = await VentaDAL.AgregarAsync(venta);
            Assert.AreNotEqual(0, result);
            ventaInicial.Id = venta.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var venta = new Venta();
            venta.Id = ventaInicial.Id;
            venta.IdCliente = ventaInicial.IdCliente;
            venta.IdDetalleVenta = ventaInicial.IdDetalleVenta;
            venta.Contacto = "00-2323";
            venta.TotalProducto = 2M;
            venta.Direccion = "acajutla";
            venta.IdTransaccion = 2M;
            venta.MontoTotal = 8M;
            int result = await VentaDAL.ModificarAsync(venta);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var venta = new Venta();
            venta.Id = ventaInicial.Id;
            var resultVenta = await VentaDAL.ObtenerPorIdAsync(venta);
            Assert.AreEqual(venta.Id, resultVenta.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultVenta = await VentaDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultVenta.Count);
        }


        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var venta = new Venta();
            venta.IdCliente = ventaInicial.IdCliente;
            venta.IdDetalleVenta = ventaInicial.IdDetalleVenta;
            venta.Contacto = "6";
            venta.TotalProducto = 6M;
            venta.Direccion = "m";
            venta.IdTransaccion = 3M;
            venta.MontoTotal = 12M;
            venta.Top_Aux = 10;
            var resultVenta = await VentaDAL.BuscarAsync(venta);
            Assert.AreNotEqual(0, resultVenta.Count);
        }

        [TestMethod()]
        public async Task T6BuscarIncluirTodosTest()
        {
            var venta = new Venta();
            venta.IdCliente = ventaInicial.IdCliente;
            venta.IdDetalleVenta = ventaInicial.IdDetalleVenta;
            venta.Contacto = "6";
            venta.TotalProducto = 6M;
            venta.Direccion = "m";
            venta.IdTransaccion = 3M;
            venta.MontoTotal = 12M;
            venta.Top_Aux = 10;
            var resultVenta = await VentaDAL.BuscarIncluirTodosAsync(venta);
            Assert.AreNotEqual(0, resultVenta.Count);
            var ultimaVenta = resultVenta.FirstOrDefault();
            Assert.IsTrue(ultimaVenta.DetalleVenta != null && venta.IdDetalleVenta == ultimaVenta.DetalleVenta.Id &&
                ultimaVenta.Cliente != null && venta.IdCliente == ultimaVenta.Cliente.Id);
        }

        [TestMethod()]
        public async Task T7EliminarAsyncTest()
        {
            var venta = new Venta();
            venta.Id = ventaInicial.Id;
            int result = await VentaDAL.EliminarAsync(venta);
            Assert.AreNotEqual(0, result);
        }
    }
}