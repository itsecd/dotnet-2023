using Airlines.Domain;
using Airlines.Server.Dto;
using Airlines.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Server.Controllers;
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
    [HttpGet]
    public IEnumerable<TicketClass> Get()
    {
        _logger.LogInformation("Get flights");
        return _airlinesRepository.Tickets.Select(flight => flight);
    }

    [HttpGet("{id}")]
    public ActionResult<TicketClass> Get(int id)
    {
        _logger.LogInformation($"Get flight with id ({id})");
        var ticket = _airlinesRepository.Tickets.FirstOrDefault(ticket => ticket.Id == id);
        if (ticket == null)
        {
            _logger.LogInformation($"Not found flight with id ({id})");
            return NotFound();
        }
        else
        {
            return Ok(ticket);
        }
    }

    [HttpPost]
    public void Post([FromBody] TicketPostDto ticket)
    {
        _logger.LogInformation("Post");
        _airlinesRepository.Tickets.Add(_mapper.Map<TicketClass>(ticket));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] TicketPostDto ticketToPut)
    {
        _logger.LogInformation("Put flight with id {0}", id);
        var ticket = _airlinesRepository.Tickets.FirstOrDefault(ticket => ticket.Id == id);
        if (ticket == null)
        {
            _logger.LogInformation("Not found flight with id {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(ticketToPut, ticket);
            return Ok();
        }
    }

    // DELETE api/<PassengerController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation($"Put flight with id ({id})");
        var ticket = _airlinesRepository.Tickets.FirstOrDefault(ticket => ticket.Id == id);
        if (ticket == null)
        {
            _logger.LogInformation($"Not found flight with id ({id})");
            return NotFound();
        }
        else
        {
            _airlinesRepository.Tickets.Remove(ticket);
            return Ok();
        }
    }
}
