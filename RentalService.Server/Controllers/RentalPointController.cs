using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentalService.Domain;
using RentalService.Server.Dto;
using RentalService.Server.Repository;

namespace RentalService.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentalPointController : ControllerBase
{
    private readonly ILogger<RentalPointController> _logger;
    
    private readonly IRentalServiceRepository _rentalServiceRepository;

    private readonly IMapper _mapper;
    
    public RentalPointController(ILogger<RentalPointController> logger, IRentalServiceRepository rentalServiceRepository, IMapper mapper)
    {
        _logger = logger;
        _rentalServiceRepository = rentalServiceRepository;
        _mapper = mapper;
    }
    [HttpGet]
    public IEnumerable<RentalPointGetDto> Get()
    {
        return _rentalServiceRepository.RentalPoints.Select(point => _mapper.Map<RentalPointGetDto>(point));
    }
    
    [HttpGet("{id}")]
    public ActionResult<RentalPointGetDto> Get(ulong id)
    {
        var rentalPoint = _rentalServiceRepository.RentalPoints.FirstOrDefault(rentalPoint => rentalPoint.Id == id);
        if (rentalPoint == null)
        {
            _logger.LogInformation($"Not found rentalPoint: {id}");
            return NotFound(); 
        }
        else
        {
            return Ok(_mapper.Map<RentalPointGetDto>(rentalPoint));
        }
    }
    
    [HttpPost]
    public void Post([FromBody] RentalPointPostDto rentalPoint)
    {
        _rentalServiceRepository.RentalPoints.Add(_mapper.Map<RentalPoint>(rentalPoint));
    }
    
    [HttpPut("{id}")]
    public IActionResult Put(ulong id, [FromBody] RentalPointPostDto rentalPointToPut)
    {
        var rentalPoint = _rentalServiceRepository.RentalPoints.FirstOrDefault(rentalPoint => rentalPoint.Id == id);
        if (rentalPoint == null)
        {
            _logger.LogInformation("Not found rentalPoint: {id}", id);
            return NotFound(); 
        }
        else
        {
            _mapper.Map(rentalPointToPut, rentalPoint);
    
            return Ok();
        }
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(ulong id)
    {
        var rentalPoint = _rentalServiceRepository.RentalPoints.FirstOrDefault(rentalPoint => rentalPoint.Id == id);
        if (rentalPoint == null)
        {
            _logger.LogInformation($"Not found rentalPoint: {id}");
            return NotFound(); 
        }
        else
        {
            _rentalServiceRepository.RentalPoints.Remove(rentalPoint);
            return Ok();
        }
    }
}

