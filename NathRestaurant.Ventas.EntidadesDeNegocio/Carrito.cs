using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NathRestaurant.Ventas.EntidadesDeNegocio
{
    public class Carrito
    {
        [Key]
        public string Id { get; set; }

        [ForeignKey("Producto")]
        public int IdProducto { get; set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }

        public Producto? Producto { get; set; }

        public Cliente? Cliente { get; set; }
    }
}
