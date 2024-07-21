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
    public class TypeSinistresController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        public readonly IMapper _mapper;

        public TypeSinistresController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/TypeSinistres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeSinistre>>> GetTypeSinistres()
        {
            var allTypes= await _context.TypeSinistres.ToListAsync();
            return Ok(_mapper.Map<List<TypeSinistreDto>>(allTypes));
        }

        // GET: api/TypeSinistres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeSinistre>> GetTypeSinistre(int id)
        {
            var typeSinistre = await _context.TypeSinistres.FindAsync(id);

            if (typeSinistre == null)
            {
                return NotFound();
            }

            return typeSinistre;
        }

        // PUT: api/TypeSinistres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeSinistre(int id, TypeSinistreDto typeSinistreDto)
        {
            var typeSinistre = _mapper.Map<TypeSinistre>(typeSinistreDto);
            if (id != typeSinistre.Id)
            {
                return BadRequest();
            }

            _context.Entry(typeSinistre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeSinistreExists(id))
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

        // POST: api/TypeSinistres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeSinistre>> PostTypeSinistre(TypeSinistreDto typeSinistreDto)
        {
            var typeSinistre = _mapper.Map<TypeSinistre>(typeSinistreDto);

            _context.TypeSinistres.Add(typeSinistre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeSinistre", new { id = typeSinistre.Id }, typeSinistre);
        }

        // DELETE: api/TypeSinistres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeSinistre(int id)
        {
            var typeSinistre = await _context.TypeSinistres.FindAsync(id);
            if (typeSinistre == null)
            {
                return NotFound();
            }

            _context.TypeSinistres.Remove(typeSinistre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeSinistreExists(int id)
        {
            return _context.TypeSinistres.Any(e => e.Id == id);
        }
    }
}
