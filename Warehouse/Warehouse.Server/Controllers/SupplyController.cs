using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain;
using Warehouse.Server.Dto;
using Warehouse.Server.Repository;

namespace Warehouse.Server.Controllers;

/// <summary>
///     Controller for supply table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SupplyController : ControllerBase
{
    private readonly ILogger<SupplyController> _logger;
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IDbContextFactory<WarehouseContext> _contextFactory;
    private readonly IMapper _mapper;

    /// <summary>
    ///     Constructor for SupplyController
    /// </summary>
    /// <param name="contextFactory"></param>
    /// <param name="logger"></param>
    /// <param name="warehouseRepository"></param>
    /// <param name="mapper"></param>
    public SupplyController(IDbContextFactory<WarehouseContext> contextFactory, ILogger<SupplyController> logger, IWarehouseRepository warehouseRepository, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _warehouseRepository = warehouseRepository;
        _mapper = mapper;
    }
    /// <summary>
    ///     Get method for supply table
    /// </summary>
    /// <returns>
    ///     Return all supplies
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<SupplyGetDto>> Get()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get supplies");
        return _mapper.Map<IEnumerable<SupplyGetDto>>(await ctx.Supplies.ToListAsync());
    }
    /// <summary>
    ///     Get by id method for supply table
    /// </summary>
    /// <returns>
    ///     Return supplies with specified id
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<SupplyGetDto>> Get(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Get supplies with id {id}");
        var supply = ctx.Supplies.FirstOrDefault(supply => supply.Id == id);
        if (supply == null)
        {
            _logger.LogInformation($"Not found supplies with id {id}");
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<SupplyGetDto>(supply));
        }
    }
    /// <summary>
    ///     Post method for supply table
    /// </summary>
    /// <param name="supply"> Supply class instance to insert to table </param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SupplyPostDto supply)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Post supply");
        await ctx.Supplies.AddAsync(_mapper.Map<Supply>(supply));
        await ctx.SaveChangesAsync();
        return Ok();
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
    public async Task<IActionResult> Put(int id, [FromBody] SupplyPostDto supplyToPut)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Put supply with id {0}", id);
        var supply = ctx.Supplies.FirstOrDefault(supply => supply.Id == id);
        if (supply == null)
        {
            _logger.LogInformation("Not found supply with id {0}", id);
            return NotFound();
        }
        else
        {
            ctx.Update(_mapper.Map(supplyToPut, supply));
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
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Put supply with id ({id})");
        var supply = ctx.Supplies.FirstOrDefault(supply => supply.Id == id);
        if (supply == null)
        {
            _logger.LogInformation($"Not found supply with id ({id})");
            return NotFound();
        }
        else
        {
            ctx.Supplies.Remove(supply);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}