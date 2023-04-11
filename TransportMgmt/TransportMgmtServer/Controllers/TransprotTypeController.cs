using Microsoft.AspNetCore.Mvc;
using TransportMgmt.Domain;

namespace TransportMgmtServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TransprotTypeController : ControllerBase
{
    private readonly ILogger<TransportMgmtRepository> _logger;

    private readonly TransportMgmtRepository _transportRepository;

    public TransprotTypeController(ILogger<TransportMgmtRepository> logger, TransportMgmtRepository transportRepository)
    {
        _logger = logger;
        _transportRepository = transportRepository;
    }

    [HttpGet]

    public IEnumerable<TransportType> Get()
    {
        //_logger.LogInformation("Get transport types");
        return _transportRepository.TransportType;
    }

    [HttpGet("{id}")]
    public ActionResult<TransportType> Get(int id)
    {
        //_logger.LogInformation($"Get transport type with id {id}");
        var transportType = _transportRepository.TransportType.FirstOrDefault(transport => transport.Id == id);
        if (transportType == null)
        {
            _logger.LogInformation($"Not found transport type: {id}");
            return NotFound();
        }
        else return Ok(transportType);
    }
}