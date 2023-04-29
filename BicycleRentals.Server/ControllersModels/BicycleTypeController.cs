using AutoMapper;
using BicycleRentals.Domain;
using BicycleRentals.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BicycleRentals.Server.ControllersModels;
[Route("api/[controller]")]
[ApiController]
public class BicycleTypeController : ControllerBase
{
    private readonly ILogger<BicycleTypeController> _logger;

    private readonly IDbContextFactory<BicycleRentalContext> _contextFactory;

    private readonly IMapper _mapper;
    public BicycleTypeController(ILogger<BicycleTypeController> logger, IDbContextFactory<BicycleRentalContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary> 
    /// Returns a list of all types. 
    /// </summary> 
    /// <returns>The list of all types.</returns>
    [HttpGet]
    public async Task<IEnumerable<BicycleTypeGetDto>> Get()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("GET: Get list of type");
        return _mapper.Map<IEnumerable<BicycleTypeGetDto>>(context.BicycleTypes);
    }

    /// <summary> 
    /// Returns a type by id. 
    /// </summary> 
    /// <param name="id">The type id.</param> 
    /// <returns>OK (the type found by the specified id) or NotFound. </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<BicycleTypeGetDto>> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var bicycleType = await context.BicycleTypes.FirstOrDefaultAsync(bt => bt.TypeId == id);
        if (bicycleType == null)
        {
            _logger.LogInformation($"Not found type with id {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"GET: Get list of type with id {id}");
            return Ok(_mapper.Map<BicycleType, BicycleTypeGetDto>(bicycleType));
        }
    }
}
