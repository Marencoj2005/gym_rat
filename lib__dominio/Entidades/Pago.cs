using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib__dominio.Entidades
{
    internal class Pago
    {
        public int IdPago { get; set; }
        public int CedulaCliente { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; } // Efectivo, Tarjeta, etc.

        public Cliente Cliente { get; set; }
    }
}
