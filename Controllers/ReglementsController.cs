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
    public class ReglementsController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;

        public ReglementsController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Reglements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reglement>>> GetReglements()
        {
            var AllReglements= await _context.Reglements
                .Include(r=>r.CompteBancaire)
                .Include(r=>r.Personne)
                .Include(r=>r.Devis)
                .Include(r=>r.Situation)
                .Select(r=>new ReglementDto
                {
                    Id=r.Id,
                    Numero=r.Numero,
                    DateRemise=r.DateRemise,
                    SituationId=r.SituationId,
                    LibelleSituation=r.Situation.Libelle,
                    CompteBancaireId=r.CompteBancaireId,
                    LibelleCompteBancaire=r.CompteBancaire.Libelle,
                    RibCompteBancaire=r.CompteBancaire.Rib,
                    CleCompteBancaire=r.CompteBancaire.Cle,
                    DevisId=r.DevisId,
                    LibelleDevis=r.Devis.Libelle,
                    PersonneId=r.PersonneId,
                    CinPersonne=r.Personne.Cin,
                    PrenomPersonne=r.Personne.Prenom,
                    NomPersonne=r.Personne.Nom

                })
                .ToListAsync();
            return Ok(_mapper.Map<List<ReglementDto>>(AllReglements));
        }

        // GET: api/Reglements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reglement>> GetReglement(int id)
        {
            var reglement = await _context.Reglements.FindAsync(id);

            if (reglement == null)
            {
                return NotFound();
            }
            var reglementDto = _mapper.Map<ReglementDto>(reglement);
            return Ok(reglementDto);
        }

        // PUT: api/Reglements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReglement(int id, ReglementDto reglementDto)
        {
            var reglement = _mapper.Map<Reglement>(reglementDto);
            if (id != reglement.Id)
            {
                return BadRequest();
            }

            _context.Entry(reglement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReglementExists(id))
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

        // POST: api/Reglements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reglement>> PostReglement(ReglementDto reglementDto)
        {
            var reglement = _mapper.Map<Reglement>(reglementDto);
            _context.Reglements.Add(reglement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReglement", new { id = reglement.Id }, reglement);
        }

        // DELETE: api/Reglements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReglement(int id)
        {
            var reglement = await _context.Reglements.FindAsync(id);
            if (reglement == null)
            {
                return NotFound();
            }

            _context.Reglements.Remove(reglement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReglementExists(int id)
        {
            return _context.Reglements.Any(e => e.Id == id);
        }
    }
}
