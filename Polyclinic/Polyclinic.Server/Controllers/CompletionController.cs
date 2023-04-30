using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polyclinic.Domain;
using Polyclinic.Server.Dto;

namespace Polyclinic.Server.Controllers;

/// <summary>
/// Completion controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CompletionController : ControllerBase
{
    private readonly ILogger<CompletionController> _logger;
    private readonly IDbContextFactory<PolyclinicDbContext> _contextFactory;
    private readonly IMapper _mapper;
    public CompletionController(ILogger<CompletionController> logger, IDbContextFactory<PolyclinicDbContext> contextFactory, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Get completions
    /// </summary>
    /// <returns>completions</returns>
    [HttpGet]
    public async Task<IEnumerable<CompletionGetDto>> Get()
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var completions = await ctx.Completions.ToArrayAsync();
        _logger.LogInformation("Get completion");
        return _mapper.Map<IEnumerable<CompletionGetDto>>(completions);
    }

    /// <summary>
    /// Get completion by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>completion</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var completion = await ctx.FindAsync<CompletionGetDto>(id);
        if (completion == null)
        {
            _logger.LogInformation($"Not found completion: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get completion with id {id}");
            return Ok(completion);
        }
    }


    /// <summary>
    /// Post completion
    /// </summary>
    /// <param name="completion"></param>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CompletionPostDto completion)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Post completion");
        await ctx.Completions.AddAsync(_mapper.Map<Completion>(completion));
        await ctx.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Put copletion by ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="completionToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] CompletionPostDto completionToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var completion = await ctx.FindAsync<Completion>(id);
        if (completion == null)
        {
            _logger.LogInformation($"Not found completion: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put completion with id {id}");
            _mapper.Map(completionToPut, completion);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// Delete completion by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var completion = await ctx.FindAsync<Completion>(id);
        if (completion == null)
        {
            _logger.LogInformation($"Not found completion: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put completion with id {id}");
            ctx.Completions.Remove(completion);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
