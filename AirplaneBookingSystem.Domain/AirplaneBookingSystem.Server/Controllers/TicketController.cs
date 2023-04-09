using AirplaneBookingSystem.Domain;
using AirplaneBookingSystem.Server.Dto;
using AirplaneBookingSystem.Server.Repository;
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
    private readonly IAirplaneBookingSystemRepository _airplaneBookingSystemRepository;
    private readonly IMapper _mapper;

    public TicketController(ILogger<TicketController> logger, IAirplaneBookingSystemRepository airplaneBookingSystemRepository, IMapper mapper)
    {
        _logger = logger;
        _airplaneBookingSystemRepository = airplaneBookingSystemRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Get method for ticket table
    /// </summary>
    /// <returns>
    /// Return all tickets
    /// </returns>
    [HttpGet]
    public IEnumerable<TicketGetDto> Get()
    {
        _logger.LogInformation("Get ticket");
        return _airplaneBookingSystemRepository.Tickets.Select(ticket => _mapper.Map<TicketGetDto>(ticket));
    }
    /// <summary>
    /// Get by id method for ticket table
    /// </summary>
    /// <returns>
    /// Return ticket with specified id
    /// </returns>
    [HttpGet("{id}")]
    public ActionResult<TicketGetDto> Get(int id)
    {
        _logger.LogInformation("Get ticket with id {id}", id);
        var ticket = _airplaneBookingSystemRepository.Tickets.FirstOrDefault(ticket => ticket.Id == id);
        if (ticket == null)
        {
            _logger.LogInformation("Not found ticket with id {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<TicketGetDto>(ticket));
        }
    }
    /// <summary>
    /// Post method for ticket table
    /// </summary>
    /// <param name="ticket"> Ticket class instance to insert to table</param>
    [HttpPost]
    public void Post([FromBody] TicketPostDto ticket)
    {
        _airplaneBookingSystemRepository.Tickets.Add(_mapper.Map<Ticket>(ticket));
    }
    /// <summary>
    /// Put method for ticket table
    /// </summary>
    /// <param name="id">An id of ticket which would be changed </param>
    /// <param name="ticketToPut">Ticket class instance to insert to table</param>
    /// <returns>Signalization of success of error</returns>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] TicketPostDto ticketToPut)
    {
        _logger.LogInformation("Put ticket with id {id}", id);
        var ticket = _airplaneBookingSystemRepository.Tickets.FirstOrDefault(ticket => ticket.Id == id);
        if (ticket == null)
        {
            _logger.LogInformation("Not found ticket with id {id}", id);
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
    public ActionResult Delete(int id)
    {
        _logger.LogInformation("Delete ticket with id {id}", id);
        var ticket = _airplaneBookingSystemRepository.Tickets.FirstOrDefault(ticket => ticket.Id == id);
        if (ticket == null)
        {
            _logger.LogInformation("Not found ticket with id {id}", id);
            return NotFound();
        }
        else
        {
            _airplaneBookingSystemRepository.Tickets.Remove(ticket);
            return Ok();
        }
    }
}