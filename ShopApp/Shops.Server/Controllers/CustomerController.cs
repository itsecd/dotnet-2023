using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shops.Domain;
using Shops.Server.Dto;
using Shops.Server.Repository;

namespace Shops.Server.Controllers;
/// <summary>
/// Controller for customer
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly IShopRepository _shopRepository;
    private readonly IMapper _mapper;
    /// <summary>
    /// Controller constructor 
    /// </summary>
    public CustomerController(ILogger<CustomerController> logger, IShopRepository shopRepository, IMapper mapper)
    {
        _logger = logger;
        _shopRepository = shopRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Return list of customer
    /// </summary>
    /// <returns>Ok(List of customer)</returns>
    [HttpGet]
    public ActionResult<IEnumerable<CustomersGetDto>> Get()
    {
        _logger.LogInformation("Get list of customer");
        return Ok(_shopRepository.Customers.Select(customer => _mapper.Map<CustomersGetDto>(customer)));
    }
    /// <summary>
    /// Return customer by id
    /// </summary>
    /// <param name="id"> Customer id</param>
    /// <returns>Ok (the customer found by specified id) or NotFound</returns>
    [HttpGet("{id}")]
    public ActionResult<CustomersGetDto> Get(int id)
    {
        var customer = _shopRepository.Customers.FirstOrDefault(customer => customer.Id == id);
        if (customer == null)
        {
            _logger.LogInformation($"Not found customer with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Customer with id = {id}");
            return Ok(_mapper.Map<CustomersGetDto>(customer));
        }
    }
    /// <summary>
    /// Add new customer in list of customers
    /// </summary>
    /// <param name="customer"> New customer</param>
    /// <returns>Ok(add new customer) </returns>
    [HttpPost]
    public IActionResult Post([FromBody] CustomerPostDto customer)
    {
        var newid = _shopRepository.Customers
            .Select(customer => customer.Id)
            .DefaultIfEmpty()
            .Max() + 1;
        var newCustomer = _mapper.Map<Customer>(customer);
        newCustomer.Id = newid;
        _shopRepository.Customers.Add(newCustomer);
        _logger.LogInformation($"Post customer, id = {newid}");
        return Ok();
    }
    /// <summary>
    /// Updates customer information
    /// </summary>
    /// <param name="id">Customer id</param>
    /// <param name="customerToPut">New information</param>
    /// <returns>Ok (update customer by id) or NotFound</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] CustomerPostDto customerToPut)
    {
        var customer = _shopRepository.Customers.FirstOrDefault(customer => customer.Id == id);
        if (customer == null)
        {
            _logger.LogInformation($"Not found customer with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Update information customer with id = {id}");
            _mapper.Map<CustomerPostDto, Customer>(customerToPut, customer);
            return Ok();
        }
    }
    /// <summary>
    /// Delete customer by id
    /// </summary>
    /// <param name="id">customer id</param>
    /// <returns>Ok (delete customer by id) or NotFound</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var customer = _shopRepository.Customers.FirstOrDefault(customer => customer.Id == id);
        if (customer == null)
        {
            _logger.LogInformation($"Not found customer with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Delete customer with id = {id}");
            _shopRepository.Customers.Remove(customer);
            return Ok();
        }
    }
}
