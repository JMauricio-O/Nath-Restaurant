using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NathRestaurant.Ventas.EntidadesDeNegocio;
using NathRestaurant.Ventas.LogicaDeNegocio;
using System.Text.Json;

namespace NathRestaurant.Ventas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private CategoriaBL _CategoriaBL = new CategoriaBL();

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Categoria>> Get()
        {
            return await _CategoriaBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Categoria> Get(int id)
        {
            Categoria categoria = new Categoria();
            categoria.Id = id;
            return await _CategoriaBL.ObtenerPorIdAsync(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Categoria categoria)
        {
            try
            {
                await _CategoriaBL.AgregarAsync(categoria);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Categoria categoria)
        {

            if (categoria.Id == id)
            {
                await _CategoriaBL.ModificarAsync(categoria);
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
                Categoria categoria = new Categoria();
                categoria.Id = id;
                await _CategoriaBL.EliminarAsync(categoria);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Categoria>> Buscar([FromBody] object pCategoria)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strCategoria = JsonSerializer.Serialize(pCategoria);
            Categoria categoria = JsonSerializer.Deserialize<Categoria>(strCategoria, option);
            return await _CategoriaBL.BuscarAsync(categoria);
        }
    }
}
