using AutoMapper;
using Factory.Domain;
using Factory.Server.Dto;
using Factory.Server.Repository;
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
    public IEnumerable<Supply> Get()
    {
        using var ctx = _contextFactory.CreateDbContext();
        _logger.LogInformation("Get Supplies");
        return ctx.Supplies;
    }

    /// <summary>
    /// Get supply by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>supply</returns>
    [HttpGet("{id}")]
    public ActionResult<Supply> Get(int id)
    {
        using var ctx = _contextFactory.CreateDbContext();
        var supply = ctx.Find<SupplierGetDto>(id);
        if (supply == null)
        {
            _logger.LogInformation($"Not found supply: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get supply with id {id}");
            return Ok(supply);
        }
    }

    /// <summary>
    /// Post supply
    /// </summary>
    /// <param name="supply"></param>
    [HttpPost]
    public void Post([FromBody] SupplyPostDto supply)
    {
        using var ctx = _contextFactory.CreateDbContext();
        _logger.LogInformation("Post supply");
        ctx.Supplies.Add(_mapper.Map<Supply>(supply));
        ctx.SaveChanges();
    }

    /// <summary>
    /// Put supply by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="supplyToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] SupplyPostDto supplyToPut)
    {
        using var ctx = _contextFactory.CreateDbContext();
        var supply = ctx.Find<Supply>(id);
        if (supply == null)
        {
            _logger.LogInformation($"Not found supply: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put supplier with id {id}");
            _mapper.Map(supplyToPut, supply);
            ctx.SaveChanges();
            return Ok();
        }
    }

    /// <summary>
    /// Delete supply by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        using var ctx = _contextFactory.CreateDbContext();
        var supply = ctx.Find<Supply>(id);
        if (supply == null)
        {
            _logger.LogInformation($"Not found supplier: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get supplier with id {id}");
            ctx.Supplies.Remove(supply);
            ctx.SaveChanges();
            return Ok();
        }
    }
}
