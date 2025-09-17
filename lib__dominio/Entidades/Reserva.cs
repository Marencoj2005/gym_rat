using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib__dominio.Entidades
{
    internal class Reserva
    {
        public int IdReserva { get; set; }
        public int CedulaCliente { get; set; }
        public int IdClase { get; set; }
        public DateTime FechaReserva { get; set; }
        public string Estado { get; set; }

        public Cliente Cliente { get; set; }
        public Clase Clase { get; set; }
    }
}
