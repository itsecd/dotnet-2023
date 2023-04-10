using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Domain;
using StoreApp.Server.Dto;
using StoreApp.Server.Repository;

namespace StoreApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{

    private readonly ILogger<ProductController> _logger;
    private readonly IStoreAppRepository _storeAppRepository;
    private readonly IMapper _mapper;

    public ProductController(ILogger<ProductController> logger, IStoreAppRepository storeAppRepository, IMapper mapper)
    {
        _logger = logger;
        _storeAppRepository = storeAppRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// GET all products
    /// </summary>
    /// <returns>
    /// JSON products
    /// </returns>
    [HttpGet]
    public IEnumerable<ProductGetDto> Get()
    {
        _logger.LogInformation("GET products");
        return _storeAppRepository.Products.Select(product => _mapper.Map<ProductGetDto>(product));
    }

    /// <summary>
    /// GET product by ID
    /// </summary>
    /// <param name="productId">
    /// ID
    /// </param>
    /// <returns>
    /// JSON product
    /// </returns>
    [HttpGet("{productId}")]
    public ActionResult<ProductGetDto> Get(int productId)
    {
        var getProduct = _storeAppRepository.Products.FirstOrDefault(product => product.ProductId == productId);
        if (getProduct == null)
        {
            _logger.LogInformation($"Not found product with ID: {productId}.");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"GET product with ID: {productId}.");
            return Ok(_mapper.Map<ProductGetDto>(getProduct));
        }

    }

    /// <summary>
    /// POST product
    /// </summary>
    /// <param name="productToPost">
    /// Product
    /// </param>
    /// <returns>
    /// Code-200
    /// </returns>
    [HttpPost]
    public ActionResult Post([FromBody] ProductPostDto productToPost)
    {
        _storeAppRepository.Products.Add(_mapper.Map<Product>(productToPost));
        _logger.LogInformation($"POST product ({productToPost.ProductGroup}, {productToPost.ProductName}, {productToPost.ProductWeight}, {productToPost.ProductType}, {productToPost.ProductPrice}, {productToPost.DateStorage})");
        return Ok();
    }

    /// <summary>
    /// PUT product
    /// </summary>
    /// <param name="productId">
    /// ID
    /// </param>
    /// <param name="productToPut">
    /// Product to put
    /// </param>
    /// <returns>
    /// Code-200 or Code-404
    /// </returns>
    [HttpPut("{productId}")]
    public ActionResult Put(int productId, [FromBody] ProductPostDto productToPut)
    {
        var product = _storeAppRepository.Products.FirstOrDefault(x => x.ProductId == productId);
        if (product == null)
        {
            _logger.LogInformation($"Not found product with ID: {productId}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"PUT product with ID: {productId} ({product.ProductName}->{productToPut.ProductName}, {product.ProductPrice}->{productToPut.ProductPrice})");
            _mapper.Map(productToPut, product);
            return Ok();
        }
    }

    /// <summary>
    /// DELETE product
    /// </summary>
    /// <param name="productId">
    /// ID
    /// </param>
    /// <returns>
    /// Code-200 or Code-404
    /// </returns>
    [HttpDelete("{productId}")]
    public IActionResult Delete(int productId)
    {
        var product = _storeAppRepository.Products.FirstOrDefault(x => x.ProductId == productId);
        if (product == null)
        {
            _logger.LogInformation($"Not found product with ID: {productId}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"DELETE product with ID: {productId}");
            _storeAppRepository.Products.Remove(product);
            return Ok();
        }
    }
}
