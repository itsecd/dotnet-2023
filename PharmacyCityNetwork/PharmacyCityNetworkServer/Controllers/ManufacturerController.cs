using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyCityNetwork.Server.Dto;
using PharmacyCityNetwork.Server.Repository;

namespace PharmacyCityNetwork.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ManufacturerController : ControllerBase
{
    private readonly ILogger<ManufacturerController> _logger;

    private readonly IPharmacyCityNetworkRepository _manufacturersRepository;
    private readonly IMapper _mapper;
    public ManufacturerController(ILogger<ManufacturerController> logger, IPharmacyCityNetworkRepository manufacturersRepository, IMapper mapper)
    {
        _logger = logger;
        _manufacturersRepository = manufacturersRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<ManufacturerGetDto> Get()
    {
        return _manufacturersRepository.Manufacturers.Select(manufacturer => _mapper.Map<ManufacturerGetDto>(manufacturer));
    }

    [HttpGet("{id}")]
    public ActionResult<Manufacturer> Get(int id)
    {
        var manufacturer = _manufacturersRepository.Manufacturers.FirstOrDefault(manufacturer => manufacturer.Id == id);
        if (manufacturer == null)
        {
            _logger.LogInformation($"Not found manufacturer: {id}");
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<ManufacturerGetDto>(manufacturer));
        }
    }

    [HttpPost]
    public void Post([FromBody] ManufacturerPostDto manufacturer)
    {
        _manufacturersRepository.Manufacturers.Add(_mapper.Map<Manufacturer>(manufacturer));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ManufacturerPostDto manufacturerToPut)
    {
        var manufacturer = _manufacturersRepository.Manufacturers.FirstOrDefault(manufacturer => manufacturer.Id == id);
        if (manufacturer == null)
        {
            _logger.LogInformation("Not found manufacturer: {id}",  id);
            return NotFound();
        }
        else
        {
           _mapper.Map(manufacturerToPut, manufacturer);
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var manufacturer = _manufacturersRepository.Manufacturers.FirstOrDefault(manufacturer => manufacturer.Id == id);
        if (manufacturer == null)
        {
            _logger.LogInformation($"Not found manufacturer: {id}");
            return NotFound();
        }
        else
        {
            _manufacturersRepository.Manufacturers.Remove(manufacturer);
            return Ok();
        }
    }
}