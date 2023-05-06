using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain;
using Warehouse.Server.Dto;

namespace Warehouse.Server.Controllers;

/// <summary>
///     Controller for warehouse cells table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class WarehouseCellsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IDbContextFactory<WarehouseDbContext> _contextFactory;
    private readonly IMapper _mapper;

    /// <summary>
    ///     Constructor for GoodsController
    /// </summary>
    /// <param name="contextFactory"></param>
    /// <param name="logger"></param>
    /// <param name="warehouseRepository"></param>
    /// <param name="mapper"></param>
    public WarehouseCellsController(IDbContextFactory<WarehouseDbContext> contextFactory, ILogger<ProductsController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }
    /// <summary>
    ///     Get method for warehouse cells table
    /// </summary>
    /// <returns>
    ///     Return all warehouse cells
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<WarehouseCellsDto>> Get()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get cells");
        return _mapper.Map<IEnumerable<WarehouseCellsDto>>(await ctx.Cells.ToListAsync());
    }
    /// <summary>
    ///     Get by id method for warehouse cells table
    /// </summary>
    /// <returns>
    ///     Return cells with specified id
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<WarehouseCellsDto>> Get(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Get cells with id {id}");
        var cell = ctx.Cells.FirstOrDefault(cell => cell.CellNumber == id);
        if (cell == null)
        {
            _logger.LogInformation($"Not found cell with id {id}");
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<WarehouseCellsDto>(cell));
        }
    }
    /// <summary>
    ///     Post method for warehouse cells table
    /// </summary>
    /// <param name="cell"> Warehouse cell class instance to insert to table </param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] WarehouseCellsDto cell)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Post cell");
        await ctx.Cells.AddAsync(_mapper.Map<WarehouseCells>(cell));
        await ctx.SaveChangesAsync();
        return Ok();
    }
    /// <summary>
    ///     Put method for warehouse cells table
    /// </summary>
    /// <param name="id"> A number of cell which would be changed </param>
    /// <param name="cellToPut"> Warehouse cells class instance to insert to table </param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] WarehouseCellsDto cellToPut)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Put cell with id {0}", id);
        var warehouseCell = ctx.Cells.FirstOrDefault(cell => cell.CellNumber == id);
        if (warehouseCell == null)
        {
            _logger.LogInformation("Not found product with id {0}", id);
            return NotFound();
        }
        else
        {
            ctx.Update(_mapper.Map(cellToPut, warehouseCell));
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    ///     Delete method 
    /// </summary>
    /// <param name="id"> A number of cell which would be deleted </param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Put cell with id ({id})");
        var warehouseCell = ctx.Cells.FirstOrDefault(cell => cell.CellNumber == id);
        if (warehouseCell == null)
        {
            _logger.LogInformation($"Not found cell with id ({id})");
            return NotFound();
        }
        else
        {
            ctx.Cells.Remove(warehouseCell);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}