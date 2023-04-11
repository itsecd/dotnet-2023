using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransportMgmt.Domain;
using TransportMgmtServer.Dto;
using TransportMgmtServer.Repository;

namespace TransportMgmtServer.Controllers;

/// <summary>
/// Controller for transport
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TransportController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<TransportController> _logger;
    /// <summary>
    /// Used to store repository
    /// </summary>
    private readonly ITransportMgmtRepository _transportRepository;
    /// <summary>
    /// Used to store map's object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// Controller constructor
    /// </summary>
    public TransportController(ILogger<TransportController> logger, ITransportMgmtRepository transportRepository, IMapper mapper)
    {
        _logger = logger;
        _transportRepository = transportRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns a list of all transports
    /// </summary>
    /// <returns> Returns a list of all transports </returns>
    [HttpGet]

    public IEnumerable<TransportGetDto> Get()
    {
        _logger.LogInformation("Get transports");
        return _transportRepository.Transports.Select(transport => _mapper.Map<TransportGetDto>(transport));
    }

    /// <summary>
    /// Get method that returns transport with a specific id
    /// </summary>
    /// <param name="id"> Transports id </param>
    /// <returns> Transports with required id </returns>
    [HttpGet("{id}")]

    public ActionResult<TransportGetDto> Get(int id)
    {
        _logger.LogInformation("Get transport with id= {id}", id);
        var transport = _transportRepository.Transports.FirstOrDefault(transport => transport.Id == id);
        if (transport == null)
        {
            _logger.LogInformation("Not found transport with id= {id} ", id);
            return NotFound();
        }
        else return Ok(_mapper.Map<TransportGetDto>(transport));
    }

    /// <summary>
    /// Post method that adding a new transport
    /// </summary>
    /// <param name="transport"></param>
    [HttpPost]

    public void Post([FromBody] TransportPostDto transport)
    {
        _transportRepository.Transports.Add(_mapper.Map<Transport>(transport));
        _logger.LogInformation("Successfully added");
    }

    /// <summary>
    /// Put method which allows change the data of transport with a specific id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="transportToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]

    public IActionResult Put(int id, [FromBody] TransportPostDto transportToPut)
    {
        var transport = _transportRepository.Transports.FirstOrDefault(transport => transport.Id == id);
        if (transport == null)
        {
            _logger.LogInformation("Not found transport with id= {id} ", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(transportToPut, transport);
            _logger.LogInformation("Successfully updates");
            return Ok();
        }
    }

    /// <summary>
    /// Delete method which allows delete a transport with a specific id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]

    public IActionResult Delete(int id)
    {
        var transport = _transportRepository.Transports.FirstOrDefault(transport => transport.Id == id);
        if (transport == null)
        {
            _logger.LogInformation("Not found transport with id= {id} ", id);
            return NotFound();
        }
        else
        {
            _transportRepository.Transports.Remove(transport);
            _logger.LogInformation("Successfully removed");
            return Ok();
        }
    }
}
