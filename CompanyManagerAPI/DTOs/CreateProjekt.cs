using System.ComponentModel.DataAnnotations;

namespace CompanyManagerAPI.DTOs
{
    public class CreateProjekt
    {

         public int IdDivizia { get; set; }
        [Required]
        public int IdProjekt { get; set; }
        [Required(ErrorMessage = "Must to be entered number"),]
        public int IdVedProjekt { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name cannot be greater than 100")]
        public string Nazov { get; set; }
    }
}