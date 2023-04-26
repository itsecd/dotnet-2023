using AutoMapper;
using Factory.Domain;
using Factory.Server.Dto;
using Factory.Server.Repository;
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
    public IEnumerable<SupplierGetDto> Get()
    {
        using var ctx = _contextFactory.CreateDbContext();
        _logger.LogInformation("Get Suppliers");
        return _mapper.Map<IEnumerable<SupplierGetDto>>(ctx.Suppliers);
    }

    /// <summary>
    /// Get supplier by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>supplier</returns>
    [HttpGet("{id}")]
    public ActionResult<SupplierGetDto> Get(int id)
    {
        using var ctx = _contextFactory.CreateDbContext();
        var supplier = ctx.Find<SupplierGetDto>(id);
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
    public void Post([FromBody] SupplierPostDto supplier)
    {
        using var ctx = _contextFactory.CreateDbContext();
        _logger.LogInformation("Post supplier");
        ctx.Suppliers.Add(_mapper.Map<Supplier>(supplier));
        ctx.SaveChanges();
    }

    /// <summary>
    /// Put supplier by ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="supplierToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] SupplierPostDto supplierToPut)
    {
        using var ctx = _contextFactory.CreateDbContext();
        var supplier = ctx.Find<Supplier>(id);
        if (supplier == null)
        {
            _logger.LogInformation($"Not found supplier: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put supplier with id {id}");
            _mapper.Map(supplierToPut, supplier);
            ctx.SaveChanges();
            return Ok();
        }
    }

    /// <summary>
    /// Delete supplier by ID/5
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        using var ctx = _contextFactory.CreateDbContext();
        var supplier = ctx.Find<Supplier>(id);
        if (supplier == null)
        {
            _logger.LogInformation($"Not found supplier: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get supplier with id {id}");
            ctx.Suppliers.Remove(supplier);
            ctx.SaveChanges();
            return Ok();
        }
    }
}
