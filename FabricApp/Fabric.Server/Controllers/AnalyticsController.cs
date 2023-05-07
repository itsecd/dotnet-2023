using AutoMapper;
using Fabrics.Domain;
using Fabrics.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fabrics.Server.Controllers;
/// <summary>
/// Analytics controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<AnalyticsController> _logger;
    /// <summary>
    /// Used to store repository
    /// </summary>
    private readonly IDbContextFactory<FabricsDbContext> _contextFactory;
    /// <summary>
    /// Used to store map-object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// AnlyticsController constructor
    /// </summary>
    /// <param name="logger">Logger</param>
    /// <param name="contextFactory">DbContext</param>
    /// <param name="mapper">Map-object</param>
    public AnalyticsController(ILogger<AnalyticsController> logger, IDbContextFactory<FabricsDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// Get information from one fabric. 
    /// </summary>
    /// <param name="id"> Id of Fabric.</param>
    /// <returns>Fabric information</returns>
    [HttpGet("fabric-information")]
    public async Task<IActionResult> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get fabric information");
        var result = await (from fabric in context.Fabrics
                            where fabric.Id == id
                            select _mapper.Map<Fabric, FabricGetDto>(fabric)).ToListAsync();
        if (result.Count == 0)
        {
            _logger.LogInformation("Not found fabric:{id}", id);
            return NotFound();
        }
        else
        {
            return Ok(result);
        }
    }
    /// <summary>
    /// Get all providers who delivered goods during the given interval.
    /// </summary>
    /// <param name="firstDate">Smaller interval boundary </param>
    /// <param name="secondDate">Bigger interval boundary</param>
    /// <returns>List of providers</returns>
    [HttpGet("providers-information-in-interval")]
    public async Task<IActionResult> GetProvidersInfoInInterval(DateTime firstDate, DateTime secondDate)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get providers who delivered goods during the given interval");
        var result = await (from shipment in context.Shipments
                            where shipment.Date.CompareTo(firstDate) > 0 && shipment.Date.CompareTo(secondDate) < 0
                            select _mapper.Map<Shipment, ShipmentGetDto>(shipment)).ToListAsync();
        if (result.Count == 0)
        {
            _logger.LogInformation("No providers delivered goods during given inteval");
            return NotFound();
        }
        else
        {
            return Ok(result);
        }
    }
    /// <summary>
    /// Get the number of fabrics that each providers works with.
    /// </summary>
    /// <returns>Pairs: providers - number of partners.</returns>

    [HttpGet("number-of-partners-of-providers")]
    public async Task<IActionResult> GetNumberOfPartners()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get number of fabrics that each providers works with.");
        var result = await (from provider in context.Providers
                            join shipment in context.Shipments on provider.Id equals shipment.ProviderId
                            join fabric in context.Providers on shipment.FabricId equals fabric.Id
                            group fabric by provider into g
                            select new
                            {
                                provider = _mapper.Map<Provider, ProviderGetDto>(g.Key),
                                count = g.Count()
                            }).ToListAsync();
        if (result.Count == 0)
        {
            _logger.LogInformation("Providers don't have partners");
            return NotFound();
        }
        else
        {
            return Ok(result);
        }
    }
    /// <summary>
    /// Get information about the number of providers for each form of ownership of fabrics.
    /// </summary>
    /// <returns>List of pairs: form of ownership - number of providers.</returns>
    [HttpGet("number-of-providers-for-each-form")]
    public async Task<IActionResult> GetNumberOfProvidersForEachType()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get information about the number of providers for each form of ownership of fabrics.");
        var result = await (from fabric in context.Fabrics
                            join shipment in context.Shipments on fabric.Id equals shipment.FabricId
                            join provider in context.Providers on shipment.ProviderId equals provider.Id
                            group provider by fabric.FormOfOwnership into g
                            select new
                            {
                                Form = g.Key,
                                count = g.Count()
                            }).ToListAsync();
        if (result.Count == 0)
        {
            _logger.LogInformation("No information found");
            return NotFound();
        }
        else
        {
            return Ok(result);
        }
    }
    /// <summary>
    /// Get top 5 of providers by the number of shipments.
    /// </summary>
    /// <returns>List of pairs: id of provider - number of shipments.</returns>
    [HttpGet("top-5-providers")]
    public async Task<IActionResult> GetTopProviders()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get top 5 of providers by the number of shipments.");
        var result = await (from provider in context.Providers
                            orderby provider.Shipments.Count descending
                            select new Tuple<ProviderGetDto, int>(_mapper.Map<Provider, ProviderGetDto>(provider), provider.Shipments.Count)).Take(5).ToListAsync();
        if (result.Count == 0)
        {
            _logger.LogInformation("No information found");
            return NotFound();
        }
        else
        {
            return Ok(result);
        }
    }

    /// <summary>
    /// Get information about providers who delivered the maximum quantity of goods during the given interval.
    /// </summary>
    /// <param name="firstDate">Smaller interval boundary </param>
    /// <param name="secondDate">Bigger interval boundary</param>
    /// <returns>List of providers</returns>
    [HttpGet("providers-information-in-interval-max")]
    public async Task<IActionResult> GetProvidersWithMaxQuantity(DateTime firstDate, DateTime secondDate)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get providers who delivered goods during the given interval");
        var shipmentsInInterval = await (from shipment in context.Shipments
                                         where shipment.Date.CompareTo(firstDate) > 0 && shipment.Date.CompareTo(secondDate) < 0
                                         join provider in context.Providers on shipment.ProviderId equals provider.Id
                                         select new
                                         {
                                             provider = _mapper.Map<Provider, ProviderGetDto>(provider),
                                             number = shipment.NumberOfGoods
                                         }).ToListAsync();
        var result = (from prov in shipmentsInInterval
                      where prov.number == shipmentsInInterval.Max(x => x.number)
                      select prov).ToList();
        if (result.Count == 0)
        {
            _logger.LogInformation("No providers delivered goods during given inteval");
            return NotFound();
        }
        else
        {
            return Ok(result);
        }
    }
}
