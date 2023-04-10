using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shops.Domain;
using Shops.Server.Dto;
using Shops.Server.Repository;

namespace Shops.Server.Controllers;
/// <summary>
/// Controller for product group
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProductGroupController : ControllerBase
{
    private readonly ILogger<ProductGroupController> _logger;
    private readonly IShopRepository _shopRepository;
    private readonly IMapper _mapper;
    /// <summary>
    /// Controller constructor 
    /// </summary>
    public ProductGroupController(ILogger<ProductGroupController> logger, IShopRepository shopRepository, IMapper mapper)
    {
        _logger = logger;
        _shopRepository = shopRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Return list of product group
    /// </summary>
    /// <returns>Ok(List of product group)</returns>
    [HttpGet]
    public ActionResult<IEnumerable<ProductGroupGetDto>> Get()
    {
        _logger.LogInformation("Get list of product group");
        return Ok(_shopRepository.ProductGroups.Select(productGroup => _mapper.Map<ProductGroupGetDto>(productGroup)));
    }
    /// <summary>
    /// Return product group by id
    /// </summary>
    /// <param name="id"> product group id</param>
    /// <returns>Ok (the product group found by specified id) or NotFound</returns>
    [HttpGet("{id}")]
    public ActionResult<ProductGroupGetDto> Get(int id)
    {
        var productGroup = _shopRepository.ProductGroups.FirstOrDefault(productGroup => productGroup.Id == id);
        if (productGroup == null)
        {
            _logger.LogInformation($"Not found product group with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"product group with id = {id}");
            return Ok(_mapper.Map<ProductGroupGetDto>(productGroup));
        }
    }
    /// <summary>
    /// Add new product group in list of product group
    /// </summary>
    /// <param name="productGroup"> New product group</param>
    /// <returns>Ok(add new product group) </returns>
    [HttpPost]
    public IActionResult Post([FromBody] ProductGroupPostDto productGroup)
    {

        var newId = _shopRepository.ProductGroups
            .Select(productGroup => productGroup.Id)
            .DefaultIfEmpty()
            .Max() + 1;
        var newProductGroup = _mapper.Map<ProductGroup>(productGroup);
        newProductGroup.Id = newId;
        _shopRepository.ProductGroups.Add(newProductGroup);
        _logger.LogInformation($"Post product group, id = {newId}");
        return Ok();
    }
    /// <summary>
    /// Updates product group information
    /// </summary>
    /// <param name="id">product group id</param>
    /// <param name="productGroupToPut">New information</param>
    /// <returns>Ok (update product group by id) or NotFound</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ProductGroupPostDto productGroupToPut)
    {
        var productGroup = _shopRepository.ProductGroups.FirstOrDefault(productGroup => productGroup.Id == id);
        if (productGroup == null)
        {
            _logger.LogInformation($"Not found product group with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Update information product group with id = {id}");
            _mapper.Map<ProductGroupPostDto, ProductGroup>(productGroupToPut, productGroup);
            return Ok();
        }
    }
    /// <summary>
    /// Delete product group by id
    /// </summary>
    /// <param name="id">product group id</param>
    /// <returns>Ok (delete product group by id) or NotFound</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var productGroup = _shopRepository.ProductGroups.FirstOrDefault(productGroup => productGroup.Id == id);
        if (productGroup == null)
        {
            _logger.LogInformation($"Not found product group with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Delete product group with id = {id}");
            _shopRepository.ProductGroups.Remove(productGroup);
            return Ok();
        }
    }
}
