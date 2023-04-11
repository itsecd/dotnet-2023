using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicMarket;
using MusicMarketServer.Dto;
using MusicMarketServer.Resository;

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
    /// Хранение репозитория
    /// </summary>
    private readonly IMusicMarketRepository _customersRepository;

    /// <summary>
    /// Хранение маппера
    /// </summary>
    /// 
    private readonly IMapper _mapper;
    public CustomerController(ILogger<CustomerController> logger, IMusicMarketRepository сustomersRepository, IMapper mapper)
    {
        _logger = logger;
        _customersRepository = сustomersRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// GET-запрос на получение всех элементов коллекции
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<CustomerGetDto> Get()
    {
        _logger.LogInformation($"Get list of customers");
        return _customersRepository.Customers.Select(customer => _mapper.Map<CustomerGetDto>(customer));
    }

    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Customer found by specified id</returns>
    [HttpGet("{id}")]
    public ActionResult<CustomerGetDto> Get(int id)
    {
        var customerById = _customersRepository.Customers.FirstOrDefault(customer => customer.Id == id);
        if (customerById == null)
        {
            _logger.LogInformation($"Not found customer with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Customer with id = {id}");
            return Ok(_mapper.Map<CustomerGetDto>(customerById));
        }
    }

    /// <summary>
    /// POST-запрос на добавление нового элемента в коллекцию
    /// </summary>
    /// <param name="customer"></param>
    /// <returns>Add new customer </returns>
    [HttpPost]
    public void Post([FromBody] CustomerPostDto customer)
    {
        _logger.LogInformation($"Add new customer");
        _customersRepository.Customers.Add(_mapper.Map<Customer>(customer));
    }


    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <param name="customerToPut"></param>
    /// <returns>Update customer by id or NotFound</returns>
    /// 
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] CustomerPostDto customerToPut)
    {
        var customer = _customersRepository.Customers.FirstOrDefault(customer => customer.Id == id);
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
    /// DELETE-запрос на удаление элемента из коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>// DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var customer = _customersRepository.Customers.FirstOrDefault(customer => customer.Id == id);
        if (customer == null)
        {
            _logger.LogInformation($"Not found customer with id: {id}");
            return NotFound();
        }
        else
        {
            _customersRepository.Customers.Remove(customer);
            _logger.LogInformation("Delete customer with id: {0}", id);
            return Ok();
        }
    }
}
