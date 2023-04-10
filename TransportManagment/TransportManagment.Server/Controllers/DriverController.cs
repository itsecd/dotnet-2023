using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TransportManagment.Classes;
using TransportManagment.Server.Dto;
using TransportManagment.Server.Repository;
namespace TransportManagment.Server.Controllers;
/// <summary>
/// Controller of driver
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DriverControlller : ControllerBase
{
    private readonly ILogger<DriverControlller> _logger;
    private readonly ITransportManagmentRepository _driverRepository;
    private readonly IMapper _mapper;
    public DriverControlller(ILogger<DriverControlller> logger, ITransportManagmentRepository driverRepository, IMapper mapper)
    {
        _logger = logger;
        _driverRepository = driverRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Method returns list of drivers
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<DriverGetDto> Get()
    {
        _logger.LogInformation("Get drivers");
        return _driverRepository.Drivers.Select(driver => _mapper.Map<DriverGetDto>(driver));
    }
    /// <summary>
    /// Method returns info about a driver with this id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<DriverGetDto> Get(int id)
    {
        var res = _driverRepository.Drivers.FirstOrDefault(driver => driver.DriverId == id);
        if (res == null)
        {
            _logger.LogInformation("Driver is not found");
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get driver with id = {id}", id);
            return Ok(_mapper.Map<DriverGetDto>(res));
        }
    }
    /// <summary>
    /// Method posts a new driver
    /// </summary>
    /// <param name="driver"></param>
    [HttpPost]
    public void Post([FromBody] DriverPostDto driver)
    {
        _driverRepository.Drivers.Add(_mapper.Map<Driver>(driver));
    }
    /// <summary>
    /// Method changes a selected driver
    /// </summary>
    /// <param name="id"></param>
    /// <param name="driverToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DriverPostDto driverToPut)
    {
        var res = _driverRepository.Drivers.FirstOrDefault(driver => driver.DriverId == id);
        if (res == null)
        {
            _logger.LogInformation("Driver is not found");
            return NotFound();
        }
        else
        {
            _mapper.Map(driverToPut, res);
            _logger.LogInformation("Get driver with id = {id}", id);
            return Ok();
        }
    }
    /// <summary>
    /// Method delets selected driver
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var res = _driverRepository.Drivers.FirstOrDefault(driver => driver.DriverId == id);
        if (res == null)
        {
            _logger.LogInformation("Driver is not found");
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Delete driver with id = {id}", id);
            _driverRepository.Drivers.Remove(res);
            return Ok();
        }

    }
}
