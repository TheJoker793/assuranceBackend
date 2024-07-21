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
    public class DemandeTypesController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;

        public DemandeTypesController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/DemandeTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DemandeType>>> GetDemandeTypes()
        {
            var AllDemandesTypes= await _context.DemandeTypes.ToListAsync();
            return Ok(_mapper.Map<List<DemandeType>>(AllDemandesTypes));
        }

        // GET: api/DemandeTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DemandeType>> GetDemandeType(int id)
        {
            var demandeType = await _context.DemandeTypes.FindAsync(id);

            if (demandeType == null)
            {
                return NotFound();
            }

            return demandeType;
        }

        // PUT: api/DemandeTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDemandeType(int id, DemandeTypeDto demandeTypeDto)
        {
            var demandeType = _mapper.Map<DemandeType>(demandeTypeDto);
            if (id != demandeType.Id)
            {
                return BadRequest();
            }

            _context.Entry(demandeType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DemandeTypeExists(id))
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

        // POST: api/DemandeTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DemandeType>> PostDemandeType(DemandeTypeDto demandeTypeDto)
        {
            var demandeType = _mapper.Map<DemandeType>(demandeTypeDto);
            _context.DemandeTypes.Add(demandeType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDemandeType", new { id = demandeType.Id }, demandeType);
        }

        // DELETE: api/DemandeTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDemandeType(int id)
        {
            var demandeType = await _context.DemandeTypes.FindAsync(id);
            if (demandeType == null)
            {
                return NotFound();
            }

            _context.DemandeTypes.Remove(demandeType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DemandeTypeExists(int id)
        {
            return _context.DemandeTypes.Any(e => e.Id == id);
        }
    }
}
