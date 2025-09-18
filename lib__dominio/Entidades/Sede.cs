using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib__dominio.Entidades
{
    public class Sede
    {
        public int IdSede { get; set; }
        public String? Nombre { get; set; }
        public String? Ubicacion { get; set; }

        public ICollection<Clase> Clases { get; set; }
        public ICollection<Empleado> Empleados { get; set; }
    }
}
