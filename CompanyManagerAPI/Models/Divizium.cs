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
    [Table("Divizia")]
    public partial class Divizium
    {
        public Divizium()
        {
            Projekty = new HashSet<Projekt>();
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

       
        public virtual Firma Firma { get; set; }
      
        public virtual Zamestnanec Veduci { get; set; }
    
        public virtual ICollection<Projekt> Projekty { get; set; }
    }
}
