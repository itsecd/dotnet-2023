using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyCityNetwork.Server.Dto;

namespace PharmacyCityNetwork.Server.Controllers;
/// <summary>
/// ProductPharmacy controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProductPharmacyController : ControllerBase
{
    private readonly ILogger<ProductPharmacyController> _logger;
    private readonly IDbContextFactory<PharmacyCityNetworkDbContext> _contextFactory;
    private readonly IMapper _mapper;
    public ProductPharmacyController(ILogger<ProductPharmacyController> logger, IDbContextFactory<PharmacyCityNetworkDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// Get info about all productPharmacys
    /// </summary>
    /// <returns>Return all productPharmacys</returns>
    [HttpGet]
    public async Task<IEnumerable<ProductPharmacyGetDto>> GetProductPharmacys()
    {
        _logger.LogInformation("Get all productPharmacys");
        var ctx = await _contextFactory.CreateDbContextAsync();
        var productPharmacys = await ctx.ProductPharmacys.ToArrayAsync();
        return _mapper.Map<IEnumerable<ProductPharmacyGetDto>>(productPharmacys);
    }
    /// <summary>
    /// Get productPharmacy info by id
    /// </summary>
    /// <param name="idProductPharmacy">ProductPharmacy Id</param>
    /// <returns>Return productPharmacy with specified id</returns>
    [HttpGet("{idProductPharmacy}")]
    public async Task<ActionResult<ProductPharmacyGetDto>> GetProductPharmacy(int idProductPharmacy)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var productPharmacy = await ctx.ProductPharmacys.FirstOrDefaultAsync(productPharmacy => productPharmacy.Id == idProductPharmacy);
        if (productPharmacy == null)
        {
            _logger.LogInformation("Not found productPharmacy : {idProductPharmacy}", idProductPharmacy);
            return NotFound($"The productPharmacy does't exist by this id {idProductPharmacy}");
        }
        else
        {
            _logger.LogInformation("Not found productPharmacy : {idProductPharmacy}", idProductPharmacy);
            return Ok(_mapper.Map<ProductPharmacyGetDto>(productPharmacy));
        }
    }
    /// <summary>
    /// Post a new productPharmacy 
    /// </summary>
    /// <param name="productPharmacy">ProductPharmacy class instance to insert to table</param>
    [HttpPost]
    public async Task PostProductPharmacy([FromBody] ProductPharmacyPostDto productPharmacy)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Create new productPharmacy");
        await ctx.ProductPharmacys.AddAsync(_mapper.Map<ProductPharmacy>(productPharmacy));
        await ctx.SaveChangesAsync();
    }
    /// <summary>
    /// Put productPharmacy 
    /// </summary>
    /// <param name="idProductPharmacy">An id of productPharmacy which would be changed</param>
    /// <param name="productPharmacyToPut">ProductPharmacy class instance to insert to table</param>
    /// <returns>Signalization of success of error</returns>
    [HttpPut("{idProductPharmacy}")]
    public async Task<IActionResult> PutProductPharmacy(int idProductPharmacy, [FromBody] ProductPharmacyPostDto productPharmacyToPut)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var productPharmacy = await ctx.ProductPharmacys.FirstOrDefaultAsync(productPharmacy => productPharmacy.Id == idProductPharmacy);
        if (productPharmacy == null)
        {
            _logger.LogInformation("Not found productPharmacy : {idProductPharmacy}", idProductPharmacy);
            return NotFound($"The productPharmacy does't exist by this id {idProductPharmacy}");
        }
        else
        {
            _logger.LogInformation("Update productPharmacy by id {idProductPharmacy}", idProductPharmacy);
            _mapper.Map(productPharmacyToPut, productPharmacy);
            ctx.ProductPharmacys.Update(_mapper.Map<ProductPharmacy>(productPharmacy));
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Delete a productPharmacy
    /// </summary>
    /// <param name="idProductPharmacy">An id of productPharmacy which would be deleted</param>
    /// <returns>Signalization of success of error</returns>
    [HttpDelete("{idProductPharmacy}")]
    public async Task<IActionResult> DeleteProductPharmacy(int idProductPharmacy)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var productPharmacy = await ctx.ProductPharmacys.Include(productPharmacy => productPharmacy.Product)
                                        .FirstOrDefaultAsync(productPharmacy => productPharmacy.Id == idProductPharmacy);
        if (productPharmacy == null)
        {
            _logger.LogInformation("Not found productPharmacy: {idProductPharmacy}", idProductPharmacy);
            return NotFound($"The productPharmacy does't exist by this id {idProductPharmacy}");
        }
        else
        {
            _logger.LogInformation("Delete productPharmacy by id {idProductPharmacy}", idProductPharmacy);
            ctx.ProductPharmacys.Remove(productPharmacy);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}