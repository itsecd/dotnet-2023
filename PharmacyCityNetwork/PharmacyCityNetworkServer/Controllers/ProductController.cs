using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyCityNetwork.Server.Dto;

namespace PharmacyCityNetwork.Server.Controllers;

/// <summary>
/// Product controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IDbContextFactory<PharmacyCityNetworkDbContext> _contextFactory;
    private readonly IMapper _mapper;
    public ProductController(ILogger<ProductController> logger, IDbContextFactory<PharmacyCityNetworkDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// Get info about all products
    /// </summary>
    /// <returns>Return all products</returns>
    [HttpGet]
    public async Task<IEnumerable<ProductGetDto>> GetProducts()
    {
        _logger.LogInformation("Get all products");
        var ctx = await _contextFactory.CreateDbContextAsync();
        var products = await ctx.Products.ToArrayAsync();
        return _mapper.Map<IEnumerable<ProductGetDto>>(products);
    }
    /// <summary>
    /// Get product info by id
    /// </summary>
    /// <param name="idProduct">Product Id</param>
    /// <returns>Return product with specified id</returns>
    [HttpGet("{idProduct}")]
    public async Task<ActionResult<ProductGetDto>> GetProduct(int idProduct)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var product = await ctx.Products.FirstOrDefaultAsync(product => product.Id == idProduct);
        if (product == null)
        {
            _logger.LogInformation("Not found product : {idProduct}", idProduct);
            return NotFound($"The product does't exist by this id {idProduct}");
        }
        else
        {
            _logger.LogInformation("Not found product : {idProduct}", idProduct);
            return Ok(_mapper.Map<ProductGetDto>(product));
        }
    }
    /// <summary>
    /// Post a new product
    /// </summary>
    /// <param name="product">Product class instance to insert to table</param>
    [HttpPost]
    public async Task PostProduct([FromBody] ProductPostDto product)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Create new product");
        await ctx.Products.AddAsync(_mapper.Map<Product>(product));
        await ctx.SaveChangesAsync();
    }
    /// <summary>
    /// Put product
    /// </summary>
    /// <param name="idProduct">An id of product which would be changed</param>
    /// <param name="productToPut">Product class instance to insert to table</param>
    /// <returns>Signalization of success of error</returns>
    [HttpPut("{idProduct}")]
    public async Task<IActionResult> PutProduct(int idProduct, [FromBody] ProductPostDto productToPut)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var product = await ctx.Products.FirstOrDefaultAsync(product => product.Id == idProduct);
        if (product == null)
        {
            _logger.LogInformation("Not found product : {idProduct}", idProduct);
            return NotFound($"The product does't exist by this id {idProduct}");
        }
        else
        {
            _logger.LogInformation("Update product by id {idProduct}", idProduct);
            _mapper.Map(productToPut, product);
            ctx.Products.Update(_mapper.Map<Product>(product));
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Delete a product
    /// </summary>
    /// <param name="idProduct">An id of product which would be deleted</param>
    /// <returns>Signalization of success of error</returns>
    [HttpDelete("{idProduct}")]
    public async Task<IActionResult> DeleteProduct(int idProduct)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var product = await ctx.Products.Include(product => product.ProductPharmacys)
                                        .FirstOrDefaultAsync(product => product.Id == idProduct);
        if (product == null)
        {
            _logger.LogInformation("Not found product: {idProduct}", idProduct);
            return NotFound($"The product does't exist by this id {idProduct}");
        }
        else
        {
            _logger.LogInformation("Delete product by id {idProduct}", idProduct);
            ctx.Products.Remove(product);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}