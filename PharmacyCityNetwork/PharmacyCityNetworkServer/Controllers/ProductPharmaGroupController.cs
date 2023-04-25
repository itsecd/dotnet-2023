using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyCityNetwork.Server.Dto;
using PharmacyCityNetwork.Server.Repository;

namespace PharmacyCityNetwork.Server.Controllers;
/// <summary>
/// ProductPharmaGroup controller
/// </summary>
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
    /// <summary>
    /// Get info about all productPharmaGroups
    /// </summary>
    /// <returns>Return all productPharmaGroups</returns>
    [HttpGet]
    public IEnumerable<ProductPharmaGroupGetDto> Get()
    {
        return _pharmacyCityNetworkRepository.ProductPharmaGroups.Select(productPharmaGroup => _mapper.Map<ProductPharmaGroupGetDto>(productPharmaGroup));
    }
    /// <summary>
    /// Get productPharmaGroup info by id
    /// </summary>
    /// <param name="id">ProductPharmaGroup Id</param>
    /// <returns>Return productPharmaGroup with specified id</returns>
    [HttpGet("{id}")]
    public ActionResult<ProductPharmaGroup> Get(int id)
    {
        var productPharmaGroup = _pharmacyCityNetworkRepository.ProductPharmaGroups.FirstOrDefault(productPharmaGroup => productPharmaGroup.Id == id);
        if (productPharmaGroup == null)
        {
            _logger.LogInformation("Not found productPharmaGroup: {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<ProductPharmaGroupGetDto>(productPharmaGroup));
        }
    }
    /// <summary>
    /// Post a new productPharmaGroup
    /// </summary>
    /// <param name="productPharmaGroup">ProductPharmaGroup class instance to insert to table</param>
    [HttpPost]
    public void Post([FromBody] ProductPharmaGroupPostDto productPharmaGroup)
    {
        _pharmacyCityNetworkRepository.ProductPharmaGroups.Add(_mapper.Map<ProductPharmaGroup>(productPharmaGroup));
    }
    /// <summary>
    /// Put productPharmaGroup
    /// </summary>
    /// <param name="id">An id of productPharmaGroup which would be changed</param>
    /// <param name="productPharmaGroupToPut">ProductPharmaGroup class instance to insert to table</param>
    /// <returns>Signalization of success of error</returns>
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
    /// <summary>
    /// Delete a productPharmaGroup
    /// </summary>
    /// <param name="id">An id of productPharmaGroup which would be deleted</param>
    /// <returns>Signalization of success of error</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var productPharmaGroup = _pharmacyCityNetworkRepository.ProductPharmaGroups.FirstOrDefault(productPharmaGroup => productPharmaGroup.Id == id);
        if (productPharmaGroup == null)
        {
            _logger.LogInformation("Not found productPharmaGroup: {id}", id);
            return NotFound();
        }
        else
        {
            _pharmacyCityNetworkRepository.ProductPharmaGroups.Remove(productPharmaGroup);
            return Ok();
        }
    }
}