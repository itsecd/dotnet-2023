using AutoMapper;
using CarSharingDomain;
using CarSharingServer.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarSharingServer.Controllers;
/// <summary>
/// Rental point controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RentalPointController : ControllerBase
{
    private readonly ILogger<RentalPointController> _logger;
    private readonly IDbContextFactory<CarSharingDbContext> _contextFactory;
    private readonly IMapper _mapper;
    /// <summary>
    /// Constructor for RentalPointController
    /// </summary>
    /// <param name="contextFactory"></param>
    /// <param name="logger"></param>
    /// <param name="mapper"></param>
    public RentalPointController(IDbContextFactory<CarSharingDbContext> contextFactory, ILogger<RentalPointController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }
    /// <summary>
    /// Get info about all rental points
    /// </summary>
    /// <returns>
    /// List of all rental points
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<RentalPointPostDto>> Get()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get the rental points");
        var rentalPoints = await ctx.RentalPoints.ToArrayAsync();
        return _mapper.Map<IEnumerable<RentalPointPostDto>>(rentalPoints);
    }
    /// <summary>
    /// Get rental point by id
    /// </summary>
    /// <param name="id">
    /// Identification number of required rental point
    /// </param>
    /// <returns>
    /// Rental point by id
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<RentalPointPostDto>> Get(uint id)
    {
        _logger.LogInformation("Get the rental point with id {id} ", id);
        var ctx = await _contextFactory.CreateDbContextAsync();
        if (ctx.RentalPoints == null)
        {
            return NotFound();
        }
        var rentalPoint = await ctx.RentalPoints.FindAsync(id);
        if (rentalPoint == null)
        {
            return NotFound();
        }
        return _mapper.Map<RentalPointPostDto>(rentalPoint);
    }

    /// <summary>
    /// Post a new rental point
    /// </summary>
    /// <param name="rentalPoint">
    /// Info about new rental point you ant to add
    /// </param>
    [HttpPost]
    public async Task Post([FromBody] RentalPointPostDto rentalPoint)
    {
        _logger.LogInformation("Post a new rental point");
        var ctx = await _contextFactory.CreateDbContextAsync();
        await ctx.RentalPoints.AddAsync(_mapper.Map<RentalPoint>(rentalPoint));
        await ctx.SaveChangesAsync();
    }

    /// <summary>
    /// Put a rental point
    /// </summary>
    /// <param name="id">
    /// Identification number of rental point which should be edited
    /// </param>
    /// <param name="rentalPointToPut">
    /// Info about rental point which should be edited
    /// </param>
    /// <returns>
    /// Success or error code
    /// </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(uint id, [FromBody] RentalPointPostDto rentalPointToPut)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        if (ctx.RentalPoints == null)
        {
            return NotFound();
        }
        var rentalPoint = await ctx.RentalPoints.FindAsync(id);
        if (rentalPoint == null)
        {
            _logger.LogInformation("Not found rental point with id {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Updating a rental point with id {id}", id);
            _mapper.Map(rentalPointToPut, rentalPoint);
            ctx.Update(_mapper.Map<RentalPoint>(rentalPoint));
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// Delete a rental point
    /// </summary>
    /// <param name="id">
    /// Identification number of rental point which should be deleted
    /// </param>
    /// <returns>
    /// Success or error code
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(uint id)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        if (ctx.RentalPoints == null)
        {
            return NotFound();
        }
        var rentalPoint = await ctx.RentalPoints.FindAsync(id);
        if (rentalPoint == null)
        {
            _logger.LogInformation("Not found rental point with id {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Delete a rental point - success");
            ctx.RentalPoints.Remove(rentalPoint);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}