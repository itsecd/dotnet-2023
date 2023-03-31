using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentalService.Domain;
using RentalService.Server.Dto;
using RentalService.Server.Repository;

namespace RentalService.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IssuedCarController : ControllerBase
{
    private readonly ILogger<IssuedCarController> _logger;
    private readonly IRentalServiceRepository _rentalServiceRepository;
    private readonly IMapper _mapper;
    
    public IssuedCarController(ILogger<IssuedCarController> logger, IRentalServiceRepository rentalServiceRepository, IMapper mapper)
    {
        _logger = logger;
        _rentalServiceRepository = rentalServiceRepository;
        _mapper = mapper;
    }
    [HttpGet]
    public IEnumerable<IssuedCar> Get()
    {
        return _rentalServiceRepository.IssuedCars;
    }
    
    [HttpGet("{id}")]
    public ActionResult<IssuedCar> Get(ulong id)
    {
        var issuedCar = _rentalServiceRepository.IssuedCars.FirstOrDefault(issuedCar => issuedCar.Id == id);
        if (issuedCar == null)
        {
            _logger.LogInformation($"Not found issuedCar: {id}");
            return NotFound(); 
        }
        else
        {
            return Ok(issuedCar);
        }
    }
    
    [HttpPost]
    public void Post([FromBody] IssuedCarPostDto issuedCar)
    {
        _rentalServiceRepository.IssuedCars.Add(_mapper.Map<IssuedCar>(issuedCar));
    }
    
    [HttpPut("{id}")]
    public IActionResult Put(ulong id, [FromBody] IssuedCarPostDto issuedCarToPut)
    {
        var issuedCar = _rentalServiceRepository.IssuedCars.FirstOrDefault(issuedCar => issuedCar.Id == id);
        if (issuedCar == null)
        {
            _logger.LogInformation("Not found issuedCar: {id}", id);
            return NotFound(); 
        }
        else
        {
            _mapper.Map(issuedCarToPut, issuedCar);
            return Ok();
        }
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(ulong id)
    {
        var issuedCar = _rentalServiceRepository.IssuedCars.FirstOrDefault(issuedCar => issuedCar.Id == id);
        if (issuedCar == null)
        {
            _logger.LogInformation($"Not found issuedCar: {id}");
            return NotFound(); 
        }
        else
        {
            _rentalServiceRepository.IssuedCars.Remove(issuedCar);
            return Ok();
        }
    }
}