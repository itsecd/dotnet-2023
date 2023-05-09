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
    public async Task<IEnumerable<CustomerGetDto>> Get()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get information about all customers");
        return _mapper.Map<IEnumerable<CustomerGetDto>>(context.Customers);
    }

    /// <summary>
    /// Get a customer by id
    /// </summary>
    /// <param name="id">Customer's id</param>
    /// <returns>Customer with required id</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerGetDto?>> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var customer = await context.Customers.FirstOrDefaultAsync(customer => customer.Id == id);
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
    /// <param name="customer">New customer</param>
    /// <returns>Ok (success code)</returns>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CustomerPostDto customer)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Post a new customer");
        context.Customers.Add(_mapper.Map<Customer>(customer));
        await context.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Put a customer
    /// </summary>
    /// <param name="id">Customer's id</param>
    /// <param name="customerToPut">New customer</param>
    /// <returns>Ok (success code) or NotFound (error code)</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] CustomerPostDto customerToPut)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var customer = await context.Customers.FirstOrDefaultAsync(customer => customer.Id == id);
        if (customer == null)
        {
            _logger.LogInformation("Not found customer with {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(customerToPut, customer);
            await context.SaveChangesAsync();
            _logger.LogInformation("Put a customer");
            return Ok();
        }
    }

    /// <summary>
    /// Delete a customer by id
    /// </summary>
    /// <param name="id">Customer's id</param>
    /// <returns>Ok (success code) or NotFound (error code)</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var customer = await context.Customers.FirstOrDefaultAsync(customer => customer.Id == id);
        if (customer == null)
        {
            _logger.LogInformation("Not found customer with {id}", id);
            return NotFound();
        }
        else
        {
            context.Customers.Remove(customer);
            await context.SaveChangesAsync();
            _logger.LogInformation("Delete an customer");
            return Ok();
        }
    }
}
