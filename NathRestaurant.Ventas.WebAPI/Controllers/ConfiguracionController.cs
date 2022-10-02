using Microsoft.AspNetCore.Mvc;
using NathRestaurant.Ventas.EntidadesDeNegocio;
using NathRestaurant.Ventas.LogicaDeNegocio;
using System.Text.Json;

namespace NathRestaurant.Ventas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionController : ControllerBase
    {
        private ConfiguracionesBL _configuracionesBL = new ConfiguracionesBL();

        [HttpGet]
        public async Task<IEnumerable<Configuracion>> Get()
        {
            return await _configuracionesBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Configuracion> Get(int id)
        {
            Configuracion configuracion = new Configuracion();
            configuracion.Id = id;
            return await _configuracionesBL.ObtenerPorIdAsync(configuracion);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Configuracion configuracion)
        {
            try
            {
                await _configuracionesBL.AgregarAsync(configuracion);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Configuracion configuracion)
        {

            if (configuracion.Id == id)
            {
                await _configuracionesBL.ModificarAsync(configuracion);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Configuracion configuracion = new Configuracion();
                configuracion.Id = id;
                await _configuracionesBL.EliminarAsync(configuracion);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Configuracion>> Buscar([FromBody] object pConfiguracion)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strConfiguracion = JsonSerializer.Serialize(pConfiguracion);
            Configuracion configuracion = JsonSerializer.Deserialize<Configuracion>(strConfiguracion, option);
            return await _configuracionesBL.BuscarAsync(configuracion);
        }
    }
}
