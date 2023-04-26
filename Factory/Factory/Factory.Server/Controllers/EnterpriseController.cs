using AutoMapper;
using Factory.Domain;
using Factory.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Factory.Server.Controllers;

/// <summary>
/// Enterprise controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class EnterpriseController : ControllerBase
{
    private readonly IDbContextFactory<FactoryContext> _contextFactory;

    private readonly ILogger<EnterpriseController> _logger;

    private readonly IMapper _mapper;
    public EnterpriseController(IDbContextFactory<FactoryContext> contextFactory, ILogger<EnterpriseController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
        //  using var ctx = _contextFactory.CreateDbContext();
    }

    /// <summary>
    /// Get enterprises
    /// </summary>
    /// <returns>enterprises</returns>
    [HttpGet]
    public async Task<IEnumerable<EnterpriseGetDto>> Get()
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var enterprises = await ctx.Enterprises.ToArrayAsync();
        _logger.LogInformation("Get Enterprises");
        return _mapper.Map<IEnumerable<EnterpriseGetDto>>(enterprises);
    }

    /// <summary>
    /// Get enterprise by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>enterprise</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<EnterpriseGetDto>> Get(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var enterprise = await ctx.FindAsync<Enterprise>(id);
        if (enterprise == null)
        {
            _logger.LogInformation("Not found enterprise: {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get enterprise with id {id}");
            return Ok(_mapper.Map<EnterpriseGetDto>(enterprise));
        }
    }

    /// <summary>
    /// Post enterprise
    /// </summary>
    /// <param name="enterprise"></param>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] EnterprisePostDto enterprise)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"POST enterprise ({enterprise.Name})");
        await ctx.Enterprises.AddAsync(_mapper.Map<Enterprise>(enterprise));
        await ctx.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Put enterprise by ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="enterpriseToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] EnterprisePostDto enterpriseToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var enterprise = await ctx.FindAsync<Enterprise>(id);
        if (enterprise == null)
        {
            _logger.LogInformation($"Not found enterprise: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put enterprise with id {id}");
            _mapper.Map(enterpriseToPut, enterprise);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// Delete enterprise by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var enterprise = await ctx.FindAsync<Enterprise>(id);
        if (enterprise == null)
        {
            _logger.LogInformation($"Not found enterprise: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get enterprise with id {id}");
            ctx.Enterprises.Remove(enterprise);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
