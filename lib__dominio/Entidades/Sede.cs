using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib__dominio.Entidades
{
    internal class Sede
    {
        public int IdSede { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }

        public ICollection<Clase> Clases { get; set; }
        public ICollection<Empleado> Empleados { get; set; }
    }
}
