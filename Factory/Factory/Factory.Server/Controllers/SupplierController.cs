using AutoMapper;
using Factory.Domain;
using Factory.Server.Dto;
using Factory.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Factory.Server.Controllers;

/// <summary>
/// Supplier controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SupplierController : ControllerBase
{
    private readonly ILogger<SupplierController> _logger;

    private readonly IFactoryRepository _factoryRepository;

    private readonly IMapper _mapper;

    public SupplierController(ILogger<SupplierController> logger, IFactoryRepository factoryRepository, IMapper mapper)
    {
        _logger = logger;
        _factoryRepository = factoryRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get suppliers
    /// </summary>
    /// <returns>suppliers</returns>
    [HttpGet]
    public IEnumerable<SupplierGetDto> Get()
    {
        _logger.LogInformation("Get Suppliers");
        return _factoryRepository.Suppliers.Select(supplier =>
            _mapper.Map<SupplierGetDto>(supplier));
    }

    /// <summary>
    /// Get supplier by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>supplier</returns>
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
            return Ok(_mapper.Map<SupplierGetDto>(supplier));
        }
    }

    /// <summary>
    /// Post supplier
    /// </summary>
    /// <param name="supplier"></param>
    [HttpPost]
    public void Post([FromBody] SupplierPostDto supplier)
    {
        _factoryRepository.Suppliers.Add(_mapper.Map<Supplier>(supplier));
    }

    /// <summary>
    /// Put supplier by ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="supplierToPut"></param>
    /// <returns></returns>
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
            _mapper.Map(supplierToPut, supplier);
            return Ok();
        }
    }

    /// <summary>
    /// Delete supplier by ID/5
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
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
