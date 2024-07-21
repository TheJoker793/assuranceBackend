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
    public class QuittancePrimesController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;

        public QuittancePrimesController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/QuittancePrimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuittancePrime>>> GetQuittancePrimes()
        {
            var AllQuittPrime= await _context.QuittancePrimes.ToListAsync();
            return Ok(_mapper.Map<List<QuittancePrimeDto>>(AllQuittPrime));
        }

        // GET: api/QuittancePrimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuittancePrime>> GetQuittancePrime(int id)
        {
            var quittancePrime = await _context.QuittancePrimes.FindAsync(id);

            if (quittancePrime == null)
            {
                return NotFound();
            }

            return quittancePrime;
        }

        // PUT: api/QuittancePrimes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuittancePrime(int id, QuittancePrimeDto quittancePrimeDto)
        {
            var quittancePrime = _mapper.Map<QuittancePrime>(quittancePrimeDto);
            if (id != quittancePrime.Id)
            {
                return BadRequest();
            }

            _context.Entry(quittancePrime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuittancePrimeExists(id))
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

        // POST: api/QuittancePrimes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuittancePrime>> PostQuittancePrime(QuittancePrimeDto quittancePrimeDto)
        {
            var quittancePrime = _mapper.Map<QuittancePrime>(quittancePrimeDto);
            _context.QuittancePrimes.Add(quittancePrime);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuittancePrime", new { id = quittancePrime.Id }, quittancePrime);
        }

        // DELETE: api/QuittancePrimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuittancePrime(int id)
        {
            var quittancePrime = await _context.QuittancePrimes.FindAsync(id);
            if (quittancePrime == null)
            {
                return NotFound();
            }

            _context.QuittancePrimes.Remove(quittancePrime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuittancePrimeExists(int id)
        {
            return _context.QuittancePrimes.Any(e => e.Id == id);
        }
    }
}
