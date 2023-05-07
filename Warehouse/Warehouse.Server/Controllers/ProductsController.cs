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
    public async Task<IEnumerable<ProductsGetDto>> GetProducts()
    {
        _logger.LogInformation("Get all products");
        var ctx = await _contextFactory.CreateDbContextAsync();
        var products = await ctx.Products.ToListAsync();
        return _mapper.Map<IEnumerable<ProductsGetDto>>(products);
    }
    /// <summary>
    ///     Get by id method for products table
    /// </summary>
    /// <param name="id"> Product id </param>
    /// <returns>
    ///     Return products with specified id
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductsGetDto>> GetProduct(int id)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var product = await ctx.Products.FirstOrDefaultAsync(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation("Not found product with id: {id}", id);
            return NotFound($"Product doesn`t exist by this id: {id}");
        }
        else
        {
            _logger.LogInformation("Get products with id: {id}", id);
            return Ok(_mapper.Map<ProductsGetDto>(product));
        }
    }
    /// <summary>
    ///     Post method for products table
    /// </summary>
    /// <param name="product"> Products class instance to insert to table </param>
    /// <returns>
    ///     Create product
    /// </returns>
    [HttpPost]
    public async Task PostProduct([FromBody] ProductsPostDto product)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Create new product");
        await ctx.Products.AddAsync(_mapper.Map<Products>(product));
        await ctx.SaveChangesAsync();
    }
    /// <summary>
    ///     Put method for products table
    /// </summary>
    /// <param name="id"> An id of product which would be changed </param>
    /// <param name="productToPut"> Products class instance to insert to table </param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ProductsPostDto productToPut)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var product = await ctx.Products.FirstOrDefaultAsync(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation("Not found product with id: {id}", id);
            return NotFound($"Product doesn`t exist by this id: {id}");
        }
        else
        {
            _logger.LogInformation("Update product with id: {id}", id);
            _mapper.Map(productToPut, product);
            ctx.Products.Update(_mapper.Map<Products>(product));
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
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var product = await ctx.Products.FirstOrDefaultAsync(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation("Not found product with id: {id}", id);
            return NotFound($"Product doesn`t exist by this id: {id}");
        }
        else
        {
            _logger.LogInformation("Delete product with id: {id}", id);
            ctx.Products.Remove(product);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}