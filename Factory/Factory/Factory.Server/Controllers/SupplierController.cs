using AutoMapper;
using Factory.Domain;
using Factory.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Factory.Server.Controllers;

/// <summary>
/// Supplier controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SupplierController : ControllerBase
{
    private readonly IDbContextFactory<FactoryContext> _contextFactory;

    private readonly ILogger<SupplierController> _logger;

    private readonly IMapper _mapper;

    public SupplierController(IDbContextFactory<FactoryContext> contextFactory, ILogger<SupplierController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Get suppliers
    /// </summary>
    /// <returns>suppliers</returns>
    [HttpGet]
    public async Task<IEnumerable<SupplierGetDto>> Get()
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get Suppliers");
        return _mapper.Map<IEnumerable<SupplierGetDto>>(ctx.Suppliers);
    }

    /// <summary>
    /// Get supplier by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>supplier</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<SupplierGetDto>> Get(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var supplier = await ctx.FindAsync<Supplier>(id);
        if (supplier == null)
        {
            _logger.LogInformation($"Not found supplier: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get supplier with id {id}");
            return Ok(_mapper.Map<SupplierGetDto>(supplier));
        }
    }

    /// <summary>
    /// Post supplier
    /// </summary>
    /// <param name="supplier"></param>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] SupplierPostDto supplier)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"POST supplier ({supplier.Name})");
        await ctx.Suppliers.AddAsync(_mapper.Map<Supplier>(supplier));
        await ctx.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Put supplier by ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="supplierToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] SupplierPostDto supplierToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var supplier = await ctx.FindAsync<Supplier>(id);
        if (supplier == null)
        {
            _logger.LogInformation($"Not found supplier: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put supplier with id {id}");
            _mapper.Map(supplierToPut, supplier);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// Delete supplier by ID/5
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var supplier = await ctx.FindAsync<Supplier>(id);
        if (supplier == null)
        {
            _logger.LogInformation($"Not found supplier: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get supplier with id {id}");
            ctx.Suppliers.Remove(supplier);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
