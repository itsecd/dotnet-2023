using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BikeRental.Domain;
using AutoMapper;
using BikeRental.Server.Dto;

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

    /// <summary>
    /// Constructor for BikeTypesController
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public BikeTypesController(BikeRentalDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// View all bike types
    /// </summary>
    /// <returns>Bike type list</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BikeTypeGetDto>>> GetBikeTypes()
    {
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
        var bikeType = await _context.BikeTypes.FindAsync(id);

        if (bikeType == null)
        {
            return NotFound();
        }

        return _mapper.Map<BikeTypeGetDto>(bikeType);
    }
}
