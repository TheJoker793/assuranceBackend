using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assurance_Backend;
using Assurance_Backend.Models;
using AutoMapper;
using Assurance_Backend.DTOs;

namespace Assurance_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DossierSinistresController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;

        public DossierSinistresController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/DossierSinistres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DossierSinistre>>> GetDossierSinistres()
        {
            var AllDossiersSinistres= await _context.DossierSinistres.ToListAsync();
            return Ok(_mapper.Map<List<DossierSinistreDto>>(AllDossiersSinistres));
        }

        // GET: api/DossierSinistres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DossierSinistre>> GetDossierSinistre(int id)
        {
            var dossierSinistre = await _context.DossierSinistres.FindAsync(id);

            if (dossierSinistre == null)
            {
                return NotFound();
            }

            return dossierSinistre;
        }

        // PUT: api/DossierSinistres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDossierSinistre(int id, DossierSinistreDto dossierSinistreDto)
        {
            var dossierSinistre = _mapper.Map<DossierSinistre>(dossierSinistreDto);
            if (id != dossierSinistre.Id)
            {
                return BadRequest();
            }

            _context.Entry(dossierSinistre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DossierSinistreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DossierSinistres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DossierSinistre>> PostDossierSinistre(DossierSinistreDto dossierSinistreDto)
        {
            var dossierSinistre = _mapper.Map<DossierSinistre>(dossierSinistreDto);

            _context.DossierSinistres.Add(dossierSinistre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDossierSinistre", new { id = dossierSinistre.Id }, dossierSinistre);
        }

        // DELETE: api/DossierSinistres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDossierSinistre(int id)
        {
            var dossierSinistre = await _context.DossierSinistres.FindAsync(id);
            if (dossierSinistre == null)
            {
                return NotFound();
            }

            _context.DossierSinistres.Remove(dossierSinistre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DossierSinistreExists(int id)
        {
            return _context.DossierSinistres.Any(e => e.Id == id);
        }
    }
}
