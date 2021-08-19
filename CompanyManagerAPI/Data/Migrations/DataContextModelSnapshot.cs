﻿// <auto-generated />
using System;
using CompanyManagerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CompanyManagerAPI.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Slovak_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CompanyManagerAPI.Models.Divizium", b =>
                {
                    b.Property<int>("IdDivizia")
                        .HasColumnType("int")
                        .HasColumnName("id_divizia");

                    b.Property<int>("IdFirma")
                        .HasColumnType("int")
                        .HasColumnName("id_firma");

                    b.Property<int>("IdVedDivizie")
                        .HasColumnType("int")
                        .HasColumnName("id_ved_divizie");

                    b.Property<string>("Nazov")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nazov");

                    b.HasKey("IdDivizia");

                    b.HasIndex("IdVedDivizie")
                        .IsUnique();

                    b.HasIndex(new[] { "IdVedDivizie" }, "IX_Relationship10");

                    b.HasIndex(new[] { "IdFirma" }, "IX_Relationship4");

                    b.ToTable("Divizia");
                });

            modelBuilder.Entity("CompanyManagerAPI.Models.Firma", b =>
                {
                    b.Property<int>("IdFirma")
                        .HasColumnType("int")
                        .HasColumnName("id_firma");

                    b.Property<int>("IdVeduci")
                        .HasColumnType("int")
                        .HasColumnName("id_veduci");

                    b.Property<string>("Nazov")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nazov");

                    b.HasKey("IdFirma");

                    b.HasIndex("IdVeduci")
                        .IsUnique();

                    b.HasIndex(new[] { "IdVeduci" }, "IX_Relationship9");

                    b.ToTable("Firmy");
                });

            modelBuilder.Entity("CompanyManagerAPI.Models.Oddelenie", b =>
                {
                    b.Property<int>("IdOddelenie")
                        .HasColumnType("int")
                        .HasColumnName("id_oddelenie");

                    b.Property<int>("IdProjekt")
                        .HasColumnType("int")
                        .HasColumnName("id_projekt");

                    b.Property<int>("IdVedOddelenia")
                        .HasColumnType("int")
                        .HasColumnName("id_ved_oddelenia");

                    b.Property<string>("Nazov")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nazov");

                    b.HasKey("IdOddelenie");

                    b.HasIndex("IdVedOddelenia")
                        .IsUnique();

                    b.HasIndex(new[] { "IdVedOddelenia" }, "IX_Relationship12");

                    b.HasIndex(new[] { "IdProjekt" }, "IX_Relationship6");

                    b.ToTable("Oddelenie");
                });

            modelBuilder.Entity("CompanyManagerAPI.Models.Projekt", b =>
                {
                    b.Property<int>("IdProjekt")
                        .HasColumnType("int")
                        .HasColumnName("id_projekt");

                    b.Property<int>("IdDivizia")
                        .HasColumnType("int")
                        .HasColumnName("id_divizia");

                    b.Property<int>("IdVedProjekt")
                        .HasColumnType("int")
                        .HasColumnName("id_ved_projekt");

                    b.Property<string>("Nazov")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nazov");

                    b.HasKey("IdProjekt");

                    b.HasIndex("IdVedProjekt")
                        .IsUnique();

                    b.HasIndex(new[] { "IdVedProjekt" }, "IX_Relationship11");

                    b.HasIndex(new[] { "IdDivizia" }, "IX_Relationship5");

                    b.ToTable("Projekt");
                });

            modelBuilder.Entity("CompanyManagerAPI.Models.Zamestnanec", b =>
                {
                    b.Property<int>("IdZamestnanec")
                        .HasColumnType("int")
                        .HasColumnName("id_zamestnanec");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(320)
                        .IsUnicode(false)
                        .HasColumnType("varchar(320)")
                        .HasColumnName("email");

                    b.Property<string>("Meno")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("meno");

                    b.Property<string>("Mobil")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("mobil");

                    b.Property<int?>("OddelenieId")
                        .HasColumnType("int");

                    b.Property<string>("Priezvisko")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("priezvisko");

                    b.Property<string>("Titul")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)")
                        .HasColumnName("titul");

                    b.HasKey("IdZamestnanec");

                    b.HasIndex(new[] { "OddelenieId" }, "IX_Relationship13");

                    b.ToTable("Zamestnanec");
                });

            modelBuilder.Entity("CompanyManagerAPI.Models.Divizium", b =>
                {
                    b.HasOne("CompanyManagerAPI.Models.Firma", "Firma")
                        .WithMany("Divizia")
                        .HasForeignKey("IdFirma")
                        .HasConstraintName("Relationship4")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CompanyManagerAPI.Models.Zamestnanec", "Veduci")
                        .WithOne("DivVed")
                        .HasForeignKey("CompanyManagerAPI.Models.Divizium", "IdVedDivizie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Firma");

                    b.Navigation("Veduci");
                });

            modelBuilder.Entity("CompanyManagerAPI.Models.Firma", b =>
                {
                    b.HasOne("CompanyManagerAPI.Models.Zamestnanec", "Veduci")
                        .WithOne("FirmaVed")
                        .HasForeignKey("CompanyManagerAPI.Models.Firma", "IdVeduci")
                        .HasConstraintName("Relationship9")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Veduci");
                });

            modelBuilder.Entity("CompanyManagerAPI.Models.Oddelenie", b =>
                {
                    b.HasOne("CompanyManagerAPI.Models.Projekt", "Projekt")
                        .WithMany("Oddelenia")
                        .HasForeignKey("IdProjekt")
                        .HasConstraintName("Relationship6")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CompanyManagerAPI.Models.Zamestnanec", "VeduciOddelenie")
                        .WithOne("OddelenieVed")
                        .HasForeignKey("CompanyManagerAPI.Models.Oddelenie", "IdVedOddelenia")
                        .HasConstraintName("Relationship12")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Projekt");

                    b.Navigation("VeduciOddelenie");
                });

            modelBuilder.Entity("CompanyManagerAPI.Models.Projekt", b =>
                {
                    b.HasOne("CompanyManagerAPI.Models.Divizium", "Divizium")
                        .WithMany("Projekty")
                        .HasForeignKey("IdDivizia")
                        .HasConstraintName("Relationship5")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CompanyManagerAPI.Models.Zamestnanec", "Veduci")
                        .WithOne("ProjVed")
                        .HasForeignKey("CompanyManagerAPI.Models.Projekt", "IdVedProjekt")
                        .HasConstraintName("Relationship11")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Divizium");

                    b.Navigation("Veduci");
                });

            modelBuilder.Entity("CompanyManagerAPI.Models.Zamestnanec", b =>
                {
                    b.HasOne("CompanyManagerAPI.Models.Oddelenie", "Oddelenie")
                        .WithMany("Zamestnanci")
                        .HasForeignKey("OddelenieId")
                        .HasConstraintName("Relationship13")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Oddelenie");
                });

            modelBuilder.Entity("CompanyManagerAPI.Models.Divizium", b =>
                {
                    b.Navigation("Projekty");
                });

            modelBuilder.Entity("CompanyManagerAPI.Models.Firma", b =>
                {
                    b.Navigation("Divizia");
                });

            modelBuilder.Entity("CompanyManagerAPI.Models.Oddelenie", b =>
                {
                    b.Navigation("Zamestnanci");
                });

            modelBuilder.Entity("CompanyManagerAPI.Models.Projekt", b =>
                {
                    b.Navigation("Oddelenia");
                });

            modelBuilder.Entity("CompanyManagerAPI.Models.Zamestnanec", b =>
                {
                    b.Navigation("DivVed");

                    b.Navigation("FirmaVed");

                    b.Navigation("OddelenieVed");

                    b.Navigation("ProjVed");
                });
#pragma warning restore 612, 618
        }
    }
}
