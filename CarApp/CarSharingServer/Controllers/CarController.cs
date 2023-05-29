using AutoMapper;
using CarSharingDomain;
using CarSharingServer.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarSharingServer.Controllers;
/// <summary>
/// Car controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
    private readonly ILogger<CarController> _logger;
    private readonly IMapper _mapper;
    private readonly IDbContextFactory<CarSharingDbContext> _contextFactory;
    /// <summary>
    /// Constructor for CarController
    /// </summary>
    /// <param name="contextFactory"></param>
    /// <param name="logger"></param>
    /// <param name="mapper"></param>
    public CarController(IDbContextFactory<CarSharingDbContext> contextFactory, ILogger<CarController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Get info about all cars
    /// </summary>
    /// <returns>
    /// List of all cars
    /// </returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CarGetDto>>> GetCars()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        if (ctx.Cars == null)
        {
            return NotFound();
        }
        _logger.LogInformation("Get the cars");
        return await _mapper.ProjectTo<CarGetDto>(ctx.Cars).ToListAsync();
    }
    /// <summary>
    /// Get car info by id
    /// </summary>
    /// <param name="id">
    /// Identification number of car
    /// </param>
    /// <returns>
    /// Car with required id
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<CarGetDto>> Get(int id)
    {
        _logger.LogInformation("Get the car with id {id} ", id);
        var ctx = await _contextFactory.CreateDbContextAsync();
        if (ctx.Cars == null)
        {
            return NotFound();
        }
        var car = await ctx.Cars.FindAsync(id);
        if (car == null)
        {
            return NotFound();
        }
        return _mapper.Map<CarGetDto>(car);
    }
    /// <summary>
    /// Post a new car
    /// </summary>
    /// <param name="car">
    /// Info about car which you want to post
    /// </param>
    [HttpPost]
    public async Task <IActionResult> Post([FromBody] CarPostDto car)
    {
        _logger.LogInformation("Post a new car");
        var ctx = await _contextFactory.CreateDbContextAsync();
        if (ctx.Cars == null)
        {
            return NotFound();
        }
        await ctx.Cars.AddAsync(_mapper.Map<Car>(car));
        await ctx.SaveChangesAsync();
        return Ok();
    }
    /// <summary>
    /// Put car
    /// </summary>
    /// <param name="id">
    /// Identification number of car which should be edited
    /// </param>
    /// <param name="carToPut">
    /// Info about car which should be edited
    /// </param>
    /// <returns>
    /// Success or error code
    /// </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] CarPostDto carToPut)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        if (ctx.Cars == null)
        {
            return NotFound();
        }
        var car = await ctx.Cars.FindAsync(id);
        if (car == null)
        {
            _logger.LogInformation("Not found car with id {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Updating a car with id {id}", id);
            _mapper.Map(carToPut, car);
            ctx.Update(_mapper.Map<Car>(car));
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Delete a car
    /// </summary>
    /// <param name="id">
    /// Identification number of car which should be deleted
    /// </param>
    /// <returns>
    /// Success or error code
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        if (ctx.Cars == null)
        {
            return NotFound();
        }
        var car = await ctx.Cars.FindAsync(id);
        if (car == null)
        {
            _logger.LogInformation("Not found car with id {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Delete a car - success");
            ctx.Cars.Remove(car);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
