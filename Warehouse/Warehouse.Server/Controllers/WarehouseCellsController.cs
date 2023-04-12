using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Domain;
using Warehouse.Server.Dto;
using Warehouse.Server.Repository;

namespace Warehouse.Server.Controllers;
/// <summary>
/// Controller for warehouse cells table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class WarehouseCellsController : ControllerBase
{
    private readonly ILogger<WarehouseCellsController> _logger;
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IMapper _mapper;
    public WarehouseCellsController(ILogger<WarehouseCellsController> logger, IWarehouseRepository warehouseRepository, IMapper mapper)
    {
        _logger = logger;
        _warehouseRepository = warehouseRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Get method for warehouse cells table
    /// </summary>
    /// <returns>
    /// Return all warehouse cells
    /// </returns>
    [HttpGet]
    public IEnumerable<WarehouseCellsGetDto> Get()
    {
        _logger.LogInformation("Get cells");
        return _warehouseRepository.Cells.Select(cell => _mapper.Map<WarehouseCellsGetDto>(cell));
    }
    /// <summary>
    /// Get by id method for warehouse cells table
    /// </summary>
    /// <returns>
    /// Return cells with specified id
    /// </returns>
    [HttpGet("{id}")]
    public ActionResult<WarehouseCellsGetDto> Get(int id)
    {
        _logger.LogInformation($"Get cells with id {id}");
        var cell = _warehouseRepository.Cells.FirstOrDefault(cell => cell.CellNumber == id);
        if (cell == null)
        {
            _logger.LogInformation($"Not found cell with id {id}");
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<WarehouseCellsGetDto>(cell));
        }
    }
    /// <summary>
    /// Post method for warehouse cells table
    /// </summary>
    /// <param name="cell"> Warehouse cell class instance to insert to table</param>
    [HttpPost]
    public void Post([FromBody] WarehouseCellsPostDto cell)
    {
        _logger.LogInformation("Post cell");
        _warehouseRepository.Cells.Add(_mapper.Map<WarehouseCells>(cell));
    }
    /// <summary>
    /// Put method for warehouse cells table
    /// </summary>
    /// <param name="id">A number of cell which would be changed</param>
    /// <param name="cellToPut">Warehouse cells class instance to insert to table</param>
    /// <returns>Signalization of success or error</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] WarehouseCellsPostDto cellToPut)
    {
        _logger.LogInformation("Put cell with id {0}", id);
        var warehouseCell = _warehouseRepository.Cells.FirstOrDefault(cell => cell.CellNumber == id);
        if (warehouseCell == null)
        {
            _logger.LogInformation("Not found product with id {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(cellToPut, warehouseCell);
            return Ok();
        }
    }
    /// <summary>
    /// Delete method 
    /// </summary>
    /// <param name="id">A number of cell which would be deleted</param>
    /// <returns>Signalization of success or error</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation($"Put cell with id ({id})");
        var warehouseCell = _warehouseRepository.Cells.FirstOrDefault(cell => cell.CellNumber == id);
        if (warehouseCell == null)
        {
            _logger.LogInformation($"Not found cell with id ({id})");
            return NotFound();
        }
        else
        {
            _warehouseRepository.Cells.Remove(warehouseCell);
            return Ok();
        }
    }
}