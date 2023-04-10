using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TransportManagment.Classes;
using TransportManagment.Server.Dto;
using TransportManagment.Server.Repository;
namespace TransportManagment.Server.Controllers;
/// <summary>
/// Controller of route
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RouteController : ControllerBase
{
    private readonly ILogger<RouteController> _logger;
    private readonly ITransportManagmentRepository _routeRepository;
    private readonly IMapper _mapper;
    public RouteController(ILogger<RouteController> logger, ITransportManagmentRepository routeRepository, IMapper mapper)
    {
        _logger = logger;
        _routeRepository = routeRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Method returns list of routes
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<RouteGetDto> Get()
    {
        _logger.LogInformation("Get routes");
        return _routeRepository.Routes.Select(route => _mapper.Map<RouteGetDto>(route));
    }
    /// <summary>
    /// Method returns info about a route with this id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<RouteGetDto> Get(int id)
    {
        var res = _routeRepository.Routes.FirstOrDefault(route => route.RouteId == id);
        if (res == null)
        {
            _logger.LogInformation("Route is not found");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get route with id = {id}");
            return Ok(_mapper.Map<RouteGetDto>(res));
        }
    }
    /// <summary>
    /// Method posts a new route
    /// </summary>
    /// <param name="route"></param>
    [HttpPost]
    public void Post([FromBody] RoutePostDto route)
    {
        _routeRepository.Routes.Add(_mapper.Map<Classes.Route>(route));
    }
    /// <summary>
    /// Method changes a selected route
    /// </summary>
    /// <param name="id"></param>
    /// <param name="routeToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] RoutePostDto routeToPut)
    {
        var res = _routeRepository.Routes.FirstOrDefault(route => route.RouteId == id);
        if (res == null)
        {
            _logger.LogInformation("Route is not found");
            return NotFound();
        }
        else
        {
            _mapper.Map(routeToPut, res);
            _logger.LogInformation("Get route with id = {id}", id);
            return Ok();
        }
    }
    /// <summary>
    /// Method delets selected route
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var res = _routeRepository.Routes.FirstOrDefault(route => route.RouteId == id);
        if (res == null)
        {
            _logger.LogInformation("Route is not found");
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Delete route with id = {id}", id);
            _routeRepository.Routes.Remove(res);
            return Ok();
        }

    }
}
