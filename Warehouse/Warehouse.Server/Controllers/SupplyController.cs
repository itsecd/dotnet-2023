using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Domain;
using Warehouse.Server.Dto;
using Warehouse.Server.Repository;

namespace Warehouse.Server.Controllers;
/// <summary>
/// Controller for supply table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SupplyController : ControllerBase
{
    private readonly ILogger<SupplyController> _logger;
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IMapper _mapper;
    public SupplyController(ILogger<SupplyController> logger, IWarehouseRepository warehouseRepository, IMapper mapper)
    {
        _logger = logger;
        _warehouseRepository = warehouseRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Get method for supply table
    /// </summary>
    /// <returns>
    /// Return all supplies
    /// </returns>
    [HttpGet]
    public IEnumerable<SupplyGetDto> Get()
    {
        _logger.LogInformation("Get supplies");
        return _warehouseRepository.Supply.Select(supply => _mapper.Map<SupplyGetDto>(supply));
    }
    /// <summary>
    /// Get by id method for supply table
    /// </summary>
    /// <returns>
    /// Return supplies with specified product id
    /// </returns>
    [HttpGet("{id}")]
    public ActionResult<SupplyGetDto> Get(int id)
    {
        _logger.LogInformation($"Get supplies with product id {id}");
        var product = _warehouseRepository.Goods.FirstOrDefault(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation($"Not found product with id {id}");
            return NotFound();
        }
        else
        {
            return Ok((from goods in _warehouseRepository.Goods
                       where goods.Id == id
                       from supply in goods.Supply
                       select _mapper.Map<Supply>(supply)).ToList());
        }
    }
    /// <summary>
    /// Post method for supply table
    /// </summary>
    /// <param name="supply"> Supply class instance to insert to table</param>
    [HttpPost]
    public void Post([FromBody] SupplyPostDto supply)
    {
        _logger.LogInformation("Post supply");
        _warehouseRepository.Supply.Add(_mapper.Map<Supply>(supply));
    }
    /// <summary>
    /// Put method for supply table
    /// </summary>
    /// <param name="id">An id of product of supply which would be changed </param>
    /// <param name="supplyToPut">Supply class instance to insert to table</param>
    /// <returns>Signalization of success or error</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] SupplyPostDto supplyToPut)
    {
        _logger.LogInformation("Put product with id {0}", id);
        var product = _warehouseRepository.Goods.FirstOrDefault(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation("Not found product with id {0}", id);
            return NotFound();
        }
        else
        {
            _warehouseRepository.Supply.Remove(from goods in _warehouseRepository.Goods
                                               from supply in goods.Supply
                                               where supply.Goods = product
                                               select supply));
            _mapper.Map(supplyToPut.Goods, product);
            return Ok();
        }
    }
    /// <summary>
    /// Delete method 
    /// </summary>
    /// <param name="id">An id of product of supply which would be deleted</param>
    /// <returns>Signalization of success or error</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation($"Put product with id ({id})");
        var product = _warehouseRepository.Goods.FirstOrDefault(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation($"Not found product with id ({id})");
            return NotFound();
        }
        else
        {
            _warehouseRepository.Supply.Remove(from goods in _warehouseRepository.Goods
                                               from supply in goods.Supply
                                               where supply.Goods = product
                                               select supply);
            return Ok();
        }
    }
}