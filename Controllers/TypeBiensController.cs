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
    public class TypeBiensController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;

        public TypeBiensController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/TypeBiens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeBien>>> GetTypeBiens()
        {
            var AllTypes= await _context.TypeBiens.ToListAsync();
            return Ok(_mapper.Map<List<TypeBienDto>>(AllTypes));
        }

        // GET: api/TypeBiens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeBien>> GetTypeBien(int id)
        {
            var typeBien = await _context.TypeBiens.FindAsync(id);

            if (typeBien == null)
            {
                return NotFound();
            }

            return typeBien;
        }

        // PUT: api/TypeBiens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeBien(int id, TypeBienDto typeBienDto)
        {
            var typeBien = _mapper.Map<TypeBien>(typeBienDto);
            if (id != typeBien.Id)
            {
                return BadRequest();
            }

            _context.Entry(typeBien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeBienExists(id))
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

        // POST: api/TypeBiens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeBien>> PostTypeBien(TypeBienDto typeBienDto)
        {
            var typeBien = _mapper.Map<TypeBien>(typeBienDto);

            _context.TypeBiens.Add(typeBien);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeBien", new { id = typeBien.Id }, typeBien);
        }

        // DELETE: api/TypeBiens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeBien(int id)
        {
            var typeBien = await _context.TypeBiens.FindAsync(id);
            if (typeBien == null)
            {
                return NotFound();
            }

            _context.TypeBiens.Remove(typeBien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeBienExists(int id)
        {
            return _context.TypeBiens.Any(e => e.Id == id);
        }
    }
}
