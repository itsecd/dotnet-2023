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

    private readonly IMainRepository _mainRepository;
    public StorageCellController(ILogger<StorageCellController> logger, IMainRepository mainRepository)
    {
        _logger = logger;
        _mainRepository = mainRepository;
    }

    /// <summary>
    ///     [HttpGet] - return all StorageCell
    /// </summary>
    [HttpGet]
    public IEnumerable<StorageCellGetDto> Get()
    {
        _logger.LogInformation("Get storage cell.");
        return _mainRepository.StorageCell.Select(storageCell =>
            new StorageCellGetDto
            {
                Number = storageCell.Number,
                ItemNumberProducts = storageCell.ItemNumberProducts,
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
        var storageCell = _mainRepository.StorageCell.FirstOrDefault(storageCell => storageCell.Number == id);
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
                ItemNumberProducts = storageCell.ItemNumberProducts,
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
        _mainRepository.StorageCell.Add(new StorageCell(
            storageCell.Number,
            storageCell.ItemNumberProducts
            )
        );
    }

    /// <summary>
    ///     HttpPut("{id}")] - update info of StorageCell with id
    /// </summary>
    /// <param Number="id">Number of the StorageCell to be update</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] StorageCell storageCell_)
    {
        var storageCell = _mainRepository.StorageCell.FirstOrDefault(storageCell => storageCell.Number == id);
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
        var storageCell = _mainRepository.StorageCell.FirstOrDefault(storageCell => storageCell.Number == id);
        if (storageCell == null)
        {
            _logger.LogInformation("Not found stirage cell with {id}.", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get storage cell with {id}.", id);
            _mainRepository.StorageCell.Remove(storageCell);
            return Ok();
        }

    }
}