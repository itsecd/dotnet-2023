using Microsoft.AspNetCore.Mvc;
using TransportMgmt.Domain;
using TransportMgmtServer.Repository;

namespace TransportMgmtServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RoutesController : Controller
{
    private readonly ILogger<RoutesController> _logger;

    private readonly ITransportMgmtRepository _transportRepository;

    public RoutesController(ILogger<RoutesController> logger, ITransportMgmtRepository transportRepository)
    {
        _logger = logger;
        _transportRepository = transportRepository;
    }

    [HttpGet]

    public IEnumerable<Routes> Get()
    {
        return _transportRepository.Routes;
    }

    [HttpGet("{id}")]

    public ActionResult<Routes> Get(int id)
    {
        //_logger.LogInformation($"Get route with id {id}");
        var route = _transportRepository.Routes.FirstOrDefault(route => route.Id == id);
        if (route == null)
        {
            _logger.LogInformation($"Not found route: {id}");
            return NotFound();
        }
        else return Ok(route);
    }
}
