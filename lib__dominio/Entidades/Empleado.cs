using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib__dominio.Entidades
{
    internal class Empleado
    {
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; } // Recepcion, Fisioterapeuta, etc.
        public int SedeId { get; set; }

        public Sede Sede { get; set; }
    }
}
