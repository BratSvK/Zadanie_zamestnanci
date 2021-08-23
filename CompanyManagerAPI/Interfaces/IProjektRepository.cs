using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyManagerAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagerAPI.Interfaces
{
    public interface IProjektRepository
    {
         void Update(ProjektDTO firma);

        Task<ActionResult<ProjektDTO>> CreateProjekt(CreateProjekt createDivizia);


        Task<bool> RemoveProjekt(int diviziaId);

        Task<bool> SaveAllAsync();

        Task<ActionResult<IEnumerable<ProjektDTO>>> GetAllProjektsByDivizionId(int divizionId);

        Task<ActionResult<ProjektDTO>> GetProjektById(int id);

        Task<bool> ProjektExists(int id);

        Task<bool> ProejektShouldAddVeduci(int idZamestnanec);
    }
}