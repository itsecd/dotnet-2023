using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyCityNetwork.Server.Dto;

namespace PharmacyCityNetwork.Server.Controllers;

/// <summary>
/// Sale controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SaleController : ControllerBase
{
    private readonly ILogger<SaleController> _logger;
    private readonly IDbContextFactory<PharmacyCityNetworkDbContext> _contextFactory;
    private readonly IMapper _mapper;
    public SaleController(ILogger<SaleController> logger, IDbContextFactory<PharmacyCityNetworkDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// Get info about all sales
    /// </summary>
    /// <returns>Return all sales</returns>
    [HttpGet]
    public async Task<IEnumerable<SaleGetDto>> GetSales()
    {
        _logger.LogInformation("Get all sales");
        var ctx = await _contextFactory.CreateDbContextAsync();
        var sales = await ctx.Sales.ToArrayAsync();
        return _mapper.Map<IEnumerable<SaleGetDto>>(sales);
    }
    /// <summary>
    /// Get sale info by id
    /// </summary>
    /// <param name="idSale">Sale Id</param>
    /// <returns>Return sale with specified id</returns>
    [HttpGet("{idSale}")]
    public async Task<ActionResult<SaleGetDto>> GetSale(int idSale)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var sale = await ctx.Sales.FirstOrDefaultAsync(sale => sale.Id == idSale);
        if (sale == null)
        {
            _logger.LogInformation("Not found sale : {idSale}", idSale);
            return NotFound($"The sale does't exist by this id {idSale}");
        }
        else
        {
            _logger.LogInformation("Not found sale : {idSale}", idSale);
            return Ok(_mapper.Map<SaleGetDto>(sale));
        }
    }
    /// <summary>
    /// Post a new sale 
    /// </summary>
    /// <param name="sale">Sale class instance to insert to table</param>
    [HttpPost]
    public async Task PostSale([FromBody] SalePostDto sale)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Create new sale");
        await ctx.Sales.AddAsync(_mapper.Map<Sale>(sale));
        await ctx.SaveChangesAsync();
    }
    /// <summary>
    /// Put sale
    /// </summary>
    /// <param name="idSale">An id of sale which would be changed</param>
    /// <param name="saleToPut">Sale class instance to insert to table</param>
    /// <returns>Signalization of success of error</returns>
    [HttpPut("{idSale}")]
    public async Task<IActionResult> PutSale(int idSale, [FromBody] SalePostDto saleToPut)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var sale = await ctx.Sales.FirstOrDefaultAsync(sale => sale.Id == idSale);
        if (sale == null)
        {
            _logger.LogInformation("Not found sale : {idSale}", idSale);
            return NotFound($"The sale does't exist by this id {idSale}");
        }
        else
        {
            _logger.LogInformation("Update sale by id {idSale}", idSale);
            _mapper.Map(saleToPut, sale);
            ctx.Sales.Update(_mapper.Map<Sale>(sale));
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Delete a sale
    /// </summary>
    /// <param name="idSale">An id of sale which would be deleted</param>
    /// <returns>Signalization of success of error</returns>
    [HttpDelete("{idSale}")]
    public async Task<IActionResult> DeleteSale(int idSale)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var sale = await ctx.Sales.Include(sale => sale.Product)
                                        .FirstOrDefaultAsync(sale => sale.Id == idSale);
        if (sale == null)
        {
            _logger.LogInformation("Not found sale: {idSale}", idSale);
            return NotFound($"The sale does't exist by this id {idSale}");
        }
        else
        {
            _logger.LogInformation("Delete sale by id {idSale}", idSale);
            ctx.Sales.Remove(sale);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}