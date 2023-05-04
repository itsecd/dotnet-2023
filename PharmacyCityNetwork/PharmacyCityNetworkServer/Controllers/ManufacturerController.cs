using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyCityNetwork.Server.Dto;

namespace PharmacyCityNetwork.Server.Controllers;

/// <summary>
/// Manufacturer controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ManufacturerController : ControllerBase
{
    private readonly ILogger<ManufacturerController> _logger;
    private readonly IDbContextFactory<PharmacyCityNetworkDbContext> _contextFactory;
    private readonly IMapper _mapper;
    public ManufacturerController(ILogger<ManufacturerController> logger, IDbContextFactory<PharmacyCityNetworkDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// Get info about all manufacturers
    /// </summary>
    /// <returns>Return all manufacturers</returns>
    [HttpGet]
    public async Task<IEnumerable<ManufacturerGetDto>> GetManufacturers()
    {
        _logger.LogInformation("Get all manufacturers");
        var ctx = await _contextFactory.CreateDbContextAsync();
        var manufacturers = await ctx.Manufacturers.ToArrayAsync();
        return _mapper.Map<IEnumerable<ManufacturerGetDto>>(manufacturers);
    }
    /// <summary>
    /// Get manufacturer info by id
    /// </summary>
    /// <param name="idManufacturer">Manufacturer Id</param>
    /// <returns>Return manufacturer with specified id</returns>
    [HttpGet("{idManufacturer}")]
    public async Task<ActionResult<ManufacturerGetDto>> GetManufacturer(int idManufacturer)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var manufacturer = await ctx.Manufacturers.FirstOrDefaultAsync(manufacturer => manufacturer.Id == idManufacturer);
        if (manufacturer == null)
        {
            _logger.LogInformation("Not found manufacturer : {idManufacturer}", idManufacturer);
            return NotFound($"The manufacturer does't exist by this id {idManufacturer}");
        }
        else
        {
            _logger.LogInformation("Not found manufacturer : {idManufacturer}", idManufacturer);
            return Ok(_mapper.Map<ManufacturerGetDto>(manufacturer));
        }
    }
    /// <summary>
    /// Post a new manufacturer
    /// </summary>
    /// <param name="manufacturer">Manufacturer class instance to insert to table</param>
    [HttpPost]
    public async Task PostManufacturer([FromBody] ManufacturerPostDto manufacturer)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Create new manufacturer");
        await ctx.Manufacturers.AddAsync(_mapper.Map<Manufacturer>(manufacturer));
        await ctx.SaveChangesAsync();
    }
    /// <summary>
    /// Put manufacturer
    /// </summary>
    /// <param name="idManufacturer">An id of manufacturer which would be changed</param>
    /// <param name="manufacturerToPut">Manufacturer class instance to insert to table</param>
    /// <returns>Signalization of success of error</returns>
    [HttpPut("{idManufacturer}")]
    public async Task<IActionResult> PutManufacturer(int idManufacturer, [FromBody] ManufacturerPostDto manufacturerToPut)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var manufacturer = await ctx.Manufacturers.FirstOrDefaultAsync(manufacturer => manufacturer.Id == idManufacturer);
        if (manufacturer == null)
        {
            _logger.LogInformation("Not found manufacturer : {idManufacturer}", idManufacturer);
            return NotFound($"The manufacturer does't exist by this id {idManufacturer}");
        }
        else
        {
            _logger.LogInformation("Update group by id {idManufacturer}", idManufacturer);
            _mapper.Map(manufacturerToPut, manufacturer);
            ctx.Manufacturers.Update(_mapper.Map<Manufacturer>(manufacturer));
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Delete a manufacturer
    /// </summary>
    /// <param name="idManufacturer">An id of manufacturer which would be deleted</param>
    /// <returns>Signalization of success of error</returns>
    [HttpDelete("{idManufacturer}")]
    public async Task<IActionResult> DeleteManufacturer(int idManufacturer)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var manufacturer = await ctx.Manufacturers.Include(manufacturer => manufacturer.Products)
                                        .FirstOrDefaultAsync(manufacturer => manufacturer.Id == idManufacturer);
        if (manufacturer == null)
        {
            _logger.LogInformation("Not found manufacturer: {idManufacturer}", idManufacturer);
            return NotFound($"The manufacturer does't exist by this id {idManufacturer}");
        }
        else
        {
            _logger.LogInformation("Delete manufacturer by id {idManufacturer}", idManufacturer);
            ctx.Manufacturers.Remove(manufacturer);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}