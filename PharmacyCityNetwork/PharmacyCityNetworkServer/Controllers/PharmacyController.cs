using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyCityNetwork.Server.Dto;

namespace PharmacyCityNetwork.Server.Controllers;

/// <summary>
/// Pharmacy controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PharmacyController : ControllerBase
{
    private readonly ILogger<PharmacyController> _logger;
    private readonly IDbContextFactory<PharmacyCityNetworkDbContext> _contextFactory;
    private readonly IMapper _mapper;
    public PharmacyController(ILogger<PharmacyController> logger, IDbContextFactory<PharmacyCityNetworkDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// Get info about all pharmacys
    /// </summary>
    /// <returns>Return all pharmacys</returns>
    [HttpGet]
    public async Task<IEnumerable<PharmacyGetDto>> GetPharmacys()
    {
        _logger.LogInformation("Get all pharmacys");
        var ctx = await _contextFactory.CreateDbContextAsync();
        var pharmacys = await ctx.Pharmacys.ToArrayAsync();
        return _mapper.Map<IEnumerable<PharmacyGetDto>>(pharmacys);
    }
    /// <summary>
    /// Get pharmacy info by id
    /// </summary>
    /// <param name="idPharmacy">Pharmacy Id</param>
    /// <returns>Return pharmacy with specified id</returns>
    [HttpGet("{idPharmacy}")]
    public async Task<ActionResult<PharmacyGetDto>> GetPharmacy(int idPharmacy)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var pharmacy = await ctx.Pharmacys.FirstOrDefaultAsync(pharmacy => pharmacy.Id == idPharmacy);
        if (pharmacy == null)
        {
            _logger.LogInformation("Not found pharmacy : {idPharmacy}", idPharmacy);
            return NotFound($"The pharmacy does't exist by this id {idPharmacy}");
        }
        else
        {
            _logger.LogInformation("Not found pharmacy : {idPharmacy}", idPharmacy);
            return Ok(_mapper.Map<PharmacyGetDto>(pharmacy));
        }
    }
    /// <summary>
    /// Post a new pharmacy
    /// </summary>
    /// <param name="pharmacy">Pharmacy class instance to insert to table</param>
    [HttpPost]
    public async Task PostPharmacy([FromBody] PharmacyPostDto pharmacy)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Create new pharmacy");
        await ctx.Pharmacys.AddAsync(_mapper.Map<Pharmacy>(pharmacy));
        await ctx.SaveChangesAsync();
    }
    /// <summary>
    /// Put pharmacy
    /// </summary>
    /// <param name="idPharmacy">An id of pharmacy which would be changed</param>
    /// <param name="pharmacyToPut">Pharmacy class instance to insert to table</param>
    /// <returns>Signalization of success of error</returns>
    [HttpPut("{idPharmacy}")]
    public async Task<IActionResult> PutPharmacy(int idPharmacy, [FromBody] PharmacyPostDto pharmacyToPut)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var pharmacy = await ctx.Pharmacys.FirstOrDefaultAsync(pharmacy => pharmacy.Id == idPharmacy);
        if (pharmacy == null)
        {
            _logger.LogInformation("Not found pharmacy : {idPharmacy}", idPharmacy);
            return NotFound($"The pharmacy does't exist by this id {idPharmacy}");
        }
        else
        {
            _logger.LogInformation("Update pharmacy by id {idPharmacy}", idPharmacy);
            _mapper.Map(pharmacyToPut, pharmacy);
            ctx.Pharmacys.Update(_mapper.Map<Pharmacy>(pharmacy));
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Delete a pharmacy
    /// </summary>
    /// <param name="idPharmacy">An id of pharmacy which would be deleted</param>
    /// <returns>Signalization of success of error</returns>
    [HttpDelete("{idPharmacy}")]
    public async Task<IActionResult> DeletePharmacy(int idPharmacy)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var pharmacy = await ctx.Pharmacys.Include(pharmacy => pharmacy.ProductPharmacys)
                                        .FirstOrDefaultAsync(pharmacy => pharmacy.Id == idPharmacy);
        if (pharmacy == null)
        {
            _logger.LogInformation("Not found pharmacy: {idPharmacy}", idPharmacy);
            return NotFound($"The pharmacy does't exist by this id {idPharmacy}");
        }
        else
        {
            _logger.LogInformation("Delete airplane by id {idPharmacy}", idPharmacy);
            ctx.Pharmacys.Remove(pharmacy);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}