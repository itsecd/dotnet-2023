using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaxiDepo.Domain;
using TaxiDepo.Server.Dto;
using TaxiDepo.Server.Repositories;

namespace TaxiDepo.Server.Controllers;

/// <summary>
/// Driver controller class 
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DriverController : ControllerBase
{
    /// <summary>
    /// Driver logger
    /// </summary>
    private readonly ILogger<DriverController> _logger;
    /// <summary>
    /// TaxiDepo repository
    /// </summary>
    private readonly ITaxiDepoRepository _taxiRepository;
    /// <summary>
    /// Mapper
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// DriverController class constructor with params
    /// </summary>
    /// <param name="logger">Driver logger</param>
    /// <param name="taxiRepository">Taxi repository</param>
    /// <param name="mapper">Mapper</param>
    public DriverController(ILogger<DriverController> logger, ITaxiDepoRepository taxiRepository, IMapper mapper)
    {
        _logger = logger;
        _taxiRepository = taxiRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Get request
    /// </summary>
    /// <returns>All drivers objects</returns>
    [HttpGet]
    public IEnumerable<DriverDto> Get()
    {
        _logger.LogInformation("Get driver");
        return _taxiRepository.Drivers.Select(driver => _mapper.Map<DriverDto>(driver));
    }
    /// <summary>
    /// Get request with search by id
    /// </summary>
    /// <param name="id">Index of search</param>
    /// <returns>Found object or 404Error</returns>
    [HttpGet("{id:int}")]
    public ActionResult<DriverDto> Get(int id)
    {
        var driver = _taxiRepository.Drivers.FirstOrDefault(driver => driver.Id == id);
        if (driver != null)
        {
            _logger.LogInformation("Get driver by Id");
            return Ok(_mapper.Map<DriverDto>(driver));
        }
        _logger.LogInformation("Not found a driver with id: {id}", id);
        return NotFound();
    }
    /// <summary>
    /// Insert request with selection by id
    /// </summary>
    /// <param name="driver">Driver object</param>
    [HttpPost]
    public void Post([FromBody] DriverDto driver)
    {
        _logger.LogInformation("Add driver");
        _taxiRepository.Drivers.Add(_mapper.Map<Driver>(driver));
    }
    /// <summary>
    /// Put request with selection by id
    /// </summary>
    /// <param name="id">Index of search</param>
    /// <param name="driverToPut">DriverDto object</param>
    /// <returns>Change object or 404Error</returns>
    [HttpPut("{id:int}")]
    public IActionResult Put(int id, [FromBody] DriverDto driverToPut)
    {
        var driver = _taxiRepository.Drivers.FirstOrDefault(driver => driver.Id == id);
        if (driver != null)
        {
            _logger.LogInformation("Put driver");
            _mapper.Map(driverToPut, driver);
            return Ok();
        }
        _logger.LogInformation("Not found a driver with id: {id}", id);
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
        var driver = _taxiRepository.Drivers.FirstOrDefault(driver => driver.Id == id);
        if (driver != null)
        {
            _logger.LogInformation("Delete driver");
            _taxiRepository.Drivers.Remove(driver);
            return Ok();
        }
        _logger.LogInformation("Not found a driver with id: {id}", id);
        return NotFound();
    }
}