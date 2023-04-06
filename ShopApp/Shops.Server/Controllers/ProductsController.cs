using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shops.Domain;
using Shops.Server.Dto;
using Shops.Server.Repository;

namespace Shops.Server.Controllers;
/// <summary>
/// Controller for products
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IShopRepository _shopRepository;
    private readonly IMapper _mapper;
    /// <summary>
    /// Controller constructor 
    /// </summary>
    public ProductsController(ILogger<ProductsController> logger, IShopRepository shopRepository, IMapper mapper)
    {
        _logger = logger;
        _shopRepository = shopRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Return list of propduct
    /// </summary>
    /// <returns>List of propduct</returns>
    [HttpGet]
    public ActionResult<IEnumerable<ProductGetDto>> Get()
    {
        return Ok(_shopRepository.Products.Select(product => _mapper.Map<ProductGetDto>(product)));
    }
    /// <summary>
    /// Return product by id
    /// </summary>
    /// <param name="id"> Product id</param>
    /// <returns>Product</returns>
    [HttpGet("{id}")]
    public ActionResult<ProductGetDto> Get(int id)
    {

        var product = _shopRepository.Products.FirstOrDefault(product => product.ProductId == id);
        if (product == null)
        {
            _logger.LogInformation($"Not found product with barcode = {id}");
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<ProductGetDto>(product));
        }
    }
    /// <summary>
    /// Add new product in list of products
    /// </summary>
    /// <param name="product"> New product</param>
    /// <returns>Status code - 200 </returns>
    [HttpPost]
    public IActionResult Post([FromBody] ProductPostDto product)
    {

        _shopRepository.Products.Add(_mapper.Map<Product>(product));
        return Ok();
    }
    /// <summary>
    /// Updates product information
    /// </summary>
    /// <param name="id">Product id</param>
    /// <param name="productToPut">New information</param>
    /// <returns>Status code 404 if not found, elsee status code 200</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ProductPostDto productToPut)
    {
        var product = _shopRepository.Products.FirstOrDefault(product => product.ProductId == id);
        if (product == null)
        {
            return NotFound();
        }
        else
        {
            _mapper.Map<ProductPostDto, Product>(productToPut, product);
            return Ok();
        }
    }
    /// <summary>
    /// Update storage limit date product
    /// </summary>
    /// <param name="id">Product id</param>
    /// <param name="newDateLimite">New storage limit date</param>
    /// <returns>Status code 404 if not found, elsee status code 200</returns>
    [HttpPut("{id}, {update-limite-date}")]
    public IActionResult PutDate(int id, [FromBody] DateTime newDateLimite)
    {
        var product = _shopRepository.Products.FirstOrDefault(product => product.ProductId == id);
        if (product == null)
        {
            return NotFound();
        }
        else
        {
            product.StorageLimitDate = newDateLimite;
            return Ok();
        }
    }
    /// <summary>
    /// Delete product by id
    /// </summary>
    /// <param name="id">Product id</param>
    /// <returns>Status code 404 if not found, elsee status code 200</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = _shopRepository.Products.FirstOrDefault(product => product.ProductId == id);
        if (product == null)
        {
            return NotFound();
        }
        else
        {
            _shopRepository.Products.Remove(product);
            return Ok();
        }
    }
}
