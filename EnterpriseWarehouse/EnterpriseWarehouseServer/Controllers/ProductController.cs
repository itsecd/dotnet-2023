using Enterprise.Data;
using EnterpriseWarehouseServer.Dto;
using EnterpriseWarehouseServer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseWarehouseServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;

    private readonly IProductRepository _productRepository;
    public ProductController(ILogger<ProductController> logger, IProductRepository productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
    }

    [HttpGet]
    public IEnumerable<ProductGetDto> Get()
    {
        _logger.LogInformation("Get products.");
        return _productRepository.Products.Select(product =>
            new ProductGetDto
            {
                ItemNumber = product.ItemNumber,
                Title = product.Title,
                Quantity = product.Quantity,
                CellNumber = product.CellNumber
            }
        );
    }

    [HttpGet("{id}")]
    public ActionResult<ProductGetDto?> Get(int id)
    {
        var product = _productRepository.Products.FirstOrDefault(product => product.ItemNumber == id);
        if (product == null)
        {
            _logger.LogInformation("Not found product with {id}.", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get product with {id}.", id);
            return Ok(new ProductGetDto
            {
                ItemNumber = product.ItemNumber,
                Title = product.Title,
                Quantity = product.Quantity,
                CellNumber = product.CellNumber
            });
        }
    }


    [HttpPost]
    public void Post([FromBody] ProductPostDto product)
    {
        _productRepository.Products.Add(new Product(
            product.ItemNumber,
            product.Title,
            product.Quantity,
            product.CellNumber)
            );
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ProductPostDto productToPut)
    {
        var product = _productRepository.Products.FirstOrDefault(product => product.ItemNumber == id);
        if (product == null)
        {
            _logger.LogInformation("Not found product with {id}.", id);
            return NotFound();
        }
        else
        {
            product.ItemNumber = productToPut.ItemNumber;
            product.Title = productToPut.Title;
            product.Quantity = productToPut.Quantity;
            product.CellNumber = productToPut.CellNumber;
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = _productRepository.Products.FirstOrDefault(product => product.ItemNumber == id);
        if (product == null)
        {
            _logger.LogInformation("Not found product with {id}.", id);
            return NotFound();
        }
        else
        {
            _productRepository.Products.Remove(product);
            return Ok();
        }
    }
}