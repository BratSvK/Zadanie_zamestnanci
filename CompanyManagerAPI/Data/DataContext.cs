using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CompanyManagerAPI.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Divizium> Divizie { get; set; }
        public virtual DbSet<Firma> Firmy { get; set; }
        public virtual DbSet<Oddelenie> Oddelenia { get; set; }
        public virtual DbSet<Projekt> Projekts { get; set; }
        public virtual DbSet<Zamestnanec> Zamestnanci { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Slovak_CI_AS");

            modelBuilder.Entity<Divizium>(entity =>
            {
                entity.Property(e => e.IdDivizia).ValueGeneratedNever();

                entity.Property(e => e.Nazov).IsUnicode(false);

                entity.HasOne(d => d.IdFirmaNavigation)
                    .WithMany(p => p.Divizia)
                    .HasForeignKey(d => d.IdFirma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship4");

                entity.HasOne(d => d.IdVedDivizieNavigation)
                    .WithMany(p => p.Divizia)
                    .HasForeignKey(d => d.IdVedDivizie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship10");
            });

            modelBuilder.Entity<Firma>(entity =>
            {
                entity.Property(e => e.IdFirma).ValueGeneratedNever();

                entity.Property(e => e.Nazov).IsUnicode(false);

                entity.HasOne(d => d.IdVeduciNavigation)
                    .WithMany(p => p.Firmas)
                    .HasForeignKey(d => d.IdVeduci)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship9");
            });

            modelBuilder.Entity<Oddelenie>(entity =>
            {
                entity.Property(e => e.IdOddelenie).ValueGeneratedNever();

                entity.Property(e => e.Nazov).IsUnicode(false);

                entity.HasOne(d => d.IdProjektNavigation)
                    .WithMany(p => p.Oddelenies)
                    .HasForeignKey(d => d.IdProjekt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship6");

                entity.HasOne(d => d.IdVedOddeleniaNavigation)
                    .WithMany(p => p.Oddelenies)
                    .HasForeignKey(d => d.IdVedOddelenia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship12");
            });

            modelBuilder.Entity<Projekt>(entity =>
            {
                entity.Property(e => e.IdProjekt).ValueGeneratedNever();

                entity.Property(e => e.Nazov).IsUnicode(false);

                entity.HasOne(d => d.IdDiviziaNavigation)
                    .WithMany(p => p.Projekts)
                    .HasForeignKey(d => d.IdDivizia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship5");

                entity.HasOne(d => d.IdVedProjektNavigation)
                    .WithMany(p => p.Projekts)
                    .HasForeignKey(d => d.IdVedProjekt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship11");
            });

            modelBuilder.Entity<Zamestnanec>(entity =>
            {
                entity.Property(e => e.IdZamestnanec).ValueGeneratedNever();

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Meno).IsUnicode(false);

                entity.Property(e => e.Mobil).IsUnicode(false);

                entity.Property(e => e.Priezvisko).IsUnicode(false);

                entity.Property(e => e.Titul).IsUnicode(false);

                entity.HasOne(d => d.IdOddelenieNavigation)
                    .WithMany(p => p.Zamestnanecs)
                    .HasForeignKey(d => d.IdOddelenie)
                    .HasConstraintName("Relationship13");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
