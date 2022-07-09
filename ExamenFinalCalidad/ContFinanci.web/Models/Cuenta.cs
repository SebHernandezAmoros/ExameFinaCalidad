using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContFinanci.web.Models
{
    public class Cuenta
    {
        public int CuentaId { get; set; }
        public string Nombre { get; set; }
        public bool Propio { get; set; }
        public double SaldoInicial { get; set; }
        public bool Dolares { get; set; }
    }
}
