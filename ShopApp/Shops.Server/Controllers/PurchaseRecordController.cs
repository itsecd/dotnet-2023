using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shops.Domain;
using Shops.Server.Dto;
using Shops.Server.Repository;

namespace Shops.Server.Controllers;
/// <summary>
/// Controller for purchase record 
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PurchaseRecordController : ControllerBase
{
    private readonly ILogger<PurchaseRecordController> _logger;
    private readonly IShopRepository _shopRepository;
    private readonly IMapper _mapper;
    /// <summary>
    /// Controller constructor 
    /// </summary>
    public PurchaseRecordController(ILogger<PurchaseRecordController> logger, IShopRepository shopRepository, IMapper mapper)
    {
        _logger = logger;
        _shopRepository = shopRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Return list of purchase record
    /// </summary>
    /// <returns>Ok(List of purchase record)</returns>
    [HttpGet]
    public ActionResult<IEnumerable<PurchaseRecordGetDto>> Get()
    {
        _logger.LogInformation("Get list of purchase record");
        return Ok(_shopRepository.PurchaseRecords.Select(product => _mapper.Map<PurchaseRecordGetDto>(product)));
    }
    /// <summary>
    /// Return purchase record
    /// </summary>
    /// <param name="id"> Purchase record id</param>
    /// <returns>Ok (the purchase record found by specified id) or NotFound</returns>
    [HttpGet("{id}")]
    public ActionResult<PurchaseRecordGetDto> Get(int id)
    {
        var record = _shopRepository.PurchaseRecords.FirstOrDefault(record => record.Id == id);
        if (record == null)
        {
            _logger.LogInformation($"Not found purchase record with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"purchase record with id = {id}");
            return Ok(_mapper.Map<PurchaseRecordGetDto>(record));
        }
    }

    /// <summary>
    /// Add new purchase record
    /// </summary>
    /// <param name="record"> New purchase record</param>
    /// <returns>Ok(add new product in shop) </returns>
    [HttpPost]
    public IActionResult Post([FromBody] PurchaseRecordPostDto record)
    {
        //проверка на наличе продукта и магазина
        var found_Product = _shopRepository.Products.FirstOrDefault(f_product => f_product.Id == record.ProductId);
        if (found_Product == null)
            return NotFound();
        var found_Shop = _shopRepository.Shops.FirstOrDefault(f_shop => f_shop.Id == record.ShopId);
        if (found_Shop == null)
            return NotFound();
        var found_customer = _shopRepository.Customers.FirstOrDefault(f_customer => f_customer.Id == record.CustomerId);
        if (found_customer == null)
            return NotFound();
        var newid = _shopRepository.PurchaseRecords
            .Select(product => product.Id)
            .DefaultIfEmpty()
            .Max() + 1;
        var newRecord = _mapper.Map<PurchaseRecord>(record);
        newRecord.Id = newid;
        newRecord.Sum = record.Quantity * found_Product.Price;
        _shopRepository.PurchaseRecords.Add(newRecord);
        _logger.LogInformation($"Post new purchase record, id = {newid}");
        return Ok();
    }
    /// <summary>
    /// Updates purchase record information
    /// </summary>
    /// <param name="id">Purchase record id</param>
    /// <param name="recordToPut">New information purchase record</param>
    /// <returns>Ok (update information purchase record) or NotFound</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] PurchaseRecordPostDto recordToPut)
    {
        var found_Product = _shopRepository.Products.FirstOrDefault(f_product => f_product.Id == recordToPut.ProductId);
        if (found_Product == null)
            return NotFound();
        var found_Shop = _shopRepository.Shops.FirstOrDefault(f_shop => f_shop.Id == recordToPut.ShopId);
        if (found_Shop == null)
            return NotFound();
        var found_customer = _shopRepository.Customers.FirstOrDefault(f_customer => f_customer.Id == recordToPut.CustomerId);
        if (found_customer == null)
            return NotFound();

        var record = _shopRepository.PurchaseRecords.FirstOrDefault(record => record.Id == id);
        if (record == null)
        {
            _logger.LogInformation($"Not found purchase record with id = {id}");
            return NotFound();
        }
        else
        {
            
            _logger.LogInformation($"Update information purchase record with id = {id}");
            _mapper.Map<PurchaseRecordPostDto, PurchaseRecord>(recordToPut, record);
            record.Sum = record.Quantity * found_Product.Price;
            return Ok();
        }
    }
    /// <summary>
    /// Delete purchase record by id
    /// </summary>
    /// <param name="id">purchase record id</param>
    /// <returns>Ok (delete purchase record  by id) or NotFound</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var record = _shopRepository.PurchaseRecords.FirstOrDefault(record => record.Id == id);
        if (record == null)
        {
            _logger.LogInformation($"Not found purchase record with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Delete purchase record with id = {id}");
            _shopRepository.PurchaseRecords.Remove(record);
            return Ok();
        }
    }
}
