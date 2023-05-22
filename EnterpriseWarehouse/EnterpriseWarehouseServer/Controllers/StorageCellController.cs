using Enterprise.Data;
using EnterpriseWarehouseServer.Dto;
using EnterpriseWarehouseServer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseWarehouseServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StorageCellController : ControllerBase
{
    private readonly ILogger<StorageCellController> _logger;

    private readonly IMainRepository _context;
    public StorageCellController(ILogger<StorageCellController> logger, IMainRepository mainRepository)
    {
        _logger = logger;
        _context = mainRepository;
    }

    /// <summary>
    ///     [HttpGet] - return all StorageCell
    /// </summary>
    [HttpGet]
    public IEnumerable<StorageCellGetDto> Get()
    {
        _logger.LogInformation("Get storage cell.");
        return _context.StorageCell.Select(storageCell =>
            new StorageCellGetDto
            {
                Number = storageCell.Number,
                ItemNumberProduct = storageCell.ItemNumberProducts,
            }
        );
    }

    /// <summary>
    ///     [HttpGet("{id}")] - return StorageCell with id
    /// </summary>
    /// <param Number = "id" >Number of the StorageCell to be view</param>
    /// <returns>Info of StorageCell</returns>
    [HttpGet("{id}")]
    public ActionResult<StorageCellGetDto?> Get(int id)
    {
        var storageCell = _context.StorageCell.FirstOrDefault(storageCell => storageCell.Number == id);
        if (storageCell == null)
        {
            _logger.LogInformation("Not found storage cell with {id}.", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get storage cell with {id}.", id);
            return Ok(new StorageCellGetDto
            {
                Number = storageCell.Number,
                ItemNumberProduct = storageCell.ItemNumberProducts,
            });
        }
    }

    /// <summary>
    ///     [HttpPost] - add new StorageCell
    /// </summary>
    /// <param StorageCell>Add new product</param>
    [HttpPost]
    public void Post([FromBody] StorageCellPostDto storageCell)
    {
        var product = _context.Products.FirstOrDefault(product => product.ItemNumber == storageCell.ItemNumberProduct);
        var new_storageCell = new StorageCell(
            storageCell.Number, product)
        {
            ItemNumberProducts = storageCell.ItemNumberProduct
        };
        product.StorageCell.Add(new_storageCell);
        _context.StorageCell.Add(new_storageCell);
    }

    /// <summary>
    ///     HttpPut("{id}")] - update info of StorageCell with id
    /// </summary>
    /// <param Number="id">Number of the StorageCell to be update</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] StorageCell storageCell_)
    {
        var storageCell = _context.StorageCell.FirstOrDefault(storageCell => storageCell.Number == id);
        if (storageCell == null)
        {
            _logger.LogInformation("Not found stirage cell with {id}.", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get storage cell with {id}.", id);
            storageCell.Number = storageCell_.Number;
            storageCell.ItemNumberProducts = storageCell_.ItemNumberProducts;
            return Ok();
        }
    }

    /// <summary>
    ///     [HttpDelete("{id}")] - delete StorageCell with id
    /// </summary>
    /// <param Number="id">Number of the StorageCell to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var storageCell = _context.StorageCell.FirstOrDefault(storageCell => storageCell.Number == id);
        if (storageCell == null)
        {
            _logger.LogInformation("Not found stirage cell with {id}.", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get storage cell with {id}.", id);
            _context.StorageCell.Remove(storageCell);
            return Ok();
        }

    }
}