using AutoMapper;
using BicycleRentals.Domain;
using BicycleRentals.Server.Controllers;
using BicycleRentals.Server.Dto;
using BicycleRentals.Server.Respostory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BicycleRentals.Server.ControllersModels;
[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;

    private readonly IDbContextFactory<BicycleRentalContext> _contextFactory;

    private readonly IMapper _mapper;
    public CustomerController(ILogger<CustomerController> logger, IDbContextFactory<BicycleRentalContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }


    /// <summary> 
    /// Returns a list of all customers. 
    /// </summary> 
    /// <returns>The list of all customers.</returns>
    [HttpGet]
    public async Task<IEnumerable<CustomerGetDto>> Get()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("GET: Get list of customer");
        return _mapper.Map<IEnumerable<CustomerGetDto>>(context.Customers);
    }

    /// <summary> 
    /// Returns a customer by id. 
    /// </summary> 
    /// <param name="id">The customer id.</param> 
    /// <returns>OK (the customer found by the specified id) or NotFound. </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerGetDto>> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var customer = await context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        if (customer == null)
        {
            _logger.LogInformation($"Not found customer with id {id}");
            return NotFound();
        }
        else
            return Ok(_mapper.Map<CustomerGetDto>(customer));
    }

    /// <summary> 
    /// Create a new customer. 
    /// </summary> 
    /// <param name="CustomerPostDto">New bicycle. </param> 
    /// <returns>New bicycle id.</returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CustomerPostDto c)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        await context.Customers.AddAsync(_mapper.Map<Customer>(c));
        await context.SaveChangesAsync();
        return Ok();
    }

    /// <summary> 
    /// Updates the existing customer data. 
    /// </summary> 
    /// <param name="CustomerPostDto">New customer data. </param>
    /// <returns>OK or NotFound.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] CustomerPostDto c)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var customer = await context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        if (customer == null)
        {
            _logger.LogInformation($"Not found bicycle with id {id}");
            return NotFound();
        }
        else
        {
            _mapper.Map(c, customer);
            context.Customers.Update(_mapper.Map<Customer>(customer));
            await context.SaveChangesAsync();
            return Ok();
        }

    }

    ///<summary> 
    ///Deletes a customer by id. 101 Ace Mapping. 
    /// </summary> 
    /// <param name="id">The customer id.</param> 
    /// <returns>OK or NotFound.</returns> 
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var customer = await context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        if (customer == null)
        {
            _logger.LogInformation($"Not found bicycle with id {id}");
            return NotFound();
        }
        else
        {
            context.Customers.Remove(customer);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
