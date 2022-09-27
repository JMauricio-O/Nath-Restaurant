using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.AccesoADatos.Tests
{
    [TestClass()]
    public class ProductoDALTests
    {
        private static Producto productoInicial = new Producto { Id = 2, IdCategoria = 1 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var producto = new Producto();
            producto.IdCategoria = productoInicial.IdCategoria;
            producto.Nombre = "Gaseosa";
            producto.Descripcion = "gaseosa coca cola sin azucar";
            producto.NombreImagen = "Img Imagen";
            producto.RutaImagen = "wwe";
            producto.Precio = 1.50;
            int result = await ProductoDAL.AgregarAsync(producto);
            Assert.AreNotEqual(0, result);
            productoInicial.Id = producto.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var producto = new Producto();
            producto.Id = productoInicial.Id;
            producto.IdCategoria = productoInicial.IdCategoria;
            producto.Nombre = "Coca Cola";
            int result = await ProductoDAL.ModificarAsync(producto);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var producto = new Producto();
            producto.Id = productoInicial.Id;
            var resultProducto = await ProductoDAL.ObtenerPorIdAsync(producto);
            Assert.AreNotEqual(0, resultProducto.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultProducto = await ProductoDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultProducto.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var producto = new Producto();
            producto.IdCategoria = productoInicial.IdCategoria;
            producto.Nombre = "C";
            producto.Descripcion = "r";
            producto.NombreImagen = "";
            producto.RutaImagen = "R";
            producto.Precio = 1;
            producto.Top_Aux = 10;
            var resultProducto = await ProductoDAL.BuscarAsync(producto);
            Assert.AreNotEqual(0, resultProducto.Count);
        }

        [TestMethod()]
        public async Task T6BuscarIncluirRolesTest()
        {
            var producto = new Producto();
            producto.IdCategoria = productoInicial.IdCategoria;
            producto.Nombre = "C";
            producto.Descripcion = "r";
            producto.NombreImagen = "";
            producto.RutaImagen = "R";
            producto.Precio = 1;
            producto.Top_Aux = 10;
            var resultProducto = await ProductoDAL.BuscarIncluirCategoria(producto);
            Assert.AreNotEqual(0, resultProducto.Count);
            var ultimoProducto = resultProducto.FirstOrDefault();
            Assert.IsTrue(ultimoProducto.Categoria != null && producto.IdCategoria == ultimoProducto.Categoria.Id);
        }

        [TestMethod()]
        public async Task T9EliminarAsyncTest()
        {
            var producto = new Producto();
            producto.Id = productoInicial.Id;
            int result = await ProductoDAL.EliminarAsync(producto);
            Assert.AreNotEqual(0, result);
        }
    }
}