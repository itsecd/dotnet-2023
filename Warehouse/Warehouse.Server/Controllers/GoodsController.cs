using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Domain;
using Warehouse.Server.Dto;
using Warehouse.Server.Repository;

namespace Warehouse.Server.Controllers;
/// <summary>
/// Controller for goods table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class GoodsController : ControllerBase
{
    private readonly ILogger<GoodsController> _logger;
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IMapper _mapper;
    public GoodsController(ILogger<GoodsController> logger, IWarehouseRepository warehouseRepository, IMapper mapper)
    {
        _logger = logger;
        _warehouseRepository = warehouseRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Get method for goods table
    /// </summary>
    /// <returns>
    /// Return all goods
    /// </returns>
    [HttpGet]
    public IEnumerable<GoodsGetDto> Get()
    {
        _logger.LogInformation("Get goods");
        return _warehouseRepository.Goods.Select(product => _mapper.Map<GoodsGetDto>(product));
    }
    /// <summary>
    /// Get by id method for goods table
    /// </summary>
    /// <returns>
    /// Return goods with specified id
    /// </returns>
    [HttpGet("{id}")]
    public ActionResult<GoodsGetDto> Get(int id)
    {
        _logger.LogInformation($"Get goods with id {id}");
        var product = _warehouseRepository.Goods.FirstOrDefault(product => product.Id == id);
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
    /// Post method for goods table
    /// </summary>
    /// <param name="product"> Goods class instance to insert to table</param>
    [HttpPost]
    public void Post([FromBody] GoodsPostDto product)
    {
        _logger.LogInformation("Post product");
        _warehouseRepository.Goods.Add(_mapper.Map<Goods>(product));
    }
    /// <summary>
    /// Put method for goods table
    /// </summary>
    /// <param name="id">An id of product which would be changed </param>
    /// <param name="productToPut">Goods class instance to insert to table</param>
    /// <returns>Signalization of success or error</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] GoodsPostDto productToPut)
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
            _mapper.Map(productToPut, product);
            return Ok();
        }
    }
    /// <summary>
    /// Delete method 
    /// </summary>
    /// <param name="id">An id of product which would be deleted</param>
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
            _warehouseRepository.Goods.Remove(product);
            return Ok();
        }
    }
}