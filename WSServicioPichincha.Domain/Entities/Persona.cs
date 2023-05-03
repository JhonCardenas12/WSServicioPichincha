using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSServicioPichincha.Domain.Entities
{
    public class Persona
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int PersonaId { get; set; }
        [Required(ErrorMessage = "Por favor ingrese el nombre completo.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Por favor ingrese el Genero.")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "Por favor ingrese la Edad.")]
        public int Edad { get; set; }
        [Required(ErrorMessage = "Por favor ingrese la Identificacion.")]
        public string Identificacion { get; set; }
        [Required(ErrorMessage = "Por favor ingrese la Direccion.")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Por favor ingrese la Telefono.")]
        public int Telefono { get; set; }
    }
}
