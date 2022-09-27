using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NathRestaurant.Ventas.EntidadesDeNegocio
{
    public class Configuracion
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre del recurso")]
        [MaxLength(50)]
        [Required(ErrorMessage ="{0} es obligatorio")]
        public string? Recurso { get; set; }

        [Display(Name = "Propiedad del recurso")]
        [MaxLength(50)]
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string? Propiedad { get; set; }

        [Display(Name = "Valor del recurso")]
        [MaxLength(60)]
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string? Valor { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
    }
}
