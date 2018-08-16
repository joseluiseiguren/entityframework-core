using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityFrameworkCore.Models
{
    public partial class testefcoreContext : DbContext
    {
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=testefcore;User Id=sa;Password=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movimientos>(entity =>
            {
                entity.ToTable("movimientos");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdPersona)
                    .HasColumnName("id_persona")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_movimientos_personas");
            });

            modelBuilder.Entity<Personas>(entity =>
            {
                entity.ToTable("personas");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("numeric(18, 0)");

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
