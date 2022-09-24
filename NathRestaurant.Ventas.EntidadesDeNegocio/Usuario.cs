using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NathRestaurant.Ventas.EntidadesDeNegocio
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Rol")]
        [ForeignKey("Rol")]
        [Required(ErrorMessage ="{0}es requerido")]
        public int IdRol { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(75, ErrorMessage = "{0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string? Nombre { get; set; }

        [Display(Name = "Apellido")]
        [MaxLength(75, ErrorMessage = "{0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string? Apellido { get; set; }

        [Display(Name = "Contacto")]
        [MaxLength(75, ErrorMessage = "{0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string? Contacto { get; set; }

        [Display(Name = "Carnet")]
        [MaxLength(75, ErrorMessage = "{0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string? Carnet { get; set; }

        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [MaxLength(32, ErrorMessage = "{0} debe tener minimo {1} y maximo {2} caracteres")]
        [Required(ErrorMessage = "{0} es obligatoria")]
        public string? Contrasenia { get; set; }

        [NotMapped]
        [Display(Name = "Confirmar Contraseña")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [MaxLength(32, ErrorMessage = "{0} debe tener minimo {1} y maximo {2} caracteres")]
        [Required(ErrorMessage = "{0} es obligatoria")]
        [Compare("Contrasenia", ErrorMessage = "Contraseñas deben ser iguales")]
        public string? Confirmar_Contrasenia { get; set; }

        public DateTime FechaRegistro { get; set; }

        public byte Estado { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        public Rol? Rol { get; set; }

    }
}
