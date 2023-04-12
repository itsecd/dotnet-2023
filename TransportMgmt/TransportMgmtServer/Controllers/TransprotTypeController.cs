using Microsoft.AspNetCore.Mvc;
using TransportMgmt.Domain;
using TransportMgmtServer.Repository;

namespace TransportMgmtServer.Controllers;

/// <summary>
/// Controller for transport types
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TransportTypeController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<TransportTypeController> _logger;
    /// <summary>
    /// Used to store repository
    /// </summary>
    private readonly ITransportMgmtRepository _transportRepository;
    /// <summary>
    /// Controller constructor
    /// </summary>
    public TransportTypeController(ILogger<TransportTypeController> logger, ITransportMgmtRepository transportRepository)
    {
        _logger = logger;
        _transportRepository = transportRepository;
    }
    /// <summary>
    /// Returns a list of all transport types
    /// </summary>
    /// <returns> Returns a list of all transport types </returns>
    [HttpGet]
    public IEnumerable<TransportType> Get()
    {
        _logger.LogInformation("Get transport types");
        return _transportRepository.TransportType;
    }
    /// <summary>
    /// Get method that returns transport types with a specific id
    /// </summary>
    /// <param name="id"> Transport type id </param>
    /// <returns> Transport type with required id </returns>
    [HttpGet("{id}")]
    public ActionResult<TransportType> Get(int id)
    {
        _logger.LogInformation("Get transport type with id= {id}", id);
        var transportType = _transportRepository.TransportType.FirstOrDefault(transport => transport.Id == id);
        if (transportType == null)
        {
            _logger.LogInformation("Not found transport type with id= {id}", id);
            return NotFound();
        }
        else return Ok(transportType);
    }
}