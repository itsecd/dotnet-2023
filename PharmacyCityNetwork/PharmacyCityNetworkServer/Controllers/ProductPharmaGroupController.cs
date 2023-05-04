using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyCityNetwork.Server.Dto;

namespace PharmacyCityNetwork.Server.Controllers;

/// <summary>
/// ProductPharmaGroup controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProductPharmaGroupController : ControllerBase
{
    private readonly ILogger<ProductPharmaGroupController> _logger;
    private readonly IDbContextFactory<PharmacyCityNetworkDbContext> _contextFactory;
    private readonly IMapper _mapper;
    public ProductPharmaGroupController(ILogger<ProductPharmaGroupController> logger, IDbContextFactory<PharmacyCityNetworkDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// Get info about all productPharmaGroups
    /// </summary>
    /// <returns>Return all productPharmaGroups</returns>
    [HttpGet]
    public async Task<IEnumerable<ProductPharmaGroupGetDto>> GetProductPharmaGroups()
    {
        _logger.LogInformation("Get all productPharmaGroups");
        var ctx = await _contextFactory.CreateDbContextAsync();
        var productPharmaGroups = await ctx.ProductPharmaGroups.ToArrayAsync();
        return _mapper.Map<IEnumerable<ProductPharmaGroupGetDto>>(productPharmaGroups);
    }
    /// <summary>
    /// Get productPharmaGroup info by id
    /// </summary>
    /// <param name="idProductPharmaGroup">ProductPharmaGroup Id</param>
    /// <returns>Return productPharmaGroup with specified id</returns>
    [HttpGet("{idProductPharmaGroup}")]
    public async Task<ActionResult<ProductPharmaGroupGetDto>> GetProductPharmaGroup(int idProductPharmaGroup)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var productPharmaGroup = await ctx.ProductPharmaGroups.FirstOrDefaultAsync(productPharmaGroup => productPharmaGroup.Id == idProductPharmaGroup);
        if (productPharmaGroup == null)
        {
            _logger.LogInformation("Not found productPharmaGroup : {idProductPharmaGroup}", idProductPharmaGroup);
            return NotFound($"The productPharmaGroup does't exist by this id {idProductPharmaGroup}");
        }
        else
        {
            _logger.LogInformation("Not found productPharmaGroup : {idProductPharmaGroup}", idProductPharmaGroup);
            return Ok(_mapper.Map<ProductPharmaGroupGetDto>(productPharmaGroup));
        }
    }
    /// <summary>
    /// Post a new productPharmaGroup 
    /// </summary>
    /// <param name="productPharmaGroup">ProductPharmaGroup class instance to insert to table</param>
    [HttpPost]
    public async Task PostProductPharmaGroup([FromBody] ProductPharmaGroupPostDto productPharmaGroup)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Create new productPharmaGroup");
        await ctx.ProductPharmaGroups.AddAsync(_mapper.Map<ProductPharmaGroup>(productPharmaGroup));
        await ctx.SaveChangesAsync();
    }
    /// <summary>
    /// Put productPharmaGroup 
    /// </summary>
    /// <param name="idProductPharmaGroup">An id of productPharmaGroup which would be changed</param>
    /// <param name="productPharmaGroupToPut">ProductPharmaGroup class instance to insert to table</param>
    /// <returns>Signalization of success of error</returns>
    [HttpPut("{idProductPharmaGroup}")]
    public async Task<IActionResult> PutProductPharmaGroup(int idProductPharmaGroup, [FromBody] ProductPharmaGroupPostDto productPharmaGroupToPut)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var productPharmaGroup = await ctx.ProductPharmaGroups.FirstOrDefaultAsync(productPharmaGroup => productPharmaGroup.Id == idProductPharmaGroup);
        if (productPharmaGroup == null)
        {
            _logger.LogInformation("Not found productPharmaGroup : {idProductPharmaGroup}", idProductPharmaGroup);
            return NotFound($"The productPharmaGroup does't exist by this id {idProductPharmaGroup}");
        }
        else
        {
            _logger.LogInformation("Update productPharmaGroup by id {idProductPharmaGroup}", idProductPharmaGroup);
            _mapper.Map(productPharmaGroupToPut, productPharmaGroup);
            ctx.ProductPharmaGroups.Update(_mapper.Map<ProductPharmaGroup>(productPharmaGroup));
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Delete a productPharmaGroup
    /// </summary>
    /// <param name="idProductPharmaGroup">An id of productPharmaGroup which would be deleted</param>
    /// <returns>Signalization of success of error</returns>
    [HttpDelete("{idProductPharmaGroup}")]
    public async Task<IActionResult> DeleteProductPharmaGroup(int idProductPharmaGroup)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var productPharmaGroup = await ctx.ProductPharmaGroups.Include(productPharmaGroup => productPharmaGroup.Product)
                                        .FirstOrDefaultAsync(productPharmaGroup => productPharmaGroup.Id == idProductPharmaGroup);
        if (productPharmaGroup == null)
        {
            _logger.LogInformation("Not found productPharmaGroup: {idProductPharmaGroup}", idProductPharmaGroup);
            return NotFound($"The productPharmaGroup does't exist by this id {idProductPharmaGroup}");
        }
        else
        {
            _logger.LogInformation("Delete productPharmaGroup by id {idProductPharmaGroup}", idProductPharmaGroup);
            ctx.ProductPharmaGroups.Remove(productPharmaGroup);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}