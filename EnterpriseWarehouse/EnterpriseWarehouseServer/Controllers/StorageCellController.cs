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

    private readonly IStorageCellRepository _storageCellRepository;
    public StorageCellController(ILogger<StorageCellController> logger, IStorageCellRepository storageCellRepository)
    {
        _logger = logger;
        _storageCellRepository = storageCellRepository;
    }

    [HttpGet]
    public IEnumerable<StorageCellGetDto> Get()
    {
        _logger.LogInformation("Get storage cell.");
        return _storageCellRepository.StorageCell.Select(storageCell =>
            new StorageCellGetDto
            {
                Number = storageCell.Number,
                ItemNumberProducts = storageCell.ItemNumberProducts,
            }
        );
    }

    [HttpGet("{id}")]
    public ActionResult<StorageCellGetDto?> Get(int id)
    {
        var storageCell = _storageCellRepository.StorageCell.FirstOrDefault(storageCell => storageCell.Number == id);
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

    [HttpPost]
    public void Post([FromBody] StorageCellPostDto storageCell)
    {
        _storageCellRepository.StorageCell.Add(new StorageCell(
            storageCell.Number,
            storageCell.ItemNumberProducts
            )
        );
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] StorageCell storageCell_)
    {
        var storageCell = _storageCellRepository.StorageCell.FirstOrDefault(storageCell => storageCell.Number == id);
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

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var storageCell = _storageCellRepository.StorageCell.FirstOrDefault(storageCell => storageCell.Number == id);
        if (storageCell == null)
        {
            _logger.LogInformation("Not found stirage cell with {id}.", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get storage cell with {id}.", id);
            _storageCellRepository.StorageCell.Remove(storageCell);
            return Ok();
        }

    }
}