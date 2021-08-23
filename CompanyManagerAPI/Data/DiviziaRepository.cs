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
    public class DiviziaRepository : IDiviziaRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DiviziaRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ActionResult<DiviziaDTO>> CreateDivizia(CreateDivizia createDivizia)
        {
            await _context.Divizie.AddAsync(_mapper.Map<Divizium>(createDivizia));
            return _mapper.Map<DiviziaDTO>(createDivizia);
        }

        public async Task<bool> DiviziaExists(int id)
        {
            return await _context.Divizie.AnyAsync(div => div.IdDivizia == id);
        }

        public async Task<bool> DiviziaShouldAddVeduci(int idZamestnanec)
        {
            return await _context.Zamestnanci.AnyAsync(zam => zam.IdZamestnanec == idZamestnanec);
        }

        public async Task<ActionResult<IEnumerable<DiviziaDTO>>> GetAllDiviziasByFirmaId(int firmaId)
        {
            // we wanna inner sequience smaller then outer 
            var divizionsByFirma = await _context.Divizie
                .Join(_context.Firmy, 
                         d => d.IdFirma, 
                         f => f.IdFirma,(d,f) => new DiviziaDTO
                         {
                            IdFirma = d.IdFirma,
                            IdDivizia = d.IdDivizia,
                            IdVedDivizie = d.IdVedDivizie,
                            Nazov = d.Nazov
                         })
                .OrderByDescending(d => d.Nazov).ToListAsync();

            return divizionsByFirma;
        }

        public async Task<ActionResult<DiviziaDTO>> GetDiviziaById(int id)
        {
            return await _context.Divizie.Where(d => d.IdDivizia == id).ProjectTo<DiviziaDTO>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public async Task<bool> RemoveDivizia(int diviziaId)
        {

            
            var divizium  = await _context.Divizie.FindAsync(diviziaId);

            if (divizium == null ) return false;
            _context.Divizie.Remove(divizium);
            return true;
        }

        public Task<bool> SaveAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update(DiviziaDTO divizia)
        {
            var diviziaToUpdate = _mapper.Map<Divizium>(divizia);

            _context.Entry(diviziaToUpdate).State = EntityState.Modified;

        }
    }
}