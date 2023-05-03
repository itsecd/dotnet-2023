using Fabrics.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fabrics.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProvidersController : ControllerBase
{
    private readonly FabricsDbContext _context;

    public ProvidersController(FabricsDbContext context)
    {
        _context = context;
    }

    // GET: api/Providers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Provider>>> GetProviders()
    {
        if (_context.Providers == null)
        {
            return NotFound();
        }
        return await _context.Providers.ToListAsync();
    }

    // GET: api/Providers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Provider>> GetProvider(int id)
    {
        if (_context.Providers == null)
        {
            return NotFound();
        }
        var provider = await _context.Providers.FindAsync(id);

        if (provider == null)
        {
            return NotFound();
        }

        return provider;
    }

    // PUT: api/Providers/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProvider(int id, Provider provider)
    {
        if (id != provider.Id)
        {
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
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Provider>> PostProvider(Provider provider)
    {
        if (_context.Providers == null)
        {
            return Problem("Entity set 'FabricsDbContext.Providers'  is null.");
        }
        _context.Providers.Add(provider);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProvider", new { id = provider.Id }, provider);
    }

    // DELETE: api/Providers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProvider(int id)
    {
        if (_context.Providers == null)
        {
            return NotFound();
        }
        var provider = await _context.Providers.FindAsync(id);
        if (provider == null)
        {
            return NotFound();
        }

        _context.Providers.Remove(provider);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProviderExists(int id)
    {
        return (_context.Providers?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
