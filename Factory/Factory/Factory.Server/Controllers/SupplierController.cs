using Factory.Domain;
using Factory.Server.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Factory.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SupplierController : ControllerBase
{
    private readonly ILogger<SupplierController> _logger;

    private readonly FactoryRepository _factoryRepository;

    public SupplierController(ILogger<SupplierController> logger, FactoryRepository factoryRepository)
    {
        _logger = logger;
        _factoryRepository = factoryRepository;
    }

    // GET: api/<SupplierController>
    [HttpGet]
    public IEnumerable<SupplierGetDto> Get()
    {
        _logger.LogInformation("Get Suppliers");
        return _factoryRepository.Suppliers.Select(supplier => 
            new SupplierGetDto
            {
                SupplierID = supplier.SupplierID,
                Name = supplier.Name,   
                Address = supplier.Address,
                Phone = supplier.Phone
            }
        );
    }

    // GET api/<SupplierController>/5
    [HttpGet("{id}")]
    public ActionResult<SupplierGetDto> Get(int id)
    {
        var supplier = _factoryRepository.Suppliers.FirstOrDefault(supplier => supplier.SupplierID == id);
        if (supplier == null)
        {
            _logger.LogInformation($"Not found supplier: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get supplier with id {id}");
            return Ok(new SupplierGetDto
            {
                SupplierID = supplier.SupplierID,
                Name = supplier.Name,
                Address = supplier.Address,
                Phone = supplier.Phone
            });
        }
    }

    // POST api/<SupplierController>
    [HttpPost]
    public void Post([FromBody] SupplierPostDto supplier)
    {
        _factoryRepository.Suppliers.Add(new Supplier() 
        {
            Name = supplier.Name,
            Address = supplier.Address,
            Phone = supplier.Phone
        });
    }

    // PUT api/<SupplierController>/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] SupplierPostDto supplierToPut)
    {
        var supplier = _factoryRepository.Suppliers.FirstOrDefault(supplier => supplier.SupplierID == id);
        if (supplier == null)
        {
            _logger.LogInformation($"Not found supplier: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put supplier with id {id}");
            supplier.Name = supplierToPut.Name;
            supplier.Address = supplierToPut.Address;
            supplier.Phone = supplierToPut.Phone;
            return Ok();
        }
    }

    // DELETE api/<SupplierController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var supplier = _factoryRepository.Suppliers.FirstOrDefault(supplier => supplier.SupplierID == id);
        if (supplier == null)
        {
            _logger.LogInformation($"Not found supplier: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get supplier with id {id}");
            _factoryRepository.Suppliers.Remove(supplier); 
            return Ok();
        }
    }
}
