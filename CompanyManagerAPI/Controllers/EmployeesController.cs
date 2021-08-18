using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagerAPI.Controllers
{
    public class EmployeesController : BaseApiController
    {
        private readonly DataContext _context;
        public EmployeesController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zamestnanec>>> GetAllEmployees()
        {
            return await _context.Zamestnanci.ToListAsync();
        }

        // api/employees/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Zamestnanec>> GetEmployee(int id)
        {
            return await _context.Zamestnanci.FindAsync(id);
        }








    }
}