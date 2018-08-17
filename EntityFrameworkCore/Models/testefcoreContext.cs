using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityFrameworkCore.Models
{
    public partial class testefcoreContext : DbContext
    {
        public static string ConnectionString;

        public testefcoreContext()
        {
        }

        public testefcoreContext(DbContextOptions<testefcoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movimientos> Movimientos { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movimientos>(entity =>
            {
                entity.ToTable("movimientos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.Importe)
                    .HasColumnName("importe")
                    .HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_movimientos_persona");
            });

            modelBuilder.Entity<Personas>(entity =>
            {
                entity.ToTable("personas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FehcaNacimiento)
                    .HasColumnName("fehca_nacimiento")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
