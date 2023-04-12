using AutoMapper;
using AirLine.Domain;
using Airline.Server.Dto;
using Airline.Server.Repository;
using Microsoft.AspNetCore.Mvc;


namespace Airline.Server.Controllers;

/// <summary>
/// Ticket table controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TicketController : ControllerBase
{
    private readonly ILogger<TicketController> _logger;
    private readonly IAirlineRepository _airlineRepository;
    private readonly IMapper _mapper;

    public TicketController(ILogger<TicketController> logger, IAirlineRepository airlineRepository, IMapper mapper)
    {
        _logger = logger;
        _airlineRepository = airlineRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get table ticket
    /// </summary>
    /// <returns>
    /// Return list all tickets
    /// </returns>
    [HttpGet]
    public IEnumerable<Ticket> Get()
    {
        _logger.LogInformation("Get tickets");
        return _airlineRepository.Tickets.Select(flight => flight);
    }

    /// <summary>
    /// Get ticket by id
    /// </summary>
    /// <param name="id">Ticket id</param>
    /// <returns>
    /// Return ticket with specified id
    /// </returns>
    [HttpGet("{id}")]
    public ActionResult<Ticket> Get(int id)
    {
        _logger.LogInformation($"Get ticket with id ({id})");
        var ticket = _airlineRepository.Tickets.FirstOrDefault(ticket => ticket.Id == id);
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
    /// Post ticket
    /// </summary>
    /// <param name="ticket">Ticket class for insert in table</param>
    [HttpPost]
    public void Post([FromBody] TicketPostDto ticket)
    {
        _logger.LogInformation("Post(ticket)");
        _airlineRepository.Tickets.Add(_mapper.Map<Ticket>(ticket));
    }

    /// <summary>
    /// Put ticket
    /// </summary>
    /// <param name="id">Ticket id for be changed</param>
    /// <param name="ticketToPut">Ticket class for insert in table</param>
    /// <returns>Signalization of success of error</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] TicketPostDto ticketToPut)
    {
        _logger.LogInformation("Put ticket: id {0}", id);
        var ticket = _airlineRepository.Tickets.FirstOrDefault(ticket => ticket.Id == id);
        if (ticket == null)
        {
            _logger.LogInformation("Not found ticket: id {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(ticketToPut, ticket);
            return Ok();
        }
    }

    /// <summary>
    /// Delete ticket
    /// </summary>
    /// <param name="id">Ticket id for deleting</param>
    /// <returns>Triggered of success and error</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation($"Put ticket: id ({id})");
        var ticket = _airlineRepository.Tickets.FirstOrDefault(ticket => ticket.Id == id);
        if (ticket == null)
        {
            _logger.LogInformation($"Not found ticket: id ({id})");
            return NotFound();
        }
        else
        {
            _airlineRepository.Tickets.Remove(ticket);
            return Ok();
        }
    }
}
