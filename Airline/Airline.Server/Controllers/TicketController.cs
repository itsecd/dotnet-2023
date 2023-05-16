using Airline.Server.Dto;
using AirLine.Model;
using AirlineModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airline.Server.Controllers;

/// <summary>
/// Ticket table controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TicketController : ControllerBase
{
    private readonly IDbContextFactory<AirlineContext> _contextFactory;
    private readonly ILogger<TicketController> _logger;
    private readonly IMapper _mapper;

    public TicketController(IDbContextFactory<AirlineContext> contextFactory, ILogger<TicketController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Get table ticket
    /// </summary>
    /// <returns>
    /// Return list all tickets
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<Ticket>> Get()
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get tickets");
        return context.Tickets.Select(flight => flight);
    }

    /// <summary>
    /// Get ticket by id
    /// </summary>
    /// <param name="id">Ticket id</param>
    /// <returns>
    /// Return ticket with specified id
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Ticket>> Get(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Get ticket with id ({id})");
        var ticket = context.Tickets.FirstOrDefault(ticket => ticket.Id == id);
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
    public async Task<IActionResult> Post([FromBody] TicketPostDto ticket)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Post(ticket)");
        context.Tickets.Add(_mapper.Map<Ticket>(ticket));
        context.SaveChanges();
        return Ok();
    }

    /// <summary>
    /// Put ticket
    /// </summary>
    /// <param name="id">Ticket id for be changed</param>
    /// <param name="ticketToPut">Ticket class for insert in table</param>
    /// <returns>Signalization of success of error</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] TicketPostDto ticketToPut)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Put ticket: id {0}", id);
        var ticket = context.Tickets.FirstOrDefault(ticket => ticket.Id == id);
        if (ticket == null)
        {
            _logger.LogInformation("Not found ticket: id {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(ticketToPut, ticket);
            context.SaveChanges();
            return Ok();
        }
    }

    /// <summary>
    /// Delete ticket
    /// </summary>
    /// <param name="id">Ticket id for deleting</param>
    /// <returns>Triggered of success and error</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Put ticket: id ({id})");
        var ticket = context.Tickets.FirstOrDefault(ticket => ticket.Id == id);
        if (ticket == null)
        {
            _logger.LogInformation($"Not found ticket: id ({id})");
            return NotFound();
        }
        else
        {
            context.Tickets.Remove(ticket);
            context.SaveChanges();
            return Ok();
        }
    }
}
