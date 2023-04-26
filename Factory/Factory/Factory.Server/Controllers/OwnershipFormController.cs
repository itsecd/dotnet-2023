using Factory.Domain;
using Factory.Server.Dto;
using Factory.Server.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Factory.Server.Controllers;

/// <summary>
/// Ownership form controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class OwnershipFormController : ControllerBase
{
    private readonly IDbContextFactory<FactoryContext> _contextFactory;

    private readonly ILogger<OwnershipFormController> _logger;

    public OwnershipFormController(IDbContextFactory<FactoryContext> contextFactory, ILogger<OwnershipFormController> logger)
    {
        _contextFactory = contextFactory;
        _logger = logger;
    }

    /// <summary>
    /// Get ownership forms
    /// </summary>
    /// <returns>ownership forms</returns>
    [HttpGet]
    public IEnumerable<OwnershipForm> Get()
    {
        using var ctx = _contextFactory.CreateDbContext();
        _logger.LogInformation("Get Ownership Forms");
        return ctx.OwnershipForms;
    }

    /// <summary>
    /// Get ownership form by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>ownership forms</returns>
    [HttpGet("{id}")]
    public ActionResult<OwnershipForm> Get(int id)
    {
        using var ctx = _contextFactory.CreateDbContext();
        var ownershipForm = ctx.Find<OwnershipForm>(id); 
        if (ownershipForm == null)
        {
            _logger.LogInformation($"Not found ownership form: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get ownership form with id {id}");
            return Ok(ownershipForm);
        }
    }
}
