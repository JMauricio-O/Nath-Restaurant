using Microsoft.AspNetCore.Mvc;
using NathRestaurant.Ventas.EntidadesDeNegocio;
using NathRestaurant.Ventas.LogicaDeNegocio;
using System.Text.Json;

namespace NathRestaurant.Ventas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private VentaBL _ventaBL = new VentaBL();

        [HttpGet]
        public async Task<IEnumerable<Venta>> Get()
        {
            return await _ventaBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Venta> Get(int id)
        {
            Venta venta = new Venta();
            venta.Id = id;
            return await _ventaBL.ObtenerPorIdAsync(venta);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Venta venta)
        {
            try
            {
                await _ventaBL.AgregarAsync(venta);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Venta venta)
        {

            if (venta.Id == id)
            {
                await _ventaBL.ModificarAsync(venta);
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
                Venta venta = new Venta();
                venta.Id = id;
                await _ventaBL.EliminarAsync(venta);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Venta>> Buscar([FromBody] object pVenta)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strVenta = JsonSerializer.Serialize(pVenta);
            Venta venta = JsonSerializer.Deserialize<Venta>(strVenta, option);
            var ventas = await _ventaBL.BuscarIncluirTodosAsync(venta);
            ventas.ForEach(v => v.DetalleVenta.Venta = null);
            ventas.ForEach(v => v.Cliente.Ventas = null);
            return ventas;
        }
    }
}
