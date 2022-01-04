using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clase4Webapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clase4Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NomyApeController : ControllerBase
    {

        private readonly NomyApeContext _context;

        public NomyApeController(NomyApeContext context)
        {
            _context = context; 
        }

        //GET: api/NomyApe
        [HttpGet]

        public async Task<ActionResult<IEnumerable<NomyApe>>> GetNomyapes()
        {
            return await _context.NomyApes.ToListAsync();
        }

        //GET: api/NomyApe/5
        [HttpGet("{id}")]

        public async Task<ActionResult<NomyApe>> GetNomyApe(int id)
        {
            var NomyApe = await _context.NomyApes.FindAsync(id);

            if (NomyApe == null)
            {
                return NotFound();
            }       

            return NomyApe;
        }

        // PUT: api/NomyApe/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNomyApe(int id, NomyApe NomyApe)
        {
            if (id != NomyApe.Id)
            {
                return BadRequest();
            }

            _context.Entry(NomyApe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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

        // POST: api/NoomyApe
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NomyApe>> PostTeam(NomyApe NomyApe)
        {
            _context.NomyApes.Add(NomyApe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeam", new { id = NomyApe.Id }, NomyApe);
        }

        // DELETE: api/NomyApe/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var NomyApe = await _context.NomyApes.FindAsync(id);
            if (NomyApe == null)
            {
                return NotFound();
            }

            _context.NomyApes.Remove(NomyApe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamExists(int id)
        {
            return _context.NomyApes.Any(e => e.Id == id);
        }

    }
}