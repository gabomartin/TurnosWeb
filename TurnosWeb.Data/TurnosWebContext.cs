using Microsoft.EntityFrameworkCore;
using TurnosWeb.Data.Models;

namespace TurnosWeb.Data
{
    public class TurnosWebContext : DbContext
    {
        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Barber> Barber { get; set; }
        public virtual DbSet<AppointmentService> AppointmentService { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<AppointmentState> AppointmentState { get; set; }

        public TurnosWebContext(DbContextOptions<TurnosWebContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");
                entity.HasKey(e => e.AppointmentId);
                entity.HasOne(e => e.Barber)
                        .WithMany()
                        .HasForeignKey(e => e.BarberId);

                entity.HasOne(e => e.State)
                        .WithMany()
                        .HasForeignKey(e => e.StateId);

                entity.HasMany(e => e.Services)
                       .WithOne(e => e.Appointment);

                entity.Property(e => e.AppointmentDate).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            });

            modelBuilder.Entity<Barber>(entity => 
            {
                entity.ToTable("Barber");
                entity.HasKey(e => e.BarberId);
            });

            modelBuilder.Entity<AppointmentService>(entity =>
            {
                entity.ToTable("AppointmentService");
                entity.HasKey(e => e.AppointmentServiceId);

                entity.HasOne(e => e.Appointment)
                .WithMany()
                .HasForeignKey(e => e.AppointmentId);

                entity.HasOne(e => e.Service)
                .WithMany()
                .HasForeignKey(e => e.ServiceId);
            });
            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");
            });
            modelBuilder.Entity<AppointmentState>(entity =>
            {
                entity.ToTable("AppointmentState");
            });
            modelBuilder.HasDefaultSchema("dbo");
        }

    }
}
