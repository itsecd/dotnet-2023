using AutoMapper;
using BicycleRentals.Domain;
using BicycleRentals.Server.Dto;
using BicycleRentals.Server.Respostory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BicycleRentals.Server.ControllersModels;
[Route("api/[controller]")]
[ApiController]
public class RentalController : ControllerBase
{
    private readonly ILogger<RentalController> _logger;

    private readonly IDbContextFactory<BicycleRentalContext> _contextFactory;

    private readonly IMapper _mapper;
    public RentalController(ILogger<RentalController> logger, IDbContextFactory<BicycleRentalContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }


    /// <summary> 
    /// Returns a list of all rentals. 
    /// </summary> 
    /// <returns>The list of all rentals.</returns>
    [HttpGet]
    public async Task<IEnumerable<RentalGetDto>> Get()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("GET: Get list of customer");
        return _mapper.Map<IEnumerable<RentalGetDto>>(context.BicycleRentals);
    }

    /// <summary> 
    /// Returns a rental by id. 
    /// </summary> 
    /// <param name="id">The rental id.</param> 
    /// <returns>OK (the rental found by the specified id) or NotFound. </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<RentalGetDto>> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var rental = await context.BicycleRentals.FirstOrDefaultAsync(r => r.RentalId == id);
        if (rental == null)
        {
            _logger.LogInformation($"Not found customer with id {id}");
            return NotFound();
        }
        else
            return Ok(_mapper.Map<RentalGetDto>(rental));
    }

    /// <summary> 
    /// Create a new rental. 
    /// </summary> 
    /// <param name="RentalPostDto">New rental. </param> 
    /// <returns>New rental id.</returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] RentalPostDto r)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        await context.BicycleRentals.AddAsync(_mapper.Map<BicycleRental>(r));
        await context.SaveChangesAsync();
        return Ok();
    }

    /// <summary> 
    /// Updates the existing rental data. 
    /// </summary> 
    /// <param name="RentalPostDto">New rental data. </param>
    /// <returns>OK or NotFound.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] RentalPostDto r)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var rental = await context.BicycleRentals.FirstOrDefaultAsync(r => r.RentalId == id);
        if (rental == null)
        {
            _logger.LogInformation($"Not found bicycle with id {id}");
            return NotFound();
        }
        else
        {
            _mapper.Map(r, rental);
            context.BicycleRentals.Update(_mapper.Map<BicycleRental>(rental));
            await context.SaveChangesAsync();
            return Ok();
        }

    }

    ///<summary> 
    ///Deletes a rental by id. 101 Ace Mapping. 
    /// </summary> 
    /// <param name="id">The rental id.</param> 
    /// <returns>OK or NotFound.</returns> 
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var rental = await context.BicycleRentals.FirstOrDefaultAsync(r => r.RentalId == id);
        if (rental == null)
        {
            _logger.LogInformation($"Not found bicycle with id {id}");
            return NotFound();
        }
        else
        {
            context.BicycleRentals.Remove(rental);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
