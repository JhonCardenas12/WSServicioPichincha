using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSServicioPichincha.Domain.Entities
{
    public class MovimientosDetalle
    {
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public int NumeroCuenta { get; set; }
        public string Tipo { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public decimal Movimiento { get; set; }
        public decimal SaldoDisponible { get; set; }
    }
}
