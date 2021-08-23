using System.ComponentModel.DataAnnotations;

namespace CompanyManagerAPI.DTOs
{
    public class CreateOddelenie
    {

        public int IdProjekt { get; set; }

        [Required]
        public int IdOddelenie { get; set; }
        [Required]
        public int IdVedOddelenia { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name cannot be greater than 100")]
        public string Nazov { get; set; }


        


    }
}