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
    public class SituationsController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;
        public SituationsController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Situations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Situation>>> GetSituations()
        {
            var AllSituations= await _context.Situations.ToListAsync();
            return Ok (_mapper.Map<List<SituationDto>>(AllSituations));
        }

        // GET: api/Situations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Situation>> GetSituation(int id)
        {
            var situation = await _context.Situations.FindAsync(id);

            if (situation == null)
            {
                return NotFound();
            }

            return situation;
        }

        // PUT: api/Situations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSituation(int id, SituationDto situationDto)
        {
            var situation = _mapper.Map<Situation>(situationDto);
            if (id != situation.Id)
            {
                return BadRequest();
            }

            _context.Entry(situation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SituationExists(id))
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

        // POST: api/Situations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Situation>> PostSituation(SituationDto situationDto)
        {
            var situation = _mapper.Map<Situation>(situationDto);
            _context.Situations.Add(situation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSituation", new { id = situation.Id }, situation);
        }

        // DELETE: api/Situations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSituation(int id)
        {
            var situation = await _context.Situations.FindAsync(id);
            if (situation == null)
            {
                return NotFound();
            }

            _context.Situations.Remove(situation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SituationExists(int id)
        {
            return _context.Situations.Any(e => e.Id == id);
        }
    }
}
