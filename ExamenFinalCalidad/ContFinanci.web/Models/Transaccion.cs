using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContFinanci.web.Models
{
    public class Transaccion
    {
        public int TransaccionId { get; set; }
        public string Cuenta { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public double Monto { get; set; }
        public bool Gasto { get; set; }
    }
}
