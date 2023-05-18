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

    private readonly IMainRepository _mainRepository;
    public ProductController(ILogger<ProductController> logger, IMainRepository mainRepository)
    {
        _logger = logger;
        _mainRepository = mainRepository;
    }

    /// <summary>
    ///     [HttpGet] - return all product
    /// </summary>
    /// <returns>List of Product</returns>
    [HttpGet]
    public IEnumerable<ProductGetDto> Get()
    {
        _logger.LogInformation("Get products.");
        return _mainRepository.Products.Select(product =>
            new ProductGetDto
            {
                ItemNumber = product.ItemNumber,
                Title = product.Title,
                Quantity = product.Quantity,
                CellNumber = product.CellNumber
            }
        );
    }

    /// <summary>
    ///     [HttpGet("{id}")] - return product with id
    /// </summary>
    /// <param ItemNumber = "id" >ItemNumber of the Product to be view</param>
    /// <returns>Info of product</returns>
    [HttpGet("{id}")]
    public ActionResult<ProductGetDto?> Get(int id)
    {
        var product = _mainRepository.Products.FirstOrDefault(product => product.ItemNumber == id);
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

    /// <summary>
    ///     [HttpPost] - add new product
    /// </summary>
    /// <param Product>Add new Product</param>
    [HttpPost]
    public void Post([FromBody] ProductPostDto product)
    {
        _mainRepository.Products.Add(new Product(
            product.ItemNumber,
            product.Title,
            product.Quantity,
            product.CellNumber)
            );
    }

    /// <summary>
    ///     [HttpPut("{id}")] - update info of product with id
    /// </summary>
    /// <param ItemNumber="id">ItemNumber of the Product to be update</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ProductPostDto productToPut)
    {
        var product = _mainRepository.Products.FirstOrDefault(product => product.ItemNumber == id);
        if (product == null)
        {
            _logger.LogInformation("Not found product with {id}.", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Put product with {id}.", id);
            product.ItemNumber = productToPut.ItemNumber;
            product.Title = productToPut.Title;
            product.Quantity = productToPut.Quantity;
            product.CellNumber = productToPut.CellNumber;
            return Ok();
        }
    }

    /// <summary>
    ///     [HttpDelete("{id}")] - delete product with id
    /// </summary>
    /// <param ItemNumber="id">ItemNumber of the Product to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = _mainRepository.Products.FirstOrDefault(product => product.ItemNumber == id);
        if (product == null)
        {
            _logger.LogInformation("Not found product with {id}.", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Delete product with {id}.", id);
            _mainRepository.Products.Remove(product);
            return Ok();
        }
    }
}