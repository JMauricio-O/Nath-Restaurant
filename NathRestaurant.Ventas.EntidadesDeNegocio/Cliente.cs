using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NathRestaurant.Ventas.EntidadesDeNegocio
{
    public class Cliente
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(75, ErrorMessage = "{0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string? Nombre { get; set; }

        [Display(Name = "Apellido")]
        [MaxLength(75, ErrorMessage = "{0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string? Apellido { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo")]
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string? Correo { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [MinLength(8)]
        [MaxLength(32, ErrorMessage = "{0} debe tener minimo {1} y maximo {2} caracteres")]
        [Required(ErrorMessage = "{0} es obligatoria")]
        public string? Contrasenia { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [MinLength(8)]
        [MaxLength(32, ErrorMessage = "{0} debe tener minimo {1} y maximo {2} caracteres")]
        [Required(ErrorMessage = "{0} es obligatoria")]
        [Compare("Contrasenia", ErrorMessage = "Contraseña deben ser iguales")]
        public string? Confirmar_Contrasenia { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        public DateTime FechaRegistro { get; set; }

        public List<Carrito> Carritos { get; set; }

        public List<Venta> Ventas { get; set; }
    }
}
