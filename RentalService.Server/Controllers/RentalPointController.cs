using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentalService.Domain;
using RentalService.Server.Dto;
using RentalService.Server.Repository;

namespace RentalService.Server.Controllers;

/// <summary>
///     Controller for rental point table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RentalPointController : ControllerBase
{
    private readonly ILogger<RentalPointController> _logger;

    private readonly IMapper _mapper;

    private readonly IRentalServiceRepository _rentalServiceRepository;

    public RentalPointController(ILogger<RentalPointController> logger,
        IRentalServiceRepository rentalServiceRepository, IMapper mapper)
    {
        _logger = logger;
        _rentalServiceRepository = rentalServiceRepository;
        _mapper = mapper;
    }

    /// <summary>
    ///     Get method which returns all rental points
    /// </summary>
    [HttpGet]
    public IEnumerable<RentalPointGetDto> Get()
    {
        return _rentalServiceRepository.RentalPoints.Select(point => _mapper.Map<RentalPointGetDto>(point));
    }

    /// <summary>
    ///     Get method which returns rental point by id
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<RentalPointGetDto> Get(ulong id)
    {
        RentalPoint? rentalPoint =
            _rentalServiceRepository.RentalPoints.FirstOrDefault(rentalPoint => rentalPoint.Id == id);
        if (rentalPoint == null)
        {
            _logger.LogInformation($"Not found rentalPoint: {id}");
            return NotFound();
        }

        return Ok(_mapper.Map<RentalPointGetDto>(rentalPoint));
    }

    /// <summary>
    ///     Post method which add new rental point
    /// </summary>
    [HttpPost]
    public void Post([FromBody] RentalPointPostDto rentalPoint)
    {
        _rentalServiceRepository.RentalPoints.Add(_mapper.Map<RentalPoint>(rentalPoint));
    }

    /// <summary>
    ///     Put method for changing data in the rental point table
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult Put(ulong id, [FromBody] RentalPointPostDto rentalPointToPut)
    {
        RentalPoint? rentalPoint =
            _rentalServiceRepository.RentalPoints.FirstOrDefault(rentalPoint => rentalPoint.Id == id);
        if (rentalPoint == null)
        {
            _logger.LogInformation("Not found rentalPoint: {id}", id);
            return NotFound();
        }

        _mapper.Map(rentalPointToPut, rentalPoint);

        return Ok();
    }

    /// <summary>
    ///     Delete method for deleting a rental point
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(ulong id)
    {
        RentalPoint? rentalPoint =
            _rentalServiceRepository.RentalPoints.FirstOrDefault(rentalPoint => rentalPoint.Id == id);
        if (rentalPoint == null)
        {
            _logger.LogInformation($"Not found rentalPoint: {id}");
            return NotFound();
        }

        _rentalServiceRepository.RentalPoints.Remove(rentalPoint);
        return Ok();
    }
}