using System.Drawing;
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
    public class ProjektRepository : IProjektRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ProjektRepository(DataContext context, IMapper mapper)

        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ActionResult<ProjektDTO>> CreateProjekt(CreateProjekt createProjekt)
        {
            await _context.Projekts.AddAsync(_mapper.Map<Projekt>(createProjekt));
            return _mapper.Map<ProjektDTO>(createProjekt);
        }

        public async Task<ActionResult<IEnumerable<ProjektDTO>>> GetAllProjektsByDivizionId(int divizionId)
        {
            var query = await _context.Projekts
                .Join(
                    _context.Divizie, 
                    p => p.IdDivizia,
                    d => d.IdDivizia,
                    (p,d) => new ProjektDTO
                    {
                        IdDivizia = p.IdDivizia,
                        IdProjekt = p.IdProjekt,
                        IdVedProjekt = p.IdVedProjekt, 
                        Nazov = p.Nazov,
                    })
                .OrderByDescending(p => p.Nazov).ToListAsync();

            return query;
        }

        public async Task<ActionResult<ProjektDTO>> GetProjektById(int id)
        {
           return await _context.Projekts.Where(p => p.IdProjekt == id).ProjectTo<ProjektDTO>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public Task<bool> ProejektShouldAddVeduci(int idZamestnanec)
        {
           return _context.Zamestnanci.AnyAsync(zam => zam.IdZamestnanec == idZamestnanec);
        }

        public async Task<bool> ProjektExists(int id) => await _context.Projekts.AnyAsync(p => p.IdProjekt == id);

        public async Task<bool> RemoveProjekt(int diviziaId)
        {
            var projekt = await _context.Projekts.FindAsync(diviziaId);

            if (projekt == null) return false;

            // adding a tracking flag 
            _context.Projekts.Remove(projekt);
            return true;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(ProjektDTO projekt)
        {
             // Ef update and add flag thats been modified 
            var projektToUpdate = _mapper.Map<Projekt>(projekt);
           
            _context.Entry(projektToUpdate).State = EntityState.Modified;
        }
    }
}