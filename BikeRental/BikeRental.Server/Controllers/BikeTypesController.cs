using AutoMapper;
using BikeRental.Domain;
using BikeRental.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeRental.Server.Controllers;

/// <summary>
/// Bike types
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class BikeTypesController : ControllerBase
{
    private readonly BikeRentalDbContext _context;

    private readonly IMapper _mapper;

    private readonly ILogger<BikeTypesController> _logger;

    public BikeTypesController(BikeRentalDbContext context, IMapper mapper, ILogger<BikeTypesController> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// View all bike types
    /// </summary>
    /// <returns>Bike type list</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BikeTypeGetDto>>> GetBikeTypes()
    {
        _logger.LogInformation("Get bike types list");
        return await _mapper.ProjectTo<BikeTypeGetDto>(_context.BikeTypes).ToListAsync();
    }

    /// <summary>
    /// View bike type by id
    /// </summary>
    /// <param name="id">Client id</param>
    /// <returns>Bike type</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<BikeTypeGetDto>> GetBikeType(int id)
    {
        _logger.LogInformation("Get the bike type by id");

        var bikeType = await _context.BikeTypes.FindAsync(id);

        if (bikeType == null)
        {
            _logger.LogInformation("Bike type not found");
            return NotFound();
        }

        return _mapper.Map<BikeTypeGetDto>(bikeType);
    }
}
