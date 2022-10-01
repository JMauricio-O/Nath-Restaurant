using Microsoft.AspNetCore.Mvc;
using NathRestaurant.Ventas.EntidadesDeNegocio;
using NathRestaurant.Ventas.LogicaDeNegocio;
using System.Text.Json;

namespace NathRestaurant.Ventas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private CarritoBL _carritoBL = new CarritoBL;
        [HttpGet]
        public async Task<IEnumerable<Carrito>> Get()
        {
            return await _carritoBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Carrito> Get(int id)
        {
            Carrito carrito = new Carrito();
            carrito.Id = id;
            return await _carritoBL.ObtenerPorIdAsync(carrito);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Carrito carrito)
        {
            try
            {
                await _carritoBL.AgregarAsync(carrito);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Carrito carrito)
        {

            if (carrito.Id == id)
            {
                await _carritoBL.ModificarAsync(carrito);
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
                Carrito carrito = new Carrito();
                carrito.Id = id;
                await _carritoBL.EliminarAsync(carrito);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Carrito>> Buscar([FromBody] object pCarrito)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strCarrito = JsonSerializer.Serialize(pCarrito);
            Carrito carrito = JsonSerializer.Deserialize<Carrito>(strCarrito, option);
            var carritosC = await _carritoBL.BuscarTodosAsync(carrito);
            carritosC.ForEach(c => c.Producto.Carritos = null);
            carritosC.ForEach(c => c.Cliente.Carritos = null);
            return carritosC;
        }
    }
}
