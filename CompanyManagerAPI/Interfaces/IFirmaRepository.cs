using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyManagerAPI.DTOs;
using CompanyManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagerAPI.Interfaces
{
    public interface IFirmaRepository
    {
         void Update(FirmaDTO firma);

        Task<ActionResult<FirmaDTO>> CreateFirma(CreateFirma createFirma);


        Task<bool> RemoveFirma(int firmaId);

        Task<bool> SaveAllAsync();

        Task<ActionResult<IEnumerable<FirmaDTO>>> GetAllFirmas();

        Task<ActionResult<FirmaDTO>> GetFirmaById(int id);

        Task<bool> FirmaExists(int id);

         Task<bool> FirmaShouldAddVeduci(int idZamestnanec);

         
    }
}