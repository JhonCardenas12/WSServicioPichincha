using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSServicioPichincha.Domain.Entities
{
    public class Movimientos
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int MovimientosId { get; set; }
        [Required(ErrorMessage = "Por favor ingrese Fecha.")]
        public DateTime Fecha { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string? Tipo { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el Valor.")]
        public decimal Valor { get; set; }
        [HiddenInput(DisplayValue = false)]
        public decimal Saldo { get; set; }
        [Required()]
        public int CuentaId { get; set; }

    }
}
