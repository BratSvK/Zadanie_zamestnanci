using System.Collections;
using System.Collections.Generic;
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
            #region  Zamestnanec
            CreateMap<Zamestnanec, EmployeeDTO>();
            CreateMap<CreateEmploeyee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Zamestnanec>();
            CreateMap<UpdateEmploeyeeDto, EmployeeDTO>().ForAllMembers(opt => opt.Condition((src, dest, sourceMember) => sourceMember != null));
            CreateMap<CreateEmploeyee, Zamestnanec>().BeforeMap((s,d) => s.Email.ToLowerInvariant());
            #endregion

            #region Firma
            CreateMap<Firma,FirmaDTO>();
            CreateMap<FirmaDTO,Firma>();

            CreateMap<CreateFirma,FirmaDTO>();
            CreateMap<CreateFirma,Firma>();

            CreateMap<UpdateFirmaDTO,FirmaDTO>().ForAllMembers(opt => opt.Condition((src, dest, sourceMember) => sourceMember != null));


            #endregion


            #region Divizia

            CreateMap<Divizium,DiviziaDTO>();
            CreateMap<DiviziaDTO,Divizium>();

            CreateMap<Divizium, CreateDivizia>();
            CreateMap<CreateDivizia, DiviziaDTO>();
            CreateMap<CreateDivizia, Divizium>();

            CreateMap<UpdateDiviziaDTO,DiviziaDTO>().ForAllMembers(opt => opt.Condition((src, dest, sourceMember) => sourceMember != null));


            
            #endregion

            #region Projekt

            CreateMap<Projekt,ProjektDTO>();
            CreateMap<ProjektDTO,Projekt>();

            CreateMap<CreateProjekt,Projekt>();

            CreateMap<CreateProjekt,ProjektDTO>();

            CreateMap<UpdateProjekt,ProjektDTO>();



           


            


            
            #endregion


            #region Oddelenie

            CreateMap<Oddelenie, OddelenieDTO>();
            CreateMap<OddelenieDTO, Oddelenie>();

            CreateMap<CreateOddelenie,Oddelenie>();
            CreateMap<CreateOddelenie, OddelenieDTO>();

            CreateMap<UpdateOddelenie,OddelenieDTO>().ForAllMembers(opt => opt.Condition((src,dest,sourceMember) => sourceMember != null ));
            CreateMap<UpdateOddelenie,Oddelenie>();

            #endregion


            
        }
    }
}