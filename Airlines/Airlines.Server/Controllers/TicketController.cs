using Airlines.Domain;
using Airlines.Server.Dto;
using Airlines.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Org.BouncyCastle.Crypto.Signers;
using System.Collections.Generic;

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
    private readonly IDbContextFactory<AirlinesContext> _contextFactory;
    private readonly IMapper _mapper;

    public TicketController(IDbContextFactory<AirlinesContext> contextFactory, ILogger<TicketController> logger, IAirlinesRepository airlinesRepository, IMapper mapper)
    {
        _logger = logger;
        _airlinesRepository = airlinesRepository;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// Get method for ticket table
    /// </summary>
    /// <returns>
    /// Return all tickets
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<Ticket>> Get()
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get tickets");
        return ctx.Tickets.ToList();
    }

    /// <summary>
    /// Get by id method for ticket table
    /// </summary>
    /// <returns>
    /// Return ticket with specified id
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Ticket>> Get(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Get ticket with id ({id})");
        var ticket = ctx.Tickets.FirstOrDefault(ticket => ticket.Id == id);
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
    public async Task<IActionResult> Post([FromBody] TicketPostDto ticket)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Post(ticket)");
        ctx.Tickets.Add(_mapper.Map<Ticket>(ticket));
        ctx.SaveChanges();
        return Ok();
    }

    /// <summary>
    /// Put method for ticket table
    /// </summary>
    /// <param name="id">An id of ticket which would be changed </param>
    /// <param name="ticketToPut">Ticket class instance to insert to table</param>
    /// <returns>Signalization of success of error</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] TicketPostDto ticketToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Put ticket with id {0}", id);
        var ticket = ctx.Tickets.FirstOrDefault(ticket => ticket.Id == id);
        if (ticket == null)
        {
            _logger.LogInformation("Not found ticket with id {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(ticketToPut, ticket);
            ctx.SaveChanges();
            return Ok();
        }
    }

    /// <summary>
    /// Delete method 
    /// </summary>
    /// <param name="id">An id of ticket which would be deleted</param>
    /// <returns>Signalization of success of error</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Put ticket with id ({id})");
        var ticket = ctx.Tickets.FirstOrDefault(ticket => ticket.Id == id);
        if (ticket == null)
        {
            _logger.LogInformation($"Not found ticket with id ({id})");
            return NotFound();
        }
        else
        {
            ctx.Tickets.Remove(ticket);
            ctx.SaveChanges();
            return Ok();
        }
    }
}