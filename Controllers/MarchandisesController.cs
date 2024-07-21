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
    public class MarchandisesController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;

        public MarchandisesController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Marchandises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marchandise>>> GetMarchandises()
        {
            var AllMarchandise= await _context.Marchandises.ToListAsync();
            return Ok(_mapper.Map<List<MarchandiseDto>>(AllMarchandise));
        }

        // GET: api/Marchandises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Marchandise>> GetMarchandise(int id)
        {
            var marchandise = await _context.Marchandises.FindAsync(id);

            if (marchandise == null)
            {
                return NotFound();
            }

            return marchandise;
        }

        // PUT: api/Marchandises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarchandise(int id, MarchandiseDto marchandiseDto)
        {
            var marchandise = _mapper.Map<Marchandise>(marchandiseDto);
            if (id != marchandise.Id)
            {
                return BadRequest();
            }

            _context.Entry(marchandise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarchandiseExists(id))
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

        // POST: api/Marchandises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Marchandise>> PostMarchandise(MarchandiseDto marchandiseDto)
        {
            var marchandise = _mapper.Map<Marchandise>(marchandiseDto);

            _context.Marchandises.Add(marchandise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarchandise", new { id = marchandise.Id }, marchandise);
        }

        // DELETE: api/Marchandises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarchandise(int id)
        {
            var marchandise = await _context.Marchandises.FindAsync(id);
            if (marchandise == null)
            {
                return NotFound();
            }

            _context.Marchandises.Remove(marchandise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MarchandiseExists(int id)
        {
            return _context.Marchandises.Any(e => e.Id == id);
        }
    }
}
