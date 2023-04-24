using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyCityNetwork.Server.Dto;
using PharmacyCityNetwork.Server.Repository;

namespace PharmacyCityNetwork.Server.Controllers;
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

    [HttpGet]
    public IEnumerable<PharmacyGetDto> Get()
    {
        return _pharmacyCityNetworkRepository.Pharmacys.Select(pharmacy => _mapper.Map<PharmacyGetDto>(pharmacy));
    }

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

    [HttpPost]
    public void Post([FromBody] PharmacyPostDto pharmacy)
    {
        _pharmacyCityNetworkRepository.Pharmacys.Add(_mapper.Map<Pharmacy>(pharmacy));
    }

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