using AutoMapper;
using Fabrics.Domain;
using Fabrics.Server.Dto;
using Fabrics.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fabrics.Server.Controllers;
/// <summary>
/// Shipment controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ShipmentController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<ShipmentController> _logger;
    /// <summary>
    /// Used to store repository
    /// </summary>
    private readonly IFabricsRepository _fabricsRepository;
    /// <summary>
    /// Used to store map-object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// ShipmentController constructor
    /// </summary>
    public ShipmentController(ILogger<ShipmentController> logger, IFabricsRepository fabricsRepository, IMapper mapper)
    {
        _logger = logger;
        _fabricsRepository = fabricsRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Get list of all shipments.
    /// </summary>
    /// <returns>List of fabrics</returns>
    [HttpGet]
    public IEnumerable<ShipmentGetDto> Get()
    {
        _logger.LogInformation("Get provider");
        return _fabricsRepository.Shipments.Select(shipment => _mapper.Map<ShipmentGetDto>(shipment));
    }
    /// <summary>
    /// Get shipment by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Shipment</returns>
    [HttpGet("{id}")]
    public ActionResult<ShipmentGetDto> Get(int id)
    {
        var shipment = _fabricsRepository.Shipments.FirstOrDefault(shipment => shipment.Id == id);
        if (shipment == null)
        {
            _logger.LogInformation("Not found shipment:{id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<ShipmentGetDto>(shipment));
        }
    }
    /// <summary>
    /// Post new shipment
    /// </summary>
    /// <param name="shipment"></param>
    [HttpPost]
    public void Post([FromBody] ShipmentPostDto shipment)
    {
        _fabricsRepository.Shipments.Add(_mapper.Map<Shipment>(shipment));
    }
    /// <summary>
    /// Put shipment
    /// </summary>
    /// <param name="id"></param>
    /// <param name="shipmentToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ShipmentPostDto shipmentToPut)
    {
        var shipment = _fabricsRepository.Shipments.FirstOrDefault(shipment => shipment.Id == id);
        if (shipment == null)
        {
            _logger.LogInformation("Not found shipment:{id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(shipmentToPut, shipment);
            return Ok();
        }
    }
    /// <summary>
    /// Delete shipment
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var shipment = _fabricsRepository.Shipments.FirstOrDefault(shipment => shipment.Id == id);
        if (shipment == null)
        {
            _logger.LogInformation("Not found shipment:{id}", id);
            return NotFound();
        }
        else
        {
            _fabricsRepository.Shipments.Remove(shipment);
            return Ok();
        }
    }
}
