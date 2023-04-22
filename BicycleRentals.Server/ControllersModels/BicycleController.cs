using AutoMapper;
using BicycleRentals.Domain;
using BicycleRentals.Server.ControllersModels;
using BicycleRentals.Server.Dto;
using BicycleRentals.Server.Respostory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BicycleRentals.Server.Controllers;
[ApiController]
[Route("[controller]")]
public class BicycleController : ControllerBase
{
    private readonly ILogger<BicycleController> _logger;

    private readonly IDbContextFactory<BicycleRentalContext> _contextFactory;

    private readonly IMapper _mapper;
    public BicycleController(ILogger<BicycleController> logger, IDbContextFactory<BicycleRentalContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory; 
        _mapper = mapper;
    }

    /// <summary> 
    /// Returns a list of all bicycles. 
    /// </summary> 
    /// <returns>The list of all bicycles.</returns>
    [HttpGet]
    public async Task<IEnumerable<BicycleGetDto>> Get()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("GET: Get list of bicycle");       
        return _mapper.Map<IEnumerable<BicycleGetDto>>(context.Bicycles);
    }

    /// <summary> 
    /// Returns a bicycle by id. 
    /// </summary> 
    /// <param name="id">The bicycle id.</param> 
    /// <returns>OK (the bicycle found by the specified id) or NotFound. </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<BicycleGetDto>> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var bicycle = await context.Bicycles.FirstOrDefaultAsync(b => b.SerialNumber == id);
        if (bicycle == null)
        {
            _logger.LogInformation($"Not found bicycle with id {id}");
            return NotFound();
        }
        else
            return Ok(_mapper.Map<BicycleGetDto>(bicycle));
    }

    /// <summary> 
    /// Create a new bicycle. 
    /// </summary> 
    /// <param name="BicyclePostDto">New bicycle. </param> 
    /// <returns>New bicycle id.</returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BicyclePostDto b)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        await context.Bicycles.AddAsync(_mapper.Map<Bicycle>(b));
        await context.SaveChangesAsync();
        return Ok();
    }

    /// <summary> 
    /// Updates the existing bicycle data. 
    /// </summary> 
    /// <param name="BicyclePostDto">New bicycle data. </param>
    /// <returns>OK or NotFound.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] BicyclePostDto b)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var bicycle = await context.Bicycles.FirstOrDefaultAsync(b => b.SerialNumber == id);
        if (bicycle == null)
        {
            _logger.LogInformation($"Not found bicycle with id {id}");
            return NotFound();
        }
        else
        {
            _mapper.Map(b, bicycle); //assign b to bicycle
            context.Bicycles.Update(_mapper.Map<Bicycle>(bicycle));
            await context.SaveChangesAsync();
            return Ok();
        }

    }

    ///<summary> 
    ///Deletes a bicycle by id. 101 Ace Mapping. 
    /// </summary> 
    /// <param name="id">The bicycle id.</param> 
    /// <returns>OK or NotFound.</returns> 
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var bicycle = await context.Bicycles.FirstOrDefaultAsync(b => b.SerialNumber == id);
        if (bicycle == null)
        {
            _logger.LogInformation($"Not found bicycle with id {id}");
            return NotFound();
        }
        else
        {
            context.Bicycles.Remove(bicycle);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
