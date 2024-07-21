﻿using System;
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
    public class SinistresController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;

        public SinistresController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Sinistres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sinistre>>> GetSinistres()
        {
            var AllSinistres= await _context.Sinistres.ToListAsync();
            return Ok(_mapper.Map<List<SinistreDto>>(AllSinistres));
        }

        // GET: api/Sinistres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sinistre>> GetSinistre(int id)
        {
            var sinistre = await _context.Sinistres.FindAsync(id);

            if (sinistre == null)
            {
                return NotFound();
            }

            return sinistre;
        }

        // PUT: api/Sinistres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSinistre(int id, SinistreDto sinistreDto)
        {
            var sinistre = _mapper.Map<Sinistre>(sinistreDto);
            if (id != sinistre.Id)
            {
                return BadRequest();
            }

            _context.Entry(sinistre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SinistreExists(id))
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

        // POST: api/Sinistres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sinistre>> PostSinistre(SinistreDto sinistreDto)
        {
            var sinistre = _mapper.Map<Sinistre>(sinistreDto);
            _context.Sinistres.Add(sinistre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSinistre", new { id = sinistre.Id }, sinistre);
        }

        // DELETE: api/Sinistres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSinistre(int id)
        {
            var sinistre = await _context.Sinistres.FindAsync(id);
            if (sinistre == null)
            {
                return NotFound();
            }

            _context.Sinistres.Remove(sinistre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SinistreExists(int id)
        {
            return _context.Sinistres.Any(e => e.Id == id);
        }
    }
}