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
    public class DevisController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;

        public DevisController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Devis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Devis>>> GetDevises()
        {
            var AllDevises= await _context.Devises.ToListAsync();
            return Ok(_mapper.Map<List<DevisDto>>(AllDevises));
        }

        // GET: api/Devis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Devis>> GetDevis(int id)
        {
            var devis = await _context.Devises.FindAsync(id);

            if (devis == null)
            {
                return NotFound();
            }

            return devis;
        }

        // PUT: api/Devis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevis(int id, DevisDto devisDto)
        {
            var devis = _mapper.Map<Devis>(devisDto);
            if (id != devis.Id)
            {
                return BadRequest();
            }

            _context.Entry(devis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DevisExists(id))
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

        // POST: api/Devis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Devis>> PostDevis(DevisDto devisDto)
        {
            var devis = _mapper.Map<Devis>(devisDto);

            _context.Devises.Add(devis);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDevis", new { id = devis.Id }, devis);
        }

        // DELETE: api/Devis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevis(int id)
        {
            var devis = await _context.Devises.FindAsync(id);
            if (devis == null)
            {
                return NotFound();
            }

            _context.Devises.Remove(devis);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DevisExists(int id)
        {
            return _context.Devises.Any(e => e.Id == id);
        }
    }
}
