using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CompanyManagerAPI.Models
{
    [Table("Projekt")]
    [Index(nameof(IdVedProjekt), Name = "IX_Relationship11")]
    [Index(nameof(IdDivizia), Name = "IX_Relationship5")]
    public partial class Projekt
    {
        public Projekt()
        {
            Oddelenies = new HashSet<Oddelenie>();
        }

        [Key]
        [Column("id_projekt")]
        public int IdProjekt { get; set; }
        [Column("id_divizia")]
        public int IdDivizia { get; set; }
        [Column("id_ved_projekt")]
        public int IdVedProjekt { get; set; }
        [Column("nazov")]
        [StringLength(100)]
        public string Nazov { get; set; }

        [ForeignKey(nameof(IdDivizia))]
        [InverseProperty(nameof(Divizium.Projekts))]
        public virtual Divizium IdDiviziaNavigation { get; set; }
        [ForeignKey(nameof(IdVedProjekt))]
        [InverseProperty(nameof(Zamestnanec.Projekts))]
        public virtual Zamestnanec IdVedProjektNavigation { get; set; }
        [InverseProperty(nameof(Oddelenie.IdProjektNavigation))]
        public virtual ICollection<Oddelenie> Oddelenies { get; set; }
    }
}
