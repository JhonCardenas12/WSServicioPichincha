using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSServicioPichincha.Domain.Entities
{
    public class Cuenta
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int CuentaId { get; set; }
        [Required(ErrorMessage = "Por favor ingrese el Número de Cuenta.")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "Por favor ingrese el Tipo de Cuenta.")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Por favor ingrese el Saldo Inicial.")]
        public decimal SaldoInicial { get; set; }
        [Required(ErrorMessage = "Por favor ingrese el Estado.")]
        public bool Estado { get; set; }
        [Required()]
        public int ClienteId { get; set; }
    }
}
