using Microsoft.AspNetCore.Mvc;
using TransportMgmt.Domain;
using TransportMgmtServer.Repository;

namespace TransportMgmtServer.Controllers;

/// <summary>
/// Controller for routes
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RoutesController : Controller
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<RoutesController> _logger;
    /// <summary>
    /// Used to store repository
    /// </summary>
    private readonly ITransportMgmtRepository _transportRepository;
    /// <summary>
    /// Controller constructor
    /// </summary>
    public RoutesController(ILogger<RoutesController> logger, ITransportMgmtRepository transportRepository)
    {
        _logger = logger;
        _transportRepository = transportRepository;
    }
    /// <summary>
    /// Returns a list of all routes
    /// </summary>
    /// <returns> Returns a list of all routes </returns>
    [HttpGet]
    public IEnumerable<Routes> Get()
    {
        _logger.LogInformation("Get routes");
        return _transportRepository.Routes;
    }
    /// <summary>
    /// Get method that returns route with a specific id
    /// </summary>
    /// <param name="id"> Route id </param>
    /// <returns> Route with required id </returns>
    [HttpGet("{id}")]
    public ActionResult<Routes> Get(int id)
    {
        _logger.LogInformation("Get route with id= {id}", id);
        var route = _transportRepository.Routes.FirstOrDefault(route => route.Id == id);
        if (route == null)
        {
            _logger.LogInformation("Not found route with id= {id}", id);
            return NotFound();
        }
        else return Ok(route);
    }
}
