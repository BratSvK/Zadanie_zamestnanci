namespace CompanyManagerAPI.DTOs
{
    public class EmployeeDTO
    {
        public int IdZamestnanec { get; set; }
        public int? IdOddelenie { get; set; }
        public string Titul { get; set; }
        public string Meno { get; set; }
        public string Priezvisko { get; set; }
        public string Mobil { get; set; }
        public string Email { get; set; }
    }
}