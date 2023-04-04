using AutoMapper;
using BicycleRentals.Domain;
using BicycleRentals.Server.Dto;
using BicycleRentals.Server.Respostory;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRentals.Server.ControllersModels;
[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ILogger<BicycleTypeController> _logger;

    private readonly IBicycleRentalRespostory _bicycleRespostory;

    private readonly IMapper _mapper;
    public CustomerController(ILogger<BicycleTypeController> logger, IBicycleRentalRespostory respostory, IMapper mapper)
    {
        _logger = logger;
        _bicycleRespostory = respostory;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<CustomerGetDto> Get()
    {
        return _bicycleRespostory.FixCustomers.Select(c => _mapper.Map<CustomerGetDto>(c));
    }

    [HttpGet("{id}")]
    public ActionResult<CustomerGetDto> Get(int id)
    {
        var customer = _bicycleRespostory.FixCustomers.FirstOrDefault(b => b.Id == id);
        if (customer == null)
        {
            _logger.LogInformation($"Not found customer with id {id}");
            return NotFound();
        }
        else
            return Ok(_mapper.Map<CustomerGetDto>(customer));
    }

    [HttpPost]
    public void Post([FromBody] CustomerPostDto b)
    {
        _bicycleRespostory.FixCustomers.Add(_mapper.Map<Customer>(b));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] CustomerPostDto b)
    {
        var customer = _bicycleRespostory.FixCustomers.FirstOrDefault(b => b.Id == id);
        if (customer == null)
        {
            _logger.LogInformation($"Not found customer with id {id}");
            return NotFound();
        }
        else
        {
            _mapper.Map(b, customer); //assign b to customer
            return Ok();
        }

    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var customer = _bicycleRespostory.FixCustomers.FirstOrDefault(b => b.Id == id);
        if (customer == null)
        {
            _logger.LogInformation($"Not found customer with id {id}");
            return NotFound();
        }
        else
        {
            _bicycleRespostory.FixCustomers.Remove(customer);
            return Ok();
        }
    }
}
