using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Domain;
using StoreApp.Server.Dto;
using StoreApp.Server.Repository;

namespace SaleApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductSaleController : ControllerBase
{
    private readonly IDbContextFactory<StoreAppContext> _contextFactory;
    private readonly ILogger<ProductSaleController> _logger;
    private readonly IMapper _mapper;

    public ProductSaleController(IDbContextFactory<StoreAppContext> contextFactory, ILogger<ProductSaleController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// GET all ProductSale
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<ProductSaleGetDto>> Get()
    {
        _logger.LogInformation("GET productSales");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var productSales = await ctx.ProductSales.ToArrayAsync();
        return _mapper.Map<IEnumerable<ProductSaleGetDto>>(productSales);
    }

    /// <summary>
    /// GET by ID
    /// </summary>
    /// <param name="id">
    /// ID
    /// </param>
    /// <returns>
    /// JSON ProductSale
    /// </returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductSaleGetDto>> Get(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var getProductSale = await ctx.ProductSales.FirstOrDefaultAsync(productSale => productSale.Id == id);
        if (getProductSale == null)
        {
            _logger.LogInformation($"Not found productSale with ID: {id}.");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"GET productSale with ID: {id}.");
            return Ok(_mapper.Map<ProductSaleGetDto>(getProductSale));
        }

    }

    /// <summary>
    /// GET product in all sales by ID product
    /// </summary>
    /// <param name="productId">
    /// ID product
    /// </param>
    /// <returns>
    /// JSON ProductSale
    /// </returns>
    [HttpGet("{productId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductSaleGetDto>> GetByProduct(int productId)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var getProductSale = await ctx.ProductSales.FirstOrDefaultAsync(productSale => productSale.ProductId == productId);
        if (getProductSale == null)
        {
            _logger.LogInformation($"Not found productSale with ID: {productId}.");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"GET productSale with ID: {productId}.");
            return Ok(_mapper.Map<ProductSaleGetDto>(getProductSale));
        }

    }

    /// <summary>
    /// GET all products in sale by ID sale
    /// </summary>
    /// <param name="saleId">
    /// ID sale
    /// </param>
    /// <returns>
    /// JSON ProductSale
    /// </returns>
    [HttpGet("{saleId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductSaleGetDto>> GetBySale(int saleId)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var getProductSale = await ctx.ProductSales.FirstOrDefaultAsync(productSale => productSale.SaleId == saleId);
        if (getProductSale == null)
        {
            _logger.LogInformation($"Not found productSale with ID: {saleId}.");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"GET productSale with ID: {saleId}.");
            return Ok(_mapper.Map<ProductSaleGetDto>(getProductSale));
        }

    }

    /// <summary>
    /// POST ProductSale
    /// </summary>
    /// <param name="productSaleToPost">
    /// ProductSale
    /// </param>
    /// <returns>
    /// Code-200
    /// </returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Post([FromBody] ProductSalePostDto productSaleToPost)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        await ctx.ProductSales.AddAsync(_mapper.Map<ProductSale>(productSaleToPost));
        await ctx.SaveChangesAsync();
        _logger.LogInformation($"POST productSale ({productSaleToPost.ProductId}, {productSaleToPost.SaleId}, {productSaleToPost.Quantity})");
        return Ok();
    }

    /// <summary>
    /// PUT ProductSale
    /// </summary>
    /// <param name="id">
    /// ID
    /// </param>
    /// <param name="productSaleToPut">
    /// ProductSale
    /// </param>
    /// <returns>
    /// Code-200 or Code-404
    /// </returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put(int id, [FromBody] ProductSalePostDto productSaleToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var productSale = await ctx.ProductSales.FirstOrDefaultAsync(productSaleId => productSaleId.Id == id);
        if (productSale == null)
        {
            _logger.LogInformation($"Not found productSale with ID: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"PUT productSale with ID: {id} ({productSale.ProductId}->{productSaleToPut.ProductId}, {productSale.SaleId}->{productSaleToPut.SaleId}, {productSale.Quantity}->{productSaleToPut.Quantity})");
            _mapper.Map(productSaleToPut, productSale);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// DELETE ProductSale
    /// </summary>
    /// <param name="id">
    /// ID
    /// </param>
    /// <returns>
    /// Code-200 or Code-404
    /// </returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var productSale = await ctx.ProductSales.FirstOrDefaultAsync(productSaleId => productSaleId.Id == id);
        if (productSale == null)
        {
            _logger.LogInformation($"Not found productSale with ID: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"DELETE productSale with ID: {id}");
            ctx.ProductSales.Remove(productSale);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
