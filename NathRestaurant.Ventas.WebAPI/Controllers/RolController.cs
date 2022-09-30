using Microsoft.AspNetCore.Mvc;
using NathRestaurant.Ventas.EntidadesDeNegocio;
using NathRestaurant.Ventas.LogicaDeNegocio;
using System.Text.Json;

namespace NathRestaurant.Ventas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private RolBL _rolBL = new RolBL();

        [HttpGet]
        public async Task<IEnumerable<Rol>> Get()
        {
            return await _rolBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Rol> Get(int id)
        {
            Rol rol = new Rol();
            rol.Id = id;
            return await _rolBL.ObtenerPorIdAsync(rol);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Rol rol)
        {
            try
            {
                await _rolBL.AgregarAsync(rol);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Rol rol)
        {

            if (rol.Id == id)
            {
                await _rolBL.ModificarAsync(rol);
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
                Rol rol = new Rol();
                rol.Id = id;
                await _rolBL.EliminarAsync(rol);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Rol>> Buscar([FromBody] object pRol)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strRol = JsonSerializer.Serialize(pRol);
            Rol rol = JsonSerializer.Deserialize<Rol>(strRol, option);
            return await _rolBL.BuscarAsync(rol);
        }
    }
}
