using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib__dominio.Entidades
{
    internal class Coach
    {
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public string HorarioTrabajo { get; set; }

        public ICollection<Asignado> Asignaciones { get; set; }
    }
}
