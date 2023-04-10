using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Domain;
using StoreApp.Server.Dto;
using StoreApp.Server.Repository;

namespace StoreApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SaleController : ControllerBase
{

    private readonly ILogger<SaleController> _logger;
    private readonly IStoreAppRepository _storeAppRepository;
    private readonly IMapper _mapper;

    public SaleController(ILogger<SaleController> logger, IStoreAppRepository storeAppRepository, IMapper mapper)
    {
        _logger = logger;
        _storeAppRepository = storeAppRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// GET all Sales
    /// </summary>
    /// <returns>
    /// JSON Sales
    /// </returns>
    [HttpGet]
    public IEnumerable<SaleGetDto> Get()
    {
        _logger.LogInformation("GET sales");
        return _storeAppRepository.Sales.Select(sale => _mapper.Map<SaleGetDto>(sale));
    }

    /// <summary>
    /// GET Sale by ID
    /// </summary>
    /// <param name="saleId">
    /// ID
    /// </param>
    /// <returns>
    /// JSON Sale
    /// </returns>
    [HttpGet("{saleId}")]
    public ActionResult<SaleGetDto> Get(int saleId)
    {
        var getSale = _storeAppRepository.Sales.FirstOrDefault(sale => sale.SaleId == saleId);
        if (getSale == null)
        {
            _logger.LogInformation($"Not found sale with ID: {saleId}.");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"GET sale with ID: {saleId}.");
            return Ok(_mapper.Map<SaleGetDto>(getSale));
        }

    }

    /// <summary>
    /// POST sale
    /// </summary>
    /// <param name="saleToPost">
    /// Sale
    /// </param>
    /// <returns>
    /// Code-200
    /// </returns>
    [HttpPost]
    public ActionResult Post([FromBody] SalePostDto saleToPost)
    {
        _storeAppRepository.Sales.Add(_mapper.Map<Sale>(saleToPost));
        _logger.LogInformation($"POST sale ({saleToPost.DateSale}, {saleToPost.CustomerId}, {saleToPost.StoreId}, {saleToPost.Products}, {saleToPost.Sum})");
        return Ok();
    }

    /// <summary>
    /// PUT sale
    /// </summary>
    /// <param name="saleId">
    /// ID
    /// </param>
    /// <param name="saleToPut">
    /// Sale
    /// </param>
    /// <returns>
    /// Code-200 or Code-404
    /// </returns>
    [HttpPut("{saleId}")]
    public ActionResult Put(int saleId, [FromBody] SalePostDto saleToPut)
    {
        var sale = _storeAppRepository.Sales.FirstOrDefault(x => x.SaleId == saleId);
        if (sale == null)
        {
            _logger.LogInformation($"Not found sale with ID: {saleId}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"PUT sale with id {saleId} ({saleToPut.DateSale}->{saleToPut.DateSale}, {saleToPut.CustomerId}->{saleToPut.CustomerId}, " +
                $"{saleToPut.StoreId}->{saleToPut.StoreId}, {saleToPut.Products}->{saleToPut.Products}, {saleToPut.Sum}->{saleToPut.Sum})");
            _mapper.Map(saleToPut, sale);
            return Ok();
        }
    }

    /// <summary>
    /// DELETE sale
    /// </summary>
    /// <param name="id">
    /// ID
    /// </param>
    /// <returns>
    /// Code-200 or Code-404
    /// </returns>
    [HttpDelete("{saleId}")]
    public IActionResult Delete(int saleId)
    {
        var sale = _storeAppRepository.Sales.FirstOrDefault(x => x.SaleId == saleId);
        if (sale == null)
        {
            _logger.LogInformation($"Not found sale with ID: {saleId}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"DELETE sale with ID: {saleId}");
            _storeAppRepository.Sales.Remove(sale);
            return Ok();
        }
    }
}
