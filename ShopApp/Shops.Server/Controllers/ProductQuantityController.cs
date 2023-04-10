using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shops.Domain;
using Shops.Server.Dto;
using Shops.Server.Repository;

namespace Shops.Server.Controllers;
/// <summary>
/// Controller for product quantity  
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProductQuantityController : ControllerBase
{
    private readonly ILogger<ProductQuantityController> _logger;
    private readonly IShopRepository _shopRepository;
    private readonly IMapper _mapper;
    /// <summary>
    /// Controller constructor 
    /// </summary>
    public ProductQuantityController(ILogger<ProductQuantityController> logger, IShopRepository shopRepository, IMapper mapper)
    {
        _logger = logger;
        _shopRepository = shopRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Return list of product quantity
    /// </summary>
    /// <returns>Ok(List of product in shops)</returns>
    [HttpGet]
    public ActionResult<IEnumerable<ProductQuantityGetDto>> Get()
    {
        _logger.LogInformation("Get list of product quanity");
        return Ok(_shopRepository.ProductQuantities.Select(product => _mapper.Map<ProductQuantityGetDto>(product)));
    }
    /// <summary>
    /// Return product in shop
    /// </summary>
    /// <param name="id"> Record produc quantity id</param>
    /// <returns>Ok (the shop found by specified id) or NotFound</returns>
    [HttpGet("{id}")]
    public ActionResult<ProductQuantityGetDto> Get(int id)
    {
        var product = _shopRepository.ProductQuantities.FirstOrDefault(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation($"Not record of product quanity with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Record of product quanity with id = {id}");
            return Ok(_mapper.Map<ProductQuantityGetDto>(product));
        }
    }

    /// <summary>
    /// Add new product in shop
    /// </summary>
    /// <param name="product"> New product in shop</param>
    /// <returns>Ok(add new product in shop) </returns>
    [HttpPost]
    public IActionResult Post([FromBody] ProductQuantityPostDto product)
    {
        var foundProduct = _shopRepository.Products.FirstOrDefault(fProduct => fProduct.Id == product.ProductId);
        if (foundProduct == null)
            return NotFound();
        var foundShop = _shopRepository.Shops.FirstOrDefault(fShop => fShop.Id == product.ShopId);
        if (foundShop == null)
            return NotFound();

        var newid = _shopRepository.ProductQuantities
            .Select(product => product.Id)
            .DefaultIfEmpty()
            .Max() + 1;
        var newProduct = _mapper.Map<ProductQuantity>(product);
        newProduct.Id = newid;
        _shopRepository.ProductQuantities.Add(newProduct);
        _logger.LogInformation($"Post new record of product quanity, id = {newid}");
        return Ok();
    }
    /// <summary>
    /// Updates quantity product in shop information
    /// </summary>
    /// <param name="id">Shop id</param>
    /// <param name="productToPut">New quantity</param>
    /// <returns>Ok (update quantity product in shop) or NotFound</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ProductQuantityPostDto productToPut)
    {
        var foundProduct = _shopRepository.Products.FirstOrDefault(fProduct => fProduct.Id == productToPut.ProductId);
        if (foundProduct == null)
            return NotFound();
        var foundShop = _shopRepository.Shops.FirstOrDefault(fShop => fShop.Id == productToPut.ShopId);
        if (foundShop == null)
            return NotFound();

        var product = _shopRepository.ProductQuantities.FirstOrDefault(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation($"Not found record of product quanity with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Update information record of product quanity with id = {id}");
            _mapper.Map<ProductQuantityPostDto, ProductQuantity>(productToPut, product);
            return Ok();
        }
    }
    /// <summary>
    /// Delete record of product quantity in shop by id
    /// </summary>
    /// <param name="id">record of product quantity id</param>
    /// <returns>Ok (delete record of product quantity  by id) or NotFound</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = _shopRepository.ProductQuantities.FirstOrDefault(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation($"Not found record of product quanity with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Delete record of product quanityt with id = {id}");
            _shopRepository.ProductQuantities.Remove(product);
            return Ok();
        }
    }
}
