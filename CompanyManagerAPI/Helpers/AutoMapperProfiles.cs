using AutoMapper;
using CompanyManagerAPI.DTOs;
using CompanyManagerAPI.Models;

namespace CompanyManagerAPI.Helpers
{
    /// <summary>
    /// This class is for auto mapping from one object to another one 
    /// </summary>
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // from -> to 
            CreateMap<Zamestnanec, EmployeeDTO>();
        }
    }
}