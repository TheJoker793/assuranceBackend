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
    public class DemandeItemsController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;

        public DemandeItemsController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/DemandeItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DemandeItem>>> GetDemandeItems()
        {
            var allDemandsItem=await _context.DemandeItems
                .Include(di => di.Bien)
                .Include(di => di.Marchandise)
                .Select(di => new DemandeItemDto 
                {
                    Id = di.Id,
                    DateEffet = di.DateEffet,
                    Origine = di.Origine,
                    Destination = di.Destination,
                    DateExpedition = di.DateExpedition,
                    NomNavire = di.NomNavire,
                    NomChauffeur = di.NomChauffeur,
                    NomCompanie = di.NomCompanie,
                    Matricule = di.Matricule,
                    IdZone = di.IdZone,
                    BienId = di.BienId,
                    CodeBien=di.Bien.Code,
                    DateAquisationBien=di.Bien.DaeAcquisation,
                    MarchandseId = di.MarchandseId,
                    CodeMarchandise=di.Marchandise.code,
                    NatureMarchandise=di.Marchandise.Nature

                })

                .ToListAsync();
            return Ok(_mapper.Map<List<DemandeItemDto>>(allDemandsItem));
                
                
                
        }

        // GET: api/DemandeItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DemandeItem>> GetDemandeItem(int id)
        {
            var demandeItem = await _context.DemandeItems.FindAsync(id);

            if (demandeItem == null)
            {
                return NotFound();
            }
            var demandeItemDto = _mapper.Map<DemandeItemDto>(demandeItem);

            return Ok(demandeItemDto);
        }

        // PUT: api/DemandeItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDemandeItem(int id, DemandeItemDto demandeItemDto)
        {
            var demandeItem = _mapper.Map<DemandeItem>(demandeItemDto);
            if (id != demandeItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(demandeItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DemandeItemExists(id))
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

        // POST: api/DemandeItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DemandeItem>> PostDemandeItem(DemandeItemDto demandeItemDto)
        {
            var demandeItem = _mapper.Map<DemandeItem>(demandeItemDto);

            _context.DemandeItems.Add(demandeItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDemandeItem", new { id = demandeItem.Id }, demandeItem);
        }

        // DELETE: api/DemandeItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDemandeItem(int id)
        {
            var demandeItem = await _context.DemandeItems.FindAsync(id);
            if (demandeItem == null)
            {
                return NotFound();
            }

            _context.DemandeItems.Remove(demandeItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DemandeItemExists(int id)
        {
            return _context.DemandeItems.Any(e => e.Id == id);
        }
    }
}
