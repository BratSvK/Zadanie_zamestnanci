using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CompanyManagerAPI.Models
{
    [Table("Oddelenie")]
    [Index(nameof(IdVedOddelenia), Name = "IX_Relationship12")]
    [Index(nameof(IdProjekt), Name = "IX_Relationship6")]
    public partial class Oddelenie
    {
        public Oddelenie()
        {
            Zamestnanecs = new HashSet<Zamestnanec>();
        }

        [Key]
        [Column("id_oddelenie")]
        public int IdOddelenie { get; set; }
        [Column("id_ved_oddelenia")]
        public int IdVedOddelenia { get; set; }
        [Column("id_projekt")]
        public int IdProjekt { get; set; }
        [Column("nazov")]
        [StringLength(100)]
        public string Nazov { get; set; }

        [ForeignKey(nameof(IdProjekt))]
        [InverseProperty(nameof(Projekt.Oddelenies))]
        public virtual Projekt IdProjektNavigation { get; set; }
        [ForeignKey(nameof(IdVedOddelenia))]
        [InverseProperty(nameof(Zamestnanec.Oddelenies))]
        public virtual Zamestnanec IdVedOddeleniaNavigation { get; set; }
        [InverseProperty(nameof(Zamestnanec.IdOddelenieNavigation))]
        public virtual ICollection<Zamestnanec> Zamestnanecs { get; set; }
    }
}
