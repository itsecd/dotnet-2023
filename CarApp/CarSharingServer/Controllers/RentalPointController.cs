using Microsoft.AspNetCore.Mvc;
using CarSharingDomain;
using CarSharingServer.Dto;
using AutoMapper;
using CarSharingServer.Repository;

namespace CarSharingServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RentalPointController : ControllerBase
{
    private readonly ILogger<RentalPointController> _logger;
    private readonly ICarSharingRepository _carRepository;
    private readonly IMapper _mapper;
    public RentalPointController(ILogger<RentalPointController> logger, ICarSharingRepository carRepository, IMapper mapper)
    {
        _logger = logger;
        _carRepository = carRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<RentalPoint> Get()
    {
        _logger.LogInformation("Get the rental points");
        return _carRepository.RentalPoints;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<RentalPoint> Get(uint id)
    {
        _logger.LogInformation($"Get the rental point with id {id} ", id);
        var rentalPointInfo = _carRepository.RentalPoints.FirstOrDefault(info => info.PointId == id);
        if (rentalPointInfo == null)
        {
            _logger.LogInformation($"Not found a rental point with id {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(rentalPointInfo);
        }
    }
   /// <summary>
   /// 
   /// </summary>
   /// <param name="rentalPoint"></param>
    [HttpPost]
    public void Post([FromBody] RentalPointPostDto rentalPoint)
    {
        _logger.LogInformation("Post a new rental point");
        _carRepository.RentalPoints.Add(_mapper.Map<RentalPoint>(rentalPoint));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="rentalPointToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(uint id, [FromBody] RentalPointPostDto rentalPointToPut)
    {
        var rentalPoint = _carRepository.RentalPoints.FirstOrDefault(info => info.PointId == id);
        if (rentalPoint == null)
        {
            _logger.LogInformation($"Not found a rental point with id {id}", id);
            return NotFound();
        }
        else
        {

            _mapper.Map(rentalPointToPut, rentalPoint);
            _logger.LogInformation("Put a new rental point - success");
            return Ok();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(uint id)
    {
        var rentalPoint = _carRepository.RentalPoints.FirstOrDefault(info => info.PointId == id);
        if (rentalPoint == null)
        {
            _logger.LogInformation($"Not found a rental point with id {id}", id);
            return NotFound();
        }
        else
        {
            _carRepository.RentalPoints.Remove(rentalPoint);
            _logger.LogInformation("Delete a rental point - success");
            return Ok();
        }
    }
}