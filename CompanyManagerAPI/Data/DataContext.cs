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

                entity.HasOne(d => d.Firma)
                    .WithMany(p => p.Divizia)
                    .HasForeignKey(d => d.IdFirma)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Relationship4");

                entity.HasOne(d => d.Veduci)
                    .WithOne(b => b.DivVed)
                    .HasForeignKey<Divizium>(d => d.IdVedDivizie);
            });

            modelBuilder.Entity<Firma>(entity =>
            {
                entity.Property(e => e.IdFirma).ValueGeneratedNever();

                entity.Property(e => e.Nazov).IsUnicode(false);

                entity.HasOne(d => d.Veduci)
                    .WithOne(p => p.FirmaVed)
                    .HasForeignKey<Firma>(d => d.IdVeduci)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Relationship9");
            });

            modelBuilder.Entity<Oddelenie>(entity =>
            {
                entity.Property(e => e.IdOddelenie).ValueGeneratedNever();

                entity.Property(e => e.Nazov).IsUnicode(false);

                entity.HasOne(d => d.Projekt)
                    .WithMany(p => p.Oddelenia)
                    .HasForeignKey(d => d.IdProjekt)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Relationship6");

                entity.HasOne(d => d.VeduciOddelenie)
                    .WithOne(p => p.OddelenieVed)
                    .HasForeignKey<Oddelenie>(d => d.IdVedOddelenia)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Relationship12");


                
            });

            modelBuilder.Entity<Projekt>(entity =>
            {
                entity.Property(e => e.IdProjekt).ValueGeneratedNever();

                entity.Property(e => e.Nazov).IsUnicode(false);

                entity.HasOne(d => d.Divizium)
                    .WithMany(p => p.Projekty)
                    .HasForeignKey(d => d.IdDivizia)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Relationship5");

                entity.HasOne(d => d.Veduci)
                    .WithOne(p => p.ProjVed)
                    .HasForeignKey<Projekt>(d => d.IdVedProjekt)
                    .OnDelete(DeleteBehavior.Restrict)
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

                entity.HasOne(d => d.Oddelenie)
                    .WithMany(p => p.Zamestnanci)
                    .HasForeignKey(d => d.OddelenieId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Relationship13");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
