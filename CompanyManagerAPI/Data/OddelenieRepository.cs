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
    public class OddelenieRepository : IOddelenieRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public OddelenieRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ActionResult<OddelenieDTO>> CreateOddelenie(CreateOddelenie createOddelenie)
        {
            await _context.Oddelenia.AddAsync(_mapper.Map<Oddelenie>(createOddelenie));
            return _mapper.Map<OddelenieDTO>(createOddelenie);
        }

        public Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployeeInOddelenie(int projektId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ActionResult<IEnumerable<OddelenieDTO>>> GetAllOddelenieByProjekt(int projektId)
        {
            var query = await _context.Oddelenia.
                        Join(
                            _context.Projekts,
                            o => o.IdProjekt,
                            p => p.IdProjekt,
                            (o,p ) => new OddelenieDTO
                            {
                                IdProjekt = o.IdProjekt,
                                IdOddelenie = o.IdOddelenie,
                                IdVedOddelenia = o.IdVedOddelenia,
                                Nazov = o.Nazov
                            }).OrderByDescending(p => p.Nazov).ToListAsync();
            return query;
        }

        public async Task<ActionResult<OddelenieDTO>> GetOddelenieByID(int id)
        {
            return await _context.Oddelenia.Where(o => o.IdOddelenie == id).ProjectTo<OddelenieDTO>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public async Task<bool> OddelenieShouldAddVeduci(int idZamestnanec)
        {
            return await _context.Zamestnanci.AnyAsync( z => z.IdZamestnanec == idZamestnanec);
        }

        public async Task<bool> OddelnieExists(int id)
        {
            return await _context.Oddelenia.AnyAsync(o => o.IdOddelenie == id);
        }

        public async Task<bool> RemoveOddenielie(int projektId)
        {
            var oddelenie = await _context.Oddelenia.FindAsync(projektId);

            if (oddelenie == null) return false;

            // adding a tracking flag 
            _context.Oddelenia.Remove(oddelenie);
            return true;
            
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(OddelenieDTO oddelenie)
        {
             // Ef update and add flag thats been modified 
            var oddelnieToUpdate = _mapper.Map<Oddelenie>(oddelenie);
           
            _context.Entry(oddelnieToUpdate).State = EntityState.Modified;
        }
    }
}