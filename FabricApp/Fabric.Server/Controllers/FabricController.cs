using AutoMapper;
using Fabrics.Domain;
using Fabrics.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fabrics.Server.Controllers;
/// <summary>
/// Fabric controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class FabricController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<FabricController> _logger;
    /// <summary>
    /// Used to store DbContext
    /// </summary>
    private readonly IDbContextFactory<FabricsDbContext> _contextFactory;
    /// <summary>
    /// Used to store map-object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// FabricController constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="contextFactory"></param>
    /// <param name="mapper"></param>
    public FabricController(ILogger<FabricController> logger, IDbContextFactory<FabricsDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// Get list of all fabrics.
    /// </summary>
    /// <returns>List of fabrics</returns>
    [HttpGet]
    public async Task<IEnumerable<FabricGetDto>> Get()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get fabric");
        var fabrics = await context.Fabrics.ToListAsync();
        return _mapper.Map<IEnumerable<FabricGetDto>>(fabrics);
    }
    /// <summary>
    /// Get fabric by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Fabric</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<FabricGetDto>> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var fabric = await context.Fabrics.FirstOrDefaultAsync(fabric => fabric.Id == id);
        if (fabric == null)
        {
            _logger.LogInformation("Not found fabric:{id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<FabricGetDto>(fabric));
        }
    }
    /// <summary>
    /// Post new Fabric
    /// </summary>
    /// <param name="fabric"></param>
    [HttpPost]
    public async void Post([FromBody] FabricPostDto fabric)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        await context.Fabrics.AddAsync(_mapper.Map<Fabric>(fabric));
        await context.SaveChangesAsync();
    }
    /// <summary>
    /// Put fabric
    /// </summary>
    /// <param name="id"></param>
    /// <param name="fabricToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] FabricPostDto fabricToPut)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var fabric = await context.Fabrics.FirstOrDefaultAsync(fabric => fabric.Id == id);
        if (fabric == null)
        {
            _logger.LogInformation("Not found fabric:{id}", id);
            return NotFound();
        }
        else
        {
            context.Update(_mapper.Map(fabricToPut, fabric));
            await context.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Delete fabric by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var fabric = await context.Fabrics.FirstOrDefaultAsync(fabric => fabric.Id == id);
        if (fabric == null)
        {
            _logger.LogInformation("Not found fabric:{id}", id);
            return NotFound();
        }
        else
        {
            context.Fabrics.Remove(fabric);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
