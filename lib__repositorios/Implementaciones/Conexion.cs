using lib__repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using lib__dominio.Entidades;

namespace lib__repositorios.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        public Conexion(DbContextOptions<Conexion> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(this.StringConexion!);
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.UsuarioLogin)
                .WithOne(ul => ul.Cliente)
                .HasForeignKey<UsuarioLogin>(ul => ul.CedulaCliente);

            modelBuilder.Entity<Membresia>()
                .HasOne(m => m.Cliente)
                .WithMany(c => c.Membresias)
                .HasForeignKey(m => m.CedulaCliente);

            modelBuilder.Entity<Membresia>()
                .HasOne(m => m.Plan)
                .WithMany(p => p.Membresias)
                .HasForeignKey(m => m.NitPlan);

            modelBuilder.Entity<Clase>()
                .HasOne(c => c.Sede)
                .WithMany(s => s.Clases)
                .HasForeignKey(c => c.SedeId);

            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Sede)
                .WithMany(s => s.Empleados)
                .HasForeignKey(e => e.SedeId);

            modelBuilder.Entity<Asignado>()
    .HasKey(a => new { a.CedulaCoach, a.IdClase });

            modelBuilder.Entity<Asignado>()
                .HasOne(a => a.Coach)
                .WithMany(c => c.Asignaciones)
                .HasForeignKey(a => a.CedulaCoach);

            modelBuilder.Entity<Asignado>()
                .HasOne(a => a.Clase)
                .WithMany(c => c.Asignaciones)
                .HasForeignKey(a => a.IdClase);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Cliente)
                .WithMany(c => c.Feedbacks)
                .HasForeignKey(f => f.CedulaCliente);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Clase)
                .WithMany(c => c.Feedbacks)
                .HasForeignKey(f => f.IdClase);

            modelBuilder.Entity<Asistencia>()
            .HasKey(a => a.IdAsistencia);

            modelBuilder.Entity<Asistencia>()
                .HasOne(a => a.Cliente)
                .WithMany(c => c.Asistencias)
                .HasForeignKey(a => a.CedulaCliente);

            modelBuilder.Entity<Asistencia>()
                .HasOne(a => a.Clase)
                .WithMany(c => c.Asistencias)
                .HasForeignKey(a => a.IdClase);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Cliente)
                .WithMany(c => c.Reservas)
                .HasForeignKey(r => r.CedulaCliente);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Clase)
                .WithMany(c => c.Reservas)
                .HasForeignKey(r => r.IdClase);

            modelBuilder.Entity<Pago>()
                .HasOne(p => p.Cliente)
                .WithMany(c => c.Pagos)
                .HasForeignKey(p => p.CedulaCliente);

            modelBuilder.Entity<DatosFisicos>()
                .HasOne(df => df.Cliente)
                .WithMany(c => c.DatosFisicos)
                .HasForeignKey(df => df.CedulaCliente);

            modelBuilder.Entity<HistorialFisico>()
                .HasOne(hf => hf.Cliente)
                .WithMany(c => c.HistorialFisicos)
                .HasForeignKey(hf => hf.CedulaCliente);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<Clase>? Clases { get; set; }
        public DbSet<Coach>? Coaches { get; set; }
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
    }
}