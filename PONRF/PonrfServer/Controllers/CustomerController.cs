using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PonrfDomain;
using PonrfServer.Dto;
using PonrfServer.Repository;

namespace PonrfServer.Controllers;
/// <summary>
/// Customer controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;

    private readonly IPonrfRepository _ponrfRepository;

    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for CustomerController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="ponrfRepository"></param>
    /// <param name="mapper"></param>
    public CustomerController(ILogger<CustomerController> logger, IPonrfRepository ponrfRepository, IMapper mapper)
    {
        _logger = logger;
        _ponrfRepository = ponrfRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get information about all customers
    /// </summary>
    /// <returns>List of customers</returns>
    [HttpGet]
    public IEnumerable<CustomerGetDto> Get()
    {
        _logger.LogInformation("Get information about all customers");
        return _mapper.Map<IEnumerable<CustomerGetDto>>(_ponrfRepository.Customers);
    }

    /// <summary>
    /// Get a customer by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Customer</returns>
    [HttpGet("{id}")]
    public ActionResult<CustomerGetDto?> Get(int id)
    {
        var customer = _ponrfRepository.Customers.FirstOrDefault(customer => customer.Id == id);
        if (customer == null)
        {
            _logger.LogInformation($"Not found customer with {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get a customer");
            return Ok(_mapper.Map<CustomerGetDto>(customer));
        }
    }

    /// <summary>
    /// Post a new customer
    /// </summary>
    /// <param name="customer"></param>
    [HttpPost]
    public void Post([FromBody] CustomerPostDto customer)
    {
        _logger.LogInformation("Post a new customer");
        _ponrfRepository.Customers.Add(_mapper.Map<Customer>(customer));
    }

    /// <summary>
    /// Put a customer
    /// </summary>
    /// <param name="id"></param>
    /// <param name="customerToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] CustomerPostDto customerToPut)
    {
        var customer = _ponrfRepository.Customers.FirstOrDefault(customer => customer.Id == id);
        if (customer == null)
        {
            _logger.LogInformation($"Not found customer with {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(customerToPut, customer);
            _logger.LogInformation("Put a customer");
            return Ok();
        }
    }

    /// <summary>
    /// Delete a customer by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var customer = _ponrfRepository.Customers.FirstOrDefault(customer => customer.Id == id);
        if (customer == null)
        {
            _logger.LogInformation($"Not found customer with {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Delete an customer");
            _ponrfRepository.Customers.Remove(customer);
            return Ok();
        }
    }
}
