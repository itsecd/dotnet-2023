using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyCityNetwork.Server.Dto;
using PharmacyCityNetwork.Server.Repository;

namespace PharmacyCityNetwork.Server.Controllers;
/// <summary>
/// Pharmacy controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PharmacyController : ControllerBase
{
    private readonly ILogger<PharmacyController> _logger;

    private readonly IPharmacyCityNetworkRepository _pharmacyCityNetworkRepository;
    private readonly IMapper _mapper;
    public PharmacyController(ILogger<PharmacyController> logger, IPharmacyCityNetworkRepository pharmacyCityNetworkRepository, IMapper mapper)
    {
        _logger = logger;
        _pharmacyCityNetworkRepository = pharmacyCityNetworkRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Get info about all pharmacys
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<PharmacyGetDto> Get()
    {
        return _pharmacyCityNetworkRepository.Pharmacys.Select(pharmacy => _mapper.Map<PharmacyGetDto>(pharmacy));
    }
    /// <summary>
    /// Get pharmacy info by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<Pharmacy> Get(int id)
    {
        var pharmacy = _pharmacyCityNetworkRepository.Pharmacys.FirstOrDefault(pharmacy => pharmacy.Id == id);
        if (pharmacy == null)
        {
            _logger.LogInformation($"Not found pharmacy: {id}");
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<PharmacyGetDto>(pharmacy));
        }
    }
    /// <summary>
    /// Post a new pharmacy
    /// </summary>
    /// <param name="pharmacy"></param>
    [HttpPost]
    public void Post([FromBody] PharmacyPostDto pharmacy)
    {
        _pharmacyCityNetworkRepository.Pharmacys.Add(_mapper.Map<Pharmacy>(pharmacy));
    }
    /// <summary>
    /// Put pharmacy
    /// </summary>
    /// <param name="id"></param>
    /// <param name="pharmacyToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] PharmacyPostDto pharmacyToPut)
    {
        var pharmacy = _pharmacyCityNetworkRepository.Pharmacys.FirstOrDefault(pharmacy => pharmacy.Id == id);
        if (pharmacy == null)
        {
            _logger.LogInformation("Not found pharmacy: {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(pharmacyToPut, pharmacy);
            return Ok();
        }
    }
    /// <summary>
    /// Delete a pharmacy
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pharmacy = _pharmacyCityNetworkRepository.Pharmacys.FirstOrDefault(pharmacy => pharmacy.Id == id);
        if (pharmacy == null)
        {
            _logger.LogInformation($"Not found pharmacy: {id}");
            return NotFound();
        }
        else
        {
            _pharmacyCityNetworkRepository.Pharmacys.Remove(pharmacy);
            return Ok();
        }
    }
}