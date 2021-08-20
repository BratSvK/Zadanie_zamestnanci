using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CompanyManagerAPI.DTOs;
using CompanyManagerAPI.Interfaces;
using CompanyManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagerAPI.Data
{
    public class EmploeyeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public EmploeyeeRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ActionResult<EmployeeDTO>> CreateEmploeyee(CreateEmploeyee emploeyee)
        {
            // tracking change to db
            await _context.Zamestnanci.AddAsync(_mapper.Map<Zamestnanec>(emploeyee));

            return  _mapper.Map<EmployeeDTO>(emploeyee);
        }

        public async Task<ActionResult<EmployeeDTO>> GetEmploeyeeByIdAsync(int id)
        {
            return await _context.Zamestnanci
            .Where(user => user.IdZamestnanec == id)
            .ProjectTo<EmployeeDTO>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }

        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployeesAsync()
        {
            return await _context.Zamestnanci.ProjectTo<EmployeeDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<bool> RemoveEmploeyee(int emploeyeeId)
        {
            var employee = await _context.Zamestnanci.FindAsync(emploeyeeId);

            if (employee == null) return false;

            // adding a tracking flag 
            _context.Zamestnanci.Remove(employee);

            return true;
        }


        /// <summary>
        /// If something is save value is > 0
        /// </summary>
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(EmployeeDTO employee)
        {
            // Ef update and add flag thats been modified 
           var zamestnanec = _mapper.Map<Zamestnanec>(employee);
           
            _context.Entry(zamestnanec).State = EntityState.Modified;
        }


        public async Task<bool> EmploeyeeExists(int id) => await _context.Zamestnanci.AnyAsync(zam => zam.IdZamestnanec == id);


        public async Task<bool> EmploeyeeShouldAddToOddelenie(int idOddelenie) => !await _context.Oddelenia.AnyAsync(odd => odd.IdOddelenie == idOddelenie);


    }
}