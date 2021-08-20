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
    public class FirmaRepository : IFirmaRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public FirmaRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ActionResult<FirmaDTO>> CreateFirma(CreateFirma createFirma)
        {

            await _context.Firmy.AddAsync(_mapper.Map<Firma>(createFirma));
            return _mapper.Map<FirmaDTO>(createFirma);
        }

        public async Task<bool> FirmaExists(int id) => await _context.Firmy.AnyAsync(fir => fir.IdFirma == id);

        public Task<bool> FirmaShouldAddVeduci(int idZamestnanec)
        {
            return _context.Zamestnanci.AnyAsync(zam => zam.IdZamestnanec == idZamestnanec);
        }

        public async Task<ActionResult<IEnumerable<FirmaDTO>>> GetAllFirmas() => await _context.Firmy.ProjectTo<FirmaDTO>(_mapper.ConfigurationProvider).ToListAsync();

        public async Task<ActionResult<FirmaDTO>> GetFirmaById(int id)
        {
            return await _context.Firmy.Where(f => f.IdFirma == id).ProjectTo<FirmaDTO>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public async Task<bool> RemoveFirma(int firmaId)
        {
            var firma = await _context.Firmy.FindAsync(firmaId);

            if (firma == null) return false;

            // adding a tracking flag 
            _context.Firmy.Remove(firma);
            return true;
            
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(FirmaDTO firma)
        {
             // Ef update and add flag thats been modified 
            var firmaToUpdate = _mapper.Map<Firma>(firma);
           
            _context.Entry(firmaToUpdate).State = EntityState.Modified;
        }
    }
}