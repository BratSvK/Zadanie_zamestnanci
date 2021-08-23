using System.ComponentModel.DataAnnotations;

namespace CompanyManagerAPI.DTOs
{
    public class CreateDivizia
    {

        public int IdFirma { get; set; }
        [Required]
        public int IdDivizia { get; set; }
        [Required(ErrorMessage = "Must to be entered number"),]
        public int IdVedDivizie { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name cannot be greater than 100")]
        public string Nazov { get; set; }
    }
}