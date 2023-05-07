using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shops.Domain;
using Shops.Server.Dto;

namespace Shops.Server.Controllers;
/// <summary>
/// Controller for purchase record 
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PurchaseRecordController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<PurchaseRecordController> _logger;
    /// <summary>
    /// Used to store factory context
    /// </summary>
    private readonly IDbContextFactory<ShopsContext> _dbContextFactory;
    /// <summary>
    /// Used to store map-object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// Controller constructor 
    /// </summary>
    public PurchaseRecordController(ILogger<PurchaseRecordController> logger, IDbContextFactory<ShopsContext> dbContextFactory, IMapper mapper)
    {
        _logger = logger;
        _dbContextFactory = dbContextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// Return list of purchase record
    /// </summary>
    /// <returns>Ok(List of purchase record)</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PurchaseRecordGetDto>>> Get()
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        _logger.LogInformation("Get list of purchase record");
        return Ok(_mapper.Map<IEnumerable<PurchaseRecordGetDto>>(ctx.PurchaseRecords));
    }
    /// <summary>
    /// Return purchase record
    /// </summary>
    /// <param name="id"> Purchase record id</param>
    /// <returns>Ok (the purchase record found by specified id) or NotFound</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<PurchaseRecordGetDto>> Get(int id)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        var record = await ctx.PurchaseRecords.FirstOrDefaultAsync(record => record.Id == id);
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
    public async Task<IActionResult> Post([FromBody] PurchaseRecordPostDto record)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        var foundProduct = await ctx.Products.FirstOrDefaultAsync(fProduct => fProduct.Id == record.ProductId);
        if (foundProduct == null)
            return NotFound();
        var foundShop = await ctx.Shops.FirstOrDefaultAsync(fShop => fShop.Id == record.ShopId);
        if (foundShop == null)
            return NotFound();
        var foundCustomer = await ctx.Customers.FirstOrDefaultAsync(fCustomer => fCustomer.Id == record.CustomerId);
        if (foundCustomer == null)
            return NotFound();
        var newId = ctx.PurchaseRecords
            .Select(product => product.Id)
            .DefaultIfEmpty()
            .Max() + 1;
        var newRecord = _mapper.Map<PurchaseRecord>(record);
        newRecord.Id = newId;
        newRecord.Sum = record.Quantity * foundProduct.Price;
        await ctx.PurchaseRecords.AddAsync(newRecord);
        await ctx.SaveChangesAsync();
        _logger.LogInformation($"Post new purchase record, id = {newId}");
        return Ok();
    }
    /// <summary>
    /// Updates purchase record information
    /// </summary>
    /// <param name="id">Purchase record id</param>
    /// <param name="recordToPut">New information purchase record</param>
    /// <returns>Ok (update information purchase record) or NotFound</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] PurchaseRecordPostDto recordToPut)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        var foundProduct = await ctx.Products.FirstOrDefaultAsync(fProduct => fProduct.Id == recordToPut.ProductId);
        if (foundProduct == null)
            return NotFound();
        var foundShop = await ctx.Shops.FirstOrDefaultAsync(fShop => fShop.Id == recordToPut.ShopId);
        if (foundShop == null)
            return NotFound();
        var foundCustomer = await ctx.Customers.FirstOrDefaultAsync(fCustomer => fCustomer.Id == recordToPut.CustomerId);
        if (foundCustomer == null)
            return NotFound();

        var record = await ctx.PurchaseRecords.FirstOrDefaultAsync(record => record.Id == id);
        if (record == null)
        {
            _logger.LogInformation($"Not found purchase record with id = {id}");
            return NotFound();
        }
        else
        {

            _logger.LogInformation($"Update information purchase record with id = {id}");
            _mapper.Map<PurchaseRecordPostDto, PurchaseRecord>(recordToPut, record);
            record.Sum = record.Quantity * foundProduct.Price;
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Delete purchase record by id
    /// </summary>
    /// <param name="id">purchase record id</param>
    /// <returns>Ok (delete purchase record  by id) or NotFound</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync();

        var record = await ctx.PurchaseRecords.FirstOrDefaultAsync(record => record.Id == id);
        if (record == null)
        {
            _logger.LogInformation($"Not found purchase record with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Delete purchase record with id = {id}");
            ctx.PurchaseRecords.Remove(record);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
