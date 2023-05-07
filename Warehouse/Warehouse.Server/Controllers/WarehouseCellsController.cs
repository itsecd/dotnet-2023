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
        _logger.LogInformation("Get all cells");
        var ctx = await _contextFactory.CreateDbContextAsync();
        var cells = await ctx.Cells.ToListAsync();
        return _mapper.Map<IEnumerable<WarehouseCellsDto>>(cells);
    }
    /// <summary>
    ///     Get by id method for warehouse cells table
    /// </summary>
    /// <param name="id"> Cell id </param>
    /// <returns>
    ///     Return cells with specified id
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<WarehouseCellsDto>> Get(int id)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var cell = await ctx.Cells.FirstOrDefaultAsync(cell => cell.CellNumber == id);
        if (cell == null)
        {
            _logger.LogInformation("Not found cell with id: {id}", id);
            return NotFound($"Cell doesn`t exist by this id: {id}");
        }
        else
        {
            _logger.LogInformation("Get cells with id: {id}", id);
            return Ok(_mapper.Map<WarehouseCellsDto>(cell));
        }
    }
    /// <summary>
    ///     Post method for warehouse cells table
    /// </summary>
    /// <param name="cell"> Warehouse cell class instance to insert to table </param>
    /// <returns>
    ///     Сreate cell
    /// </returns>
    [HttpPost]
    public async Task Post([FromBody] WarehouseCellsDto cell)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Create new cell");
        await ctx.Cells.AddAsync(_mapper.Map<WarehouseCells>(cell));
        await ctx.SaveChangesAsync();
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
        var ctx = await _contextFactory.CreateDbContextAsync();
        var warehouseCell = await ctx.Cells.FirstOrDefaultAsync(cell => cell.CellNumber == id);
        if (warehouseCell == null)
        {
            _logger.LogInformation("Not found product with id: {id}", id);
            return NotFound($"Cell doesn`t exist by this id: {id}");
        }
        else
        {
            _logger.LogInformation("Update cell with id {id}", id);
            _mapper.Map(cellToPut, warehouseCell);
            ctx.Cells.Update(_mapper.Map<WarehouseCells>(warehouseCell));
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
        var ctx = await _contextFactory.CreateDbContextAsync();
        var warehouseCell = await ctx.Cells.Include(cells => cells.Product)
                                           .FirstOrDefaultAsync(cell => cell.CellNumber == id);
        if (warehouseCell == null)
        {
            _logger.LogInformation("Not found cell with id: {id}", id);
            return NotFound($"Cell doesn`t exist by this id: {id}");
        }
        else
        {
            _logger.LogInformation("Delete cell with id {id}", id);
            ctx.Cells.Remove(warehouseCell);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}