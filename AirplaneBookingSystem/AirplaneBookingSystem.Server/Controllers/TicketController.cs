using AirplaneBookingSystem.Model;
using AirplaneBookingSystem.Server.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirplaneBookingSystem.Server.Controllers;
/// <summary>
/// Tickets
/// </summary>

[Route("api/[controller]")]
[ApiController]
public class TicketController : ControllerBase
{
    private readonly IDbContextFactory<AirplaneBookingSystemDbContext> _contextFactory;
    private readonly IMapper _mapper;
    private readonly ILogger<AirplaneController> _logger;

    public TicketController(ILogger<AirplaneController> logger, IDbContextFactory<AirplaneBookingSystemDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
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
    public async Task<IEnumerable<TicketGetDto>> GetTicket()
    {
        _logger.LogInformation("Get all tickets");
        var ctx = await _contextFactory.CreateDbContextAsync();
        var tickets = await ctx.Tickets.ToArrayAsync();
        return _mapper.Map<IEnumerable<TicketGetDto>>(tickets);
    }
    /// <summary>
    /// Get by id method for ticket table
    /// </summary>
    /// <param name="idTicket">id ticket</param>
    /// <returns>Ok with TicketGetDto or NotFound</returns>
    [HttpGet("{idTicket}")]
    public async Task<ActionResult<TicketGetDto>> GetTicket(int idTicket)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var ticket = await ctx.Tickets.FirstOrDefaultAsync(ticket => ticket.Id == idTicket);
        if (ticket == null)
        {
            _logger.LogInformation("Not found ticket : {idTicket}", idTicket);
            return NotFound($"The ticket does't exist by this id {idTicket}");
        }
        else
        {
            _logger.LogInformation("Get ticket by {idTicket}", idTicket);
            return Ok(_mapper.Map<TicketGetDto>(ticket));
        }
    }
    /// <summary>
    /// Put method for ticket table
    /// </summary>
    /// <param name="idTicket">An id of ticket which would be changed </param>
    /// <param name="ticketToPut">Ticket class instance to insert to table</param>
    /// <returns>Ok or NotFound</returns>
    [HttpPut("{idTicket}")]
    public async Task<IActionResult> PutTicket(int idTicket, [FromBody] TicketPostDto ticketToPut)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var ticket = await ctx.Tickets.FirstOrDefaultAsync(ticket => ticket.Id == idTicket);
        if (ticket == null)
        {
            _logger.LogInformation("Not found ticket : {idTicket}", idTicket);
            return NotFound($"The ticket does't exist by this id {idTicket}");
        }
        else
        {
            _logger.LogInformation("Update ticket by id {idTicket}", idTicket);
            _mapper.Map(ticketToPut, ticket);
            ctx.Tickets.Update(_mapper.Map<Ticket>(ticket));
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Post method for ticket table
    /// </summary>
    /// <param name="ticket"> Ticket class instance to insert to table</param>
    /// <returns>Сreated ticket</returns>
    [HttpPost]
    public async Task PostTicket([FromBody] TicketPostDto ticket)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Create new ticket");
        await ctx.Tickets.AddAsync(_mapper.Map<Ticket>(ticket));
        await ctx.SaveChangesAsync();
    }
    /// <summary>
    /// Delete method 
    /// </summary>
    /// <param name="idTicket">An id of ticket which would be deleted</param>
    /// <returns>Ok or NotFound</returns>
    [HttpDelete("{idTicket}")]
    public async Task<IActionResult> DeleteTicket(int idTicket)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var ticket = await ctx.Tickets.FirstOrDefaultAsync(ticket => ticket.Id == idTicket);
        if (ticket == null)
        {
            _logger.LogInformation("Not found ticket : {idTicket}", idTicket);
            return NotFound($"The ticket does't exist by this id {idTicket}");
        }
        else
        {
            _logger.LogInformation("Delete ticket by id {idTicket}", idTicket);
            ctx.Tickets.Remove(ticket);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}