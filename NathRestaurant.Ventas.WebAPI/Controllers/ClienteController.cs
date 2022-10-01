using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NathRestaurant.Ventas.EntidadesDeNegocio;
using NathRestaurant.Ventas.LogicaDeNegocio;
using NathRestaurant.Ventas.UI.WebApp.Auth;
using System.Text.Json;

namespace NathRestaurant.Ventas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private ClienteBL _clienteBL = new ClienteBL();

        private readonly IJwtAuthenticationService authService;

        public ClienteController(IJwtAuthenticationService pAuthService)
        {
            authService = pAuthService;
        }

        [HttpGet]
        public async Task<IEnumerable<Cliente>> Get()
        {
            return await _clienteBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Cliente> Get(int id)
        {
            Cliente cliente = new Cliente();
            cliente.Id = id;
            return await _clienteBL.ObtenerPorIdAsync(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Cliente cliente)
        {
            try
            {
                await _clienteBL.AgregarAsync(cliente);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pCliente)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strCliente = JsonSerializer.Serialize(pCliente);
            Cliente cliente = JsonSerializer.Deserialize<Cliente>(strCliente, option);
            if (cliente.Id == id)
            {
                await _clienteBL.ModificarAsync(cliente);
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
                Cliente cliente = new Cliente();
                cliente.Id = id;
                await _clienteBL.EliminarAsync(cliente);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Cliente>> Buscar([FromBody] object pCliente)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strCliente = JsonSerializer.Serialize(pCliente);
            Cliente cliente = JsonSerializer.Deserialize<Cliente>(strCliente, option);
            return await _clienteBL.BuscarAsync(pCliente);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] object pCliente)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strCliente = JsonSerializer.Serialize(pCliente);
            Cliente cliente = JsonSerializer.Deserialize<Cliente>(strCliente, option);
            Cliente cliente_auth = await _clienteBL.Login(cliente);
            if (cliente_auth != null && cliente_auth.Id > 0 && cliente.Correo == cliente_auth.Correo)
            {
                var token = authService.AuthenticateClient(cliente_auth);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("CambiarContrasenia")]
        public async Task<ActionResult> CambiarPassword([FromBody] Object pCliente)
        {
            try
            {
                var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                string strCliente = JsonSerializer.Serialize(pCliente);
                Cliente cliente = JsonSerializer.Deserialize<Cliente>(strCliente, option);
                await _clienteBL.CambiarContrasenia(cliente, cliente.Confirmar_Contrasenia);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
