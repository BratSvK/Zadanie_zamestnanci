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
            CreateMap<CreateEmploeyee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Zamestnanec>();
            CreateMap<UpdateEmploeyeeDto, EmployeeDTO>().ForAllMembers(opt => opt.Condition((src, dest, sourceMember) => sourceMember != null));
            CreateMap<CreateEmploeyee, Zamestnanec>().BeforeMap((s,d) => s.Email.ToLowerInvariant());
            
        }
    }
}