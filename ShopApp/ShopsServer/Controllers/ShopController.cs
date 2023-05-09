using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shops.Domain;
using Shops.Server.Dto;

namespace Shops.Server.Controllers;
/// <summary>
/// Controller for shops
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ShopController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<ShopController> _logger;
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
    public ShopController(ILogger<ShopController> logger, IDbContextFactory<ShopsContext> dbContextFactory, IMapper mapper)
    {
        _logger = logger;
        _dbContextFactory = dbContextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// Return list of shop
    /// </summary>
    /// <returns>Ok(list of shop)</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShopGetDto>>> Get()
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        _logger.LogInformation("Get list of shop");
        return Ok(_mapper.Map<IEnumerable<ShopGetDto>>(ctx.Shops));
    }
    /// <summary>
    /// Return shop by id
    /// </summary>
    /// <param name="id"> Shop id</param>
    /// <returns>Shop</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ShopGetDto>> Get(int id)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        var shop = await ctx.Shops.FirstOrDefaultAsync(shop => shop.Id == id);
        if (shop == null)
        {
            _logger.LogInformation("Not found shop with id = {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Shop with id = {id}", id);
            return Ok(_mapper.Map<ShopGetDto>(shop));
        }
    }
    /// <summary>
    /// Add new shop in list of shops
    /// </summary>
    /// <param name="shop"> New shop</param>
    /// <returns>Ok(add new shop) </returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ShopPostDto shop)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        var newId = ctx.Shops
           .Select(shop => shop.Id)
           .DefaultIfEmpty()
           .Max() + 1;
        var newShop = _mapper.Map<Shop>(shop);
        newShop.Id = newId;
        await ctx.Shops.AddAsync(newShop);
        await ctx.SaveChangesAsync();
        _logger.LogInformation("Post shop, id = {newId}", newId);
        return Ok();
    }
    /// <summary>
    /// Updates shop information
    /// </summary>
    /// <param name="id">Shop id</param>
    /// <param name="shopToPut">New information</param>
    /// <returns>Ok (update shop by id) or NotFound</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ShopPostDto shopToPut)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        var shop = await ctx.Shops.FirstOrDefaultAsync(shop => shop.Id == id);
        if (shop == null)
        {
            _logger.LogInformation("Not found shop with id = {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Update information shop with id = {id}", id);
            _mapper.Map<ShopPostDto, Shop>(shopToPut, shop);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Delete shop by id
    /// </summary>
    /// <param name="id">Shop id</param>
    /// <returns>Ok (delete shop by id) or NotFound</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        var shop = await ctx.Shops.FirstOrDefaultAsync(shop => shop.Id == id);
        if (shop == null)
        {
            _logger.LogInformation("Not found shop with id = {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Delete shop with id = {id}", id);
            ctx.Shops.Remove(shop);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
