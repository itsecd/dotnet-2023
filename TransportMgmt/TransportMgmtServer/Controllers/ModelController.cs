using Microsoft.AspNetCore.Mvc;
using TransportMgmt.Domain;
using TransportMgmtServer.Dto;

namespace TransportMgmtServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModelController : Controller
{
    private readonly ILogger<TransportMgmtRepository> _logger;

    private readonly TransportMgmtRepository _transportRepository;

    public ModelController(ILogger<TransportMgmtRepository> logger, TransportMgmtRepository transportRepository)
    {
        _logger = logger;
        _transportRepository = transportRepository;
    }

    [HttpGet]

    public IEnumerable<Model> Get()
    {
        return _transportRepository.Models;
    }

    [HttpGet("{id}")]

    public ActionResult<Model> Get(int id)
    {
        var model = _transportRepository.Models.FirstOrDefault(model => model.Id == id);
        if (model == null)
        {
            _logger.LogInformation($"Not found model: {id}");
            return NotFound();
        }
        else return Ok(model);
    }

    [HttpPost]

    public void Post([FromBody] ModelPostDto model) 
    {
        _transportRepository.Models.Add(new Model
        {
            ModelName = model.ModelName,
            FloorLevel = model.FloorLevel,
            MaxCapacity = model.MaxCapacity
        });
    }
}
