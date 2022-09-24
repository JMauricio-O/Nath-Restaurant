using System.ComponentModel.DataAnnotations;

namespace NathRestaurant.Ventas.EntidadesDeNegocio
{
    public class Configuracion
    {
        [Display(Name = "Nombre del recurso")]
        public string? Recurso { get; set; }

        [Display(Name = "Propiedad del recurso")]
        public string? Propiedad { get; set; }

        [Display(Name = "Valor del recurso")]
        public string? Valor { get; set; }
    }
}
