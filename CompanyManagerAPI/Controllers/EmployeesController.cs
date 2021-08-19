using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CompanyManagerAPI.DTOs;
using CompanyManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagerAPI.Controllers
{
    public class EmployeesController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public EmployeesController(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }


        // get emploeyee

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployees()
        {
            var employess = await _context.Zamestnanci.ToListAsync();

            return Ok(_mapper.Map<IEnumerable<EmployeeDTO>>(employess));
            
        }

        // api/employees/1
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {
            var employes = await _context.Zamestnanci.FindAsync(id);
            return _mapper.Map<EmployeeDTO>(employes);
        }

        // create a emploeyee
        // APIController is smart enough dont need write from where we have data 

        [HttpPost("create")]
        public async Task<ActionResult<Zamestnanec>> CreateEmploeyee(CreateEmploeyee emploeyee)
        {

            if (await EmploeyeeExists(emploeyee.IdZamestnanec)) return BadRequest("The emploeyee with this id already exists");


            var createdEmploeyee = new Zamestnanec
            {
                IdZamestnanec = emploeyee.IdZamestnanec,
                OddelenieId = emploeyee.IdOddelenie,
                Titul = emploeyee.Titul,
                Meno = emploeyee.Meno,
                Priezvisko = emploeyee.Priezvisko,
                Mobil = emploeyee.Mobil,
                Email = emploeyee.Email
            };



            // tracking change to db
            _context.Zamestnanci.Add(createdEmploeyee);

            // save to db

            await _context.SaveChangesAsync();



            return createdEmploeyee;

        }


        private async Task<bool> EmploeyeeExists(int id) => await _context.Zamestnanci.AnyAsync(zam => zam.IdZamestnanec == id);


        // delete emploeyee



        // update emploeyee








    }
}