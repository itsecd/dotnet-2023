using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Domain;
using StoreApp.Server.Dto;
using StoreApp.Server.Repository;

namespace StoreApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{

    private readonly ILogger<CustomerController> _logger;
    private readonly IStoreAppRepository _storeAppRepository;
    private readonly IMapper _mapper;

    public CustomerController(ILogger<CustomerController> logger, IStoreAppRepository storeAppRepository, IMapper mapper)
    {
        _logger = logger;
        _storeAppRepository = storeAppRepository;
        _mapper = mapper;
    }


    [HttpGet]
    public IEnumerable<CustomerGetDto> Get()
    {
        _logger.LogInformation("Get customers");
        return _storeAppRepository.Customers.Select(customer => _mapper.Map<CustomerGetDto>(customer));
    }

    [HttpGet("{id}")]
    public ActionResult<CustomerGetDto> Get(int id)
    {
        var getCustomer = _storeAppRepository.Customers.FirstOrDefault(customer => customer.CustomerId == id);
        if (getCustomer == null)
        {
            _logger.LogInformation($"Not found customer with ID: {id}.");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"GET customer with ID: {id}.");
            return Ok(_mapper.Map<CustomerGetDto>(getCustomer));
        }

    }

    [HttpPost]
    public ActionResult Post([FromBody] CustomerPostDto customerToPost)
    {
        _storeAppRepository.Customers.Add(_mapper.Map<Customer>(customerToPost));
        _logger.LogInformation($"POST customer ({customerToPost.CustomerName}, {customerToPost.CustomerCardNumber})");
        return Ok();
    }

    [HttpPut]
    public ActionResult Put(int id, [FromBody] CustomerPostDto cusomerToPut)
    {
        var customer = _storeAppRepository.Customers.FirstOrDefault(x => x.CustomerId == id);
        if (customer == null)
        {
            _logger.LogInformation($"Not found customer with ID: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"PUT customer with ID: {id} ({customer.CustomerName}->{cusomerToPut.CustomerName}, {customer.CustomerCardNumber}->{cusomerToPut.CustomerCardNumber})");
            _mapper.Map(cusomerToPut, customer);
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var customer = _storeAppRepository.Customers.FirstOrDefault(x => x.CustomerId == id);
        if (customer == null)
        {
            _logger.LogInformation($"Not found customer with ID: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"DELETE customer with ID: {id}");
            _storeAppRepository.Customers.Remove(customer);
            return Ok();
        }
    }


}
