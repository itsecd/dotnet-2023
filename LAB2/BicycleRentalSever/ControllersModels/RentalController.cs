using AutoMapper;
using BicycleRentals;
using BicycleSever.Dto;
using BicycleSever.Respostory;
using Microsoft.AspNetCore.Mvc;

namespace BicycleSever.Controllers;

[Route("api/Models/[controller]")]
[ApiController]
public class RentalController : ControllerBase
{
    private readonly ILogger<BicycleTypeController> _logger;

    private readonly IBicycleRentalRespostory _bicycleRespostory;

    private readonly IMapper _mapper;
    public RentalController(ILogger<BicycleTypeController> logger, IBicycleRentalRespostory respostory, IMapper mapper)
    {
        _logger = logger;
        _bicycleRespostory = respostory;
        _mapper = mapper;
    }
    
    [HttpGet]
    public IEnumerable<RentalGetDto> Get()
    {
        return _bicycleRespostory.FixRentals.Select(r => _mapper.Map<RentalGetDto>(r));
    }

    [HttpGet("{id}")]
    public ActionResult<RentalGetDto> Get(int id)
    {
        var rental = _bicycleRespostory.FixRentals.FirstOrDefault(r => r.RentalId == id);
        if (rental == null)
        {
            _logger.LogInformation($"Not found rental with id {id}");
            return NotFound();
        }
        else
            return Ok(_mapper.Map<RentalGetDto>(rental));
    }

    [HttpPost]
    public void Post([FromBody] RentalPostDto r)
    {
        _bicycleRespostory.FixRentals.Add(_mapper.Map<BicycleRental>(r));
        _bicycleRespostory.FixBicycles[r.SerialNumber - 1].Rentals.Add(_mapper.Map<BicycleRental>(r));
        _bicycleRespostory.FixCustomers[r.CustomerId - 1].Rentals.Add(_mapper.Map<BicycleRental>(r));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] RentalPostDto r)
    {
        var rental = _bicycleRespostory.FixRentals.FirstOrDefault(r => r.RentalId == id);
        if (rental == null)
        {
            _logger.LogInformation($"Not found rental with id {id}");
            return NotFound();
        }
        else
        {
            _mapper.Map(r, rental); //assign r to rental
            return Ok();
        }

    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var rental = _bicycleRespostory.FixRentals.FirstOrDefault(r => r.RentalId == id);
        if (rental == null)
        {
            _logger.LogInformation($"Not found rental with id {id}");
            return NotFound();
        }
        else
        {
            _bicycleRespostory.FixRentals.Remove(rental);
            var rentalDelete1 = _bicycleRespostory.FixBicycles[rental.SerialNumber - 1].Rentals.FirstOrDefault(r => r.RentalId == rental.RentalId);
            if (rentalDelete1 != null)
                _bicycleRespostory.FixBicycles[rental.SerialNumber - 1].Rentals.Remove(rentalDelete1);            
            var rentalDelete2 = _bicycleRespostory.FixCustomers[rental.CustomerId - 1].Rentals.FirstOrDefault(r => r.RentalId == rental.RentalId);
            if (rentalDelete2 != null)
                _bicycleRespostory.FixBicycles[rental.CustomerId - 1].Rentals.Remove(rentalDelete2);
            return Ok();
        }
    }
}
