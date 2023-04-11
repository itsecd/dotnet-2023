using Microsoft.AspNetCore.Mvc;
using TransportMgmt.Domain;
using TransportMgmtServer.Repository;

namespace TransportMgmtServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TransprotTypeController : ControllerBase
{
    private readonly ILogger<TransprotTypeController> _logger;

    private readonly ITransportMgmtRepository _transportRepository;

    public TransprotTypeController(ILogger<TransprotTypeController> logger, ITransportMgmtRepository transportRepository)
    {
        _logger = logger;
        _transportRepository = transportRepository;
    }

    [HttpGet]

    public IEnumerable<TransportType> Get()
    {
        return _transportRepository.TransportType;
    }

    [HttpGet("{id}")]
    public ActionResult<TransportType> Get(int id)
    {
        var transportType = _transportRepository.TransportType.FirstOrDefault(transport => transport.Id == id);
        if (transportType == null)
        {
            _logger.LogInformation($"Not found transport type: {id}");
            return NotFound();
        }
        else return Ok(transportType);
    }
}