using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransportMgmt.Domain;
using TransportMgmtServer.Dto;
using TransportMgmtServer.Repository;

namespace TransportMgmtServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModelController : ControllerBase
{
    private readonly ILogger<ModelController> _logger;

    private readonly ITransportMgmtRepository _transportRepository;

    private readonly IMapper _mapper;

    public ModelController(ILogger<ModelController> logger, ITransportMgmtRepository transportRepository, IMapper mapper)
    {
        _logger = logger;
        _transportRepository = transportRepository;
        _mapper = mapper;
    }

    [HttpGet]

    public IEnumerable<ModelGetDto> Get()
    {
        return _transportRepository.Models.Select(model => _mapper.Map<ModelGetDto>(model));
    }

    [HttpGet("{id}")]

    public ActionResult<ModelGetDto> Get(int id)
    {
        var model = _transportRepository.Models.FirstOrDefault(model => model.Id == id);
        if (model == null)
        {
            _logger.LogInformation("Not found model: {id}", id);
            return NotFound();
        }
        else return Ok(_mapper.Map<ModelGetDto>(model));
    }

    [HttpPost]

    public void Post([FromBody] ModelPostDto model)
    {
        _transportRepository.Models.Add(_mapper.Map<Model>(model));
    }

    [HttpPut("{id}")]

    public IActionResult Put(int id, [FromBody] ModelPostDto modelToPut)
    {
        var model = _transportRepository.Models.FirstOrDefault(model => model.Id == id);
        if (model == null)
        {
            _logger.LogInformation("Not found model: {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(modelToPut, model);
            return Ok();
        }
    }

    [HttpDelete("{id}")]

    public IActionResult Delete(int id)
    {
        var model = _transportRepository.Models.FirstOrDefault(model => model.Id == id);
        if (model == null)
        {
            _logger.LogInformation("Not found model: {id}", id);
            return NotFound();
        }
        else
        {
            _transportRepository.Models.Remove(model);
            return Ok();
        }
    }
}
