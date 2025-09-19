using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lib__dominio.Entidades
{
    public class Coach
    {
        [Key]
        public int Cedula { get; set; }
        public String? Nombre { get; set; }
        public String? Especialidad { get; set; }
        public String? HorarioTrabajo { get; set; }

        public ICollection<Asignado> Asignaciones { get; set; }
    }
}