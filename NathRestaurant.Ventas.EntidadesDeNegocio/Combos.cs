using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NathRestaurant.Ventas.EntidadesDeNegocio
{
    public class Combos
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Producto")]
        public int IdProducto { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(75, ErrorMessage = "{0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "{0} es requerido")]
        public string? Nombre { get; set; }

        [Display(Name = "Descripcion")]
        [MaxLength(75, ErrorMessage = "{0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "{0} es requerido")]
        public string? Descripcion { get; set; }

        [Display(Name = "Nombre de Imagen")]
        [MaxLength(75, ErrorMessage = "{0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "{0} es requerido")]
        public string? NombreImagen { get; set; }

        [Display(Name = "Ruta Imagen")]
        [MaxLength(100, ErrorMessage = "{0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "{0} es requerido")]
        public string? RutaImagen { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "{0} es obligatorio")]
        public double Precio { get; set; }

        public DateTime FechaRegistro { get; set; }

        public byte Estado { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        public Producto? Producto { get; set; }
    }
}
