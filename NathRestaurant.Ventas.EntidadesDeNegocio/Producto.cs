using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NathRestaurant.Ventas.EntidadesDeNegocio
{
    public class Producto
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Categoria")]
        [ForeignKey("Categoria")]
        [Required(ErrorMessage ="{0} es obligatorio")]
        public int IdCategoria { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(75, ErrorMessage = "{0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "{0} es requerido")]
        public string? Nombre { get; set; }

        [Display(Name = "Descripcion")]
        [MinLength(10)]
        [MaxLength(75, ErrorMessage = "La {0} debe tener minimo {1} caracteres y maximos {2} caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? Descripcion { get; set; }

        [Display(Name = "Nombre Imagen")]
        [MaxLength(100, ErrorMessage = "{0} debe tener maximos {1} caracteres")]
        [Required(ErrorMessage = "{0} es requerido")]
        public string? NombreImagen { get; set; }

        [Required]
        public string? RutaImagen { get; set; }

        [Display(Name = "Precio del Producto")]
        [Required(ErrorMessage = "{0} es requerido")]
        public decimal Precio { get; set; }

        public DateTime FechaRegistro { get; set; }

        public byte Estado { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        public Categoria? Categoria { get; set; }
    }
}
