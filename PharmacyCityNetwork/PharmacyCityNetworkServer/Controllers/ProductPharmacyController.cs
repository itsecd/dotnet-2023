using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyCityNetwork.Server.Dto;
using PharmacyCityNetwork.Server.Repository;

namespace PharmacyCityNetwork.Server.Controllers;
/// <summary>
/// ProductPharmacy controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProductPharmacyController : ControllerBase
{
    private readonly ILogger<ProductPharmacyController> _logger;

    private readonly IPharmacyCityNetworkRepository _pharmacyCityNetworkRepository;
    private readonly IMapper _mapper;
    public ProductPharmacyController(ILogger<ProductPharmacyController> logger, IPharmacyCityNetworkRepository pharmacyCityNetworkRepository, IMapper mapper)
    {
        _logger = logger;
        _pharmacyCityNetworkRepository = pharmacyCityNetworkRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Get info about all productPharmacys
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<ProductPharmacyGetDto> Get()
    {
        return _pharmacyCityNetworkRepository.ProductPharmacys.Select(productPharmacy => _mapper.Map<ProductPharmacyGetDto>(productPharmacy));
    }
    /// <summary>
    /// Get productPharmacy info by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<ProductPharmacy> Get(int id)
    {
        var productPharmacy = _pharmacyCityNetworkRepository.ProductPharmacys.FirstOrDefault(productPharmacy => productPharmacy.Id == id);
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
    /// <summary>
    /// Post a new productPharmacy
    /// </summary>
    /// <param name="productPharmacy"></param>
    [HttpPost]
    public void Post([FromBody] ProductPharmacyPostDto productPharmacy)
    {
        _pharmacyCityNetworkRepository.ProductPharmacys.Add(_mapper.Map<ProductPharmacy>(productPharmacy));
    }
    /// <summary>
    /// Put productPharmacy
    /// </summary>
    /// <param name="id"></param>
    /// <param name="productPharmacyToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ProductPharmacyPostDto productPharmacyToPut)
    {
        var productPharmacy = _pharmacyCityNetworkRepository.ProductPharmacys.FirstOrDefault(productPharmacy => productPharmacy.Id == id);
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
    /// <summary>
    /// Delete a productPharmacy
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var productPharmacy = _pharmacyCityNetworkRepository.ProductPharmacys.FirstOrDefault(productPharmacy => productPharmacy.Id == id);
        if (productPharmacy == null)
        {
            _logger.LogInformation($"Not found productPharmacy: {id}");
            return NotFound();
        }
        else
        {
            _pharmacyCityNetworkRepository.ProductPharmacys.Remove(productPharmacy);
            return Ok();
        }
    }
}