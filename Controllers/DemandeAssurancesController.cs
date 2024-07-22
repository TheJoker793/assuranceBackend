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
    public class DemandeAssurancesController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;

        public DemandeAssurancesController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/DemandeAssurances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DemandeAssurance>>> GetDemandeAssurances()
        {
            var AllDemandes=await _context.DemandeAssurances
                .Include(da=>da.DemandeType)
                .Include(da=>da.QuittancePrime)
                .Include(da=>da.Personne)
                .Select(da=>new DemandeAssuranceDto
                {
                    Id=da.Id,
                    Reference=da.Reference,
                    DateDemande=da.DateDemande,
                    DateEffet=da.DateEffet,
                    DemandeTypeId=da.DemandeTypeId,
                    LibelleDemandeType=da.DemandeType.Libelle,
                    QuittancePrimeId=da.QuittancePrimeId,
                    LibelleQuittancePrime=da.QuittancePrime.Libelle,
                    MontantQuittancePrime=da.QuittancePrime.Montant,
                    DateAjoutQuittancePrime=da.QuittancePrime.DateAjout,
                    PersonneId=da.PersonneId,
                    Cin=da.Personne.Cin,
                    PrenomPersonne=da.Personne.Prenom,
                    NomPersonne=da.Personne.Nom,
                    DateNAissancePersonne=da.Personne.DateNaissance

                })
                .ToListAsync();
            return Ok(_mapper.Map<List<DemandeAssuranceDto>>(AllDemandes));
        }

        // GET: api/DemandeAssurances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DemandeAssurance>> GetDemandeAssurance(int id)
        {
            var demandeAssurance = await _context.DemandeAssurances.FindAsync(id);

            if (demandeAssurance == null)
            {
                return NotFound();
            }
            var DemandeAssuranceDto = _mapper.Map<DemandeAssuranceDto>(demandeAssurance);
            return Ok (DemandeAssuranceDto);
        }

        // PUT: api/DemandeAssurances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDemandeAssurance(int id, DemandeAssuranceDto demandeAssuranceDto)
        {
            var demandeAssurance = _mapper.Map<DemandeAssurance>(demandeAssuranceDto);

            if (id != demandeAssurance.Id)
            {
                return BadRequest();
            }

            _context.Entry(demandeAssurance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DemandeAssuranceExists(id))
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

        // POST: api/DemandeAssurances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DemandeAssurance>> PostDemandeAssurance(DemandeAssuranceDto demandeAssuranceDto)
        {
            var demandeAssurance = _mapper.Map<DemandeAssurance>(demandeAssuranceDto);

            _context.DemandeAssurances.Add(demandeAssurance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDemandeAssurance", new { id = demandeAssurance.Id }, demandeAssurance);
        }

        // DELETE: api/DemandeAssurances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDemandeAssurance(int id)
        {
            var demandeAssurance = await _context.DemandeAssurances.FindAsync(id);
            if (demandeAssurance == null)
            {
                return NotFound();
            }

            _context.DemandeAssurances.Remove(demandeAssurance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DemandeAssuranceExists(int id)
        {
            return _context.DemandeAssurances.Any(e => e.Id == id);
        }
    }
}
