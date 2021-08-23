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
        private readonly IDiviziaRepository _diviziaRepository;
        private readonly IProjektRepository _projektRepository;
        public CompanyController(IFirmaRepository firmaRepository, IMapper mapper, IDiviziaRepository diviziaRepository, IProjektRepository projektRepository)
        {
            _mapper = mapper;
            _projektRepository = projektRepository;
            _diviziaRepository = diviziaRepository;
            _firmaRepository = firmaRepository;
        }



        #region Firma

        [HttpGet("firmy")]
        public async Task<ActionResult<IEnumerable<FirmaDTO>>> GetAllFirmas()
        {
            return await _firmaRepository.GetAllFirmas();
        }

        // create

        [HttpPost("firma/create")]
        public async Task<ActionResult<FirmaDTO>> CreateFirma(CreateFirma createFirma)
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
        public async Task<ActionResult> RemoveFirma(int firmaId)
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

        #endregion


        #region Divizia


        [HttpGet("firma/{idFirma}/divizie")]
        public async Task<ActionResult<IEnumerable<DiviziaDTO>>> GetAllDivizionsByFirmaId(int idFirma)
        {
            if (!await _firmaRepository.FirmaExists(idFirma)) return NotFound("Firma not found ");

            return await _diviziaRepository.GetAllDiviziasByFirmaId(idFirma);
        }

        // create


        [HttpPost("firma/{idFirma}/divizia/create")]
        public async Task<ActionResult<DiviziaDTO>> CreateDivizia(int idFirma, CreateDivizia createDivizia)
        {

            if (!await _firmaRepository.FirmaExists(idFirma)) return BadRequest("The firma doesn't exits ");

            if (await _diviziaRepository.DiviziaExists(createDivizia.IdDivizia)) return BadRequest("The divizia exists already");

            if (!await _diviziaRepository.DiviziaShouldAddVeduci(createDivizia.IdVedDivizie)) return BadRequest("Cannot assing veduci to your firma");

            createDivizia.IdFirma = idFirma;

            var divizia = await _diviziaRepository.CreateDivizia(createDivizia);


            // save to db
            if (await _firmaRepository.SaveAllAsync()) return Ok(divizia.Value);

            return BadRequest("Failed to create a Divizia");
        }


        // remove 

        // delete emploeyee
        [HttpDelete("firma/{idFirma}/divizium/{idDivizium}/remove")]
        public async Task<ActionResult> RemoveDivizium(int idFirma, int idDivizium)
        {

            if (!await _firmaRepository.FirmaExists(idFirma)) return BadRequest("The firma doesn't exits ");

            if (!await _diviziaRepository.RemoveDivizia(idDivizium)) return NotFound("Divizium not found in your company");

            if (await _firmaRepository.SaveAllAsync()) return Ok("Divizium succesfully deleted");

            return BadRequest("Failed to remove a firma");

        }


        // edit  

        [HttpPut("firma/{firmaId}/divizium/{diviziumId}/update")]
        public async Task<ActionResult> UpdateDivizium(int firmaId, int diviziumId, UpdateDiviziaDTO updateDiviziaDTO)
        {

            if (!await _firmaRepository.FirmaExists(firmaId)) return NotFound("Firma not found ");

            if (!await _diviziaRepository.DiviziaExists(diviziumId)) return NotFound("Divizia not found");

            var divizia = await _diviziaRepository.GetDiviziaById(diviziumId);

            updateDiviziaDTO.IdVeduci = divizia.Value.IdVedDivizie;
            updateDiviziaDTO.IdFirma = divizia.Value.IdFirma;

            // mapp all properties which we changed 
            _mapper.Map(updateDiviziaDTO, divizia.Value);

            _diviziaRepository.Update(divizia.Value);



            if (await _firmaRepository.SaveAllAsync()) return Ok("Succesfully updated");

            return BadRequest("Updating failed");


        }

        #endregion

        //#region  Projekt


        [HttpGet("divizia/{idDivizia}/projekty")]
        public async Task<ActionResult<IEnumerable<ProjektDTO>>> GetAllProjekts(int idDivizia)
        {
            if (!await _diviziaRepository.DiviziaExists(idDivizia)) return NotFound("Divizia not found ");

            return await _projektRepository.GetAllProjektsByDivizionId(idDivizia);
        }

        // create


        [HttpPost("divizia/{idDivizia}/projekt/create")]
        public async Task<ActionResult<ProjektDTO>> CreateProjekt(int idDivizia, CreateProjekt createProjekt)
        {

            if (!await _diviziaRepository.DiviziaExists(idDivizia)) return BadRequest("The divizia doesn't exits ");

            if (await _projektRepository.ProjektExists(createProjekt.IdProjekt)) return BadRequest("The divizia exists already");

            if (!await _projektRepository.ProejektShouldAddVeduci(createProjekt.IdVedProjekt)) return BadRequest("Cannot assing veduci to your firma");

            createProjekt.IdDivizia = idDivizia;

            var divizia = await _projektRepository.CreateProjekt(createProjekt);


            // save to db
            if (await _firmaRepository.SaveAllAsync()) return Ok(divizia.Value);

            return BadRequest("Failed to create a Divizia");
        }

        


        // remove 

        // delete emploeyee
        [HttpDelete("divizia/{idDivizium}/projekt/{idProjekt}/remove")]
        public async Task<ActionResult> RemoveProjekt(int idProjekt,int idDivizium)
        {

            if (!await _diviziaRepository.DiviziaExists(idDivizium)) return BadRequest("The Divizium doesn't exits ");

            if (!await _projektRepository.RemoveProjekt(idProjekt)) return NotFound("Projekt not found in your company");

            if (await _firmaRepository.SaveAllAsync()) return Ok("Divizium succesfully deleted");

            return BadRequest("Failed to remove a firma");

        }

        /*


        // edit  

        [HttpPut("firma/{firmaId}/divizium/{diviziumId}/update")]
        public async Task<ActionResult> UpdateDivizium(int firmaId,int diviziumId, UpdateDiviziaDTO updateDiviziaDTO)
        {

            if (!await _firmaRepository.FirmaExists(firmaId)) return NotFound("Firma not found ");

            if (! await _diviziaRepository.DiviziaExists(diviziumId)) return NotFound("Divizia not found");

            var divizia  = await _diviziaRepository.GetDiviziaById(diviziumId);

            updateDiviziaDTO.IdVeduci = divizia.Value.IdVedDivizie;
            updateDiviziaDTO.IdFirma = divizia.Value.IdFirma;

            // mapp all properties which we changed 
            _mapper.Map(updateDiviziaDTO, divizia.Value);

            _diviziaRepository.Update(divizia.Value);



            if (await _firmaRepository.SaveAllAsync()) return Ok("Succesfully updated");

            return BadRequest("Updating failed");


        }

        #endregion
        */


    }
}