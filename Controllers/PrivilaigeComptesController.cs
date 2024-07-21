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
    public class PrivilaigeComptesController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;

        public PrivilaigeComptesController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/PrivilaigeComptes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrivilaigeCompte>>> GetPrivilaigeComptes()
        {
            var AllPrivilaigesComptes = await _context.PrivilaigeComptes.ToListAsync();
            return Ok(_mapper.Map<List<PrivilaigeCompteDto>>(AllPrivilaigesComptes)); 
            
        }

        // GET: api/PrivilaigeComptes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrivilaigeCompte>> GetPrivilaigeCompte(int id)
        {
            var privilaigeCompte = await _context.PrivilaigeComptes.FindAsync(id);

            if (privilaigeCompte == null)
            {
                return NotFound();
            }

            return privilaigeCompte;
        }

        // PUT: api/PrivilaigeComptes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrivilaigeCompte(int id, PrivilaigeCompteDto privilaigeCompteDto)
        {
            var privilaigeCompte = _mapper.Map<PrivilaigeCompte>(privilaigeCompteDto);
            if (id != privilaigeCompte.Id)
            {
                return BadRequest();
            }

            _context.Entry(privilaigeCompte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrivilaigeCompteExists(id))
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

        // POST: api/PrivilaigeComptes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PrivilaigeCompte>> PostPrivilaigeCompte(PrivilaigeCompteDto privilaigeCompteDto)
        {
            var privilaigeCompte = _mapper.Map<PrivilaigeCompte>(privilaigeCompteDto);
            _context.PrivilaigeComptes.Add(privilaigeCompte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrivilaigeCompte", new { id = privilaigeCompte.Id }, privilaigeCompte);
        }

        // DELETE: api/PrivilaigeComptes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrivilaigeCompte(int id)
        {
            var privilaigeCompte = await _context.PrivilaigeComptes.FindAsync(id);
            if (privilaigeCompte == null)
            {
                return NotFound();
            }

            _context.PrivilaigeComptes.Remove(privilaigeCompte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrivilaigeCompteExists(int id)
        {
            return _context.PrivilaigeComptes.Any(e => e.Id == id);
        }
    }
}
