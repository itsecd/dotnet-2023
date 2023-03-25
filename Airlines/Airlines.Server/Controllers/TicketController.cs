using Airlines.Domain;
using Airlines.Server.Dto;
using Airlines.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Server.Controllers;

/// <summary>
/// Controller for ticket table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TicketController : ControllerBase
{
    private readonly ILogger<TicketController> _logger;
    private readonly IAirlinesRepository _airlinesRepository;
    private readonly IMapper _mapper;

    public TicketController(ILogger<TicketController> logger, IAirlinesRepository airlinesRepository, IMapper mapper)
    {
        _logger = logger;
        _airlinesRepository = airlinesRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get method for ticket table
    /// </summary>
    /// <returns>
    /// Return all tickets
    /// </returns>
    [HttpGet]
    public IEnumerable<TicketClass> Get()
    {
        _logger.LogInformation("Get tickets");
        return _airlinesRepository.Tickets.Select(flight => flight);
    }

    /// <summary>
    /// Get by id method for ticket table
    /// </summary>
    /// <returns>
    /// Return ticket with specified id
    /// </returns>
    [HttpGet("{id}")]
    public ActionResult<TicketClass> Get(int id)
    {
        _logger.LogInformation($"Get ticket with id ({id})");
        var ticket = _airlinesRepository.Tickets.FirstOrDefault(ticket => ticket.Id == id);
        if (ticket == null)
        {
            _logger.LogInformation($"Not found ticket with id ({id})");
            return NotFound();
        }
        else
        {
            return Ok(ticket);
        }
    }

    /// <summary>
    /// Post method for ticket table
    /// </summary>
    /// <param name="ticket"> Ticket class instance to insert to table</param>
    [HttpPost]
    public void Post([FromBody] TicketPostDto ticket)
    {
        _logger.LogInformation("Post(ticket)");
        _airlinesRepository.Tickets.Add(_mapper.Map<TicketClass>(ticket));
    }

    /// <summary>
    /// Put method for ticket table
    /// </summary>
    /// <param name="id">An id of ticket which would be changed </param>
    /// <param name="ticketToPut">Ticket class instance to insert to table</param>
    /// <returns>Signalization of success of error</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] TicketPostDto ticketToPut)
    {
        _logger.LogInformation("Put ticket with id {0}", id);
        var ticket = _airlinesRepository.Tickets.FirstOrDefault(ticket => ticket.Id == id);
        if (ticket == null)
        {
            _logger.LogInformation("Not found ticket with id {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(ticketToPut, ticket);
            return Ok();
        }
    }

    /// <summary>
    /// Delete method 
    /// </summary>
    /// <param name="id">An id of ticket which would be deleted</param>
    /// <returns>Signalization of success of error</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation($"Put ticket with id ({id})");
        var ticket = _airlinesRepository.Tickets.FirstOrDefault(ticket => ticket.Id == id);
        if (ticket == null)
        {
            _logger.LogInformation($"Not found ticket with id ({id})");
            return NotFound();
        }
        else
        {
            _airlinesRepository.Tickets.Remove(ticket);
            return Ok();
        }
    }
}