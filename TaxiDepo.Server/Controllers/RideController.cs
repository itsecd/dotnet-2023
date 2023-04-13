using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaxiDepo.Domain;
using TaxiDepo.Server.Dto;
using TaxiDepo.Server.Repositories;

namespace TaxiDepo.Server.Controllers;

/// <summary>
/// Ride controller class 
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RideController : ControllerBase
{
    /// <summary>
    /// Ride logger
    /// </summary>
    private readonly ILogger<RideController> _logger;
    /// <summary>
    /// TaxiDepo repository
    /// </summary>
    private readonly ITaxiDepoRepository _taxiRepository;
    /// <summary>
    /// Mapper
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// RideController class constructor with params
    /// </summary>
    /// <param name="logger">Ride logger</param>
    /// <param name="taxiRepository">Taxi repository</param>
    /// <param name="mapper">Mapper</param>
    public RideController(ILogger<RideController> logger, ITaxiDepoRepository taxiRepository, IMapper mapper)
    {
        _logger = logger;
        _taxiRepository = taxiRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Get request
    /// </summary>
    /// <returns>All rides objects</returns>
    [HttpGet]
    public IEnumerable<RideDto> Get()
    {
        _logger.LogInformation("Get ride");
        return _taxiRepository.Rides.Select(ride => _mapper.Map<RideDto>(ride));
    }
    /// <summary>
    /// Get request with search by id
    /// </summary>
    /// <param name="id">Index of search</param>
    /// <returns>Found object or 404Error</returns>
    [HttpGet("{id:int}")]
    public ActionResult<RideDto> Get(int id)
    {
        var ride = _taxiRepository.Rides.FirstOrDefault(ride => ride.Id == id);
        if (ride != null)
        {
            _logger.LogInformation("Get ride by Id");
            return Ok(_mapper.Map<RideDto>(ride));
        }
        _logger.LogInformation("Not found a ride with id: {id}", id);
        return NotFound();
    }
    /// <summary>
    /// Insert request with selection by id
    /// </summary>
    /// <param name="ride">Ride object</param>
    [HttpPost]
    public void Post([FromBody] RideDto ride)
    {
        _logger.LogInformation("Add ride");
        _taxiRepository.Rides.Add(_mapper.Map<Ride>(ride));
    }
    /// <summary>
    /// Put request with selection by id
    /// </summary>
    /// <param name="id">Index of search</param>
    /// <param name="rideToPut">RideDto object</param>
    /// <returns>Change object or 404Error</returns>
    [HttpPut("{id:int}")]
    public IActionResult Put(int id, [FromBody] RideDto rideToPut)
    {
        var ride = _taxiRepository.Rides.FirstOrDefault(ride => ride.Id == id);
        if (ride != null)
        {
            _logger.LogInformation("Put ride");
            _mapper.Map(rideToPut, ride);
            return Ok();
        }
        _logger.LogInformation("Not found a ride with id: {id}", id);
        return NotFound();
    }
    /// <summary>
    /// Delete request with selection by id
    /// </summary>
    /// <param name="id">Index of search</param>
    /// <returns>Delete object or 404Error</returns>
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var ride = _taxiRepository.Rides.FirstOrDefault(ride => ride.Id == id);
        if (ride != null)
        {
            _logger.LogInformation("Delete ride");
            _taxiRepository.Rides.Remove(ride);
            return Ok();
        }
        _logger.LogInformation("Not found a ride with id: {id}", id);
        return NotFound();
    }
}