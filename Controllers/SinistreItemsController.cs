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
    public class SinistreItemsController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;

        public SinistreItemsController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/SinistreItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SinistreItem>>> GetSinistreItems()
        {
            var allItems= await _context.SinistreItems.ToListAsync();
            return Ok(_mapper.Map<List<SinistreItemDto>>(allItems));
        }

        // GET: api/SinistreItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SinistreItem>> GetSinistreItem(int id)
        {
            var sinistreItem = await _context.SinistreItems.FindAsync(id);

            if (sinistreItem == null)
            {
                return NotFound();
            }

            return sinistreItem;
        }

        // PUT: api/SinistreItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSinistreItem(int id, SinistreItemDto sinistreItemDto)
        {
            var sinistreItem = _mapper.Map<SinistreItem>(sinistreItemDto);
            if (id != sinistreItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(sinistreItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SinistreItemExists(id))
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

        // POST: api/SinistreItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SinistreItem>> PostSinistreItem(SinistreItemDto sinistreItemDto)
        {
            var sinistreItem = _mapper.Map<SinistreItem>(sinistreItemDto);

            _context.SinistreItems.Add(sinistreItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSinistreItem", new { id = sinistreItem.Id }, sinistreItem);
        }

        // DELETE: api/SinistreItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSinistreItem(int id)
        {
            var sinistreItem = await _context.SinistreItems.FindAsync(id);
            if (sinistreItem == null)
            {
                return NotFound();
            }

            _context.SinistreItems.Remove(sinistreItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SinistreItemExists(int id)
        {
            return _context.SinistreItems.Any(e => e.Id == id);
        }
    }
}
