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
    public class PoliceController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;

        public PoliceController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Police
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Police>>> GetPolices()
        {
            var AllPolices= await _context.Polices
                .Include(p=>p.Personne)
                .Include(p=>p.Assureur)
                .Include(p=>p.Contrat)
                .Include(p=>p.Marchandise)
                .Include(p=>p.Article)
                .Include(p=>p.TypeBien)
                .Select(p=>new PoliceDto
                {
                    Id=p.Id,
                    Code=p.Code,
                    DateAjout=p.DateAjout,
                    PersonneId=p.PersonneId,
                    CinPersonne=p.Personne.Cin,
                    PrenomPersonne=p.Personne.Prenom,
                    NomPersonne=p.Personne.Prenom,
                    DateNaissancePersonne=p.Personne.DateNaissance,
                    AssureurId=p.AssureurId,
                    DesignationAssureur=p.Assureur.Designation,
                    AddressAssureur=p.Assureur.Address,
                    ContratId=p.ContratId,
                    DateEffet=p.Contrat.DateEffet,
                    DateEcheance=p.Contrat.DateEcheance,
                    DateSignature=p.Contrat.DateSignature,
                    ExerciceContrat=p.Contrat.Exercice,
                    MarchandiseId=p.MarchandiseId,
                    CodeMarchandise=p.Marchandise.code,
                    NatureMarchandise=p.Marchandise.Nature,
                    TypeBienId=p.TypeBienId,
                    LibelleTypeBien=p.TypeBien.Libelle,
                    ArticleId=p.ArticleId,
                    LibelleArticle=p.Article.Libelle,
                    ReferenceArticle=p.Article.Reference,
                    PrixArticle=p.Article.Prix
                    
                })
                .ToListAsync();
            return Ok(_mapper.Map<List<PoliceDto>>(AllPolices));
        }

        // GET: api/Police/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Police>> GetPolice(int id)
        {
            var police = await _context.Polices.FindAsync(id);

            if (police == null)
            {
                return NotFound();
            }
            var policeDto = _mapper.Map<PoliceDto>(police);
            return Ok(policeDto);
        }

        // PUT: api/Police/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolice(int id, PoliceDto policeDto)
        {
            var police = _mapper.Map<Police>(policeDto);
            if (id != police.Id)
            {
                return BadRequest();
            }

            _context.Entry(police).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoliceExists(id))
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

        // POST: api/Police
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Police>> PostPolice(PoliceDto policeDto)
        {
            var police = _mapper.Map<Police>(policeDto);
            _context.Polices.Add(police);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPolice", new { id = police.Id }, police);
        }

        // DELETE: api/Police/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolice(int id)
        {
            var police = await _context.Polices.FindAsync(id);
            if (police == null)
            {
                return NotFound();
            }

            _context.Polices.Remove(police);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PoliceExists(int id)
        {
            return _context.Polices.Any(e => e.Id == id);
        }
    }
}
