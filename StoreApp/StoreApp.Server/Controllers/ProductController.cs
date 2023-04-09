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


    [HttpGet]
    public IEnumerable<Product> Get()
    {
        _logger.LogInformation("Get products");
        return _storeAppRepository.Products;
    }

    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
        var getProduct = _storeAppRepository.Products.FirstOrDefault(product => product.ProductId == id);
        if (getProduct == null)
        {
            _logger.LogInformation($"Not found product with ID: {id}.");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"GET product with ID: {id}.");
            return Ok(getProduct);
        }

    }

    [HttpPost]
    public ActionResult Post([FromBody] ProductPostDto productToPost)
    {
        _logger.LogInformation($"POST product ({productToPost.ProductGroup}, {productToPost.ProductName}, {productToPost.ProductWeight}, {productToPost.ProductType}, {productToPost.ProductPrice}, {productToPost.DateStorage})");
        _storeAppRepository.Products.Add(_mapper.Map<Product>(productToPost));
        _logger.LogInformation($"POST product ({productToPost.ProductGroup}, {productToPost.ProductName}, {productToPost.ProductWeight}, {productToPost.ProductType}, {productToPost.ProductPrice}, {productToPost.DateStorage})");
        return Ok();
    }

    [HttpPut]
    public ActionResult Put(int id, [FromBody] ProductPostDto productToPut)
    {
        var product = _storeAppRepository.Products.FirstOrDefault(x => x.ProductId == id);
        if (product == null)
        {
            _logger.LogInformation($"Not found product with ID: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"PUT product with ID: {id} ({product.ProductName}->{productToPut.ProductName}, {product.ProductPrice}->{productToPut.ProductPrice})");
            _mapper.Map(productToPut, product);
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = _storeAppRepository.Products.FirstOrDefault(x => x.ProductId == id);
        if (product == null)
        {
            _logger.LogInformation($"Not found product with ID: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"DELETE product with ID: {id}");
            _storeAppRepository.Products.Remove(product);
            return Ok();
        }
    }


}
