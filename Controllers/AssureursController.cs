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
    public class AssureursController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;

        public AssureursController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Assureurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assureur>>> GetAssureurs()
        {
            var AllAssureurs= await _context.Assureurs.ToListAsync();
            return Ok(_mapper.Map<List<AssureurDto>>(AllAssureurs));
        }

        // GET: api/Assureurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assureur>> GetAssureur(int id)
        {
            var assureur = await _context.Assureurs.FindAsync(id);

            if (assureur == null)
            {
                return NotFound();
            }

            return assureur;
        }

        // PUT: api/Assureurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssureur(int id, AssureurDto assureurDto)
        {
            var assureur = _mapper.Map<Assureur>(assureurDto);
            if (id != assureur.Id)
            {
                return BadRequest();
            }

            _context.Entry(assureur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssureurExists(id))
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

        // POST: api/Assureurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Assureur>> PostAssureur(AssureurDto assureurDto)
        {
            var assureur = _mapper.Map<Assureur>(assureurDto);

            _context.Assureurs.Add(assureur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssureur", new { id = assureur.Id }, assureur);
        }

        // DELETE: api/Assureurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssureur(int id)
        {
            var assureur = await _context.Assureurs.FindAsync(id);
            if (assureur == null)
            {
                return NotFound();
            }

            _context.Assureurs.Remove(assureur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssureurExists(int id)
        {
            return _context.Assureurs.Any(e => e.Id == id);
        }
    }
}
