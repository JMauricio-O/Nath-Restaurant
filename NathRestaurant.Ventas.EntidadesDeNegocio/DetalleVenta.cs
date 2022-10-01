using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NathRestaurant.Ventas.EntidadesDeNegocio
{
    public class DetalleVenta
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Producto")]
        [Required]
        public int IdProducto { get; set; }

        [Required]
        [DataType("integer")]
        public int Cantidad { get; set; }

        [Required]
        public decimal Subtotal { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        public Producto? Producto { get; set; }

        public List<Venta> Venta { get; set; }
    }
}
