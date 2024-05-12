using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PIAProWeb.Models.dbModels
{
    public partial class GymContext : DbContext
    {
        public GymContext()
        {
        }

        public GymContext(DbContextOptions<GymContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Compra> Compras { get; set; } = null!;
        public virtual DbSet<Ejercicio> Ejercicios { get; set; } = null!;
        public virtual DbSet<EjerciciosRutina> EjerciciosRutinas { get; set; } = null!;
        public virtual DbSet<GruposMusculare> GruposMusculares { get; set; } = null!;
        public virtual DbSet<MetodoPago> MetodoPagos { get; set; } = null!;
        public virtual DbSet<Peso> Pesos { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Rutina> Rutinas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Gym;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .HasName("PK_Compra");

                entity.HasOne(d => d.IdMetodoPagoNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdMetodoPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compras_MetodoPago");

                entity.HasOne(d => d.IdPaqueteNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdPaquete)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compra_Paquetes");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compra_Usuario");
            });

            modelBuilder.Entity<Ejercicio>(entity =>
            {
                entity.HasOne(d => d.IdGruposMuscularesNavigation)
                    .WithMany(p => p.Ejercicios)
                    .HasForeignKey(d => d.IdGruposMusculares)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ejercicios_GruposMusculares");
            });

            modelBuilder.Entity<EjerciciosRutina>(entity =>
            {
                entity.HasKey(e => new { e.IdEjercicio, e.IdRutina });

                entity.HasOne(d => d.IdEjercicioNavigation)
                    .WithMany(p => p.EjerciciosRutinas)
                    .HasForeignKey(d => d.IdEjercicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EjerciciosRutinas_Ejercicios");

                entity.HasOne(d => d.IdPesoNavigation)
                    .WithMany(p => p.EjerciciosRutinas)
                    .HasForeignKey(d => d.IdPeso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EjerciciosRutinas_Peso");

                entity.HasOne(d => d.IdRutinaNavigation)
                    .WithMany(p => p.EjerciciosRutinas)
                    .HasForeignKey(d => d.IdRutina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EjerciciosRutinas_Rutinas");
            });

            modelBuilder.Entity<Rutina>(entity =>
            {
                entity.HasKey(e => e.IdRutina)
                    .HasName("PK_Paquetes");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK_Usuario");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Roles1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
