using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NathRestaurant.Ventas.EntidadesDeNegocio
{
    public class Carrito
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Producto")]
        public int IdProducto { get; set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
        public Producto? Producto { get; set; }

        public Cliente? Cliente { get; set; }
    }
}
