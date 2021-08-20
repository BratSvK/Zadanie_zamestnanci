namespace CompanyManagerAPI.DTOs
{
    /// <summary>
    ///  this is what everything we should update for our employee
    /// </summary>
    public class UpdateEmploeyeeDto
    {
        public int? OddelenieId { get; set; }
        public string Titul { get; set; }
        public string Mobil { get; set; }
        public string Email { get; set; }
    }
}