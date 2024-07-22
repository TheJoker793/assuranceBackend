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
    public class PieceJointesController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;
        public PieceJointesController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/PieceJointes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PieceJointe>>> GetPieceJointes()
        {
            var allPieces= await _context.PieceJointes
                .Include(pj=>pj.Sinistre)
                .Select(pj => new PieceJointeDto
                {
                    Id=pj.Id,
                    Name=pj.Name,
                    Extension=pj.Extension,
                    DateCreation=pj.DateCreation,
                    SinistreId=pj.SinistreId,
                    LibelleSinistre=pj.Sinistre.Libelle,
                    ReferenceSinistre=pj.Sinistre.Reference
                })
                .ToListAsync();
            return Ok(_mapper.Map<List<PieceJointeDto>>(allPieces));
        }

        // GET: api/PieceJointes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PieceJointe>> GetPieceJointe(int id)
        {
            var pieceJointe = await _context.PieceJointes.FindAsync(id);

            if (pieceJointe == null)
            {
                return NotFound();
            }
            var PieceJointeDto = _mapper.Map<PieceJointeDto>(pieceJointe);

            return Ok(PieceJointeDto);
        }

        // PUT: api/PieceJointes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPieceJointe(int id, PieceJointeDto pieceJointeDto)
        {
            var pieceJointe=_mapper.Map<PieceJointe>(pieceJointeDto);
            if (id != pieceJointe.Id)
            {
                return BadRequest();
            }

            _context.Entry(pieceJointe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PieceJointeExists(id))
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

        // POST: api/PieceJointes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PieceJointe>> PostPieceJointe(PieceJointeDto pieceJointeDto)
        {
            var pieceJointe = _mapper.Map<PieceJointe>(pieceJointeDto);
            _context.PieceJointes.Add(pieceJointe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPieceJointe", new { id = pieceJointe.Id }, pieceJointe);
        }

        // DELETE: api/PieceJointes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePieceJointe(int id)
        {
            var pieceJointe = await _context.PieceJointes.FindAsync(id);
            if (pieceJointe == null)
            {
                return NotFound();
            }

            _context.PieceJointes.Remove(pieceJointe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PieceJointeExists(int id)
        {
            return _context.PieceJointes.Any(e => e.Id == id);
        }
    }
}
