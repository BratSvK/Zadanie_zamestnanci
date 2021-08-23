using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyManagerAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagerAPI.Interfaces
{
    public interface IOddelenieRepository
    {
         void Update(OddelenieDTO oddelenie);

        Task<ActionResult<OddelenieDTO>> CreateOddelenie(CreateOddelenie createOddelenie);


        Task<bool> RemoveOddenielie(int projektId);

        Task<bool> SaveAllAsync();

        Task<ActionResult<IEnumerable<OddelenieDTO>>> GetAllOddelenieByProjekt(int projektId);


        Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployeeInOddelenie(int projektId);

        Task<ActionResult<OddelenieDTO>> GetOddelenieByID(int id);

        Task<bool> OddelnieExists(int id);

        Task<bool> OddelenieShouldAddVeduci(int idZamestnanec);



    }
}