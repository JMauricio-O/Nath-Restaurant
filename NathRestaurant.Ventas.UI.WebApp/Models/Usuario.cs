namespace NathRestaurant.Ventas.UI.WebApp.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Carnet { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
    }
    public class UsuarioLogin
    {
        public string Carnet { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
    }
}
