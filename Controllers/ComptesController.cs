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
    public class ComptesController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;

        public ComptesController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Comptes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compte>>> GetComptes()
        {
            var AllAccounts= await _context.Comptes
                .Include(c=>c.Personne)
                .Select(c=>new CompteDto
                {
                    Id=c.Id,
                    Numero=c.Numero,
                    Email=c.Email,
                    Login=c.Login,
                    Password=c.Password,
                    PersonneId=c.PersonneId,
                    CinPersonne=c.Personne.Cin,
                    PrenomPersonne=c.Personne.Prenom,
                    NomPersonne=c.Personne.Nom,
                    DateNaissancePersonne=c.Personne.DateNaissance
                })
                .ToListAsync();
            
            return Ok(_mapper.Map<List<CompteDto>>(AllAccounts));
        }

        // GET: api/Comptes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Compte>> GetCompte(int id)
        {
            var compte = await _context.Comptes
                .Include(c=>c.Personne)
                .Select(c=>new CompteDto
                {
                    Id=c.Id,
                    Numero=c.Numero,
                    Email=c.Email,
                    Login=c.Login,
                    Password=c.Password,
                    PersonneId = c.PersonneId,
                    CinPersonne=c.Personne.Cin,
                    PrenomPersonne=c.Personne.Prenom,
                    NomPersonne=c.Personne.Nom,
                    DateNaissancePersonne=c.Personne.DateNaissance

                })
                .FirstOrDefaultAsync(c => c.Id == id);
                

            if (compte == null)
            {
                return NotFound();
            }
            var compteDto = _mapper.Map<CompteDto>(compte);
            return Ok(compteDto);
        }

        // PUT: api/Comptes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompte(int id, CompteDto compteDto)
        {
            var compte = _mapper.Map<Compte>(compteDto);
            if (id != compte.Id)
            {
                return BadRequest();
            }

            _context.Entry(compte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompteExists(id))
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

        // POST: api/Comptes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Compte>> PostCompte(CompteDto compteDto)
        {
            var compte = _mapper.Map<Compte>(compteDto);

            _context.Comptes.Add(compte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompte", new { id = compte.Id }, compte);
        }

        // DELETE: api/Comptes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompte(int id)
        {
            var compte = await _context.Comptes.FindAsync(id);
            if (compte == null)
            {
                return NotFound();
            }

            _context.Comptes.Remove(compte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompteExists(int id)
        {
            return _context.Comptes.Any(e => e.Id == id);
        }
    }
}
