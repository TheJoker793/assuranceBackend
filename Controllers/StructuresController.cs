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
    public class StructuresController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;
        public StructuresController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Structures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Structure>>> GetStructures()
        {
            var allStructures= await _context.Structures.ToListAsync();
            return Ok( _mapper.Map<List<StructureDto>>(allStructures));
        }

        // GET: api/Structures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Structure>> GetStructure(int id)
        {
            var structure = await _context.Structures.FindAsync(id);

            if (structure == null)
            {
                return NotFound();
            }

            return structure;
        }

        // PUT: api/Structures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStructure(int id, StructureDto structureDto)
        {
            var structure = _mapper.Map<Structure>(structureDto);
            if (id != structure.Id)
            {
                return BadRequest();
            }

            _context.Entry(structure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StructureExists(id))
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

        // POST: api/Structures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Structure>> PostStructure(StructureDto structureDto)
        {
            var structure = _mapper.Map<Structure>(structureDto);

            _context.Structures.Add(structure);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStructure", new { id = structure.Id }, structure);
        }

        // DELETE: api/Structures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStructure(int id)
        {
            var structure = await _context.Structures.FindAsync(id);
            if (structure == null)
            {
                return NotFound();
            }

            _context.Structures.Remove(structure);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StructureExists(int id)
        {
            return _context.Structures.Any(e => e.Id == id);
        }
    }
}
