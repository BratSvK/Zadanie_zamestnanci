using System.ComponentModel.DataAnnotations;

namespace CompanyManagerAPI.DTOs
{
    public class CreateEmploeyee
    {

        [Required]
        public int IdZamestnanec { get; set; }
        public int? IdOddelenie { get; set; }
        [StringLength(5)]
        public string Titul { get; set; }
        [Required]
        [StringLength(15)]
        public string Meno { get; set; }
        [Required]
        [StringLength(30)]
        public string Priezvisko { get; set; }
        [Required]
        [StringLength(15)]
        [Phone]
        public string Mobil { get; set; }
        [Required]
        [StringLength(320)]
        [EmailAddress]
        public string Email { get; set; }
    }
}