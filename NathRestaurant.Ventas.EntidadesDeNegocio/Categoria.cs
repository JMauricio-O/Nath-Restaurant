﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NathRestaurant.Ventas.EntidadesDeNegocio
{

    public class Categoria
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre Categoria")]
        [StringLength(50, ErrorMessage = "{0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "{0} es requerido")]
        public string? Nombre { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        public List<Producto>? Productos { get; set; }
    }
}
