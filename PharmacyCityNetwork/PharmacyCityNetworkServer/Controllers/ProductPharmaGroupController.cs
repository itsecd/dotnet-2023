using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyCityNetwork.Server.Dto;
using PharmacyCityNetwork.Server.Repository;

namespace PharmacyCityNetwork.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductPharmaGroupController : ControllerBase
{
    private readonly ILogger<ProductPharmaGroupController> _logger;

    private readonly IPharmacyCityNetworkRepository _pharmacyCityNetworkRepository;
    private readonly IMapper _mapper;
    public ProductPharmaGroupController(ILogger<ProductPharmaGroupController> logger, IPharmacyCityNetworkRepository pharmacyCityNetworkRepository, IMapper mapper)
    {
        _logger = logger;
        _pharmacyCityNetworkRepository = pharmacyCityNetworkRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<ProductPharmaGroupGetDto> Get()
    {
        return _pharmacyCityNetworkRepository.ProductPharmaGroups.Select(productPharmaGroup => _mapper.Map<ProductPharmaGroupGetDto>(productPharmaGroup));
    }

    [HttpGet("{id}")]
    public ActionResult<ProductPharmaGroup> Get(int id)
    {
        var productPharmaGroup = _pharmacyCityNetworkRepository.ProductPharmaGroups.FirstOrDefault(productPharmaGroup => productPharmaGroup.Id == id);
        if (productPharmaGroup == null)
        {
            _logger.LogInformation($"Not found productPharmaGroup: {id}");
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<ProductPharmaGroupGetDto>(productPharmaGroup));
        }
    }

    [HttpPost]
    public void Post([FromBody] ProductPharmaGroupPostDto productPharmaGroup)
    {
        _pharmacyCityNetworkRepository.ProductPharmaGroups.Add(_mapper.Map<ProductPharmaGroup>(productPharmaGroup));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ProductPharmaGroupPostDto productPharmaGroupToPut)
    {
        var productPharmaGroup = _pharmacyCityNetworkRepository.ProductPharmaGroups.FirstOrDefault(productPharmaGroup => productPharmaGroup.Id == id);
        if (productPharmaGroup == null)
        {
            _logger.LogInformation("Not found productPharmaGroup: {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(productPharmaGroupToPut, productPharmaGroup);
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var productPharmaGroup = _pharmacyCityNetworkRepository.ProductPharmaGroups.FirstOrDefault(productPharmaGroup => productPharmaGroup.Id == id);
        if (productPharmaGroup == null)
        {
            _logger.LogInformation($"Not found productPharmaGroup: {id}");
            return NotFound();
        }
        else
        {
            _pharmacyCityNetworkRepository.ProductPharmaGroups.Remove(productPharmaGroup);
            return Ok();
        }
    }
}