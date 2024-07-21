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
    public class ItemMarchandisesController : ControllerBase
    {
        private readonly AssuranceDbContext _context;
        private readonly IMapper _mapper;

        public ItemMarchandisesController(AssuranceDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ItemMarchandises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemMarchandise>>> GetItemMarchandises()
        {
            var AllItems= await _context.ItemMarchandises.ToListAsync();
            return Ok(_mapper.Map<List<ItemMarchandiseDto>>(AllItems));
        }

        // GET: api/ItemMarchandises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemMarchandise>> GetItemMarchandise(int id)
        {
            var itemMarchandise = await _context.ItemMarchandises.FindAsync(id);

            if (itemMarchandise == null)
            {
                return NotFound();
            }

            return itemMarchandise;
        }

        // PUT: api/ItemMarchandises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemMarchandise(int id, ItemMarchandiseDto itemMarchandiseDto)
        {
            var itemMarchandise = _mapper.Map<ItemMarchandise>(itemMarchandiseDto);
            if (id != itemMarchandise.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemMarchandise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemMarchandiseExists(id))
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

        // POST: api/ItemMarchandises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemMarchandise>> PostItemMarchandise(ItemMarchandiseDto itemMarchandiseDto)
        {
            var itemMarchandise = _mapper.Map<ItemMarchandise>(itemMarchandiseDto);

            _context.ItemMarchandises.Add(itemMarchandise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemMarchandise", new { id = itemMarchandise.Id }, itemMarchandise);
        }

        // DELETE: api/ItemMarchandises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemMarchandise(int id)
        {
            var itemMarchandise = await _context.ItemMarchandises.FindAsync(id);
            if (itemMarchandise == null)
            {
                return NotFound();
            }

            _context.ItemMarchandises.Remove(itemMarchandise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemMarchandiseExists(int id)
        {
            return _context.ItemMarchandises.Any(e => e.Id == id);
        }
    }
}
