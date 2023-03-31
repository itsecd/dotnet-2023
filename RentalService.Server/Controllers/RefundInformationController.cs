using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentalService.Domain;
using RentalService.Server.Dto;
using RentalService.Server.Repository;

namespace RentalService.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RefundInformationController : ControllerBase
{
    private readonly ILogger<RefundInformationController> _logger;
    private readonly IRentalServiceRepository _rentalServiceRepository;
    private readonly IMapper _mapper;
    
    public RefundInformationController(ILogger<RefundInformationController> logger, IRentalServiceRepository rentalServiceRepository, IMapper mapper)
    {
        _logger = logger;
        _rentalServiceRepository = rentalServiceRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    public IEnumerable<RefundInformation> Get()
    {
        return _rentalServiceRepository.RefundInformations;
    }
    
    [HttpGet("{id}")]
    public ActionResult<RefundInformation> Get(ulong id)
    {
        var refundInformation = _rentalServiceRepository.RefundInformations.FirstOrDefault(refundInformation => refundInformation.Id == id);
        if (refundInformation == null)
        {
            _logger.LogInformation($"Not found refundInformation: {id}");
            return NotFound(); 
        }
        else
        {
            return Ok(refundInformation);
        }
    }
    
    [HttpPost]
    public void Post([FromBody] RefundInformationPostDto refundInformation)
    {
        _rentalServiceRepository.RefundInformations.Add(_mapper.Map<RefundInformation>(refundInformation));
    }
    
    [HttpPut("{id}")]
    public IActionResult Put(ulong id, [FromBody] RefundInformationPostDto refundInformationToPut)
    {
        var refundInformation = _rentalServiceRepository.RefundInformations.FirstOrDefault(information => information.Id == id);
        if (refundInformation == null)
        {
            _logger.LogInformation("Not found refundInformationToPut: {id}", id);
            return NotFound(); 
        }
        else
        {
            _mapper.Map(refundInformationToPut, refundInformation);
            return Ok();
        }
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(ulong id)
    {
        var refundInformation = _rentalServiceRepository.RefundInformations.FirstOrDefault(information => information.Id == id);
        if (refundInformation == null)
        {
            _logger.LogInformation($"Not found refundInformation: {id}");
            return NotFound(); 
        }
        else
        {
            _rentalServiceRepository.RefundInformations.Remove(refundInformation);
            return Ok();
        }
    }
}

