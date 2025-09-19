using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using lib__dominio.Entidades;

namespace lib__repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Cliente>? Clientes { get; set; }
        DbSet<Clase>? Clases { get; set; }
        DbSet<Coach>? Coaches { get; set; }
        DbSet<Membresia>? Membresias { get; set; }
        DbSet<Plan>? Planes { get; set; }
        DbSet<Reserva>? Reservas { get; set; }
        DbSet<Asistencia>? Asistencias { get; set; }
        DbSet<Empleado>? Empleados { get; set; }
        DbSet<Sede>? Sedes { get; set; }
        DbSet<Feedback>? Feedbacks { get; set; }
        DbSet<HistorialFisico>? Historiales { get; set; }
        DbSet<DatosFisicos>? DatosFisicos { get; set; }
        DbSet<Pago>? Pagos { get; set; }
        DbSet<UsuarioLogin>? UsuariosLogin { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}