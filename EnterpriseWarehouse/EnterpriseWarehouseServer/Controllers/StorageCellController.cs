using AutoMapper;
using Enterprise.Data;
using EnterpriseWarehouseServer.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseWarehouseServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StorageCellController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;

    private readonly EnterpriseWarehouseDbContext _context;

    private readonly IMapper _mapper;
    public StorageCellController(ILogger<ProductController> logger, EnterpriseWarehouseDbContext context, IMapper mapper)
    {
        _logger = logger;
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    ///     [HttpGet] - return all StorageCell
    /// </summary>
    /// /// <returns>List of Storage Cell</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StorageCellGetDto>>> Get()
    {
        _logger.LogInformation("Get storage cell.");
        if (_context.StorageCells != null)
            return await _mapper.ProjectTo<StorageCellGetDto>(_context.StorageCells.OrderBy(x => x.Number)).ToListAsync();
        else
            return NotFound();
    }

    /// <summary>
    ///     [HttpGet("{cellNumber}")] - return StorageCell with cellNumber
    /// </summary>
    /// <param Number = "cellNumber" >Number of the StorageCell to be view</param>
    /// <returns>Info of StorageCell</returns>
    [HttpGet("{cellNumber}")]
    public async Task<ActionResult<ActionResult<StorageCellGetDto?>>> Get(int cellNumber)
    {
        if (_context.StorageCells != null)
        {
            var storageCell = await _context.StorageCells.FirstOrDefaultAsync(cell => cell.Number == cellNumber);
            if (storageCell != null)
            {
                _logger.LogInformation("Get storage cell with {cellNumber}.", cellNumber);
                return Ok(_mapper.Map<StorageCellGetDto>(storageCell));
            }
            else
            {
                _logger.LogInformation("Not found storage cell with {cellNumber}.", cellNumber);
                return NotFound();
            }
        }
        else
        {
            _logger.LogInformation("Not found storage cell with {cellNumber}.", cellNumber);
            return NotFound();
        }
    }

    /// <summary>
    ///     [HttpPost] - add new StorageCell
    /// </summary>
    /// <param StorageCell>Add new product</param>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<int>> Post([FromBody] StorageCellPostDto storageCell)
    {
        if (_context.StorageCells != null)
        {
            if (_context.StorageCells.FirstOrDefaultAsync(cell => cell.Number == storageCell.Number) == null)
            {
                var mapperStorageCell = _mapper.Map<StorageCell>(storageCell);
                _context.Add(mapperStorageCell);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Post", storageCell.Number);
            }
            else
                return Problem("Such a cell already exists.");
        }
        else
            return Problem("Entity set 'EnterpriseWarehouseDbContext.Products is null.");
    }

    /// <summary>
    ///     HttpPut("{cellNumber}")] - update info of StorageCell with cellNumber
    /// </summary>
    /// <param Number="cellNumber">Number of the StorageCell to be update</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{cellNumber}")]
    public async Task<IActionResult> Put(int cellNumber, [FromBody] StorageCellPostDto storageCellToPut)
    {
        if (_context.StorageCells == null)
            return NotFound();
        var storageCellToModify = await _context.StorageCells.FirstOrDefaultAsync(cell => cell.Number == cellNumber);
        if (storageCellToModify == null)
        {
            _logger.LogInformation("Not found storage cell with {cellNumber}.", cellNumber);
            return NotFound();
        }
        else
        {
            _mapper.Map(storageCellToPut, storageCellToModify);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

    /// <summary>
    ///     [HttpDelete("{cellNumber}")] - delete StorageCell with cellNumber
    /// </summary>
    /// <param Number="cellNumber">Number of the StorageCell to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{cellNumber}")]
    public async Task<ActionResult> Delete(int cellNumber)
    {
        if (_context.StorageCells != null)
        {
            var storageCell = await _context.StorageCells.FirstOrDefaultAsync(cell => cell.Number == cellNumber);
            if (storageCell == null)
            {
                _logger.LogInformation("Not found storage cell with {cellNumber}.", cellNumber);
                return NotFound();
            }
            else
            {
                _logger.LogInformation("Delete storage cell with {cellNumber}.", cellNumber);
                _context.StorageCells.Remove(storageCell);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
        else
            return NoContent();
    }
}