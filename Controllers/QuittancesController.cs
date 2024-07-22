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
    public class QuittancesController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;

        public QuittancesController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Quittances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quittance>>> GetQuittances()
        {
            var AllQuittances= await _context.Quittances
                .Include(q=>q.Devis)
                .Include(q=>q.DossierSinistre)
                .Include(q=>q.Assureur)
                .Select(q=>new QuittanceDto
                {
                    Id=q.Id,
                    Libelle=q.Libelle,
                    Montant=q.Montant,
                    DateAjout=q.DateAjout,
                    DateSignature=q.DateSignature,
                    DevisId=q.DevisId,
                    LibelleDevis=q.Devis.Libelle,
                    DossierSinistreId=q.DossierSinistreId,
                    DateAjoutDossierSinistre=q.DossierSinistre.DateAjout,
                    MontantAssuranceDossierSinistre=q.DossierSinistre.MontantAssurance,
                    MontantSinistreDossierSinistre=q.DossierSinistre.MontantSinistre,
                    ObservationDossierSinistre=q.DossierSinistre.Observation,
                    AssureurId=q.AssureurId,
                    DesignationAssureur=q.Assureur.Designation,
                    AddressAssureur=q.Assureur.Address

                })
                .ToListAsync();
            return Ok(_mapper.Map<List<QuittanceDto>>(AllQuittances));
        }

        // GET: api/Quittances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quittance>> GetQuittance(int id)
        {
            var quittance = await _context.Quittances.FindAsync(id);

            if (quittance == null)
            {
                return NotFound();
            }
            var quittanceDto = _mapper.Map<QuittanceDto>(quittance);
            return Ok(quittanceDto);
        }

        // PUT: api/Quittances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuittance(int id, QuittanceDto quittanceDto)
        {
            var quittance = _mapper.Map<Quittance>(quittanceDto);
            if (id != quittance.Id)
            {
                return BadRequest();
            }

            _context.Entry(quittance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuittanceExists(id))
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

        // POST: api/Quittances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quittance>> PostQuittance(QuittanceDto quittanceDto)
        {
            var quittance = _mapper.Map<Quittance>(quittanceDto);
            _context.Quittances.Add(quittance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuittance", new { id = quittance.Id }, quittance);
        }

        // DELETE: api/Quittances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuittance(int id)
        {
            var quittance = await _context.Quittances.FindAsync(id);
            if (quittance == null)
            {
                return NotFound();
            }

            _context.Quittances.Remove(quittance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuittanceExists(int id)
        {
            return _context.Quittances.Any(e => e.Id == id);
        }
    }
}
