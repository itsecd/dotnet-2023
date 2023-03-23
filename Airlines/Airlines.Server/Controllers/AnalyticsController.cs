using Airlines.Domain;
using Airlines.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Airlines.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly ILogger<AnalyticsController> _logger;
    private readonly IAirlinesRepository _airlinesRepository;
    private readonly IMapper _mapper;
    public AnalyticsController(ILogger<AnalyticsController> logger, IAirlinesRepository airlinesRepository, IMapper mapper)
    {
        _logger = logger;
        _airlinesRepository = airlinesRepository;
        _mapper = mapper;
    }
    // GET: api/<AnalyticsController>
    [HttpGet]
    public IEnumerable<PassengerClass> Get()
    {
        var request = (from flight in _airlinesRepository.Flights
                       from ticket in _airlinesRepository.Tickets
                       from passenger in _airlinesRepository.Passengers
                       from t in passenger.Tickets
                       where (flight.Id == 1) && (ticket.BaggageWeight == 0) && (t.TicketNumber == ticket.TicketNumber)
                       select passenger);
        return request;
    }

    // GET api/<AnalyticsController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<AnalyticsController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<AnalyticsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<AnalyticsController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
