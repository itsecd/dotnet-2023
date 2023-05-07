using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportManagment.Classes;
using TransportManagment.Server.Dto;
namespace TransportManagment.Server.Controllers;
/// <summary>
/// Transports
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TransportsController : ControllerBase
{
    private readonly TransportManagmentDbContext _context;
    private readonly ILogger<TransportsController> _logger;
    private readonly IMapper _mapper;
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public TransportsController(ILogger<TransportsController> logger, TransportManagmentDbContext context, IMapper mapper)
    {
        _logger = logger;
        _context = context;
        _mapper = mapper;
    }
    /// <summary>
    /// Get all transports
    /// </summary>
    /// <returns> List of transports </returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TransportGetDto>>> GetTransports()
    {
        if (_context.Transports == null)
        {
            _logger.LogInformation("Transports is not founded");
            return NotFound();
        }
        _logger.LogInformation("Get transports");
        return await _mapper.ProjectTo<TransportGetDto>(_context.Transports).ToListAsync();
    }
    /// <summary>
    /// Get transport for id
    /// </summary>
    /// <param name="id"></param>
    /// <returns> Transport </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<TransportGetDto>> GetTransport(int id)
    {
        if (_context.Transports == null)
        {
            _logger.LogInformation("Transport is not founded");
            return NotFound();
        }
        var transport = await _context.Transports.FindAsync(id);
        if (transport == null)
        {
            _logger.LogInformation("Transport is not founded");
            return NotFound();
        }
        _logger.LogInformation("Get transport with this id");
        return _mapper.Map<TransportGetDto>(transport);
    }
    /// <summary>
    /// Changing information about transport
    /// </summary>
    /// <param name="id"></param>
    /// <param name="transport"> Changed information about transport </param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTransport(int id, [FromBody] TransportPostDto transport)
    {
        if (_context.Transports == null)
        {
            _logger.LogInformation("There is no transport");
            return NotFound();
        }
        var transportToChanged = await _context.Transports.FindAsync(id);
        if (transportToChanged == null)
        {
            _logger.LogInformation("Transport is not founded");
            return NotFound();
        }
        _mapper.Map(transport, transportToChanged);
        await _context.SaveChangesAsync();
        _logger.LogInformation("Transport was changimg");
        return NoContent();
    }
    /// <summary>
    /// Method posts a new transport
    /// </summary>
    /// <param name="transport"> New transport </param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<TransportGetDto>> PostTransport([FromBody] TransportPostDto transport)
    {
        if (_context.Transports == null)
        {
            _logger.LogInformation("There is no transport");
            return Problem("Entity set 'TransportManagmentDbContext.Transports'  is null.");
        }
        var addedTransport = _mapper.Map<Transport>(transport);
        _context.Transports.Add(addedTransport);
        await _context.SaveChangesAsync();
        _logger.LogInformation("New transport recorded");
        return CreatedAtAction("GetTransport", new { id = addedTransport.TransportId }, _mapper.Map<TransportGetDto>(addedTransport));
    }
    /// <summary>
    /// Deleting transport for id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransport(int id)
    {
        if (_context.Transports == null)
        {
            _logger.LogInformation("Transport is not founded");
            return NotFound();
        }
        var transport = await _context.Transports.FindAsync(id);
        if (transport == null)
        {
            _logger.LogInformation("There is no transport");
            return NotFound();
        }
        _context.Transports.Remove(transport);
        await _context.SaveChangesAsync();
        _logger.LogInformation("Transport deleted");
        return NoContent();
    }
}