using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CompanyManagerAPI.Models
{
    [Index(nameof(IdVedDivizie), Name = "IX_Relationship10")]
    [Index(nameof(IdFirma), Name = "IX_Relationship4")]
    public partial class Divizium
    {
        public Divizium()
        {
            Projekts = new HashSet<Projekt>();
        }

        [Key]
        [Column("id_divizia")]
        public int IdDivizia { get; set; }
        [Column("id_firma")]
        public int IdFirma { get; set; }
        [Column("id_ved_divizie")]
        public int IdVedDivizie { get; set; }
        [Column("nazov")]
        [StringLength(100)]
        public string Nazov { get; set; }

        [ForeignKey(nameof(IdFirma))]
        [InverseProperty(nameof(Firma.Divizia))]
        public virtual Firma IdFirmaNavigation { get; set; }
        [ForeignKey(nameof(IdVedDivizie))]
        [InverseProperty(nameof(Zamestnanec.Divizia))]
        public virtual Zamestnanec IdVedDivizieNavigation { get; set; }
        [InverseProperty(nameof(Projekt.IdDiviziaNavigation))]
        public virtual ICollection<Projekt> Projekts { get; set; }
    }
}
