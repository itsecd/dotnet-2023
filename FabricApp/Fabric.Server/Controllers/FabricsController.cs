using AutoMapper;
using Fabrics.Domain;
using Fabrics.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fabrics.Server.Controllers;
/// <summary>
/// Fabric controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class FabricsController : ControllerBase
{
    private readonly ILogger<FabricsController> _logger;
    private readonly FabricsDbContext _context;

    private readonly IMapper _mapper;

    public FabricsController(FabricsDbContext context, IMapper mapper, ILogger<FabricsController> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<FabricGetDto>>> GetFabrics()
    {
        _logger.LogInformation("Get fabric");
        if (_context.Fabrics == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<FabricGetDto>(_context.Fabrics).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FabricGetDto>> GetFabric(int id)
    {
        if (_context.Fabrics == null)
        {
            return NotFound();
        }
        var fabric = await _context.Fabrics.FindAsync(id);

        if (fabric == null)
        {
            return NotFound();
        }

        return _mapper.Map<FabricGetDto>(fabric);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutFabric(int id, FabricPostDto fabric)
    {
        if (_context.Fabrics == null)
        {
            return NotFound();
        }
        var fabricToModify = await _context.Fabrics.FindAsync(id);
        if (fabricToModify == null)
        {
            return NotFound();
        }
        _mapper.Map(fabric, fabricToModify);


        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<FabricGetDto>> PostFabric(FabricPostDto fabric)
    {
        if (_context.Fabrics == null)
        {
            return Problem("Entity set 'FabricsDbContext.Fabrics'  is null.");
        }

        var mappedFabric = _mapper.Map<Fabric>(fabric);

        _context.Fabrics.Add(mappedFabric);
        await _context.SaveChangesAsync();

        return CreatedAtAction("PostFabric", new { id = mappedFabric.Id }, _mapper.Map<FabricGetDto>(mappedFabric));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFabric(int id)
    {
        if (_context.Fabrics == null)
        {
            return NotFound();
        }
        var fabric = await _context.Fabrics.FindAsync(id);
        if (fabric == null)
        {
            return NotFound();
        }

        _context.Fabrics.Remove(fabric);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}