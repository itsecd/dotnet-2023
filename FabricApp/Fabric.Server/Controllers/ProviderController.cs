using AutoMapper;
using Fabrics.Domain;
using Fabrics.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fabrics.Server.Controllers;
/// <summary>
/// Provider controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProviderController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<ProviderController> _logger;
    /// <summary>
    /// Used to store DbContext
    /// </summary>
    private readonly IDbContextFactory<FabricsDbContext> _contextFactory;
    /// <summary>
    /// Used to store map-object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// ProviderController constructor
    /// </summary>
    /// <param name="logger">Logger</param>
    /// <param name="contextFactory">Repository</param>
    /// <param name="mapper">Map-object</param>
    public ProviderController(ILogger<ProviderController> logger, IDbContextFactory<FabricsDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// Get list of all providers.
    /// </summary>
    /// <returns>List of providers</returns>
    [HttpGet]
    public async Task<IEnumerable<ProviderGetDto>> Get()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get provider");
        var providers = await context.Providers.ToListAsync();
        return _mapper.Map<IEnumerable<ProviderGetDto>>(providers);
    }
    /// <summary>
    /// Get provider by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Provider</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ProviderGetDto>> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var provider = await context.Providers.FirstOrDefaultAsync(provider => provider.Id == id);
        if (provider == null)
        {
            _logger.LogInformation("Not found provider:{id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<ProviderGetDto>(provider));
        }
    }
    /// <summary>
    /// Post new provider
    /// </summary>
    /// <param name="provider"></param>
    [HttpPost]
    public async Task<ActionResult<ProviderGetDto>> Post([FromBody] ProviderPostDto provider)
    {
        var mappedProvider = _mapper.Map<Provider>(provider);

        await using var context = await _contextFactory.CreateDbContextAsync();
        await context.Providers.AddAsync(mappedProvider);
        await context.SaveChangesAsync();

        return Ok(_mapper.Map<ProviderGetDto>(mappedProvider));
    }
    /// <summary>
    /// Put provider
    /// </summary>
    /// <param name="id"></param>
    /// <param name="providerToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ProviderPostDto providerToPut)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var provider = await context.Providers.FirstOrDefaultAsync(provider => provider.Id == id);
        if (provider == null)
        {
            _logger.LogInformation("Not found provider:{id}", id);
            return NotFound();
        }
        else
        {
            context.Update(_mapper.Map(providerToPut, provider));
            await context.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Delete provider
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var provider = await context.Providers.FirstOrDefaultAsync(provider => provider.Id == id);
        if (provider == null)
        {
            _logger.LogInformation("Not found provider:{id}", id);
            return NotFound();
        }
        else
        {
            context.Providers.Remove(provider);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
