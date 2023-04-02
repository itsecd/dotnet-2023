using AutoMapper;
using Fabrics.Domain;
using Fabrics.Server.Dto;
using Fabrics.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fabrics.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ShipmentController : ControllerBase
{
    private readonly ILogger<ShipmentController> _logger;

    private readonly IFabricsRepository _fabricsRepository;

    private readonly IMapper _mapper;
    public ShipmentController(ILogger<ShipmentController> logger, IFabricsRepository fabricsRepository, IMapper mapper)
    {
        _logger = logger;
        _fabricsRepository = fabricsRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Returns list of all shipments.
    /// </summary>
    /// <returns>List of fabrics</returns>
    [HttpGet]
    public IEnumerable<ShipmentGetDto> Get()
    {
        _logger.LogInformation("Get provider");
        return _fabricsRepository.Shipments.Select(shipment => _mapper.Map<ShipmentGetDto>(shipment));
    }

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

    [HttpPost]
    public void Post([FromBody] ShipmentPostDto shipment)
    {
        _fabricsRepository.Shipments.Add(_mapper.Map<Shipment>(shipment));
    }

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
