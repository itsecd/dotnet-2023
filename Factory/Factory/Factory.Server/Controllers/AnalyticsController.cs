using Factory.Server.Dto;
using Factory.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Factory.Domain;

namespace Factory.Server.Controllers;

/// <summary>
///  Analytics controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly ILogger<AnalyticsController> _logger;

    private readonly IFactoryRepository _factoryRepository;

    private readonly IMapper _mapper;
    public AnalyticsController(ILogger<AnalyticsController> logger, IFactoryRepository factoryRepository, IMapper mapper)
    {
        _logger = logger;
        _factoryRepository = factoryRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get information about some enterprise
    /// </summary>
    /// <returns></returns>
    [HttpGet("/InformationAboutEnterprise")]
    public IEnumerable<EnterpriseGetDto> GetInformationAboutEnterprise(string registration)
    {
        _logger.LogInformation("Get information about enterprise");
       
        var result = from e in _factoryRepository.Enterprises
                     where e.RegistrationNumber == registration
                     select _mapper.Map<EnterpriseGetDto>(e);

        return result;
    }

    /// <summary>
    /// Get all suppliers who made supplies from date1 to date2
    /// </summary>
    /// <returns></returns>
    [HttpGet("/SuppliersWhoMadeSuppliesOnDate")]
    public IEnumerable<SupplierGetDto> GetSuppliersWhoMadeSupliesOnDate(DateTime date1, DateTime date2)
    {
        _logger.LogInformation("Get suppliers who made supplies from date1 to date2");
        var result = from sr in _factoryRepository.Suppliers
                     join s in _factoryRepository.Supplies on sr.SupplierID equals s.SupplierID
                     where s.Date > date1 && s.Date < date2
                     orderby sr.Name
                     select _mapper.Map<SupplierGetDto>(sr);

        return result;
    }

    /// <summary>
    /// Get count of enterprises working with every supplier
    /// </summary>
    /// <returns></returns>
    [HttpGet("/CountOfEnterprisesWorkingWithEverySupplier")]
    public IActionResult GetCountOfEnterprisesWorkingWithEverySupplier()
    {
        _logger.LogInformation("Get count of enterprises working with every supplier");

        var result = from sr in _factoryRepository.Suppliers
                     join s in _factoryRepository.Supplies on sr.SupplierID equals s.SupplierID
                     join e in _factoryRepository.Enterprises on s.EnterpriseID equals e.EnterpriseID
                     group e by sr.Name into g
                     select new
                     {
                         SupplierName = g.Key,
                         NumberOfCompanies = g.Select(s => s.EnterpriseID).Distinct().Count()
                     };
        return Ok(result);
    }

    /// <summary>
    /// Get count of suppliers for every type and ownership form
    /// </summary>
    /// <returns></returns>
    [HttpGet("/CountOfSuppliersForEveryTypeAndOwneship")]
    public IActionResult GetCountOfSuppliersForEveryTypeAndOwnership()
    {
        _logger.LogInformation("Get count of suppliers for every type of industry and owneship form");
        var result = from sr in _factoryRepository.Suppliers
                     join s in _factoryRepository.Supplies on sr.SupplierID equals s.SupplierID
                     join e in _factoryRepository.Enterprises on s.EnterpriseID equals e.EnterpriseID
                     group sr by new { e.TypeID, e.OwnershipFormID } into g
                     select new 
                     {
                        IndustryType = g.Key.TypeID,
                        OwnershipForm = g.Key.OwnershipFormID,
                        NumberOfSuppliers = g.Count()
                     };

        return Ok(result);
    }

    /// <summary>
    /// Get top-5 enterprises by supply count 
    /// </summary>
    /// <returns></returns>
    [HttpGet("/Top5EnterprisesBySupplyCount")]
    public IEnumerable<EnterpriseGetDto> GetTop5EnterprisesBySupplies()
    {
        _logger.LogInformation("Get top-5 enterprises by supply count");

        var result = (from s in _factoryRepository.Supplies
                      join e in _factoryRepository.Enterprises on s.EnterpriseID equals e.EnterpriseID
                      group s by e into g
                      orderby g.Count() descending
                      select _mapper.Map<EnterpriseGetDto>(g.Key))
                             .Take(5);

        return result;
    }

    /// <summary>
    /// Get supplier who delivered max quantity 
    /// of goods from date1 to date2
    /// </summary>
    /// <returns></returns>
    [HttpGet("/SupplierWhoDeliveredMaxQuantityOfGoodsOnDate")]
    public IEnumerable<SupplierGetDto> GetSupplierWhoDeliveredMaxGoodsOnDate(DateTime date1, DateTime date2)
    {
        _logger.LogInformation("Get supplier who delivered max quantity of goods from date1 to date2");

        var result = (from s in _factoryRepository.Suppliers
                      join sp in _factoryRepository.Supplies on s.SupplierID equals sp.SupplierID
                      where sp.Date > date1 && sp.Date < date2
                      orderby sp.Quantity descending
                      select _mapper.Map<SupplierGetDto>(s)).Take(1);

        return result;
    }
}
