using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NathRestaurant.Ventas.EntidadesDeNegocio
{

    public class Venta
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("DetalleVenta")]
        [Required]
        public int IdDetalleVenta { get; set; }

        [ForeignKey("Cliente")]
        [Required]
        public int IdCliente { get; set; }

        [Display(Name = "Contacto")]
        [MaxLength(50, ErrorMessage = "{0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string? Contacto { get; set; }

        [Display(Name = "Total Producto")]
        [Required(ErrorMessage = "{0} es obligatorio")]
        public double TotalProducto { get; set; }

        [Display(Name = "Direccion")]
        [MaxLength(75, ErrorMessage = "{0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "{0} es obligatorio")]
        public string? Direccion { get; set; }

        public double IdTransaccion { get; set; }

        public double MontoTotal { get; set; }

        public DateTime FechaRegistro { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        public Cliente? Cliente { get; set; }

        public DetalleVenta? DetalleVenta { get; set; }
    }
}
