using AutoMapper;
using Fabrics.Domain;
using Fabrics.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fabrics.Server.Controllers;
/// <summary>
/// Provider controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProvidersController : ControllerBase
{
    private readonly ILogger<ProvidersController> _logger;

    private readonly FabricsDbContext _context;

    private readonly IMapper _mapper;

    public ProvidersController(FabricsDbContext context, IMapper mapper, ILogger<ProvidersController> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProviderGetDto>>> GetProviders()
    {
        _logger.LogInformation("Get providers");
        if (_context.Providers == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<ProviderGetDto>(_context.Providers).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProviderGetDto>> GetProvider(int id)
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

        return _mapper.Map<ProviderGetDto>(provider);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutProvider(int id, ProviderPostDto provider)
    {
        if (_context.Providers == null)
        {
            return NotFound();
        }

        var providerToModify = await _context.Providers.FindAsync(id);
        if (providerToModify == null)
        {
            return NotFound();
        }
        _mapper.Map(provider, providerToModify);


        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<ProviderGetDto>> PostProvider(Provider provider)
    {
        if (_context.Providers == null)
        {
            return Problem("Entity set 'FabricsDbContext.Providers'  is null.");
        }

        var mappedProvider = _mapper.Map<Provider>(provider);

        _context.Providers.Add(mappedProvider);
        await _context.SaveChangesAsync();

        return CreatedAtAction("PostProvider", new { id = mappedProvider.Id }, _mapper.Map<ProviderGetDto>(mappedProvider));
    }

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
}
