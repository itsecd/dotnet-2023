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

    /// <summary>
    /// GET all customers
    /// </summary>
    /// <returns>
    /// JSON customers
    /// </returns>
    [HttpGet]
    public IEnumerable<CustomerGetDto> Get()
    {
        _logger.LogInformation("GET customers");
        return _storeAppRepository.Customers.Select(customer => _mapper.Map<CustomerGetDto>(customer));
    }

    /// <summary>
    /// GET customer by ID
    /// </summary>
    /// <param name="customerId">
    /// ID
    /// </param>
    /// <returns>
    /// JSON customer
    /// </returns>
    [HttpGet("{customerId}")]
    public ActionResult<CustomerGetDto> Get(int customerId)
    {
        var getCustomer = _storeAppRepository.Customers.FirstOrDefault(customer => customer.CustomerId == customerId);
        if (getCustomer == null)
        {
            _logger.LogInformation($"Not found customer with ID: {customerId}.");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"GET customer with ID: {customerId}.");
            return Ok(_mapper.Map<CustomerGetDto>(getCustomer));
        }

    }

    /// <summary>
    /// POST customer
    /// </summary>
    /// <param name="customerToPost">
    /// Customer
    /// </param>
    /// <returns>
    /// Code-200
    /// </returns>
    [HttpPost]
    public ActionResult Post([FromBody] CustomerPostDto customerToPost)
    {
        _storeAppRepository.Customers.Add(_mapper.Map<Customer>(customerToPost));
        _logger.LogInformation($"POST customer ({customerToPost.CustomerName}, {customerToPost.CustomerCardNumber})");
        return Ok();
    }

    /// <summary>
    /// PUT customer
    /// </summary>
    /// <param name="customerId">
    /// ID
    /// </param>
    /// <param name="customerToPut">
    /// Customer to put
    /// </param>
    /// <returns>
    /// Code-200 or Code-404
    /// </returns>
    [HttpPut("{customerId}")]
    public ActionResult Put(int customerId, [FromBody] CustomerPostDto customerToPut)
    {
        var customer = _storeAppRepository.Customers.FirstOrDefault(x => x.CustomerId == customerId);
        if (customer == null)
        {
            _logger.LogInformation($"Not found customer with ID: {customerId}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"PUT customer with ID: {customerId} ({customer.CustomerName}->{customerToPut.CustomerName}, {customer.CustomerCardNumber}->{customerToPut.CustomerCardNumber})");
            _mapper.Map(customerToPut, customer);
            return Ok();
        }
    }

    /// <summary>
    /// DELETE customer
    /// </summary>
    /// <param name="customerId">
    /// ID
    /// </param>
    /// <returns>
    /// Code-200 or Code-404
    /// </returns>
    [HttpDelete("{customerId}")]
    public IActionResult Delete(int customerId)
    {
        var customer = _storeAppRepository.Customers.FirstOrDefault(x => x.CustomerId == customerId);
        if (customer == null)
        {
            _logger.LogInformation($"Not found customer with ID: {customerId}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"DELETE customer with ID: {customerId}");
            _storeAppRepository.Customers.Remove(customer);
            return Ok();
        }
    }
}
