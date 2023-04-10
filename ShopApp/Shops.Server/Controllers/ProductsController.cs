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
    /// <returns>Ok(List of propduct)</returns>
    [HttpGet]
    public ActionResult<IEnumerable<ProductGetDto>> Get()
    {
        _logger.LogInformation("Get list of product");
        return Ok(_shopRepository.Products.Select(product => _mapper.Map<ProductGetDto>(product)));
    }
    /// <summary>
    /// Return product by id
    /// </summary>
    /// <param name="id"> Product id</param>
    /// <returns>Ok (the product found by specified id) or NotFound</returns>
    [HttpGet("{id}")]
    public ActionResult<ProductGetDto> Get(int id)
    {

        var product = _shopRepository.Products.FirstOrDefault(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation($"Not found product with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Product with id = {id}");
            return Ok(_mapper.Map<ProductGetDto>(product));
        }
    }
    /// <summary>
    /// Add new product in list of products
    /// </summary>
    /// <param name="product"> New product</param>
    /// <returns>Ok(add new product) </returns>
    [HttpPost]
    public IActionResult Post([FromBody] ProductPostDto product)
    {

        var newId = _shopRepository.Products
            .Select(product => product.Id)
            .DefaultIfEmpty()
            .Max() + 1;
        var newProduct = _mapper.Map<Product>(product);
        newProduct.Id = newId;
        _shopRepository.Products.Add(newProduct);
        _logger.LogInformation($"Post product, id = {newId}");
        return Ok();
    }
    /// <summary>
    /// Updates product information
    /// </summary>
    /// <param name="id">Product id</param>
    /// <param name="productToPut">New information</param>
    /// <returns>Ok (update product by id) or NotFound</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ProductPostDto productToPut)
    {
        var product = _shopRepository.Products.FirstOrDefault(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation($"Not found product with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Update information product with id = {id}");
            _mapper.Map<ProductPostDto, Product>(productToPut, product);
            return Ok();
        }
    }
    /// <summary>
    /// Update storage limit date product
    /// </summary>
    /// <param name="id">Product id</param>
    /// <param name="newDateLimit">New storage limit date</param>
    /// <returns>Ok (update  limit date product by id) or NotFound</returns>
    [HttpPut("{id}, update-limite-date")]
    public IActionResult PutDate(int id, [FromBody] DateTime newDateLimit)
    {
        var product = _shopRepository.Products.FirstOrDefault(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation($"Not found product with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Update storage limit date product with id = {id}");
            product.StorageLimitDate = newDateLimit;
            return Ok();
        }
    }
    /// <summary>
    /// Delete product by id
    /// </summary>
    /// <param name="id">Product id</param>
    /// <returns>Ok (delete product by id) or NotFound</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = _shopRepository.Products.FirstOrDefault(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation($"Not found product with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Delete product with id = {id}");
            _shopRepository.Products.Remove(product);
            return Ok();
        }
    }
}
