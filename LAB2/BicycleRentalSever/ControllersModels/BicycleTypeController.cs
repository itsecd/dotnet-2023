using Microsoft.AspNetCore.Mvc;
using BicycleRentals;
using BicycleSever.Respostory;

namespace BicycleSever.Controllers;

[Route("api/Models/[controller]")]
[ApiController]
public class BicycleTypeController : ControllerBase
{
    private readonly ILogger<BicycleTypeController> _logger;

    private readonly IBicycleRentalRespostory _bicycleRespostory;
    public BicycleTypeController(ILogger<BicycleTypeController> logger,IBicycleRentalRespostory respostory)
    {
        _logger = logger;
        _bicycleRespostory = respostory;
    }
    
    [HttpGet]
    public IEnumerable<BicycleType> Get()
    {
        return _bicycleRespostory.FixTypes;
    }

    [HttpGet("{id}")]
    public ActionResult<BicycleType> Get(int id)
    {
        var bicycleType = _bicycleRespostory.FixTypes.FirstOrDefault(bt => bt.TypeId == id);
        if (bicycleType == null)
        {
            _logger.LogInformation($"Not found type with id {id}");
            return NotFound();
        }
        else
            return Ok(bicycleType);        
    }    
}
