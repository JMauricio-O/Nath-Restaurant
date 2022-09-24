using Microsoft.EntityFrameworkCore;
using NathRestaurant.Ventas.EntidadesDeNegocio;

namespace NathRestaurant.Ventas.AccesoADatos
{
    public class DBContext : DbContext
    {
        public DbSet<Carrito>? Carrito { get; set; }
        public DbSet<Categoria>? Categoria { get; set; }
        public DbSet<Cliente>? Cliente { get; set; }
        public DbSet<Combos>? Combos { get; set; }
        public DbSet<Configuracion>? Configuracion { get; set; }
        public DbSet<DetalleVenta>? DetalleVenta { get; set; }
        public DbSet<Producto>? Producto { get; set; }
        public DbSet<Rol>? Rol { get; set; }
        public DbSet<Usuario>? Usuario { get; set; }
        public DbSet<Venta>? Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=VINNY;Initial Catalog=NathRestaurant;Integrated Security=True");
        }
    }
}
