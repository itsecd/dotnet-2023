using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using StoreApp.Domain;
using StoreApp.Server.Dto;
using StoreApp.Server.Repository;

namespace StoreApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StoreController : ControllerBase
{
    private readonly IDbContextFactory<StoreAppContext> _contextFactory;
    private readonly ILogger<StoreController> _logger;
    private readonly IMapper _mapper;

    public StoreController(IDbContextFactory<StoreAppContext> contextFactory, ILogger<StoreController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// GET all stores
    /// </summary>
    /// <returns>
    /// JSON stores
    /// </returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<StoreGetDto>> Get()
    {
        _logger.LogInformation("Get stores");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var stores = await ctx.Stores.ToArrayAsync();
        return _mapper.Map<IEnumerable<StoreGetDto>>(stores);
    }

    /// <summary>
    /// GET store by ID
    /// </summary>
    /// <param name="storeId">
    /// ID
    /// </param>
    /// <returns>
    /// JSON store
    /// </returns>
    [HttpGet("{storeId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<StoreGetDto>> Get(int storeId)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var getStore = await ctx.Stores.FirstOrDefaultAsync(store => store.StoreId == storeId);
        if (getStore == null)
        {
            _logger.LogInformation($"Not found store with ID: {storeId}.");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"GET store with ID: {storeId}.");
            return Ok(_mapper.Map<StoreGetDto>(getStore));
        }

    }

    /// <summary>
    /// POST store
    /// </summary>
    /// <param name="storeToPost">
    /// Store
    /// </param>
    /// <returns>
    /// Code-200
    /// </returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Post([FromBody] StorePostDto storeToPost)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        await ctx.Stores.AddAsync(_mapper.Map<Store>(storeToPost));
        await ctx.SaveChangesAsync();
        _logger.LogInformation($"POST store ({storeToPost.StoreName},  {storeToPost.StoreAddress})");
        return Ok();
    }

    /// <summary>
    /// PUT store
    /// </summary>
    /// <param name="storeId">
    /// ID
    /// </param>
    /// <param name="storeToPut">
    /// Store
    /// </param>
    /// <returns>
    /// Code-200 or Code-404
    /// </returns>
    [HttpPut("{storeId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put(int storeId, [FromBody] StorePostDto storeToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var store = await ctx.Stores.FirstOrDefaultAsync(x => x.StoreId == storeId);
        if (store == null)
        {
            _logger.LogInformation($"Not found store with ID: {storeId}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"PUT store with ID: {storeId} ({store.StoreName}->{storeToPut.StoreName}, {store.StoreAddress}->{storeToPut.StoreAddress})");
            _mapper.Map(storeToPut, store);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// DELETE store
    /// </summary>
    /// <param name="storeId">
    /// ID
    /// </param>
    /// <returns>
    /// Code-200 or Code-404
    /// </returns>
    [HttpDelete("{storeId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int storeId)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var store = await ctx.Stores.FirstOrDefaultAsync(x => x.StoreId == storeId);
        if (store == null)
        {
            _logger.LogInformation($"Not found store with ID: {storeId}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"DELETE store with ID: {storeId}");
            ctx.Stores.Remove(store);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
