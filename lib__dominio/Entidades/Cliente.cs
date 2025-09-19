using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lib__dominio.Entidades
{
    public class Cliente
    {
        [Key]
        public int Cedula { get; set; }
        public String? Nombre { get; set; }
        public String? Email { get; set; }
        public String? TipoUsuario { get; set; }
        public bool Activo { get; set; }

        public ICollection<Membresia> Membresias { get; set; }
        // public ICollection<Reserva> Reservas { get; set; }
        public ICollection<Asistencia> Asistencias { get; set; } = new List<Asistencia>();
        public ICollection<Reserva> Reservas { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<HistorialFisico> HistorialFisicos { get; set; } = new List<HistorialFisico>();
        public ICollection<DatosFisicos> DatosFisicos { get; set; }

        public ICollection<Pago> Pagos { get; set; } = new List<Pago>();

        public UsuarioLogin UsuarioLogin { get; set; }
    }
}
