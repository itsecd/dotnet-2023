using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Realtor;
using RealtorServer.Dto;
using RealtorServer.Repository;

namespace RealtorServer.Controllers;
/// <summary>
///     Controller for houses table
/// </summary>

[Route("api/[controller]")]
[ApiController]
public class HouseController : ControllerBase
{
    private readonly ILogger<HouseController> _logger;
    private readonly IDbContextFactory<RealtorDbContext> _contextFactory;
    private readonly IMapper _mapper;
    /// <summary>
    ///     Constructor for HouseController
    /// </summary>
    public HouseController(ILogger<HouseController> logger, IDbContextFactory<RealtorDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    ///     Get method for houses table
    /// </summary>
    /// <returns>
    ///     Return all houses
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<HouseGetDto>> GetHouses()
    {
        _logger.LogInformation("Get houses");
        await using RealtorDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var houses = await ctx.Houses.ToListAsync();
        return _mapper.Map<IEnumerable<HouseGetDto>>(houses);
    }
    /// <summary>
    ///     Get by id method for houses table
    /// </summary>
    /// <param name="id"> Product id </param>
    /// <returns>
    ///     Return house with specified id
    /// </returns>

    [HttpGet("{id}")]
    public async Task<ActionResult<HouseGetDto>> GetHouse(int id)
    {
        await using RealtorDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var house = await ctx.Houses.FirstOrDefaultAsync(house => house.Id==id);
        if (house == null)
        {
            _logger.LogInformation("Not found house with id {id}", id);
            return NotFound($"House doesn`t exist by this id: {id}");
        }
        else
        {
            _logger.LogInformation("Get house with id {id}", id);
            return Ok(_mapper.Map<HouseGetDto>(house));
        }
    }
    /// <summary>
    ///     Post method for houses table
    /// </summary>
    /// <param name="house"> House class instance to insert to table </param>
    /// <returns>
    ///     Create house
    /// </returns>


    [HttpPost]
    public async Task PostHouse([FromBody] HousePostDto house)
    {
        await using RealtorDbContext ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Create new house");
        await ctx.Houses.AddAsync(_mapper.Map<House>(house));
        await ctx.SaveChangesAsync();
    }
    /// <summary>
    ///     Put method for houses table
    /// </summary>
    /// <param name="id"> An id of house which would be changed </param>
    /// <param name="houseToPut"> House class instance to insert to table </param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] HousePostDto houseToPut)
    {
        await using RealtorDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var house = await ctx.Houses.FirstOrDefaultAsync(house => house.Id == id);
        if (house == null)
        {
            _logger.LogInformation("Not found house with id {id}", id);
            return NotFound($"House doesn`t exist by this id: {id}");
        }
        else
        {
            _logger.LogInformation("Update house with id {id}", id);
            _mapper.Map(houseToPut, house);
            ctx.Houses.Update(_mapper.Map<House>(house));
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    ///     Delete method 
    /// </summary>
    /// <param name="id"> An id of house which would be deleted </param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHouse(int id)
    {
        await using RealtorDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var house = await ctx.Houses.FirstOrDefaultAsync(house => house.Id == id);
        if (house == null)
        {
            _logger.LogInformation("Not found house with id {id}", id);
            return NotFound($"House doesn`t exist by this id: {id}");
        }
        else
        {
            _logger.LogInformation("Delete house with id: {id}", id);
            ctx.Houses.Remove(house);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
