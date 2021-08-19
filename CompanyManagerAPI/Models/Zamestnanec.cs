using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CompanyManagerAPI.Models
{
    [Table("Zamestnanec")]
    [Index(nameof(OddelenieId), Name = "IX_Relationship13")]
    public partial class Zamestnanec
    {
        public Zamestnanec()
        {
        }

        [Key]
        [Column("id_zamestnanec")]

        public int IdZamestnanec { get; set; }
        

        [Column("titul")]
        [StringLength(5)]
        public string Titul { get; set; }
       
        [Column("meno")]
        [Required]
        [StringLength(15)]
        public string Meno { get; set; }

        [Column("priezvisko")]
        [Required]
        [StringLength(30)]
        public string Priezvisko { get; set; }



        [Column("mobil")]
        [Required]
        [StringLength(15)]
        public string Mobil { get; set; }

        [Column("email")]
        [Required]
        [StringLength(320)]
        public string Email { get; set; }


        // vztahy
        [Column("id_oddelenie")]

        public virtual int? OddelenieId { get; set; }
        public virtual Oddelenie OddelenieVed { get; set; }


        public virtual Oddelenie Oddelenie { get; set; }


        public virtual Firma FirmaVed { get; set; }

        public virtual Divizium DivVed { get; set; }

        public virtual Projekt ProjVed { get; set; }









       
    }
}
