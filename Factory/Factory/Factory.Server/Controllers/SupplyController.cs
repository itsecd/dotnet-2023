using AutoMapper;
using Factory.Domain;
using Factory.Server.Dto;
using Factory.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Factory.Server.Controllers;

/// <summary>
/// Supply controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SupplyController : ControllerBase
{
    private readonly ILogger<SupplyController> _logger;

    private readonly IFactoryRepository _factoryRepository;

    private readonly IMapper _mapper;

    public SupplyController(ILogger<SupplyController> logger, IFactoryRepository factoryRepository, IMapper mapper)
    {
        _logger = logger;
        _factoryRepository = factoryRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get supplies
    /// </summary>
    /// <returns>supplies</returns>
    [HttpGet]
    public IEnumerable<Supply> Get()
    {
        _logger.LogInformation("Get Supplies");
        return _factoryRepository.Supplies;
    }

    /// <summary>
    /// Get supply by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>supply</returns>
    [HttpGet("{id}")]
    public ActionResult<Supply> Get(int id)
    {
        var supply = _factoryRepository.Supplies.FirstOrDefault(supply => supply.SupplyID == id);
        if (supply == null)
        {
            _logger.LogInformation($"Not found supply: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get supply with id {id}");
            return Ok(supply);
        }
    }

    /// <summary>
    /// Post supply
    /// </summary>
    /// <param name="supply"></param>
    [HttpPost]
    public void Post([FromBody] SupplyPostDto supply)
    {
        _factoryRepository.Supplies.Add(_mapper.Map<Supply>(supply));
    }

    /// <summary>
    /// Put supply by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="supplyToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] SupplyPostDto supplyToPut)
    {
        var supply = _factoryRepository.Supplies.FirstOrDefault(supply => supply.SupplyID == id);
        if (supply == null)
        {
            _logger.LogInformation($"Not found supply: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put supplier with id {id}");
            _mapper.Map(supplyToPut, supply);
            return Ok();
        }
    }

    /// <summary>
    /// Delete supply by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var supply = _factoryRepository.Supplies.FirstOrDefault(supply => supply.SupplyID == id);
        if (supply == null)
        {
            _logger.LogInformation($"Not found supplier: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get supplier with id {id}");
            _factoryRepository.Supplies.Remove(supply);
            return Ok();
        }
    }
}
