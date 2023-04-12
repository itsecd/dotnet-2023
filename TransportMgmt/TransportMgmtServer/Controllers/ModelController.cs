using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransportMgmt.Domain;
using TransportMgmtServer.Dto;
using TransportMgmtServer.Repository;

namespace TransportMgmtServer.Controllers;

/// <summary>
/// Controller for model
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ModelController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<ModelController> _logger;
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
    public ModelController(ILogger<ModelController> logger, ITransportMgmtRepository transportRepository, IMapper mapper)
    {
        _logger = logger;
        _transportRepository = transportRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Returns a list of all models
    /// </summary>
    /// <returns> Returns a list of all models </returns>
    [HttpGet]
    public IEnumerable<ModelGetDto> Get()
    {
        _logger.LogInformation("Get models");
        return _transportRepository.Models.Select(model => _mapper.Map<ModelGetDto>(model));
    }
    /// <summary>
    /// Get method that returns model with a specific id
    /// </summary>
    /// <param name="id"> Model id </param>
    /// <returns> Model with required id </returns>
    [HttpGet("{id}")]
    public ActionResult<ModelGetDto> Get(int id)
    {
        _logger.LogInformation("Get model with id= {id}", id);
        var model = _transportRepository.Models.FirstOrDefault(model => model.Id == id);
        if (model == null)
        {
            _logger.LogInformation("Not found model with id= {id} ", id);
            return NotFound();
        }
        else return Ok(_mapper.Map<ModelGetDto>(model));
    }
    /// <summary>
    /// Post method that adding a new model
    /// </summary>
    /// <param name="model"> Added model </param>
    [HttpPost]
    public void Post([FromBody] ModelPostDto model)
    {
        _transportRepository.Models.Add(_mapper.Map<Model>(model));
        _logger.LogInformation("Successfully added");
    }
    /// <summary>
    /// Put method which allows change the data of model with a specific id
    /// </summary>
    /// <param name="id"> Model id whose data will change </param>
    /// <param name="modelToPut"> New model data </param>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ModelPostDto modelToPut)
    {
        var model = _transportRepository.Models.FirstOrDefault(model => model.Id == id);
        if (model == null)
        {
            _logger.LogInformation("Not found model with id= {id} ", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(modelToPut, model);
            _logger.LogInformation("Successfully updates");
            return Ok();
        }
    }
    /// <summary>
    /// Delete method which allows delete a model with a specific id
    /// </summary>
    /// <param name="id"> Model id </param>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var model = _transportRepository.Models.FirstOrDefault(model => model.Id == id);
        if (model == null)
        {
            _logger.LogInformation("Not found model with id= {id} ", id);
            return NotFound();
        }
        else
        {
            _transportRepository.Models.Remove(model);
            _logger.LogInformation("Successfully removed");
            return Ok();
        }
    }
}
