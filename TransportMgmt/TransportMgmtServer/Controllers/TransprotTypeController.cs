using Microsoft.AspNetCore.Mvc;
using TransportMgmt.Domain;
using TransportMgmtServer.Repository;

namespace TransportMgmtServer.Controllers;

/// <summary>
/// Controller for transprot types
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TransprotTypeController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<TransprotTypeController> _logger;
    /// <summary>
    /// Used to store repository
    /// </summary>
    private readonly ITransportMgmtRepository _transportRepository;
    /// <summary>
    /// Controller constructor
    /// </summary>
    public TransprotTypeController(ILogger<TransprotTypeController> logger, ITransportMgmtRepository transportRepository)
    {
        _logger = logger;
        _transportRepository = transportRepository;
    }

    /// <summary>
    /// Returns a list of all transprot types
    /// </summary>
    /// <returns> Returns a list of all transprot types </returns>
    [HttpGet]
    public IEnumerable<TransportType> Get()
    {
        _logger.LogInformation("Get transport types");
        return _transportRepository.TransportType;
    }

    /// <summary>
    /// Get method that returns transprot types with a specific id
    /// </summary>
    /// <param name="id"> Transprot type id </param>
    /// <returns> Transprot type with required id </returns>
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