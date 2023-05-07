using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shops.Domain;
using Shops.Server.Dto;

namespace Shops.Server.Controllers;
/// <summary>
/// Controller for product group
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProductGroupController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<ProductGroupController> _logger;
    /// <summary>
    /// Used to store factory context
    /// </summary>
    private readonly IDbContextFactory<ShopsContext> _dbContextFactory;
    /// <summary>
    /// Used to store map-object
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Controller constructor 
    /// </summary>
    public ProductGroupController(ILogger<ProductGroupController> logger, IDbContextFactory<ShopsContext> dbContextFactory, IMapper mapper)
    {
        _logger = logger;
        _dbContextFactory = dbContextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// Return list of product group
    /// </summary>
    /// <returns>Ok(List of product group)</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductGroupGetDto>>> Get()
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get list of product group");
        return Ok(_mapper.Map<IEnumerable<ProductGroupGetDto>>(ctx.ProductGroups));
    }
    /// <summary>
    /// Return product group by id
    /// </summary>
    /// <param name="id"> product group id</param>
    /// <returns>Ok (the product group found by specified id) or NotFound</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductGroupGetDto>> Get(int id)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        var productGroup = await ctx.ProductGroups.FirstOrDefaultAsync(productGroup => productGroup.Id == id);
        if (productGroup == null)
        {
            _logger.LogInformation("Not found product group with id = {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Product group with id = {id}", id);
            return Ok(_mapper.Map<ProductGroupGetDto>(productGroup));
        }
    }
    /// <summary>
    /// Add new product group in list of product group
    /// </summary>
    /// <param name="productGroup"> New product group</param>
    /// <returns>Ok(add new product group) </returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProductGroupPostDto productGroup)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        var newId = ctx.ProductGroups
            .Select(productGroup => productGroup.Id)
            .DefaultIfEmpty()
            .Max() + 1;
        var newProductGroup = _mapper.Map<ProductGroup>(productGroup);
        newProductGroup.Id = newId;
        await ctx.ProductGroups.AddAsync(newProductGroup);
        await ctx.SaveChangesAsync();
        _logger.LogInformation("Post product group, id = {newId}", newId);
        return Ok();
    }
    /// <summary>
    /// Updates product group information
    /// </summary>
    /// <param name="id">product group id</param>
    /// <param name="productGroupToPut">New information</param>
    /// <returns>Ok (update product group by id) or NotFound</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ProductGroupPostDto productGroupToPut)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        var productGroup = await ctx.ProductGroups.FirstOrDefaultAsync(productGroup => productGroup.Id == id);
        if (productGroup == null)
        {
            _logger.LogInformation("Not found product group with id = {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Update information product group with id = {id}", id);
            _mapper.Map<ProductGroupPostDto, ProductGroup>(productGroupToPut, productGroup);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Delete product group by id
    /// </summary>
    /// <param name="id">product group id</param>
    /// <returns>Ok (delete product group by id) or NotFound</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        var productGroup = await ctx.ProductGroups.FirstOrDefaultAsync(productGroup => productGroup.Id == id);
        if (productGroup == null)
        {
            _logger.LogInformation("Not found product group with id = {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Delete product group with id = {id}", id);
            ctx.ProductGroups.Remove(productGroup);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
