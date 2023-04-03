using AutoMapper;
using Fabrics.Domain;
using Fabrics.Server.Dto;
using Fabrics.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fabrics.Server.Controllers;
/// <summary>
/// Fabric controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class FabricController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<FabricController> _logger;
    /// <summary>
    /// Used to store repository
    /// </summary>
    private readonly IFabricsRepository _fabricsRepository;
    /// <summary>
    /// Used to store map-object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="fabricsRepository"></param>
    /// <param name="mapper"></param>
    public FabricController(ILogger<FabricController> logger, IFabricsRepository fabricsRepository, IMapper mapper)
    {
        _logger = logger;
        _fabricsRepository = fabricsRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Get list of all fabrics.
    /// </summary>
    /// <returns>List of fabrics</returns>
    [HttpGet]
    public IEnumerable<FabricGetDto> Get()
    {
        _logger.LogInformation("Get fabric");
        return _fabricsRepository.Fabrics.Select(fabric => _mapper.Map<FabricGetDto>(fabric));
    }
    /// <summary>
    /// Get fabric by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Fabric</returns>
    [HttpGet("{id}")]
    public ActionResult<FabricGetDto> Get(int id)
    {
        var fabric = _fabricsRepository.Fabrics.FirstOrDefault(fabric => fabric.Id == id);
        if (fabric == null)
        {
            _logger.LogInformation("Not found fabric:{id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<FabricGetDto>(fabric));
        }
    }
    /// <summary>
    /// Post new Fabric
    /// </summary>
    /// <param name="fabric"></param>
    [HttpPost]
    public void Post([FromBody] FabricPostDto fabric)
    {
        _fabricsRepository.Fabrics.Add(_mapper.Map<Fabric>(fabric));
    }
    /// <summary>
    /// Put fabric
    /// </summary>
    /// <param name="id"></param>
    /// <param name="fabricToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] FabricPostDto fabricToPut)
    {
        var fabric = _fabricsRepository.Fabrics.FirstOrDefault(fabric => fabric.Id == id);
        if (fabric == null)
        {
            _logger.LogInformation("Not found fabric:{id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(fabricToPut, fabric);
            return Ok();
        }
    }
    /// <summary>
    /// Delete fabric by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var fabric = _fabricsRepository.Fabrics.FirstOrDefault(fabric => fabric.Id == id);
        if (fabric == null)
        {
            _logger.LogInformation("Not found fabric:{id}", id);
            return NotFound();
        }
        else
        {
            _fabricsRepository.Fabrics.Remove(fabric);
            return Ok();
        }
    }
}
