using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CompanyManagerAPI.DTOs;
using CompanyManagerAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagerAPI.Controllers
{
    public class CompanyController : BaseApiController
    {
        private readonly IFirmaRepository _firmaRepository;
        private readonly IMapper _mapper;
        public CompanyController(IFirmaRepository firmaRepository, IMapper mapper)
        {
            _mapper = mapper;
            _firmaRepository = firmaRepository;
        }





        [HttpGet("firmy")]
        public async Task<ActionResult<IEnumerable<FirmaDTO>>> GetAllFirmas()
        {
            return await _firmaRepository.GetAllFirmas();
        }

        // create

        [HttpPost("firma/create")]
        public async Task<ActionResult<FirmaDTO>> CreateEmploeyee(CreateFirma createFirma)
        {

            if (await _firmaRepository.FirmaExists(createFirma.IdFirma)) return BadRequest("The firma with this id already exists");

            if (!await _firmaRepository.FirmaShouldAddVeduci(createFirma.IdVeduci)) return BadRequest("Cannot assing veduci to your firma");

            var firma = await _firmaRepository.CreateFirma(createFirma);
            // save to db
            if (await _firmaRepository.SaveAllAsync()) return Ok(firma.Value);

            return BadRequest("Failed to create a emploeyee");
        }

        // remove 

        // delete emploeyee
        [HttpDelete("remove-firma/{firmaId}")]
        public async Task<ActionResult> RemoveEmploeyee(int firmaId)
        {
            if (!await _firmaRepository.RemoveFirma(firmaId)) return NotFound("Firma not found in your company");

            if (await _firmaRepository.SaveAllAsync()) return Ok("Firma succesfully deleted");

            return BadRequest("Failed to remove a firma");

        }

        // edit  

        [HttpPut("update/{firmaId}")]
        public async Task<ActionResult> UpdateEmploeyee(int firmaId, UpdateFirmaDTO updateFirmaDTO)
        {

            if (!await _firmaRepository.FirmaExists(firmaId)) return NotFound("Firma not found ");

            var firma = await _firmaRepository.GetFirmaById(firmaId);

            // mapp all properties which we changed 
            _mapper.Map(updateFirmaDTO, firma.Value);



            _firmaRepository.Update(firma.Value);

            if (await _firmaRepository.SaveAllAsync()) return Ok("Succesfully updated");

            return BadRequest("Updating failed");


        }


    }
}