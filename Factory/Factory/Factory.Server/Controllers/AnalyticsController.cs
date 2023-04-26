using AutoMapper;
using Factory.Domain;
using Factory.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Factory.Server.Controllers;

/// <summary>
///  Analytics controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly IDbContextFactory<FactoryContext> _contextFactory;

    private readonly ILogger<AnalyticsController> _logger;

    private readonly IMapper _mapper;

    public AnalyticsController(IDbContextFactory<FactoryContext> contextFactory, ILogger<AnalyticsController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Get information about some enterprise
    /// </summary>
    /// <returns></returns>
    [HttpGet("/InformationAboutEnterprise")]
    public async Task<IActionResult> GetInformationAboutEnterprise(string registration)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get information about enterprise");

        var result = await (from e in ctx.Enterprises
                            where e.RegistrationNumber == registration
                            select _mapper.Map<EnterpriseGetDto>(e)).ToListAsync();

        return Ok(result);
    }

    /// <summary>
    /// Get all suppliers who made supplies from date1 to date2
    /// </summary>
    /// <returns></returns>
    [HttpGet("/SuppliersWhoMadeSuppliesOnDate")]
    public async Task<IActionResult> GetSuppliersWhoMadeSupliesOnDate(DateTime date1, DateTime date2)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get suppliers who made supplies from date1 to date2");
        var result = await (from sr in ctx.Suppliers
                            join s in ctx.Supplies on sr.SupplierID equals s.SupplierID
                            where s.Date > date1 && s.Date < date2
                            orderby sr.Name
                            select _mapper.Map<SupplierGetDto>(sr)).ToListAsync();

        return Ok(result);
    }

    /// <summary>
    /// Get count of enterprises working with every supplier
    /// </summary>
    /// <returns></returns>
    [HttpGet("/CountOfEnterprisesWorkingWithEverySupplier")]
    public async Task<IActionResult> GetCountOfEnterprisesWorkingWithEverySupplier()
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get count of enterprises working with every supplier");
        var result = await (from sr in ctx.Suppliers
                            join s in ctx.Supplies on sr.SupplierID equals s.SupplierID
                            join e in ctx.Enterprises on s.EnterpriseID equals e.EnterpriseID
                            group e by sr.Name into g
                            select new
                            {
                                SupplierName = g.Key,
                                NumberOfCompanies = g.Select(s => s.EnterpriseID).Distinct().Count()
                            }).ToListAsync();
        return Ok(result);
    }

    /// <summary>
    /// Get count of suppliers for every type and ownership form
    /// </summary>
    /// <returns></returns>
    [HttpGet("/CountOfSuppliersForEveryTypeAndOwneship")]
    public async Task<IActionResult> GetCountOfSuppliersForEveryTypeAndOwnership()
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get count of suppliers for every type of industry and owneship form");
        var result = await (from sr in ctx.Suppliers
                            join s in ctx.Supplies on sr.SupplierID equals s.SupplierID
                            join e in ctx.Enterprises on s.EnterpriseID equals e.EnterpriseID
                            group sr by new { e.TypeID, e.OwnershipFormID } into g
                            select new
                            {
                                IndustryType = g.Key.TypeID,
                                OwnershipForm = g.Key.OwnershipFormID,
                                NumberOfSuppliers = g.Count()
                            }).ToListAsync();

        return Ok(result);
    }

    /// <summary>
    /// Get top-5 enterprises by supply count 
    /// </summary>
    /// <returns></returns>
    [HttpGet("/Top5EnterprisesBySupplyCount")]
    public async Task<IActionResult> GetTop5EnterprisesBySupplies()
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get top-5 enterprises by supply count");
        var result = await ((from e in ctx.Enterprises
                             join s in (
                                 from s in ctx.Supplies
                                 group s by s.EnterpriseID into g
                                 orderby g.Count() descending
                                 select new { EnterpriseID = g.Key, Count = g.Count() }
                             ) on e.EnterpriseID equals s.EnterpriseID
                             orderby s.Count descending
                             select _mapper.Map<EnterpriseGetDto>(e))
                            .Take(5))
                            .ToListAsync();


        return Ok(result);
    }

    /// <summary>
    /// Get supplier who delivered max quantity 
    /// of goods from date1 to date2
    /// </summary>
    /// <returns></returns>
    [HttpGet("/SupplierWhoDeliveredMaxQuantityOfGoodsOnDate")]
    public async Task<IActionResult> GetSupplierWhoDeliveredMaxGoodsOnDate(DateTime date1, DateTime date2)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get supplier who delivered max quantity of goods from date1 to date2");
        var result = await ((from s in ctx.Suppliers
                             join sp in ctx.Supplies on s.SupplierID equals sp.SupplierID
                             where sp.Date > date1 && sp.Date < date2
                             orderby sp.Quantity descending
                             select _mapper.Map<SupplierGetDto>(s)).Take(1)).ToListAsync();

        return Ok(result);
    }
}
