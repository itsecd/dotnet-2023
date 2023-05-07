using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Model;
using StoreApp.Server.Dto;

namespace StoreApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductStoreController : ControllerBase
{
    private readonly IDbContextFactory<StoreAppContext> _contextFactory;
    private readonly ILogger<ProductStoreController> _logger;
    private readonly IMapper _mapper;

    public ProductStoreController(IDbContextFactory<StoreAppContext> contextFactory, ILogger<ProductStoreController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// GET all ProductStore
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<ProductStoreGetDto>> Get()
    {
        _logger.LogInformation("GET productStores");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var productStores = await ctx.ProductStores.ToArrayAsync();
        return _mapper.Map<IEnumerable<ProductStoreGetDto>>(productStores);
    }

    /// <summary>
    /// GET by ID
    /// </summary>
    /// <param name="id">
    /// ID
    /// </param>
    /// <returns>
    /// JSON ProductStore
    /// </returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductStoreGetDto>> Get(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var getProductStore = await ctx.ProductStores.FirstOrDefaultAsync(productStore => productStore.Id == id);
        if (getProductStore == null)
        {
            _logger.LogInformation($"Not found productStore with ID: {id}.");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"GET productStore with ID: {id}.");
            return Ok(_mapper.Map<ProductStoreGetDto>(getProductStore));
        }

    }


    /// <summary>
    /// GET product in all stores by ID product
    /// </summary>
    /// <param name="productId">
    /// ID product
    /// </param>
    /// <returns>
    /// JSON ProductStore
    /// </returns>
    [HttpGet("{productId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductStoreGetDto>> GetByProduct(int productId)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var getProductStore = await ctx.ProductStores.FirstOrDefaultAsync(productStore => productStore.ProductId == productId);
        if (getProductStore == null)
        {
            _logger.LogInformation($"Not found productStore with ID: {productId}.");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"GET productStore with ID: {productId}.");
            return Ok(_mapper.Map<ProductStoreGetDto>(getProductStore));
        }

    }

    /// <summary>
    /// GET all products in by ID store
    /// </summary>
    /// <param name="storeId">
    /// ID store
    /// </param>
    /// <returns>
    /// JSON ProductStore
    /// </returns>
    [HttpGet("{storeId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductStoreGetDto>> GetByStore(int storeId)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var getProductStore = await ctx.ProductStores.FirstOrDefaultAsync(productStore => productStore.StoreId == storeId);
        if (getProductStore == null)
        {
            _logger.LogInformation($"Not found productStore with ID: {storeId}.");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"GET productStore with ID: {storeId}.");
            return Ok(_mapper.Map<ProductStoreGetDto>(getProductStore));
        }

    }

    /// <summary>
    /// POST ProductStore
    /// </summary>
    /// <param name="productStoreToPost">
    /// ProductStore
    /// </param>
    /// <returns>
    /// Code-200
    /// </returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Post([FromBody] ProductStorePostDto productStoreToPost)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        await ctx.ProductStores.AddAsync(_mapper.Map<ProductStore>(productStoreToPost));
        await ctx.SaveChangesAsync();
        _logger.LogInformation($"POST productStore ({productStoreToPost.ProductId}, {productStoreToPost.StoreId}, {productStoreToPost.Quantity})");
        return Ok();
    }

    /// <summary>
    /// PUT ProductStore
    /// </summary>
    /// <param name="id">
    /// ID
    /// </param>
    /// <param name="productStoreToPut">
    /// ProductStore
    /// </param>
    /// <returns>
    /// Code-200 or Code-404
    /// </returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put(int id, [FromBody] ProductStorePostDto productStoreToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var productStore = await ctx.ProductStores.FirstOrDefaultAsync(productStoreId => productStoreId.Id == id);
        if (productStore == null)
        {
            _logger.LogInformation($"Not found productStore with ID: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"PUT productStore with ID: {id} ({productStore.ProductId}->{productStoreToPut.ProductId}, {productStore.StoreId}->{productStoreToPut.StoreId}, {productStore.Quantity}->{productStoreToPut.Quantity})");
            _mapper.Map(productStoreToPut, productStore);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// DELETE ProductStore
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
        var productStore = await ctx.ProductStores.FirstOrDefaultAsync(productStoreId => productStoreId.Id == id);
        if (productStore == null)
        {
            _logger.LogInformation($"Not found productStore with ID: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"DELETE productStore with ID: {id}");
            ctx.ProductStores.Remove(productStore);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
