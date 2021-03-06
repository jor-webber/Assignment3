using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment3.Data;
using Assignment3.Models;
using Microsoft.Extensions.Logging;

namespace Assignment3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly Assignment3Context _context;
        private readonly ILogger _logger;

        public ProviderController(Assignment3Context context, ILogger<ProviderController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Provider
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Provider>>> GetProvider(string firstName, string lastName, int licenseNumber)
        {

            if (firstName != null)
            {
                return await _context.Provider.Where(p => p.FirstName == firstName).ToListAsync();
            }

            if (lastName != null)
            {
                return await _context.Provider.Where(p => p.LastName == lastName).ToListAsync();
            }

            if (licenseNumber > -1)
            {
                return await _context.Provider.Where(p => p.Equals(licenseNumber)).ToListAsync();
            }

            return await _context.Provider.ToListAsync();
        }

        // GET: api/Provider/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Provider>> GetProvider(Guid id)
        {
            var provider = await _context.Provider.FindAsync(id);

            if (provider == null)
            {
                _logger.LogError($"Could not find provider with id: {id}");
                return NotFound();
            }

            return provider;
        }

        // PUT: api/Provider/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvider(Guid id, Provider provider)
        {
            if (id != provider.Id)
            {
                _logger.LogError($"Bad request with provider with id: {id}");
                return BadRequest();
            }

            _context.Entry(provider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProviderExists(id))
                {
                    _logger.LogError($"Provider with id: {id} not found.");
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Providers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Provider>> PostProvider(Provider provider)
        {
            _context.Provider.Add(provider);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProvider", new { id = provider.Id }, provider);
        }

        // DELETE: api/Providers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Provider>> DeleteProvider(Guid id)
        {
            var provider = await _context.Provider.FindAsync(id);
            if (provider == null)
            {
                _logger.LogError($"Provider with id: {id} not found.");
                return NotFound();
            }

            _context.Provider.Remove(provider);
            await _context.SaveChangesAsync();

            return provider;
        }

        private bool ProviderExists(Guid id)
        {
            return _context.Provider.Any(e => e.Id == id);
        }
    }
}
