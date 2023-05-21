using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicMarket;
using MusicMarketplace;
using MusicMarketServer.Dto;

namespace MusicMarketServer.Controllers;

/// <summary>
/// Контроллер покупателей
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    /// <summary>
    /// Хранение логгера
    /// </summary>
    private readonly ILogger<CustomerController> _logger;


    /// <summary>
    /// Хранение DbContext
    /// </summary>
    private readonly IDbContextFactory<MusicMarketDbContext> _contextFactory;

    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор контроллера customer
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="contextFactory"></param>
    /// <param name="mapper"></param>
    public CustomerController(ILogger<CustomerController> logger, IDbContextFactory<MusicMarketDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// GET-запрос на получение всех элементов коллекции
    /// </summary>
    /// <returns> Returns a list of all customers</returns>
    [HttpGet]
    public async Task<IEnumerable<CustomerGetDto>> Get()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get customers");
        var customers = await context.Customers.ToListAsync();
        return _mapper.Map<IEnumerable<CustomerGetDto>>(customers);
    }

    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id">CustomerId</param>
    /// <returns>Customer found by specified id</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerGetDto>> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var customer = await context.Customers.FirstOrDefaultAsync(customer => customer.Id == id);
        if (customer == null)
        {
            _logger.LogInformation("Not found customer:{id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<CustomerGetDto>(customer));
        }

    }

    /// <summary>
    /// POST-запрос на добавление нового элемента в коллекцию
    /// </summary>
    /// <param name="customer">New customer</param>
    [HttpPost]
    public async void Post([FromBody] CustomerPostDto customer)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        await context.Customers.AddAsync(_mapper.Map<Customer>(customer));
        await context.SaveChangesAsync();

    }


    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id">CustomerId</param>
    /// <param name="customerToPut">New customer</param>
    /// <returns>Update customer by id or NotFound</returns>
    /// 
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] CustomerPostDto customerToPut)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var customer = await context.Customers.FirstOrDefaultAsync(customer => customer.Id == id);
        if (customer == null)
        {
            _logger.LogInformation("Not found customer:{id}", id);
            return NotFound();
        }
        else
        {
            context.Update(_mapper.Map(customerToPut, customer));
            await context.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// DELETE-запрос на удаление элемента из коллекции
    /// </summary>
    /// <param name="id">CustomerId</param>
    /// <returns>DELETE element</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var customer = await context.Customers.FirstOrDefaultAsync(customer => customer.Id == id);
        if (customer == null)
        {
            _logger.LogInformation("Not found customer:{id}", id);
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
