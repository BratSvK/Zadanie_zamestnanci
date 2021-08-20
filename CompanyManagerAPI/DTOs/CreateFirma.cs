using System.ComponentModel.DataAnnotations;

namespace CompanyManagerAPI.DTOs
{
    public class CreateFirma
    {
        [Required]
        public int IdFirma { get; set; }
        [Required(ErrorMessage = "Must to be entered number"),]
        public int IdVeduci { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name cannot be greater than 100")]
        public string Nazov { get; set; }
    }
}