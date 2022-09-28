using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.AccesoADatos.Tests
{
    [TestClass()]
    public class ConfiguracionesDALTests
    {
        private static Configuracion configuracionInicial = new Configuracion { Id = 4 };

        [TestMethod()]
        public async Task T1AgregarAsyncTest()
        {
            var conf = new Configuracion();
            conf.Recurso = "12";
            conf.Propiedad = "ww";
            conf.Valor = "er";
            int result = await ConfiguracionesDAL.AgregarAsync(conf);
            Assert.AreNotEqual(0, result);
            configuracionInicial.Id = conf.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var conf = new Configuracion();
            conf.Id = configuracionInicial.Id;
            conf.Recurso = "122";
            conf.Propiedad = "ww3";
            conf.Valor = "eer";
            int result = await ConfiguracionesDAL.ModificarAsync(conf);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var conf = new Configuracion();
            conf.Id = configuracionInicial.Id;
            var resultConf = await ConfiguracionesDAL.ObtenerPorIdAsync(conf);
            Assert.AreEqual(conf.Id, resultConf.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultConf = await ConfiguracionesDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultConf.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var conf = new Configuracion();
            conf.Recurso = "2";
            conf.Propiedad = "w";
            conf.Valor = "e";
            conf.Top_Aux = 10;
            var resultConf = await ConfiguracionesDAL.BuscarAsync(conf);
            Assert.AreNotEqual(0, resultConf.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var conf = new Configuracion();
            conf.Id = configuracionInicial.Id;
            int result = await ConfiguracionesDAL.EliminarAsync(conf);
            Assert.AreNotEqual(0, result);
        }
    }
}