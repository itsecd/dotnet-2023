using Microsoft.AspNetCore.Mvc;
using CarSharingDomain;
using CarSharingServer.Dto;
using AutoMapper;
using CarSharingServer.Repository;
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
    /// <returns></returns>
    [HttpGet]
    public async Task<IEnumerable<CarGetDto>> GetCars()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get the cars");
        var cars = await ctx.Cars.ToArrayAsync();
        return _mapper.Map<IEnumerable<CarGetDto>>(cars);
    }
    /// <summary>
    /// Get car info by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<CarGetDto>> Get(uint id)
    {
        if (_contextFactory==null)
        {
            return NotFound();
        }
        _logger.LogInformation("Get the car with id {id} ", id);
        var ctx = await _contextFactory.CreateDbContextAsync();
        var car = await ctx.Cars.FindAsync(id);
        if (car == null) {
            return NotFound();
        }
        return _mapper.Map<CarGetDto>(car);
    }
    /// <summary>
    /// Post a new car
    /// </summary>
    /// <param name="car"></param>
    [HttpPost]
    public async Task Post([FromBody] CarPostDto car)
    {
        _logger.LogInformation("Post a new car");
        var ctx =await _contextFactory.CreateDbContextAsync();
        await ctx.Cars.AddAsync(_mapper.Map<Car>(car));
        await ctx.SaveChangesAsync();
    }
    /// <summary>
    /// Put car
    /// </summary>
    /// <param name="id"></param>
    /// <param name="carToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(uint id, [FromBody] CarPostDto carToPut)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
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
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(uint id)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
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
