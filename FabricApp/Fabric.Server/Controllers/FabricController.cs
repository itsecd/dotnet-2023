using AutoMapper;
using Fabrics.Domain;
using Fabrics.Server.Dto;
using Fabrics.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fabrics.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FabricController : ControllerBase
{
    private readonly ILogger<FabricController> _logger;

    private readonly IFabricsRepository _fabricsRepository;

    private readonly IMapper _mapper;
    public FabricController(ILogger<FabricController> logger, IFabricsRepository fabricsRepository, IMapper mapper)
    {
        _logger = logger;
        _fabricsRepository = fabricsRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Returns list of all fabrics.
    /// </summary>
    /// <returns>List of fabrics</returns>
    [HttpGet]
    public IEnumerable<FabricGetDto> Get()
    {
        _logger.LogInformation("Get fabric");
        return _fabricsRepository.Fabrics.Select(fabric =>_mapper.Map<FabricGetDto>(fabric));
    }

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

    [HttpPost]
    public void Post([FromBody] FabricPostDto fabric)
    {
        _fabricsRepository.Fabrics.Add(_mapper.Map<Fabric>(fabric));
    }

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
