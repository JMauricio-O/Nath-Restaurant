using Microsoft.AspNetCore.Mvc;
using NathRestaurant.Ventas.EntidadesDeNegocio;
using NathRestaurant.Ventas.LogicaDeNegocio;
using System.Text.Json;

namespace NathRestaurant.Ventas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private ProductoBL _productoBL = new ProductoBL();

        [HttpGet]
        public async Task<IEnumerable<Producto>> Get()
        {
            return await _productoBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Producto> Get(int id)
        {
            Producto producto = new Producto();
            producto.Id = id;
            return await _productoBL.ObtenerPorIdAsync(producto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Producto producto)
        {
            try
            {
                await _productoBL.AgregarAsync(producto);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Producto producto)
        {

            if (producto.Id == id)
            {
                await _productoBL.ModificarAsync(producto);
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
                Producto producto = new Producto();
                producto.Id = id;
                await _productoBL.EliminarAsync(producto);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Producto>> Buscar([FromBody] object pProducto)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strProducto = JsonSerializer.Serialize(pProducto);
            Producto producto = JsonSerializer.Deserialize<Producto>(strProducto, option);
            var productos = await _productoBL.BuscarIncluirCategoriaAsync(producto);
            productos.ForEach(p => p.Categoria.Productos = null);
            return productos;
        }
    }
}
