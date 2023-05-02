using AutoMapper;
using Factory.Model;
using Factory.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Factory.Server.Controllers;

/// <summary>
/// Supply controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SupplyController : ControllerBase
{
    private readonly IDbContextFactory<FactoryContext> _contextFactory;

    private readonly ILogger<SupplyController> _logger;

    private readonly IMapper _mapper;

    public SupplyController(IDbContextFactory<FactoryContext> contextFactory, ILogger<SupplyController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Get supplies
    /// </summary>
    /// <returns>supplies</returns>
    [HttpGet]
    public async Task<IEnumerable<SupplyGetDto>> Get()
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get Supplies");
        return _mapper.Map<IEnumerable<SupplyGetDto>>(ctx.Supplies);
    }

    /// <summary>
    /// Get supply by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>supply</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Supply>> Get(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var supply = await ctx.FindAsync<Supply>(id);
        if (supply == null)
        {
            _logger.LogInformation($"Not found supply: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get supply with id {id}");
            return Ok(_mapper.Map<SupplyGetDto>(supply));
        }
    }

    /// <summary>
    /// Post supply
    /// </summary>
    /// <param name="supply"></param>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] SupplyPostDto supply)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"POST supply ({supply.Date})");
        await ctx.Supplies.AddAsync(_mapper.Map<Supply>(supply));
        await ctx.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Put supply by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="supplyToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] SupplyPostDto supplyToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var supply = await ctx.FindAsync<Supply>(id);
        if (supply == null)
        {
            _logger.LogInformation($"Not found supply: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put supplier with id {id}");
            _mapper.Map(supplyToPut, supply);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// Delete supply by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var supply = await ctx.FindAsync<Supply>(id);
        if (supply == null)
        {
            _logger.LogInformation($"Not found supplier: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get supplier with id {id}");
            ctx.Supplies.Remove(supply);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
