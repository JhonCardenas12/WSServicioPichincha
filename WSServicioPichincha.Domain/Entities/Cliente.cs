using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSServicioPichincha.Domain.Entities
{
    public class Cliente
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Por favor ingrese la contraseña.")]
        public int Contraseña { get; set; }
        [Required(ErrorMessage = "Por favor ingrese el Estado.")]
        public bool Estado { get; set; }
        [Required()]
        public int PersonaId { get; set; }
    }
}
