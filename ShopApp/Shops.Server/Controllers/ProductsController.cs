using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shops.Domain;
using Shops.Server.Dto;

namespace Shops.Server.Controllers;
/// <summary>
/// Controller for products
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<ProductsController> _logger;
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
    public ProductsController(ILogger<ProductsController> logger, IDbContextFactory<ShopsContext> dbContextFactory, IMapper mapper)
    {
        _logger = logger;
        _dbContextFactory = dbContextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// Return list of product
    /// </summary>
    /// <returns>Ok(List of product)</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductGetDto>>> Get()
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        _logger.LogInformation("Get list of product");
        return Ok(_mapper.Map<IEnumerable<ProductGetDto>>(ctx.Products));
    }
    /// <summary>
    /// Return product by id
    /// </summary>
    /// <param name="id"> Product id</param>
    /// <returns>Ok (the product found by specified id) or NotFound</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductGetDto>> Get(int id)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        var product = await ctx.Products.FirstOrDefaultAsync(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation($"Not found product with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Product with id = {id}");
            return Ok(_mapper.Map<ProductGetDto>(product));
        }
    }
    /// <summary>
    /// Add new product in list of products
    /// </summary> обработать отсутствие груп айди
    /// <param name="product"> New product</param>
    /// <returns>Ok(add new product) </returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProductPostDto product)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();
        var foundProductGroup = await ctx.ProductGroups.FirstOrDefaultAsync(fProductGroup => fProductGroup.Id == product.ProductGroupId);
        if (foundProductGroup == null)
            return NotFound();
        var newId = ctx.Products
            .Select(product => product.Id)
            .DefaultIfEmpty()
            .Max() + 1;
        var newProduct = _mapper.Map<Product>(product);
        newProduct.Id = newId;
        await ctx.Products.AddAsync(newProduct);
        await ctx.SaveChangesAsync();
        _logger.LogInformation($"Post product, id = {newId}");
        return Ok();
    }
    /// <summary>
    /// Updates product information
    /// </summary>
    /// <param name="id">Product id</param>
    /// <param name="productToPut">New information</param>
    /// <returns>Ok (update product by id) or NotFound</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ProductPostDto productToPut)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();
        var foundProductGroup = await ctx.ProductGroups.FirstOrDefaultAsync(fProductGroup => fProductGroup.Id == productToPut.ProductGroupId);
        if (foundProductGroup == null)
            return NotFound();
        var product = await ctx.Products.FirstOrDefaultAsync(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation($"Not found product with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Update information product with id = {id}");
            _mapper.Map<ProductPostDto, Product>(productToPut, product);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Update storage limit date product
    /// </summary>
    /// <param name="id">Product id</param>
    /// <param name="newDateLimit">New storage limit date</param>
    /// <returns>Ok (update  limit date product by id) or NotFound</returns>
    [HttpPut("{id}, update-limit-date")]
    public async Task<IActionResult> PutDate(int id, [FromBody] DateTime newDateLimit)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        var product = await ctx.Products.FirstOrDefaultAsync(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation($"Not found product with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Update storage limit date product with id = {id}");
            product.StorageLimitDate = newDateLimit;
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Delete product by id
    /// </summary>
    /// <param name="id">Product id</param>
    /// <returns>Ok (delete product by id) or NotFound</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        var product = await ctx.Products.FirstOrDefaultAsync(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation($"Not found product with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Delete product with id = {id}");
            ctx.Products.Remove(product);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
