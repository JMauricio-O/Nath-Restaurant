using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NathRestaurant.Ventas.EntidadesDeNegocio
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre Rol")]
        [MaxLength(50, ErrorMessage = "{0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string? Nombre { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        public List<Usuario>? Usuario { get; set; }
    }
}
