using lib__repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib__repositorios.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<Clase>? Clases { get; set; }
        public DbSet<Coach>? Coachs { get; set; }
        public DbSet<Membresia>? Membresias { get; set; }
        public DbSet<Plan>? Planes { get; set; }
        public DbSet<Reserva>? Reservas { get; set; }
        public DbSet<Asistencia>? Asistencias { get; set; }
        public DbSet<Empleado>? Empleados { get; set; }
        public DbSet<Sede>? Sedes { get; set; }
        public DbSet<Feedback>? Feedbacks { get; set; }
        public DbSet<HistorialFisico>? Historiales { get; set; }
        public DbSet<DatosFisicos>? DatosFisicos { get; set; }
        public DbSet<Pago>? Pagos { get; set; }
        public DbSet<UsuarioLogin>? UsuariosLogin { get; set; }

        public EntityEntry<T> Entry<T>(T entity) where T : class => base.Entry(entity);
    }
}