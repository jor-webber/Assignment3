using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment3.Data;
using W7D2_webAPI.Models;

namespace Assignment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImmunizationController : ControllerBase
    {
        private readonly Assignment3Context _context;

        public ImmunizationController(Assignment3Context context)
        {
            _context = context;
        }

        // GET: /Immunization
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Immunization>>> GetImmunization(string creationTime, string officalName, string tradeName, string lotNumber)
        {
            if (creationTime != null)
            {
                var timeCreated = DateTimeOffset.Parse(creationTime);
                return await _context.Immunization.Where(i => i.CreationTime == timeCreated).ToListAsync();
            }
            if (officalName != null)
            {
                return await _context.Immunization.Where(i => i.OfficialName == officalName).ToListAsync();
            }

            if (tradeName != null)
            {
                return await _context.Immunization.Where(i => i.TradeName == tradeName).ToListAsync();
            }
            if (lotNumber != null)
            {
                return await _context.Immunization.Where(i => i.LotNumber == lotNumber).ToListAsync();
            }

            return await _context.Immunization.ToListAsync();
        }

        // GET: /Immunizations/
        [HttpGet("{id}")]
        public async Task<ActionResult<Immunization>> GetImmunization(Guid id)
        {
            var immunization = await _context.Immunization.FindAsync(id);

            if (immunization == null)
            {
                return NotFound();
            }

            return immunization;
        }

        // PUT: /Immunizations/
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImmunization(Guid id, Immunization immunization)
        {
            if (id != immunization.Id)
            {
                return BadRequest();
            }

            _context.Entry(immunization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImmunizationExists(id))
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

        // POST: /Immunization
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Immunization>> PostImmunization(Immunization immunization)
        {
            _context.Immunization.Add(immunization);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImmunization", new { id = immunization.Id }, immunization);
        }

        // DELETE: /Immunization/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Immunization>> DeleteImmunization(Guid id)
        {
            var immunization = await _context.Immunization.FindAsync(id);
            if (immunization == null)
            {
                return NotFound();
            }

            _context.Immunization.Remove(immunization);
            await _context.SaveChangesAsync();

            return immunization;
        }

        private bool ImmunizationExists(Guid id)
        {
            return _context.Immunization.Any(e => e.Id == id);
        }
    }
}
