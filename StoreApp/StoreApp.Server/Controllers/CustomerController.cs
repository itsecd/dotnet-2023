using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Domain;
using StoreApp.Server.Dto;

namespace StoreApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{

    private readonly ILogger<CustomerController> _logger;
    private readonly IMapper _mapper;
    private readonly IDbContextFactory<StoreAppContext> _contextFactory;

    public CustomerController(ILogger<CustomerController> logger, IDbContextFactory<StoreAppContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// GET all customers
    /// </summary>
    /// <returns>
    /// JSON customers
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<CustomerGetDto>> Get()
    {
        _logger.LogInformation("GET customers");
        //return _storeAppRepository.Customers.Select(customer => _mapper.Map<CustomerGetDto>(customer));
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var customers = await ctx.Customers.ToArrayAsync();
        return _mapper.Map<IEnumerable<CustomerGetDto>>(customers);
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
    public async Task<ActionResult<CustomerGetDto>> Get(int customerId)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var getCustomer = await ctx.Customers.FirstOrDefaultAsync(customer => customer.CustomerId == customerId);
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
    public async Task<ActionResult> Post([FromBody] CustomerPostDto customerToPost)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        await ctx.Customers.AddAsync(_mapper.Map<Customer>(customerToPost));
        await ctx.SaveChangesAsync();
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
    public async Task<ActionResult> Put(int customerId, [FromBody] CustomerPostDto customerToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var customer = await ctx.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);
        if (customer == null)
        {
            _logger.LogInformation($"Not found customer with ID: {customerId}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"PUT customer with ID: {customerId} ({customer.CustomerName}->{customerToPut.CustomerName}, {customer.CustomerCardNumber}->{customerToPut.CustomerCardNumber})");
            _mapper.Map(customerToPut, customer);
            await ctx.SaveChangesAsync();
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
    public async Task<IActionResult> Delete(int customerId)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var customer = await ctx.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);
        if (customer == null)
        {
            _logger.LogInformation($"Not found customer with ID: {customerId}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"DELETE customer with ID: {customerId}");
            ctx.Customers.Remove(customer);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
