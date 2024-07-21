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
    public class SinistreItemNaturesController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;

        public SinistreItemNaturesController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/SinistreItemNatures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SinistreItemNature>>> GetSinistreItemNatures()
        {
            var AllNatures= await _context.SinistreItemNatures.ToListAsync();
            return Ok(_mapper.Map<List<SinistreItemNatureDto>>(AllNatures));
        }

        // GET: api/SinistreItemNatures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SinistreItemNature>> GetSinistreItemNature(int id)
        {
            var sinistreItemNature = await _context.SinistreItemNatures.FindAsync(id);

            if (sinistreItemNature == null)
            {
                return NotFound();
            }

            return sinistreItemNature;
        }

        // PUT: api/SinistreItemNatures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSinistreItemNature(int id, SinistreItemNatureDto sinistreItemNatureDto)
        {
            var sinistreItemNature = _mapper.Map<SinistreItemNature>(sinistreItemNatureDto);
            if (id != sinistreItemNature.Id)
            {
                return BadRequest();
            }

            _context.Entry(sinistreItemNature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SinistreItemNatureExists(id))
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

        // POST: api/SinistreItemNatures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SinistreItemNature>> PostSinistreItemNature(SinistreItemNatureDto sinistreItemNatureDto)
        {
            var sinistreItemNature = _mapper.Map<SinistreItemNature>(sinistreItemNatureDto);

            _context.SinistreItemNatures.Add(sinistreItemNature);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSinistreItemNature", new { id = sinistreItemNature.Id }, sinistreItemNature);
        }

        // DELETE: api/SinistreItemNatures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSinistreItemNature(int id)
        {
            var sinistreItemNature = await _context.SinistreItemNatures.FindAsync(id);
            if (sinistreItemNature == null)
            {
                return NotFound();
            }

            _context.SinistreItemNatures.Remove(sinistreItemNature);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SinistreItemNatureExists(int id)
        {
            return _context.SinistreItemNatures.Any(e => e.Id == id);
        }
    }
}
