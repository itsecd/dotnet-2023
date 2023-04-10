using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TransportManagment.Classes;
using TransportManagment.Server.Dto;
using TransportManagment.Server.Repository;
namespace TransportManagment.Server.Controllers;
/// <summary>
/// Controller of transport
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TransportControlller : ControllerBase
{
    private readonly ILogger<TransportControlller> _logger;
    private readonly ITransportManagmentRepository _transportRepository;
    private readonly IMapper _mapper;
    public TransportControlller(ILogger<TransportControlller> logger, ITransportManagmentRepository transportRepository, IMapper mapper)
    {
        _logger = logger;
        _transportRepository = transportRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Method returns list of transports
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<TransportGetDto> Get()
    {
        _logger.LogInformation("Get transports");
        return _transportRepository.Transports.Select(transport => _mapper.Map<TransportGetDto>(transport));
    }
    /// <summary>
    /// Method returns info about a transport with this id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<TransportGetDto> Get(int id)
    {
        var res = _transportRepository.Transports.FirstOrDefault(transport => transport.TransportId == id);
        if (res == null)
        {
            _logger.LogInformation("Transport is not found");
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get transport with id = {id}", id);
            return Ok(_mapper.Map<TransportGetDto>(res));
        }
    }
    /// <summary>
    /// Method posts a new transport
    /// </summary>
    /// <param name="transport"></param>
    [HttpPost]
    public void Post([FromBody] TransportPostDto transport)
    {
        _transportRepository.Transports.Add(_mapper.Map<Transport>(transport));
    }
    /// <summary>
    /// Method changes a selected transport
    /// </summary>
    /// <param name="id"></param>
    /// <param name="transportToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] TransportPostDto transportToPut)
    {
        var res = _transportRepository.Transports.FirstOrDefault(transport => transport.TransportId == id);
        if (res == null)
        {
            _logger.LogInformation("Transport is not found");
            return NotFound();
        }
        else
        {
            _mapper.Map(transportToPut, res);
            _logger.LogInformation("Get transport with id = {id}", id);
            return Ok();
        }
    }
    /// <summary>
    /// Method delets selected transport
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var res = _transportRepository.Transports.FirstOrDefault(transport => transport.TransportId == id);
        if (res == null)
        {
            _logger.LogInformation("Transport is not found");
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Delete transport with id = {id}", id);
            _transportRepository.Transports.Remove(res);
            return Ok();
        }

    }
}
