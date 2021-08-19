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
            Oddelenia = new HashSet<Oddelenie>();
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

        public virtual Divizium Divizium { get; set; }
        public virtual Zamestnanec Veduci { get; set; }
        public virtual ICollection<Oddelenie> Oddelenia { get; set; }
    }
}
