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
    public class DossiersController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;

        public DossiersController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Dossiers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dossier>>> GetDossiers()
        {
            var AllDossiers= await _context.Dossiers.ToListAsync();
            return Ok(_mapper.Map<List<DossierDto>>(AllDossiers));
        }

        // GET: api/Dossiers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dossier>> GetDossier(int id)
        {
            var dossier = await _context.Dossiers.FindAsync(id);

            if (dossier == null)
            {
                return NotFound();
            }

            return dossier;
        }

        // PUT: api/Dossiers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDossier(int id, DossierDto dossierDto)
        {
            var dossier = _mapper.Map<Dossier>(dossierDto);
            if (id != dossier.Id)
            {
                return BadRequest();
            }

            _context.Entry(dossier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DossierExists(id))
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

        // POST: api/Dossiers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dossier>> PostDossier(DossierDto dossierDto)
        {
            var dossier = _mapper.Map<Dossier>(dossierDto);

            _context.Dossiers.Add(dossier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDossier", new { id = dossier.Id }, dossier);
        }

        // DELETE: api/Dossiers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDossier(int id)
        {
            var dossier = await _context.Dossiers.FindAsync(id);
            if (dossier == null)
            {
                return NotFound();
            }

            _context.Dossiers.Remove(dossier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DossierExists(int id)
        {
            return _context.Dossiers.Any(e => e.Id == id);
        }
    }
}
