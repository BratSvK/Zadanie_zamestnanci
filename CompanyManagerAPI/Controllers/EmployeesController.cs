using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyManagerAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using CompanyManagerAPI.Interfaces;
using AutoMapper;

namespace CompanyManagerAPI.Controllers
{
    /// <summary>
    /// using a repository pattern -> exetuing login with our database 
    /// </summary>
    public class EmployeesController : BaseApiController
    {
        private readonly IEmployeeRepository _emploeyeeRepository;
        private readonly IMapper _mapper;
        public EmployeesController(IEmployeeRepository emploeyeeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _emploeyeeRepository = emploeyeeRepository;
        }


        // get emploeyee

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployees() => await _emploeyeeRepository.GetEmployeesAsync();

        // api/employees/1
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id) => await _emploeyeeRepository.GetEmploeyeeByIdAsync(id);

        // create a emploeyee
        // APIController is smart enough dont need write from where we have data 

        [HttpPost("create")]
        public async Task<ActionResult<EmployeeDTO>> CreateEmploeyee(CreateEmploeyee emploeyee)
        {

            if (await _emploeyeeRepository.EmploeyeeExists(emploeyee.IdZamestnanec)) return BadRequest("The emploeyee with this id already exists");

            if (emploeyee.IdOddelenie != null && await _emploeyeeRepository.EmploeyeeShouldAddToOddelenie(emploeyee.IdOddelenie.Value)) return BadRequest("The oddelenie doesn't exists");

            var employeer = await _emploeyeeRepository.CreateEmploeyee(emploeyee);
            // save to db
            if (await _emploeyeeRepository.SaveAllAsync()) return Ok(employeer.Value);

            return BadRequest("Failed to create a emploeyee");
        }

        // delete emploeyee
        [HttpDelete("remove-emploeyee/{employeeId}")]
        public async Task<ActionResult> RemoveEmploeyee(int employeeId)
        {
            if (!await _emploeyeeRepository.RemoveEmploeyee(employeeId)) return NotFound("Emploeyee not found in your company");

            if (await _emploeyeeRepository.SaveAllAsync()) return Ok("Employer succesfully deleted");

            return BadRequest("Failed to remove a emploeyee");

        }

        // update emploeyee
        // using put -> update resources to our server 

        [HttpPut("update/{employeeId}")]
        public async Task<ActionResult> UpdateEmploeyee(int employeeId, UpdateEmploeyeeDto updateEmploeyeeDto)
        {
            
            if (!await _emploeyeeRepository.EmploeyeeExists(employeeId))  return NotFound("Employee not found ");

            if (updateEmploeyeeDto.OddelenieId != null && await _emploeyeeRepository.EmploeyeeShouldAddToOddelenie(updateEmploeyeeDto.OddelenieId.Value)) return BadRequest("Could Update Emploeyee, oddelenie not exists");

            var emploeyee = await _emploeyeeRepository.GetEmploeyeeByIdAsync(employeeId);

            // mapp all properties which we changed 
            _mapper.Map(updateEmploeyeeDto, emploeyee.Value);

            

            _emploeyeeRepository.Update(emploeyee.Value);

            if (await _emploeyeeRepository.SaveAllAsync()) return Ok("Succesfully updated"); 

            return BadRequest("Updating failed");


        }




    }
}