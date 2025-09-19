using lib__repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using lib__dominio.Entidades;

namespace lib__repositorios.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        // Constructor que acepta DbContextOptions<Conexion>
        public Conexion(DbContextOptions<Conexion> options) : base(options) { }

        // Este método OnConfiguring solo se ejecuta si no se pasa una configuración de DbContextOptions
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Si las opciones no están configuradas, se configura para usar SQL Server
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(this.StringConexion!);  // Usar la cadena de conexión
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); // Configurar el seguimiento de las consultas
            }
        }

        // Definición de las entidades
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.UsuarioLogin)
                .WithOne(ul => ul.Cliente)
                .HasForeignKey<UsuarioLogin>(ul => ul.CedulaCliente);

            modelBuilder.Entity<Asignado>()
                .HasKey(a => new { a.CedulaCoach, a.IdClase });

            modelBuilder.Entity<Asistencia>()
                .HasKey(a => a.IdAsistencia);

            modelBuilder.Entity<Clase>()
                .HasKey(c => c.IdClase);

            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.Cedula);

            base.OnModelCreating(modelBuilder);
        }

        // Método para acceder a las entradas de las entidades
        public EntityEntry<T> Entry<T>(T entity) where T : class => base.Entry(entity);
    }
}
