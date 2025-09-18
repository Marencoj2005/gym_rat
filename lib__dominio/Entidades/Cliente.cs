using System.Collections.Generic;

namespace lib__dominio.Entidades
{
    internal class Cliente
    {
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string TipoUsuario { get; set; }
        public bool Activo { get; set; }

        public ICollection<Membresia> Membresias { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
        public ICollection<Asistencia> Asistencias { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<HistorialFisico> Historiales { get; set; }
        public ICollection<DatosFisicos> DatosFisicos { get; set; }

        public UsuarioLogin UsuarioLogin { get; set; }
    }
}
