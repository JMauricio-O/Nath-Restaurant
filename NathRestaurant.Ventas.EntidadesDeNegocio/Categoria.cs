﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NathRestaurant.Ventas.EntidadesDeNegocio
{
    
        public class Categoria
        {

            [Key]
            public int Id { get; set; }

            [Display(Name = "Nombre Categoria")]
            [StringLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
            [Required(ErrorMessage = "El campo {0} es requerido")]
            public string? Nombre { get; set; }

            [NotMapped]
            public int Top_Aux { get; set; }

            public List<Producto>? Productos { get; set; }
        }
}
