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
    public class CompteBancairesController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;

        public CompteBancairesController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/CompteBancaires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompteBancaire>>> GetCompteBancaires()
        {
            var AllComptesBancaires= await _context.CompteBancaires.ToListAsync();
            return Ok(_mapper.Map<List<CompteBancaireDto>>(AllComptesBancaires));
        }

        // GET: api/CompteBancaires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompteBancaire>> GetCompteBancaire(int id)
        {
            var compteBancaire = await _context.CompteBancaires.FindAsync(id);

            if (compteBancaire == null)
            {
                return NotFound();
            }

            return compteBancaire;
        }

        // PUT: api/CompteBancaires/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompteBancaire(int id, CompteBancaireDto compteBancaireDto)
        {
            var compteBancaire = _mapper.Map<CompteBancaire>(compteBancaireDto);
            if (id != compteBancaire.Id)
            {
                return BadRequest();
            }

            _context.Entry(compteBancaire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompteBancaireExists(id))
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

        // POST: api/CompteBancaires
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompteBancaire>> PostCompteBancaire(CompteBancaireDto compteBancaireDto)
        {
            var compteBancaire = _mapper.Map<CompteBancaire>(compteBancaireDto);

            _context.CompteBancaires.Add(compteBancaire);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompteBancaire", new { id = compteBancaire.Id }, compteBancaire);
        }

        // DELETE: api/CompteBancaires/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompteBancaire(int id)
        {
            var compteBancaire = await _context.CompteBancaires.FindAsync(id);
            if (compteBancaire == null)
            {
                return NotFound();
            }

            _context.CompteBancaires.Remove(compteBancaire);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompteBancaireExists(int id)
        {
            return _context.CompteBancaires.Any(e => e.Id == id);
        }
    }
}
