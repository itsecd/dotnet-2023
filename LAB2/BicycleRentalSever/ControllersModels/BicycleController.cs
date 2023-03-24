using AutoMapper;
using BicycleRentals;
using BicycleSever.Dto;
using BicycleSever.Respostory;
using Microsoft.AspNetCore.Mvc;

namespace BicycleSever.Controllers;

[Route("api/Models/[controller]")]
[ApiController]
public class BicycleController : ControllerBase
{
    private readonly ILogger<BicycleTypeController> _logger;

    private readonly IBicycleRentalRespostory _bicycleRespostory;

    private readonly IMapper _mapper;
    public BicycleController(ILogger<BicycleTypeController> logger, IBicycleRentalRespostory respostory, IMapper mapper)
    {
        _logger = logger;
        _bicycleRespostory = respostory;
        _mapper = mapper;
    }
 
    [HttpGet]
    public IEnumerable<BicycleGetDto> Get()
    {
        return _bicycleRespostory.FixBicycles.Select(b=>_mapper.Map<BicycleGetDto>(b));
    }
    
    [HttpGet("{id}")]
    public ActionResult<BicycleGetDto> Get(int id)
    {
        var bicycle = _bicycleRespostory.FixBicycles.FirstOrDefault(b => b.SerialNumber == id);
        if (bicycle == null)
        {
            _logger.LogInformation($"Not found bicycle with id {id}");
            return NotFound();
        }
        else
            return Ok(_mapper.Map<BicycleGetDto>(bicycle));
    }

    [HttpPost]
    public void Post([FromBody] BicyclePostDto b)
    {
        _bicycleRespostory.FixBicycles.Add(_mapper.Map<Bicycle>(b));
        _bicycleRespostory.FixTypes[b.TypeId - 1].Bicycles.Add(_mapper.Map<Bicycle>(b));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] BicyclePostDto b)
    {
        var bicycle = _bicycleRespostory.FixBicycles.FirstOrDefault(b => b.SerialNumber == id);
        if (bicycle == null)
        {
            _logger.LogInformation($"Not found bicycle with id {id}");
            return NotFound();
        }
        else
        {           
            _mapper.Map(b,bicycle); //assign b to bicycle
            return Ok();
        }

    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var bicycle = _bicycleRespostory.FixBicycles.FirstOrDefault(b => b.SerialNumber == id);
        if (bicycle == null)
        {
            _logger.LogInformation($"Not found bicycle with id {id}");
            return NotFound();
        }
        else
        {
            _bicycleRespostory.FixBicycles.Remove(bicycle);
            var bicycleDelete = _bicycleRespostory.FixTypes[bicycle.TypeId - 1].Bicycles.FirstOrDefault(b => b.SerialNumber == bicycle.SerialNumber);
            if (bicycleDelete != null)
                _bicycleRespostory.FixTypes[bicycle.TypeId - 1].Bicycles.Remove(bicycleDelete);
            return Ok();
        }
    }
}
