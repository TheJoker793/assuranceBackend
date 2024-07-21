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
    public class BiensController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;

        public BiensController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Biens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bien>>> GetBiens()
        {
            var ListeBiens= await _context.Biens.ToListAsync();
            return Ok(_mapper.Map<List<BienDto>>(ListeBiens));
        }

        // GET: api/Biens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bien>> GetBien(int id)
        {
            var bien = await _context.Biens.FindAsync(id);

            if (bien == null)
            {
                return NotFound();
            }

            return bien;
        }

        // PUT: api/Biens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBien(int id, BienDto bienDto)
        {
            var bien = _mapper.Map<Bien>(bienDto);
            if (id != bien.Id)
            {
                return BadRequest();
            }

            _context.Entry(bien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BienExists(id))
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

        // POST: api/Biens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bien>> PostBien(BienDto bienDto)
        {
            var bien = _mapper.Map<Bien>(bienDto);

            _context.Biens.Add(bien);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBien", new { id = bien.Id }, bien);
        }

        // DELETE: api/Biens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBien(int id)
        {
            var bien = await _context.Biens.FindAsync(id);
            if (bien == null)
            {
                return NotFound();
            }

            _context.Biens.Remove(bien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BienExists(int id)
        {
            return _context.Biens.Any(e => e.Id == id);
        }
    }
}
