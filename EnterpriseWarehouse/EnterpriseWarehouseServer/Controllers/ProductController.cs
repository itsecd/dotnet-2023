using AutoMapper;
using Enterprise.Data;
using EnterpriseWarehouseServer.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseWarehouseServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;

    private readonly EnterpriseWarehouseDbContext _context;

    private readonly IMapper _mapper;
    public ProductController(ILogger<ProductController> logger, EnterpriseWarehouseDbContext context, IMapper mapper)
    {
        _logger = logger;
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    ///     [HttpGet] - return all product
    /// </summary>
    /// <returns>List of Product</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductGetDto>>> Get()
    {
        _logger.LogInformation("Get products.");
        if (_context.Products != null)
        {
            return await _mapper.ProjectTo<ProductGetDto>(_context.Products).ToListAsync();
            return await _context.Products.Select(product =>
                new ProductGetDto
                {
                    ItemNumber = product.ItemNumber,
                    Title = product.Title,
                    Quantity = product.Quantity
                }
            ).ToListAsync();
        }
        else
            return NotFound();
    }

    /// <summary>
    ///     [HttpGet("{id}")] - return product with id
    /// </summary>
    /// <param ItemNumber = "id" >ItemNumber of the Product to be view</param>
    /// <returns>Info of product</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ActionResult<ProductGetDto?>>> Get(int id)
    {
        if (_context.Products != null)
        {
            var product = _context.Products.FirstOrDefault(product => product.ItemNumber == id);
            if (product != null)
            {
                _logger.LogInformation("Get product with {id}.", id);
                return Ok(_mapper.Map<ProductGetDto>(product));
                return Ok(new ProductGetDto
                {
                    ItemNumber = product.ItemNumber,
                    Title = product.Title,
                    Quantity = product.Quantity
                });
            }
            else
            {
                _logger.LogInformation("Not found product with {id}.", id);
                return NotFound();
            }
        }
        else
        {
            _logger.LogInformation("Not found product with {id}.", id);
            return NotFound();
        }
    }

    /// <summary>
    ///     [HttpPost] - add new product
    /// </summary>
    /// <param Product>Add new Product</param>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<Product>> Post([FromBody] ProductPostDto product)
    {
        if (_context.Products != null)
        {
            var mappedProduct = _mapper.Map<Product>(product);

            _context.Add(mappedProduct);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Post", new { itemNumber = mappedProduct.ItemNumber }, _mapper.Map<ProductGetDto>(mappedProduct));
        }
        else
            return Problem("Entity set 'EnterpriseWarehouseDbContext.Products is null.");

    }

    /// <summary>
    ///     [HttpPut("{id}")] - update info of product with id
    /// </summary>
    /// <param ItemNumber="id">ItemNumber of the Product to be update</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ProductPostDto productToPut)
    {
        if (_context.Products == null)
            return NotFound();
        var productToModify = await _context.Products.FindAsync(id);
        if (productToModify == null)
        {
            _logger.LogInformation("Not found product with {id}.", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(productToPut, productToModify);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

    /// <summary>
    ///     [HttpDelete("{id}")] - delete product with id
    /// </summary>
    /// <param ItemNumber="id">ItemNumber of the Product to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        if (_context.Products != null)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                _logger.LogInformation("Not found product with {id}.", id);
                return NotFound();
            }
            else
            {
                _logger.LogInformation("Delete product with {id}.", id);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
        else
            return NotFound();
    }
}