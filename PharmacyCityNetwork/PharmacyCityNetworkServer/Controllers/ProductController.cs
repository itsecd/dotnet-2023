using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyCityNetwork.Server.Dto;
using PharmacyCityNetwork.Server.Repository;

namespace PharmacyCityNetwork.Server.Controllers;
/// <summary>
/// Product controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;

    private readonly IPharmacyCityNetworkRepository _pharmacyCityNetworkRepository;
    private readonly IMapper _mapper;
    public ProductController(ILogger<ProductController> logger, IPharmacyCityNetworkRepository pharmacyCityNetworkRepository, IMapper mapper)
    {
        _logger = logger;
        _pharmacyCityNetworkRepository = pharmacyCityNetworkRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Get info about all products
    /// </summary>
    /// <returns>Return all products</returns>
    [HttpGet]
    public IEnumerable<ProductGetDto> Get()
    {
        return _pharmacyCityNetworkRepository.Products.Select(product => _mapper.Map<ProductGetDto>(product));
    }
    /// <summary>
    /// Get product info by id
    /// </summary>
    /// <param name="id">Product Id</param>
    /// <returns>Return product with specified id</returns>
    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
        var product = _pharmacyCityNetworkRepository.Products.FirstOrDefault(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation("Not found product: {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<ProductGetDto>(product));
        }
    }
    /// <summary>
    /// Post a new product
    /// </summary>
    /// <param name="product">Product class instance to insert to table</param>
    [HttpPost]
    public void Post([FromBody] ProductPostDto product)
    {
        _pharmacyCityNetworkRepository.Products.Add(_mapper.Map<Product>(product));
    }
    /// <summary>
    /// Put product
    /// </summary>
    /// <param name="id">An id of product which would be changed</param>
    /// <param name="productToPut">Product class instance to insert to table</param>
    /// <returns>Signalization of success of error</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ProductPostDto productToPut)
    {
        var product = _pharmacyCityNetworkRepository.Products.FirstOrDefault(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation("Not found product: {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(productToPut, product);
            return Ok();
        }
    }
    /// <summary>
    /// Delete a product
    /// </summary>
    /// <param name="id">An id of product which would be deleted</param>
    /// <returns>Signalization of success of error</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = _pharmacyCityNetworkRepository.Products.FirstOrDefault(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation("Not found product: {id}", id);
            return NotFound();
        }
        else
        {
            _pharmacyCityNetworkRepository.Products.Remove(product);
            return Ok();
        }
    }
}