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
    public class TypeTransportsController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;

        public TypeTransportsController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/TypeTransports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeTransport>>> GetTypeTransports()
        {
            var AllTypes= await _context.TypeTransports.ToListAsync();
            return Ok(_mapper.Map<List<TypeTransportDto>>(AllTypes));
        }

        // GET: api/TypeTransports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeTransport>> GetTypeTransport(int id)
        {
            var typeTransport = await _context.TypeTransports.FindAsync(id);

            if (typeTransport == null)
            {
                return NotFound();
            }

            return typeTransport;
        }

        // PUT: api/TypeTransports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeTransport(int id, TypeTransportDto typeTransportDto)
        {
            var typeTransport = _mapper.Map<TypeTransport>(typeTransportDto);
            if (id != typeTransport.Id)
            {
                return BadRequest();
            }

            _context.Entry(typeTransport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeTransportExists(id))
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

        // POST: api/TypeTransports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeTransport>> PostTypeTransport(TypeTransportDto typeTransportDto)
        {
            var typeTransport = _mapper.Map<TypeTransport>(typeTransportDto);

            _context.TypeTransports.Add(typeTransport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeTransport", new { id = typeTransport.Id }, typeTransport);
        }

        // DELETE: api/TypeTransports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeTransport(int id)
        {
            var typeTransport = await _context.TypeTransports.FindAsync(id);
            if (typeTransport == null)
            {
                return NotFound();
            }

            _context.TypeTransports.Remove(typeTransport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeTransportExists(int id)
        {
            return _context.TypeTransports.Any(e => e.Id == id);
        }
    }
}
