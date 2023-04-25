using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyCityNetwork.Server.Dto;
using PharmacyCityNetwork.Server.Repository;

namespace PharmacyCityNetwork.Server.Controllers;
/// <summary>
/// Manufacturer controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ManufacturerController : ControllerBase
{
    private readonly ILogger<ManufacturerController> _logger;

    private readonly IPharmacyCityNetworkRepository _pharmacyCityNetworkRepository;
    private readonly IMapper _mapper;
    public ManufacturerController(ILogger<ManufacturerController> logger, IPharmacyCityNetworkRepository pharmacyCityNetworkRepository, IMapper mapper)
    {
        _logger = logger;
        _pharmacyCityNetworkRepository = pharmacyCityNetworkRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Get info about all manufacturers
    /// </summary>
    /// <returns>Return all manufacturers</returns>
    [HttpGet]
    public IEnumerable<ManufacturerGetDto> Get()
    {
        return _pharmacyCityNetworkRepository.Manufacturers.Select(manufacturer => _mapper.Map<ManufacturerGetDto>(manufacturer));
    }
    /// <summary>
    /// Get manufacturer info by id
    /// </summary>
    /// <param name="id">Manufacturer Id</param>
    /// <returns>Return manufacturer with specified id</returns>
    [HttpGet("{id}")]
    public ActionResult<Manufacturer> Get(int id)
    {
        var manufacturer = _pharmacyCityNetworkRepository.Manufacturers.FirstOrDefault(manufacturer => manufacturer.Id == id);
        if (manufacturer == null)
        {
            _logger.LogInformation("Not found manufacturer: {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<ManufacturerGetDto>(manufacturer));
        }
    }
    /// <summary>
    /// Post a new manufacturer
    /// </summary>
    /// <param name="manufacturer">Manufacturer class instance to insert to table</param>
    [HttpPost]
    public void Post([FromBody] ManufacturerPostDto manufacturer)
    {
        _pharmacyCityNetworkRepository.Manufacturers.Add(_mapper.Map<Manufacturer>(manufacturer));
    }
    /// <summary>
    /// Put manufacturer
    /// </summary>
    /// <param name="id">An id of manufacturer which would be changed</param>
    /// <param name="manufacturerToPut">Manufacturer class instance to insert to table</param>
    /// <returns>Signalization of success of error</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ManufacturerPostDto manufacturerToPut)
    {
        var manufacturer = _pharmacyCityNetworkRepository.Manufacturers.FirstOrDefault(manufacturer => manufacturer.Id == id);
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
    /// <summary>
    /// Delete a manufacturer
    /// </summary>
    /// <param name="id">An id of manufacturer which would be deleted</param>
    /// <returns>Signalization of success of error</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var manufacturer = _pharmacyCityNetworkRepository.Manufacturers.FirstOrDefault(manufacturer => manufacturer.Id == id);
        if (manufacturer == null)
        {
            _logger.LogInformation("Not found manufacturer: {id}", id);
            return NotFound();
        }
        else
        {
            _pharmacyCityNetworkRepository.Manufacturers.Remove(manufacturer);
            return Ok();
        }
    }
}