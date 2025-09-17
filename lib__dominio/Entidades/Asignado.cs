using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib__dominio.Entidades
{
    internal class Asignado
    {
        public int CedulaCoach { get; set; }
        public int IdClase { get; set; }

        public Coach Coach { get; set; }
        public Clase Clase { get; set; }
    }
}
