using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib__dominio.Entidades
{
    public class Clase
    {
        public int IdClase { get; set; }
        public String? NombreClase { get; set; }
        public TimeSpan Horario { get; set; }
        public int CupoMaximo { get; set; }
        public int SedeId { get; set; }

        public Sede Sede { get; set; }
        public ICollection<Asignado> Asignaciones { get; set; }
       // public ICollection<Reserva> Reservas { get; set; }
        public ICollection<Asistencia> Asistencias { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
