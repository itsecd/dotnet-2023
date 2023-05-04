using Microsoft.AspNetCore.Mvc;
using CarSharingDomain;
using CarSharingServer.Dto;
using AutoMapper;
using CarSharingServer.Repository;
using Microsoft.EntityFrameworkCore;

namespace CarSharingServer.Controllers;
/// <summary>
/// Rented car controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RentedCarController : ControllerBase
{
    private readonly ILogger<RentedCarController> _logger;
    private readonly ICarSharingRepository _carRepository;
    private readonly IDbContextFactory<CarSharingDbContext> _contextFactory;
    private readonly IMapper _mapper;
    /// <summary>
    /// Constructor for RentedCarController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="carRepository"></param>
    /// <param name="mapper"></param>
    public RentedCarController(IDbContextFactory<CarSharingDbContext> contextFactory, ILogger<RentedCarController> logger, ICarSharingRepository carRepository, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _carRepository = carRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get info about all rented cars
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IEnumerable<RentedCarGetDto>> Get()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get the rented cars");
        var rentedCars = await ctx.RentedCars.ToArrayAsync();
        return _mapper.Map<IEnumerable<RentedCarGetDto>>(rentedCars);
    }
    /// <summary>
    /// Get rented car by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<RentedCarGetDto>> Get(uint id)
    {
        if (_contextFactory == null)
        {
            return NotFound();
        }
        _logger.LogInformation("Get the rented car with id {id} ", id);
        var ctx = await _contextFactory.CreateDbContextAsync();
        var rentedCar = await ctx.RentedCars.FindAsync(id);
        if (rentedCar == null)
        {
            return NotFound();
        }
        return _mapper.Map<RentedCarGetDto>(rentedCar);
    }
    /// <summary>
    /// Post a new rented car
    /// </summary>
    /// <param name="rentedCar"></param>
    [HttpPost]
    public async Task Post([FromBody] RentedCarPostDto rentedCar)
    {
        _logger.LogInformation("Post a new rented car");
        var ctx = await _contextFactory.CreateDbContextAsync();
        await ctx.RentedCars.AddAsync(_mapper.Map<RentedCar>(rentedCar));
        await ctx.SaveChangesAsync();
    }
    /// <summary>
    /// Put a rented car
    /// </summary>
    /// <param name="id"></param>
    /// <param name="rentedCarToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(uint id, [FromBody] RentalPointPostDto rentedCarToPut)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var rentedCar = await ctx.RentedCars.FindAsync(id);
        if (rentedCar == null)
        {
            _logger.LogInformation("Not found rented car with id {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Updating a rented car with id {id}", id);
            _mapper.Map(rentedCarToPut, rentedCar);
            ctx.Update(_mapper.Map<RentedCar>(rentedCar));
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Delete rented car
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(uint id)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var rentedCar = await ctx.RentedCars.FindAsync(id);
        if (rentedCar == null)
        {
            _logger.LogInformation("Not found rented car with id {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Delete a rented car - success");
            ctx.RentedCars.Remove(rentedCar);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
