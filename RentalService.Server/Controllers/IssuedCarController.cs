using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentalService.Domain;
using RentalService.Server.Dto;
using RentalService.Server.Repository;

namespace RentalService.Server.Controllers;

/// <summary>
///     Controller for issued car table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class IssuedCarController : ControllerBase
{
    private readonly ILogger<IssuedCarController> _logger;
    private readonly IMapper _mapper;
    private readonly IRentalServiceRepository _rentalServiceRepository;

    public IssuedCarController(ILogger<IssuedCarController> logger, IRentalServiceRepository rentalServiceRepository,
        IMapper mapper)
    {
        _logger = logger;
        _rentalServiceRepository = rentalServiceRepository;
        _mapper = mapper;
    }

    /// <summary>
    ///     Get method which returns all issued cars
    /// </summary>
    [HttpGet]
    public IEnumerable<IssuedCar> Get()
    {
        return _rentalServiceRepository.IssuedCars;
    }

    /// <summary>
    ///     Get method which returns issued car by id
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<IssuedCar> Get(ulong id)
    {
        IssuedCar? issuedCar = _rentalServiceRepository.IssuedCars.FirstOrDefault(issuedCar => issuedCar.Id == id);
        if (issuedCar == null)
        {
            _logger.LogInformation($"Not found issuedCar: {id}");
            return NotFound();
        }

        return Ok(issuedCar);
    }

    /// <summary>
    ///     Post method which add new issued car
    /// </summary>
    [HttpPost]
    public void Post([FromBody] IssuedCarPostDto issuedCar)
    {
        _rentalServiceRepository.IssuedCars.Add(_mapper.Map<IssuedCar>(issuedCar));
    }

    /// <summary>
    ///     Put method for changing data in the issued car table
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult Put(ulong id, [FromBody] IssuedCarPostDto issuedCarToPut)
    {
        IssuedCar? issuedCar = _rentalServiceRepository.IssuedCars.FirstOrDefault(issuedCar => issuedCar.Id == id);
        if (issuedCar == null)
        {
            _logger.LogInformation("Not found issuedCar: {id}", id);
            return NotFound();
        }

        _mapper.Map(issuedCarToPut, issuedCar);
        return Ok();
    }

    /// <summary>
    ///     Delete method for deleting a issued car
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(ulong id)
    {
        IssuedCar? issuedCar = _rentalServiceRepository.IssuedCars.FirstOrDefault(issuedCar => issuedCar.Id == id);
        if (issuedCar == null)
        {
            _logger.LogInformation($"Not found issuedCar: {id}");
            return NotFound();
        }

        _rentalServiceRepository.IssuedCars.Remove(issuedCar);
        return Ok();
    }
}