using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.UI.WebApp.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(Usuario pUsuario);

        string AuthenticateClient(Cliente pCliente);
    }
}
