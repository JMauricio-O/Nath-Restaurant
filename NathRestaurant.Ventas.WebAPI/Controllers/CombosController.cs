using Microsoft.AspNetCore.Mvc;
using NathRestaurant.Ventas.EntidadesDeNegocio;
using NathRestaurant.Ventas.LogicaDeNegocio;
using System.Text.Json;

namespace NathRestaurant.Ventas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombosController : ControllerBase
    {
        private CombosBL _combosBL = new CombosBL();

        [HttpGet]
        public async Task<IEnumerable<Combos>> Get()
        {
            return await _combosBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Combos> Get(int id)
        {
            Combos combos = new Combos();
            combos.Id = id;
            return await _combosBL.ObtenerPorIdAsync(combos);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Combos combos)
        {
            try
            {
                await _combosBL.AgregarAsync(combos);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Combos combos)
        {

            if (combos.Id == id)
            {
                await _combosBL.ModificarAsync(combos);
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
                Combos combos = new Combos();
                combos.Id = id;
                await _combosBL.EliminarAsync(combos);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Combos>> Buscar([FromBody] object pCombos)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strCombos = JsonSerializer.Serialize(pCombos);
            Combos combos = JsonSerializer.Deserialize<Combos>(strCombos, option);
            var combosC = await _combosBL.BuscarIncluirProductoAsync(combos);
            combosC.ForEach(c => c.Producto.Combos = null);
            return combosC;
        }
    }
}
