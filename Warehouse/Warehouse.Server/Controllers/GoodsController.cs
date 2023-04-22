using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain;
using Warehouse.Server.Dto;
using Warehouse.Server.Repository;

namespace Warehouse.Server.Controllers;

/// <summary>
///     Controller for goods table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class GoodsController : ControllerBase
{
    private readonly ILogger<GoodsController> _logger;
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IDbContextFactory<WarehouseContext> _contextFactory;
    private readonly IMapper _mapper;

    /// <summary>
    ///     Constructor for GoodsController
    /// </summary>
    /// <param name="contextFactory"></param>
    /// <param name="logger"></param>
    /// <param name="warehouseRepository"></param>
    /// <param name="mapper"></param>
    public GoodsController(IDbContextFactory<WarehouseContext> contextFactory, ILogger<GoodsController> logger, IWarehouseRepository warehouseRepository, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _warehouseRepository = warehouseRepository;
        _mapper = mapper;
    }
    /// <summary>
    ///     Get method for goods table
    /// </summary>
    /// <returns>
    ///     Return all goods
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<GoodsGetDto>> Get()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get goods");
        return _mapper.Map<IEnumerable<GoodsGetDto>>(await ctx.Products.ToListAsync());
    }
    /// <summary>
    ///     Get by id method for goods table
    /// </summary>
    /// <returns>
    ///     Return goods with specified id
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GoodsGetDto>> Get(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Get goods with id {id}");
        var product = ctx.Products.FirstOrDefault(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation($"Not found product with id {id}");
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<GoodsGetDto>(product));
        }
    }
    /// <summary>
    ///     Post method for goods table
    /// </summary>
    /// <param name="product"> Goods class instance to insert to table </param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] GoodsPostDto product)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Post product");
        await ctx.Products.AddAsync(_mapper.Map<Goods>(product));
        await ctx.SaveChangesAsync();
        return Ok();
    }
    /// <summary>
    ///     Put method for goods table
    /// </summary>
    /// <param name="id"> An id of product which would be changed </param>
    /// <param name="productToPut"> Goods class instance to insert to table </param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] GoodsPostDto productToPut)
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