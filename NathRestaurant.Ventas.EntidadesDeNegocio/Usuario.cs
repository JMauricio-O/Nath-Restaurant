using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NathRestaurant.Ventas.EntidadesDeNegocio
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Rol")]
        public int IdRol { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50,ErrorMessage ="{0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage ="{0} es obligatorio")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        [MaxLength(50, ErrorMessage = "{0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string Apellido { get; set; }

        [Display(Name = "Contacto")]
        [MaxLength(50, ErrorMessage = "{0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string Contacto { get; set; }

        [Display(Name = "Carnet")]
        [MaxLength(50, ErrorMessage = "{0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string Carnet { get; set; }


        public string Contrasenia { get; set; }

        public Rol Rol { get; set; }

    }
}
