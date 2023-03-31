using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentalService.Domain;
using RentalService.Server.Dto;
using RentalService.Server.Repository;

namespace RentalService.Server.Controllers;

/// <summary>
///     Controller for refund information table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RefundInformationController : ControllerBase
{
    private readonly ILogger<RefundInformationController> _logger;
    private readonly IMapper _mapper;
    private readonly IRentalServiceRepository _rentalServiceRepository;

    public RefundInformationController(ILogger<RefundInformationController> logger,
        IRentalServiceRepository rentalServiceRepository, IMapper mapper)
    {
        _logger = logger;
        _rentalServiceRepository = rentalServiceRepository;
        _mapper = mapper;
    }

    /// <summary>
    ///     Get method which returns all refund information
    /// </summary>
    [HttpGet]
    public IEnumerable<RefundInformation> Get()
    {
        return _rentalServiceRepository.RefundInformations;
    }

    /// <summary>
    ///     Get method which returns refund information by id
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<RefundInformation> Get(ulong id)
    {
        RefundInformation? refundInformation =
            _rentalServiceRepository.RefundInformations.FirstOrDefault(refundInformation => refundInformation.Id == id);
        if (refundInformation == null)
        {
            _logger.LogInformation($"Not found refundInformation: {id}");
            return NotFound();
        }

        return Ok(refundInformation);
    }

    /// <summary>
    ///     Post method which add new refund information
    /// </summary>
    [HttpPost]
    public void Post([FromBody] RefundInformationPostDto refundInformation)
    {
        _rentalServiceRepository.RefundInformations.Add(_mapper.Map<RefundInformation>(refundInformation));
    }

    /// <summary>
    ///     Put method for changing data in the refund information table
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult Put(ulong id, [FromBody] RefundInformationPostDto refundInformationToPut)
    {
        RefundInformation? refundInformation =
            _rentalServiceRepository.RefundInformations.FirstOrDefault(information => information.Id == id);
        if (refundInformation == null)
        {
            _logger.LogInformation("Not found refundInformationToPut: {id}", id);
            return NotFound();
        }

        _mapper.Map(refundInformationToPut, refundInformation);
        return Ok();
    }

    /// <summary>
    ///     Delete method for deleting a refund information
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(ulong id)
    {
        RefundInformation? refundInformation =
            _rentalServiceRepository.RefundInformations.FirstOrDefault(information => information.Id == id);
        if (refundInformation == null)
        {
            _logger.LogInformation($"Not found refundInformation: {id}");
            return NotFound();
        }

        _rentalServiceRepository.RefundInformations.Remove(refundInformation);
        return Ok();
    }
}