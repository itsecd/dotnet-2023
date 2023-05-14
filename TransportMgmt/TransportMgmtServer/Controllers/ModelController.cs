using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportMgmt.Domain;
using TransportMgmtServer.Dto;

namespace TransportMgmtServer.Controllers;

/// <summary>
/// Controller for model
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ModelController : ControllerBase
{
    /// <summary>
    /// Used to store factory contex
    /// </summary>
    private readonly IDbContextFactory<TransportMgmtContext> _contextFactory;
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<ModelController> _logger;
    /// <summary>
    /// Used to store map's object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// Controller constructor
    /// </summary>
    public ModelController(IDbContextFactory<TransportMgmtContext> contextFactory, ILogger<ModelController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }
    /// <summary>
    /// Returns a list of all models
    /// </summary>
    /// <returns> Returns a list of all models </returns>
    [HttpGet]
    public async Task<IEnumerable<ModelGetDto>> Get()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get models");
        return _mapper.Map<IEnumerable<ModelGetDto>>(context.Models);
    }
    /// <summary>
    /// Get method that returns model with a specific id
    /// </summary>
    /// <param name="id"> Model id </param>
    /// <returns> Model with required id </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ModelGetDto>> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get model with id= {id}", id);
        var model = await context.Models.FirstOrDefaultAsync(model => model.Id == id);
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
    public async Task Post([FromBody] ModelPostDto model)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        await context.Models.AddAsync(_mapper.Map<Model>(model));
        _logger.LogInformation("Successfully added");
        await context.SaveChangesAsync();
    }
    /// <summary>
    /// Put method which allows change the data of model with a specific id
    /// </summary>
    /// <param name="id"> Model id whose data will change </param>
    /// <param name="modelToPut"> New model data </param>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ModelPostDto modelToPut)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var model = await context.Models.FirstOrDefaultAsync(model => model.Id == id);
        if (model == null)
        {
            _logger.LogInformation("Not found model with id= {id} ", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(modelToPut, model);
            _logger.LogInformation("Successfully updates");
            await context.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Delete method which allows delete a model with a specific id
    /// </summary>
    /// <param name="id"> Model id </param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var model = await context.Models.FirstOrDefaultAsync(model => model.Id == id);
        if (model == null)
        {
            _logger.LogInformation("Not found model with id= {id} ", id);
            return NotFound();
        }
        else
        {
            context.Models.Remove(model);
            _logger.LogInformation("Successfully removed");
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
