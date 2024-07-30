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
    public class TypeReglementsController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;

        public TypeReglementsController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/TypeReglements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeReglement>>> GetTypeReglements()
        {
            var AllTypes= await _context.TypeReglements.ToListAsync();
            var result=_mapper.Map<List<TypeReglementDto>>(AllTypes);
            return Ok(result);
        }

        // GET: api/TypeReglements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeReglement>> GetTypeReglement(int id)
        {
            var typeReglement = await _context.TypeReglements.FindAsync(id);

            if (typeReglement == null)
            {
                return NotFound();
            }

            return typeReglement;
        }

        // PUT: api/TypeReglements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeReglement(int id, TypeReglementDto typeReglementDto)
        {
            var typeReglement = _mapper.Map<TypeReglement>(typeReglementDto);
            if (id != typeReglement.Id)
            {
                return BadRequest();
            }

            _context.Entry(typeReglement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeReglementExists(id))
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

        // POST: api/TypeReglements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeReglement>> PostTypeReglement(TypeReglementDto typeReglementDto)
        {
            var typeReglement = _mapper.Map<TypeReglement>(typeReglementDto);

            _context.TypeReglements.Add(typeReglement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeReglement", new { id = typeReglement.Id }, typeReglement);
        }

        // DELETE: api/TypeReglements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeReglement(int id)
        {
            var typeReglement = await _context.TypeReglements.FindAsync(id);
            if (typeReglement == null)
            {
                return NotFound();
            }

            _context.TypeReglements.Remove(typeReglement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeReglementExists(int id)
        {
            return _context.TypeReglements.Any(e => e.Id == id);
        }
    }
}
