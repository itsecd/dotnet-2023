using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shops.Domain;
using Shops.Server.Dto;

namespace Shops.Server.Controllers;
/// <summary>
/// Controller for product quantity  
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProductQuantityController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<ProductQuantityController> _logger;
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
    public ProductQuantityController(ILogger<ProductQuantityController> logger, IDbContextFactory<ShopsContext> dbContextFactory, IMapper mapper)
    {
        _logger = logger;
        _dbContextFactory = dbContextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// Return list of product quantity
    /// </summary>
    /// <returns>Ok(List of product in shops)</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductQuantityGetDto>>> Get()
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        _logger.LogInformation("Get list of product quantity");
        return Ok(_mapper.Map<IEnumerable<ProductQuantityGetDto>>(ctx.ProductQuantity));
    }
    /// <summary>
    /// Return product in shop
    /// </summary>
    /// <param name="id"> Record product quantity id</param>
    /// <returns>Ok (the shop found by specified id) or NotFound</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductQuantityGetDto>> Get(int id)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        var product = await ctx.ProductQuantity.FirstOrDefaultAsync(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation("Not record of product quantity with id = {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Record of product quantity with id = {id}", id);
            return Ok(_mapper.Map<ProductQuantityGetDto>(product));
        }
    }

    /// <summary>
    /// Add new product in shop
    /// </summary>
    /// <param name="product"> New product in shop</param>
    /// <returns>Ok(add new product in shop) </returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProductQuantityPostDto product)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        var foundProduct = await ctx.Products.FirstOrDefaultAsync(fProduct => fProduct.Id == product.ProductId);
        if (foundProduct == null)
            return NotFound();
        var foundShop = await ctx.Shops.FirstOrDefaultAsync(fShop => fShop.Id == product.ShopId);
        if (foundShop == null)
            return NotFound();

        var newId = ctx.ProductQuantity
            .Select(product => product.Id)
            .DefaultIfEmpty()
            .Max() + 1;
        var newProduct = _mapper.Map<ProductQuantity>(product);
        newProduct.Id = newId;
        await ctx.ProductQuantity.AddAsync(newProduct);
        await ctx.SaveChangesAsync();
        _logger.LogInformation("Post new record of product quantity, id = {newId}", newId);
        return Ok();
    }
    /// <summary>
    /// Updates quantity product in shop information
    /// </summary>
    /// <param name="id">Shop id</param>
    /// <param name="productToPut">New quantity</param>
    /// <returns>Ok (update quantity product in shop) or NotFound</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ProductQuantityPostDto productToPut)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        var foundProduct = await ctx.Products.FirstOrDefaultAsync(fProduct => fProduct.Id == productToPut.ProductId);
        if (foundProduct == null)
            return NotFound();
        var foundShop = await ctx.Shops.FirstOrDefaultAsync(fShop => fShop.Id == productToPut.ShopId);
        if (foundShop == null)
            return NotFound();

        var product = await ctx.ProductQuantity.FirstOrDefaultAsync(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation("Not found record of product quantity with id = {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Update information record of product quantity with id = {id}", id);
            _mapper.Map<ProductQuantityPostDto, ProductQuantity>(productToPut, product);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Delete record of product quantity in shop by id
    /// </summary>
    /// <param name="id">record of product quantity id</param>
    /// <returns>Ok (delete record of product quantity  by id) or NotFound</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        var product = await ctx.ProductQuantity.FirstOrDefaultAsync(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation("Not found record of product quantity with id = {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Delete record of product quantity with id = {id}", id);
            ctx.ProductQuantity.Remove(product);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
