using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentalService.Domain;
using RentalService.Server.Dto;
using RentalService.Server.Repository;

namespace RentalService.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentalInformationController : ControllerBase
{
    private readonly ILogger<RentalInformationController> _logger;
    private readonly IRentalServiceRepository _rentalServiceRepository;
    private readonly IMapper _mapper;
    
    public RentalInformationController(ILogger<RentalInformationController> logger, IRentalServiceRepository rentalServiceRepository, IMapper mapper)
    {
        _logger = logger;
        _rentalServiceRepository = rentalServiceRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    public IEnumerable<RentalInformation> Get()
    {
        return _rentalServiceRepository.RentalInformations;
    }
    
    [HttpGet("{id}")]
    public ActionResult<RentalInformation> Get(ulong id)
    {
        var rentalInformation = _rentalServiceRepository.RentalInformations.FirstOrDefault(rentalInformation => rentalInformation.Id == id);
        if (rentalInformation == null)
        {
            _logger.LogInformation($"Not found rentalInformation: {id}");
            return NotFound(); 
        }
        else
        {
            return Ok(rentalInformation);
        }
    }
    
    [HttpPost]
    public void Post([FromBody] RentalInformationPostDto rentalInformation)
    {
        _rentalServiceRepository.RentalInformations.Add(_mapper.Map<RentalInformation>(rentalInformation));
    }
    
    [HttpPut("{id}")]
    public IActionResult Put(ulong id, [FromBody] RentalInformationPostDto rentalInformationToPut)
    {
        var rentalInformation = _rentalServiceRepository.RentalInformations.FirstOrDefault(rentalInformation => rentalInformation.Id == id);
        if (rentalInformation == null)
        {
            _logger.LogInformation("Not found rentalInformation: {id}", id);
            return NotFound(); 
        }
        else
        {
            _mapper.Map(rentalInformationToPut, rentalInformation);
            return Ok();
        }
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(ulong id)
    {
        var rentalInformation = _rentalServiceRepository.RentalInformations.FirstOrDefault(rentalInformation => rentalInformation.Id == id);
        if (rentalInformation == null)
        {
            _logger.LogInformation($"Not found rentalInformation: {id}");
            return NotFound(); 
        }
        else
        {
            _rentalServiceRepository.RentalInformations.Remove(rentalInformation);
            return Ok();
        }
    }
}

