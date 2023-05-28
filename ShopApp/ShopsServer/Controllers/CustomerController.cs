using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shops.Domain;
using Shops.Server.Dto;

namespace Shops.Server.Controllers;
/// <summary>
/// Controller for customer
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<CustomerController> _logger;
    /// <summary>
    /// Used to store factory context
    /// </summary>
    private readonly IDbContextFactory<ShopsContext> _dbContextFactory;
    /// <summary>
    /// Used to store map-object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// Controller constructor 
    /// </summary>
    public CustomerController(ILogger<CustomerController> logger, IDbContextFactory<ShopsContext> dbContextFactory, IMapper mapper)
    {
        _logger = logger;
        _dbContextFactory = dbContextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// Return list of customer
    /// </summary>
    /// <returns>Ok(List of customer)</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerGetDto>>> Get()
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get list of customer");
        return await _mapper.ProjectTo<CustomerGetDto>(ctx.Customers).ToListAsync();
    }
    /// <summary>
    /// Return customer by id
    /// </summary>
    /// <param name="id"> Customer id</param>
    /// <returns>Ok (the customer found by specified id) or NotFound</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerGetDto>> Get(int id)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        var customer = await ctx.Customers.FirstOrDefaultAsync(customer => customer.Id == id);
        if (customer == null)
        {
            _logger.LogInformation("Not found customer with id = {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Customer with id = {id}", id);
            return Ok(_mapper.Map<CustomerGetDto>(customer));
        }
    }
    /// <summary>
    /// Add new customer in list of customers
    /// </summary>
    /// <param name="customer"> New customer</param>
    /// <returns>Ok(add new customer) </returns>
    [HttpPost]
    public async Task<ActionResult<CustomerGetDto>> Post([FromBody] CustomerPostDto customer)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        var newId = ctx.Customers
            .Select(customer => customer.Id)
            .DefaultIfEmpty()
            .Max() + 1;
        var newCustomer = _mapper.Map<Customer>(customer);
        newCustomer.Id = newId;
        await ctx.Customers.AddAsync(newCustomer);
        await ctx.SaveChangesAsync();
        _logger.LogInformation("Post customer, id = {newId}", newId);
        return Ok(_mapper.Map<CustomerGetDto>(newCustomer));
    }
    /// <summary>
    /// Updates customer information
    /// </summary>
    /// <param name="id">Customer id</param>
    /// <param name="customerToPut">New information</param>
    /// <returns>Ok (update customer by id) or NotFound</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] CustomerPostDto customerToPut)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        var customer = await ctx.Customers.FirstOrDefaultAsync(customer => customer.Id == id);
        if (customer == null)
        {
            _logger.LogInformation("Not found customer with id = {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Update information customer with id = {id}", id);
            _mapper.Map<CustomerPostDto, Customer>(customerToPut, customer);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Delete customer by id
    /// </summary>
    /// <param name="id">customer id</param>
    /// <returns>Ok (delete customer by id) or NotFound</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        var customer = await ctx.Customers.FirstOrDefaultAsync(customer => customer.Id == id);
        if (customer == null)
        {
            _logger.LogInformation("Not found customer with id = {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Delete customer with id = {id}", (id));
            ctx.Customers.Remove(customer);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
