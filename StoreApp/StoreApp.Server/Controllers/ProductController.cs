using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Domain;
using StoreApp.Server.Dto;
using StoreApp.Server.Repository;

namespace StoreApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IDbContextFactory<StoreAppContext> _contextFactory;
    private readonly ILogger<ProductController> _logger;
    private readonly IMapper _mapper;

    public ProductController(IDbContextFactory<StoreAppContext> contextFactory, ILogger<ProductController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;  
        _mapper = mapper;
    }

    /// <summary>
    /// GET all products
    /// </summary>
    /// <returns>
    /// JSON products
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<ProductGetDto>> Get()
    {
        _logger.LogInformation("GET products");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var products = await ctx.Products.ToArrayAsync();
        return _mapper.Map<IEnumerable<ProductGetDto>>(products);
    }

    /// <summary>
    /// GET product by ID
    /// </summary>
    /// <param name="productId">
    /// ID
    /// </param>
    /// <returns>
    /// JSON product
    /// </returns>
    [HttpGet("{productId}")]
    public async Task<ActionResult<ProductGetDto>> Get(int productId)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var getProduct = await ctx.Products.FirstOrDefaultAsync(product => product.ProductId == productId);
        if (getProduct == null)
        {
            _logger.LogInformation($"Not found product with ID: {productId}.");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"GET product with ID: {productId}.");
            return Ok(_mapper.Map<ProductGetDto>(getProduct));
        }

    }

    /// <summary>
    /// POST product
    /// </summary>
    /// <param name="productToPost">
    /// Product
    /// </param>
    /// <returns>
    /// Code-200
    /// </returns>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProductPostDto productToPost)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        await ctx.Products.AddAsync(_mapper.Map<Product>(productToPost));
        await ctx.SaveChangesAsync();
        _logger.LogInformation($"POST product ({productToPost.ProductGroup}, {productToPost.ProductName}, {productToPost.ProductWeight}, {productToPost.ProductType}, {productToPost.ProductPrice}, {productToPost.DateStorage})");
        return Ok();
    }

    /// <summary>
    /// PUT product
    /// </summary>
    /// <param name="productId">
    /// ID
    /// </param>
    /// <param name="productToPut">
    /// Product to put
    /// </param>
    /// <returns>
    /// Code-200 or Code-404
    /// </returns>
    [HttpPut("{productId}")]
    public async Task<ActionResult> Put(int productId, [FromBody] ProductPostDto productToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var product = await ctx.Products.FirstOrDefaultAsync(productToDelete => productToDelete.ProductId == productId);
        if (product == null)
        {
            _logger.LogInformation($"Not found product with ID: {productId}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"PUT product with ID: {productId} ({product.ProductName}->{productToPut.ProductName}, {product.ProductPrice}->{productToPut.ProductPrice})");
            _mapper.Map(productToPut, product);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// DELETE product
    /// </summary>
    /// <param name="productId">
    /// ID
    /// </param>
    /// <returns>
    /// Code-200 or Code-404
    /// </returns>
    [HttpDelete("{productId}")]
    public async Task<IActionResult> Delete(int productId)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var product = await ctx.Products.FirstOrDefaultAsync(productToDelete => productToDelete.ProductId == productId);
        if (product == null)
        {
            _logger.LogInformation($"Not found product with ID: {productId}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"DELETE product with ID: {productId}");
            ctx.Products.Remove(product);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
