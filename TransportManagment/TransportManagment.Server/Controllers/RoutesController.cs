using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportManagment.Classes;
using TransportManagment.Server.Dto;
namespace TransportManagment.Server.Controllers;
/// <summary>
/// Routes
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RoutesController : ControllerBase
{
    private readonly TransportManagmentDbContext _context;
    private readonly ILogger<RoutesController> _logger;
    private readonly IMapper _mapper;
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public RoutesController(ILogger<RoutesController> logger, TransportManagmentDbContext context, IMapper mapper)
    {
        _logger = logger;
        _context = context;
        _mapper = mapper;
    }
    /// <summary>
    /// Get all routes
    /// </summary>
    /// <returns> List of routes </returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RouteGetDto>>> GetRoutes()
    {
        if (_context.Routes == null)
        {
            _logger.LogInformation("Routes is not founded");
            return NotFound();
        }
        _logger.LogInformation("Get routes");
        return await _mapper.ProjectTo<RouteGetDto>(_context.Routes).ToListAsync();
    }
    /// <summary>
    /// Get route for id
    /// </summary>
    /// <param name="id"></param>
    /// <returns> Route </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<RouteGetDto>> GetRoute(int id)
    {
        if (_context.Routes == null)
        {
            _logger.LogInformation("Route is not founded");
            return NotFound();
        }
        var route = await _context.Routes.FindAsync(id);
        if (route == null)
        {
            _logger.LogInformation("Route is not founded");
            return NotFound();
        }
        _logger.LogInformation("Get route with this id");
        return _mapper.Map<RouteGetDto>(route);
    }
    /// <summary>
    /// Changing information about route
    /// </summary>
    /// <param name="id"></param>
    /// <param name="route"> Changed information about route </param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRoute(int id, [FromBody] RoutePostDto route)
    {
        if (_context.Routes == null)
        {
            _logger.LogInformation("There is no route");
            return NotFound();
        }
        var routeToChanged = await _context.Routes.FindAsync(id);
        if (routeToChanged == null)
        {
            _logger.LogInformation("Route is not founded");
            return NotFound();
        }
        _mapper.Map(route, routeToChanged);
        await _context.SaveChangesAsync();
        _logger.LogInformation("Route was changimg");
        return NoContent();
    }
    /// <summary>
    /// Method posts a new route
    /// </summary>
    /// <param name="route"> New route </param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<RouteGetDto>> PostRoute([FromBody] RoutePostDto route)
    {
        if (_context.Routes == null)
        {
            _logger.LogInformation("There is no route");
            return Problem("Entity set 'RouteManagmentDbContext.Routes'  is null.");
        }
        var addedRoute = _mapper.Map<Classes.Route>(route);
        _context.Routes.Add(addedRoute);
        await _context.SaveChangesAsync();
        _logger.LogInformation("New route recorded");
        return CreatedAtAction("GetRoute", new { id = addedRoute.RouteId }, _mapper.Map<RouteGetDto>(addedRoute));
    }
    /// <summary>
    /// Deleting route for id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoute(int id)
    {
        if (_context.Routes == null)
        {
            _logger.LogInformation("Route is not founded");
            return NotFound();
        }
        var route = await _context.Routes.FindAsync(id);
        if (route == null)
        {
            _logger.LogInformation("There is no route");
            return NotFound();
        }
        _context.Routes.Remove(route);
        await _context.SaveChangesAsync();
        _logger.LogInformation("Route deleted");
        return NoContent();
    }
}