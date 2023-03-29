using Microsoft.AspNetCore.Mvc;
using PonrfDomain;

namespace PonrfServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;

    private readonly PonrfRepository _ponrfRepository;

    public CustomerController(ILogger<CustomerController> logger, PonrfRepository ponrfRepository)
    {
        _logger = logger;
        _ponrfRepository = ponrfRepository;
    }


    [HttpGet]
    public IEnumerable<Customer> Get()
    {
        _logger.LogInformation("Get all customers");
        return _ponrfRepository.Customers;
    }

    [HttpGet("{id}")]
    public ActionResult<Customer?> Get(int id)
    {
        var customer = _ponrfRepository.Customers.FirstOrDefault(customer => customer.Id == id);
        if (customer == null)
        {
            _logger.LogInformation($"Not found customer with {id}");
            return NotFound();
        }
        else return Ok(customer);
    }

    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
