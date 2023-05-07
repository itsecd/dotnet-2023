using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain;
using Warehouse.Server.Dto;

namespace Warehouse.Server.Controllers;

/// <summary>
///     Controller for supply table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SuppliesController : ControllerBase
{
    private readonly ILogger<SuppliesController> _logger;
    private readonly IDbContextFactory<WarehouseDbContext> _contextFactory;
    private readonly IMapper _mapper;

    /// <summary>
    ///     Constructor for SupplyController
    /// </summary>
    public SuppliesController(IDbContextFactory<WarehouseDbContext> contextFactory, ILogger<SuppliesController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }
    /// <summary>
    ///     Get method for supply table
    /// </summary>
    /// <returns>
    ///     Return all supplies
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<SuppliesGetDto>> Get()
    {
        _logger.LogInformation("Get all supplies");
        var ctx = await _contextFactory.CreateDbContextAsync();
        var supplies = await ctx.Supplies.ToListAsync();
        return _mapper.Map<IEnumerable<SuppliesGetDto>>(supplies);
    }
    /// <summary>
    ///     Get by id method for supply table
    /// </summary>
    /// <param name="id"> Supply id </param>
    /// <returns>
    ///     Return supplies with specified id
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<SuppliesGetDto>> Get(int id)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var supply = await ctx.Supplies.FirstOrDefaultAsync(supply => supply.Id == id);
        if (supply == null)
        {
            _logger.LogInformation("Not found supplies with id: {id}", id);
            return NotFound($"Supply doesn`t exist by this id: {id}");
        }
        else
        {
            _logger.LogInformation("Get supplies with id: {id}", id);
            return Ok(_mapper.Map<SuppliesGetDto>(supply));
        }
    }
    /// <summary>
    ///     Post method for supply table
    /// </summary>
    /// <param name="supply"> Supply class instance to insert to table </param>
    /// <returns>
    ///     Create supply
    /// </returns>
    [HttpPost]
    public async Task Post([FromBody] SuppliesPostDto supply)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Create new supply");
        await ctx.Supplies.AddAsync(_mapper.Map<Supplies>(supply));
        await ctx.SaveChangesAsync();
    }
    /// <summary>
    ///     Put method for supply table
    /// </summary>
    /// <param name="id"> An id of supply which would be changed </param>
    /// <param name="supplyToPut"> Supply class instance to insert to table </param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] SuppliesPostDto supplyToPut)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var supply = await ctx.Supplies.FirstOrDefaultAsync(supply => supply.Id == id);
        if (supply == null)
        {
            _logger.LogInformation("Not found supply with id: {id}", id);
            return NotFound($"Supply doesn`t exist by this id: {id}");
        }
        else
        {
            _logger.LogInformation("Update supply with id: {id}", id);
            _mapper.Map(supplyToPut, supply);
            ctx.Supplies.Update(_mapper.Map<Supplies>(supply));
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    ///     Delete method 
    /// </summary>
    /// <param name="id"> An id of supply which would be deleted </param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var supply = await ctx.Supplies.Include(supply => supply.Products)
                                       .FirstOrDefaultAsync(supply => supply.Id == id);
        if (supply == null)
        {
            _logger.LogInformation("Not found supply with id: {id}", id);
            return NotFound($"Supply doesn`t exist by this id: {id}");
        }
        else
        {
            _logger.LogInformation("Delete supply with id {id}", id);
            ctx.Supplies.Remove(supply);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}