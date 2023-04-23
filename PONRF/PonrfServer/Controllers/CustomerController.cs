using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PonrfDomain;
using PonrfServer.Dto;

namespace PonrfServer.Controllers;

/// <summary>
/// Customer controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;

    private readonly IDbContextFactory<PonrfContext> _contextFactory;

    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for CustomerController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="contextFactory"></param>
    /// <param name="mapper"></param>
    public CustomerController(ILogger<CustomerController> logger, IDbContextFactory<PonrfContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// Get information about all customers
    /// </summary>
    /// <returns>List of customers</returns>
    [HttpGet]
    public IEnumerable<CustomerGetDto> Get()
    {
        using var context = _contextFactory.CreateDbContext();
        _logger.LogInformation("Get information about all customers");
        return _mapper.Map<IEnumerable<CustomerGetDto>>(context.Customers);
    }

    /// <summary>
    /// Get a customer by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Customer</returns>
    [HttpGet("{id}")]
    public ActionResult<CustomerGetDto?> Get(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        var customer = context.Customers.FirstOrDefault(customer => customer.Id == id);
        if (customer == null)
        {
            _logger.LogInformation("Not found customer with {id}", id);
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
        using var context = _contextFactory.CreateDbContext();
        _logger.LogInformation("Post a new customer");
        context.Customers.Add(_mapper.Map<Customer>(customer));
        context.SaveChanges();
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
        using var context = _contextFactory.CreateDbContext();
        var customer = context.Customers.FirstOrDefault(customer => customer.Id == id);
        if (customer == null)
        {
            _logger.LogInformation("Not found customer with {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(customerToPut, customer);
            context.SaveChanges();
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
        using var context = _contextFactory.CreateDbContext();
        var customer = context.Customers.FirstOrDefault(customer => customer.Id == id);
        if (customer == null)
        {
            _logger.LogInformation("Not found customer with {id}", id);
            return NotFound();
        }
        else
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
            _logger.LogInformation("Delete an customer");
            return Ok();
        }
    }
}
