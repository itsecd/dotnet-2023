using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentalService.Domain;
using RentalService.Server.Dto;
using RentalService.Server.Repository;

namespace RentalService.Server.Controllers;

/// <summary>
///     Controller for rental information table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RentalInformationController : ControllerBase
{
    private readonly ILogger<RentalInformationController> _logger;
    private readonly IMapper _mapper;
    private readonly IRentalServiceRepository _rentalServiceRepository;

    public RentalInformationController(ILogger<RentalInformationController> logger,
        IRentalServiceRepository rentalServiceRepository, IMapper mapper)
    {
        _logger = logger;
        _rentalServiceRepository = rentalServiceRepository;
        _mapper = mapper;
    }

    /// <summary>
    ///     Get method which returns all rental information
    /// </summary>
    [HttpGet]
    public IEnumerable<RentalInformation> Get()
    {
        return _rentalServiceRepository.RentalInformations;
    }

    /// <summary>
    ///     Get method which returns rental information by id
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<RentalInformation> Get(ulong id)
    {
        RentalInformation? rentalInformation =
            _rentalServiceRepository.RentalInformations.FirstOrDefault(rentalInformation => rentalInformation.Id == id);
        if (rentalInformation == null)
        {
            _logger.LogInformation($"Not found rentalInformation: {id}");
            return NotFound();
        }

        return Ok(rentalInformation);
    }

    /// <summary>
    ///     Post method which add new rental information
    /// </summary>
    [HttpPost]
    public void Post([FromBody] RentalInformationPostDto rentalInformation)
    {
        _rentalServiceRepository.RentalInformations.Add(_mapper.Map<RentalInformation>(rentalInformation));
    }

    /// <summary>
    ///     Put method for changing data in the rental information table
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult Put(ulong id, [FromBody] RentalInformationPostDto rentalInformationToPut)
    {
        RentalInformation? rentalInformation =
            _rentalServiceRepository.RentalInformations.FirstOrDefault(rentalInformation => rentalInformation.Id == id);
        if (rentalInformation == null)
        {
            _logger.LogInformation("Not found rentalInformation: {id}", id);
            return NotFound();
        }

        _mapper.Map(rentalInformationToPut, rentalInformation);
        return Ok();
    }

    /// <summary>
    ///     Delete method for deleting a rental information
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(ulong id)
    {
        RentalInformation? rentalInformation =
            _rentalServiceRepository.RentalInformations.FirstOrDefault(rentalInformation => rentalInformation.Id == id);
        if (rentalInformation == null)
        {
            _logger.LogInformation($"Not found rentalInformation: {id}");
            return NotFound();
        }

        _rentalServiceRepository.RentalInformations.Remove(rentalInformation);
        return Ok();
    }
}