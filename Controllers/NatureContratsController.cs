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
    public class NatureContratsController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;
        public NatureContratsController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/NatureContrats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NatureContrat>>> GetNatureContrats()
        {
            var AllNatures= await _context.NatureContrats.ToListAsync();
            return Ok(_mapper.Map<List<NatureContratDto>>(AllNatures));
        }

        // GET: api/NatureContrats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NatureContrat>> GetNatureContrat(int id)
        {
            var natureContrat = await _context.NatureContrats.FindAsync(id);

            if (natureContrat == null)
            {
                return NotFound();
            }

            return natureContrat;
        }

        // PUT: api/NatureContrats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNatureContrat(int id, NatureContratDto natureContratDto)
        {
            var natureContrat = _mapper.Map<NatureContrat>(natureContratDto);
            if (id != natureContrat.Id)
            {
                return BadRequest();
            }

            _context.Entry(natureContrat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NatureContratExists(id))
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

        // POST: api/NatureContrats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NatureContrat>> PostNatureContrat(NatureContratDto natureContratDto)
        {
            var natureContrat = _mapper.Map<NatureContrat>(natureContratDto);

            _context.NatureContrats.Add(natureContrat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNatureContrat", new { id = natureContrat.Id }, natureContrat);
        }

        // DELETE: api/NatureContrats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNatureContrat(int id)
        {
            var natureContrat = await _context.NatureContrats.FindAsync(id);
            if (natureContrat == null)
            {
                return NotFound();
            }

            _context.NatureContrats.Remove(natureContrat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NatureContratExists(int id)
        {
            return _context.NatureContrats.Any(e => e.Id == id);
        }
    }
}
