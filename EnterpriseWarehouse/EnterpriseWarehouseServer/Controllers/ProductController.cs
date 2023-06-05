using AutoMapper;
using Enterprise.Data;
using EnterpriseWarehouse.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseWarehouse.Server.Controllers;
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
        }
        else
            return NotFound();
    }

    /// <summary>
    ///     [HttpGet("{id}")] - return product with id
    /// </summary>
    /// <param ItemNumber = "itemNumber" >ItemNumber of the Product to be view</param>
    /// <returns>Info of product</returns>
    [HttpGet("{itemNumber}")]
    public async Task<ActionResult<ActionResult<ProductGetDto?>>> Get(int itemNumber)
    {
        if (_context.Products != null)
        {
            var product = await _context.Products.FirstOrDefaultAsync(product => product.ItemNumber == itemNumber);
            if (product != null)
            {
                _logger.LogInformation("Get product with {id}.", itemNumber);
                return Ok(_mapper.Map<ProductGetDto>(product));
            }
            else
            {
                _logger.LogInformation("Not found product with {id}.", itemNumber);
                return NotFound();
            }
        }
        else
        {
            _logger.LogInformation("Not found product with {id}.", itemNumber);
            return NotFound();
        }
    }

    /// <summary>
    ///     [HttpPost] - add new product
    /// </summary>
    /// <param Product>Add new Product</param>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<int>> Post([FromBody] ProductPostDto product)
    {
        if (_context.Products != null)
        {
            var mappedProduct = _mapper.Map<Product>(product);

            _context.Add(mappedProduct);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Post", mappedProduct.ItemNumber);
        }
        else
            return Problem("Entity set Products is null.");

    }

    /// <summary>
    ///     [HttpPut("{id}")] - update info of product with id
    /// </summary>
    /// <param ItemNumber="itemNumber">ItemNumber of the Product to be update</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{itemNumber}")]
    public async Task<IActionResult> Put(int itemNumber, [FromBody] ProductPostDto productToPut)
    {
        if (_context.Products == null)
            return NotFound();
        var productToModify = await _context.Products.Where(product => product.ItemNumber == itemNumber).FirstAsync();
        if (productToModify == null)
        {
            _logger.LogInformation("Not found product with {id}.", itemNumber);
            return NotFound();
        }
        else
        {
            _mapper.Map(productToPut, productToModify);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    ///     [HttpDelete("{id}")] - delete product with id
    /// </summary>
    /// <param ItemNumber="itemNumber">ItemNumber of the Product to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{itemNumber}")]
    public async Task<ActionResult> Delete(int itemNumber)
    {
        if (_context.Products != null)
        {
            var product = await _context.Products.Where(product => product.ItemNumber == itemNumber).FirstAsync();
            if (product == null)
            {
                _logger.LogInformation("Not found product with {id}.", itemNumber);
                return NotFound();
            }
            else
            {
                _logger.LogInformation("Delete product with {id}.", itemNumber);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
        else
            return NotFound();
    }
}