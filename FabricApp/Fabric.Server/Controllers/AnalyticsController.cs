using AutoMapper;
using Fabrics.Domain;
using Fabrics.Server.Dto;
using Fabrics.Server.Repository;
using Microsoft.AspNetCore.Mvc;

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
    private readonly IFabricsRepository _fabricsRepository;
    /// <summary>
    /// Used to store map-object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// AnlyticsController constructor
    /// </summary>
    /// <param name="logger">Logger</param>
    /// <param name="fabricsRepository">Repository</param>
    /// <param name="mapper">Map-object</param>
    public AnalyticsController(ILogger<AnalyticsController> logger, IFabricsRepository fabricsRepository, IMapper mapper)
    {
        _logger = logger;
        _fabricsRepository = fabricsRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Get information from one fabric. 
    /// </summary>
    /// <param name="id"> Id of Fabric.</param>
    /// <returns>Fabric information</returns>
    [HttpGet("fabric-information")]
    public IActionResult Get(int id)
    {
        _logger.LogInformation("Get fabric information");
        var result = (from fabric in _fabricsRepository.Fabrics
                      where fabric.Id == id
                      select _mapper.Map<Fabric, FabricGetDto>(fabric)).ToList();
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
    public IActionResult GetProvidersInfoInInterval(DateTime firstDate, DateTime secondDate)
    {
        _logger.LogInformation("Get providers who delivered goods during the given interval");
        var result = (from shipment in _fabricsRepository.Shipments
                      where shipment.Date.CompareTo(firstDate) > 0 && shipment.Date.CompareTo(secondDate) < 0
                      select _mapper.Map<Shipment, ShipmentGetDto>(shipment)).ToList();
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
    public IActionResult GetNumberOfPartners()
    {
        _logger.LogInformation("Get number of fabrics that each providers works with.");
        var result = (from provider in _fabricsRepository.Providers
                      join shipment in _fabricsRepository.Shipments on provider.Id equals shipment.ProviderId
                      join fabric in _fabricsRepository.Providers on shipment.FabricId equals fabric.Id
                      group fabric by provider into g
                      select new
                      {
                          provider = _mapper.Map<Provider, ProviderGetDto>(g.Key),
                          count = g.Count()
                      }).ToList();
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
    public IActionResult GetNumberOfProvidersForEachType()
    {
        _logger.LogInformation("Get information about the number of providers for each form of ownership of fabrics.");
        var result = (from fabric in _fabricsRepository.Fabrics
                      join shipment in _fabricsRepository.Shipments on fabric.Id equals shipment.FabricId
                      join provider in _fabricsRepository.Providers on shipment.ProviderId equals provider.Id
                      group provider by fabric.FormOfOwnership into g
                      select new
                      {
                          Form = g.Key,
                          count = g.Count()
                      }).ToList();
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
    public IActionResult GetTopProviders()
    {
        _logger.LogInformation("Get top 5 of providers by the number of shipments.");
        var result = (from provider in _fabricsRepository.Providers
                      orderby provider.Shipments.Count descending
                      select new Tuple<ProviderGetDto, int>(_mapper.Map<Provider, ProviderGetDto>(provider), provider.Shipments.Count)).Take(5).ToList();
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
    public IActionResult GetProvidersWithMaxQuantity(DateTime firstDate, DateTime secondDate)
    {
        _logger.LogInformation("Get providers who delivered goods during the given interval");
        var shipmentsInInterval = (from shipment in _fabricsRepository.Shipments
                                   where shipment.Date.CompareTo(firstDate) > 0 && shipment.Date.CompareTo(secondDate) < 0
                                   join provider in _fabricsRepository.Providers on shipment.ProviderId equals provider.Id
                                   select new
                                   {
                                       provider = _mapper.Map<Provider, ProviderGetDto>(provider),
                                       number = shipment.NumberOfGoods
                                   }).ToList();
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
