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
    public class PrivilaigesController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;

        public PrivilaigesController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Privilaiges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Privilaige>>> GetPrivilaiges()
        {
            var AllPrivilaiges= await _context.Privilaiges.ToListAsync();
            return Ok(_mapper.Map<List<PrivilaigeDto>>(AllPrivilaiges));
        }

        // GET: api/Privilaiges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Privilaige>> GetPrivilaige(int id)
        {

            var privilaige = await _context.Privilaiges.FindAsync(id);

            if (privilaige == null)
            {
                return NotFound();
            }

            return privilaige;
        }

        // PUT: api/Privilaiges/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrivilaige(int id, PrivilaigeDto privilaigeDto)
        {
            var privilaige = _mapper.Map<Privilaige>(privilaigeDto);
            
            if (id != privilaige.Id)
            {
                return BadRequest();
            }

            _context.Entry(privilaige).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrivilaigeExists(id))
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

        // POST: api/Privilaiges
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Privilaige>> PostPrivilaige(PrivilaigeDto privilaigeDto)
        {
            var privilaige = _mapper.Map<Privilaige>(privilaigeDto);
            _context.Privilaiges.Add(privilaige);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrivilaige", new { id = privilaige.Id }, privilaige);
        }

        // DELETE: api/Privilaiges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrivilaige(int id)
        {
            var privilaige = await _context.Privilaiges.FindAsync(id);
            if (privilaige == null)
            {
                return NotFound();
            }

            _context.Privilaiges.Remove(privilaige);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrivilaigeExists(int id)
        {
            return _context.Privilaiges.Any(e => e.Id == id);
        }
    }
}
