using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CompanyManagerAPI.Models
{
    [Table("Firma")]
    [Index(nameof(IdVeduci), Name = "IX_Relationship9")]
    public partial class Firma
    {
        public Firma()
        {
            Divizia = new HashSet<Divizium>();
        }

        [Key]
        [Column("id_firma")]
        public int IdFirma { get; set; }
        [Column("id_veduci")]

        public int IdVeduci { get; set; }
        
        [Column("nazov")]
        [StringLength(100)]
        public string Nazov { get; set; }
        public virtual Zamestnanec Veduci { get; set; }
      
        public virtual ICollection<Divizium> Divizia { get; set; }
    }
}
