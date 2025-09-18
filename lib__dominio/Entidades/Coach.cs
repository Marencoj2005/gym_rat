using System.Collections.Generic;

namespace lib__dominio.Entidades
{
    public class Coach
    {
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public string HorarioTrabajo { get; set; }

        public ICollection<Asignado> Asignaciones { get; set; }
    }
}