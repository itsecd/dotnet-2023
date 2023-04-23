using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyCityNetwork.Server.Dto;
using PharmacyCityNetwork.Server.Repository;

namespace PharmacyCityNetwork.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductPharmacyController : ControllerBase
{
    private readonly ILogger<ProductPharmacyController> _logger;

    private readonly IPharmacyCityNetworkRepository _productPharmacysRepository;
    private readonly IMapper _mapper;
    public ProductPharmacyController(ILogger<ProductPharmacyController> logger, IPharmacyCityNetworkRepository productPharmacysRepository, IMapper mapper)
    {
        _logger = logger;
        _productPharmacysRepository = productPharmacysRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<ProductPharmacyGetDto> Get()
    {
        return _productPharmacysRepository.ProductPharmacys.Select(productPharmacy => _mapper.Map<ProductPharmacyGetDto>(productPharmacy));
    }

    [HttpGet("{id}")]
    public ActionResult<ProductPharmacy> Get(int id)
    {
        var productPharmacy = _productPharmacysRepository.ProductPharmacys.FirstOrDefault(productPharmacy => productPharmacy.PharmacyId == id);
        if (productPharmacy == null)
        {
            _logger.LogInformation($"Not found productPharmacy: {id}");
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<ProductPharmacyGetDto>(productPharmacy));
        }
    }

    [HttpPost]
    public void Post([FromBody] ProductPharmacyPostDto productPharmacy)
    {
        _productPharmacysRepository.ProductPharmacys.Add(_mapper.Map<ProductPharmacy>(productPharmacy));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ProductPharmacyPostDto productPharmacyToPut)
    {
        var productPharmacy = _productPharmacysRepository.ProductPharmacys.FirstOrDefault(productPharmacy => productPharmacy.PharmacyId == id);
        if (productPharmacy == null)
        {
            _logger.LogInformation("Not found productPharmacy: {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(productPharmacyToPut, productPharmacy);
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var productPharmacy = _productPharmacysRepository.ProductPharmacys.FirstOrDefault(productPharmacy => productPharmacy.PharmacyId == id);
        if (productPharmacy == null)
        {
            _logger.LogInformation($"Not found productPharmacy: {id}");
            return NotFound();
        }
        else
        {
            _productPharmacysRepository.ProductPharmacys.Remove(productPharmacy);
            return Ok();
        }
    }
}