using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NathRestaurant.Ventas.EntidadesDeNegocio;
using NathRestaurant.Ventas.LogicaDeNegocio;
using System.Text.Json;

namespace NathRestaurant.Ventas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentaController : ControllerBase
    {
        private DetalleVentaBL _detalleVentaBL = new DetalleVentaBL();

        [HttpGet]
        public async Task<IEnumerable<DetalleVenta>> Get()
        {
            return await _detalleVentaBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<DetalleVenta> Get(int id)
        {
            DetalleVenta detalleVenta = new DetalleVenta();
            detalleVenta.Id = id;
            return await _detalleVentaBL.ObtenerPorIdAsync(detalleVenta);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DetalleVenta detalleVenta)
        {
            try
            {
                await _detalleVentaBL.AgregarAsync(detalleVenta);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] DetalleVenta detalleVenta )
        {

            if (detalleVenta.Id == id)
            {
                await _detalleVentaBL.ModificarAsync(detalleVenta);
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
                DetalleVenta detalleVenta = new DetalleVenta();
                detalleVenta.Id = id;
                await _detalleVentaBL.EliminarAsync(detalleVenta);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<DetalleVenta>> Buscar([FromBody] object pDetalleVenta)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strDetalleVenta = JsonSerializer.Serialize(pDetalleVenta);
            DetalleVenta detalleVenta = JsonSerializer.Deserialize<DetalleVenta>(strDetalleVenta, option);
            var detallesVentas = await _detalleVentaBL.BuscarIncluirProducto(detalleVenta);
            detallesVentas.ForEach(d => d.Producto.DetalleVentas = null);
            return detallesVentas;
        }
    }
}
