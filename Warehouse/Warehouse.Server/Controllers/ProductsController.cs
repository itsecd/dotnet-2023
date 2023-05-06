using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain;
using Warehouse.Server.Dto;

namespace Warehouse.Server.Controllers;

/// <summary>
///     Controller for products table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IDbContextFactory<WarehouseDbContext> _contextFactory;
    private readonly IMapper _mapper;

    /// <summary>
    ///     Constructor for ProductsController
    /// </summary>
    /// <param name="contextFactory"></param>
    /// <param name="logger"></param>
    /// <param name="mapper"></param>
    public ProductsController(IDbContextFactory<WarehouseDbContext> contextFactory, ILogger<ProductsController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }
    /// <summary>
    ///     Get method for products table
    /// </summary>
    /// <returns>
    ///     Return all products
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<ProductsGetDto>> Get()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get products");
        return _mapper.Map<IEnumerable<ProductsGetDto>>(await ctx.Products.ToListAsync());
    }
    /// <summary>
    ///     Get by id method for products table
    /// </summary>
    /// <returns>
    ///     Return products with specified id
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductsGetDto>> Get(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Get products with id {id}");
        var product = ctx.Products.FirstOrDefault(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation($"Not found product with id {id}");
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<ProductsGetDto>(product));
        }
    }
    /// <summary>
    ///     Post method for products table
    /// </summary>
    /// <param name="product"> products class instance to insert to table </param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProductsPostDto product)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Post product");
        await ctx.Products.AddAsync(_mapper.Map<Products>(product));
        await ctx.SaveChangesAsync();
        return Ok();
    }
    /// <summary>
    ///     Put method for products table
    /// </summary>
    /// <param name="id"> An id of product which would be changed </param>
    /// <param name="productToPut"> products class instance to insert to table </param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ProductsPostDto productToPut)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Put product with id {0}", id);
        var product = ctx.Products.FirstOrDefault(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation("Not found product with id {0}", id);
            return NotFound();
        }
        else
        {
            ctx.Update(_mapper.Map(productToPut, product));
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    ///     Delete method 
    /// </summary>
    /// <param name="id"> An id of product which would be deleted </param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Put product with id ({id})");
        var product = ctx.Products.FirstOrDefault(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation($"Not found product with id ({id})");
            return NotFound();
        }
        else
        {
            ctx.Products.Remove(product);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}