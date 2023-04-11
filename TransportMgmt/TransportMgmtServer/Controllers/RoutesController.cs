using Microsoft.AspNetCore.Mvc;
using TransportMgmt.Domain;

namespace TransportMgmtServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RoutesController : Controller
{
    private readonly ILogger<TransportMgmtRepository> _logger;

    private readonly TransportMgmtRepository _transportRepository;

    public RoutesController(ILogger<TransportMgmtRepository> logger, TransportMgmtRepository transportRepository)
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
