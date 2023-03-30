using Factory.Domain;
using Factory.Server.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Factory.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SupplyController : ControllerBase
{
    private readonly ILogger<SupplyController> _logger;

    private readonly FactoryRepository _factoryRepository;

    public SupplyController(ILogger<SupplyController> logger, FactoryRepository factoryRepository)
    {
        _logger = logger;
        _factoryRepository = factoryRepository;
    }

    // GET: api/<SupplyController>
    [HttpGet]
    public IEnumerable<Supply> Get()
    {
        _logger.LogInformation("Get Supplies");
        return _factoryRepository.Supplies;
    }

    // GET api/<SupplyController>/5
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

    // POST api/<SupplyController>
    [HttpPost]
    public void Post([FromBody] SupplyPostDto supply)
    {
        _factoryRepository.Supplies.Add(new Supply()
        {
            EnterpriseID = supply.EnterpriseID,
            SupplierID = supply.SupplierID,
            Date = supply.Date,
            Quantity = supply.Quantity
        });
    }

    // PUT api/<SupplyController>/5
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
            supply.EnterpriseID = supplyToPut.EnterpriseID;
            supply.SupplierID = supplyToPut.SupplierID;
            supply.Date = supplyToPut.Date;
            supply.Quantity = supplyToPut.Quantity;
            return Ok();
        }
    }

    // DELETE api/<SupplyController>/5
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
