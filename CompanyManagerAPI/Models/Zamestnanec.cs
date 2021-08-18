using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CompanyManagerAPI.Models
{
    [Table("Zamestnanec")]
    [Index(nameof(IdOddelenie), Name = "IX_Relationship13")]
    public partial class Zamestnanec
    {
        public Zamestnanec()
        {
            Divizia = new HashSet<Divizium>();
            Firmas = new HashSet<Firma>();
            Oddelenies = new HashSet<Oddelenie>();
            Projekts = new HashSet<Projekt>();
        }

        [Key]
        [Column("id_zamestnanec")]
        public int IdZamestnanec { get; set; }
        [Column("id_oddelenie")]
        public int? IdOddelenie { get; set; }
        [Column("titul")]
        [StringLength(5)]
        public string Titul { get; set; }
        [Required]
        [Column("meno")]
        [StringLength(15)]
        public string Meno { get; set; }
        [Required]
        [Column("priezvisko")]
        [StringLength(30)]
        public string Priezvisko { get; set; }
        [Required]
        [Column("mobil")]
        [StringLength(15)]
        public string Mobil { get; set; }
        [Required]
        [Column("email")]
        [StringLength(320)]
        public string Email { get; set; }

        [ForeignKey(nameof(IdOddelenie))]
        [InverseProperty(nameof(Oddelenie.Zamestnanecs))]
        public virtual Oddelenie IdOddelenieNavigation { get; set; }
        [InverseProperty(nameof(Divizium.IdVedDivizieNavigation))]
        public virtual ICollection<Divizium> Divizia { get; set; }
        [InverseProperty(nameof(Firma.IdVeduciNavigation))]
        public virtual ICollection<Firma> Firmas { get; set; }
        [InverseProperty(nameof(Oddelenie.IdVedOddeleniaNavigation))]
        public virtual ICollection<Oddelenie> Oddelenies { get; set; }
        [InverseProperty(nameof(Projekt.IdVedProjektNavigation))]
        public virtual ICollection<Projekt> Projekts { get; set; }
    }
}
