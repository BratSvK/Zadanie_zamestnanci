using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyManagerAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagerAPI.Interfaces
{
    public interface IDiviziaRepository
    {

        void Update(DiviziaDTO firma);

        Task<ActionResult<DiviziaDTO>> CreateDivizia(CreateDivizia createDivizia);


        Task<bool> RemoveDivizia(int diviziaId);

        Task<bool> SaveAllAsync();

        Task<ActionResult<IEnumerable<DiviziaDTO>>> GetAllDiviziasByFirmaId(int firmaId);

        Task<ActionResult<DiviziaDTO>> GetDiviziaById(int id);

        Task<bool> DiviziaExists(int id);

        Task<bool> DiviziaShouldAddVeduci(int idZamestnanec);

         
    }
}