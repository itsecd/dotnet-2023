using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyCityNetwork.Server.Dto;
using PharmacyCityNetwork.Server.Repository;

namespace PharmacyCityNetwork.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SaleController : ControllerBase
{
    private readonly ILogger<SaleController> _logger;

    private readonly IPharmacyCityNetworkRepository _pharmacyCityNetworkRepository;
    private readonly IMapper _mapper;
    public SaleController(ILogger<SaleController> logger, IPharmacyCityNetworkRepository pharmacyCityNetworkRepository, IMapper mapper)
    {
        _logger = logger;
        _pharmacyCityNetworkRepository = pharmacyCityNetworkRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<SaleGetDto> Get()
    {
        return _pharmacyCityNetworkRepository.Sale.Select(sale => _mapper.Map<SaleGetDto>(sale));
    }

    [HttpGet("{id}")]
    public ActionResult<Sale> Get(int id)
    {
        var sale = _pharmacyCityNetworkRepository.Sale.FirstOrDefault(sale => sale.Id == id);
        if (sale == null)
        {
            _logger.LogInformation($"Not found sale: {id}");
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<SaleGetDto>(sale));
        }
    }

    [HttpPost]
    public void Post([FromBody] SalePostDto sale)
    {
        _pharmacyCityNetworkRepository.Sale.Add(_mapper.Map<Sale>(sale));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] SalePostDto saleToPut)
    {
        var sale = _pharmacyCityNetworkRepository.Sale.FirstOrDefault(sale => sale.Id == id);
        if (sale == null)
        {
            _logger.LogInformation("Not found sale: {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(saleToPut, sale);
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var sale = _pharmacyCityNetworkRepository.Sale.FirstOrDefault(sale => sale.Id == id);
        if (sale == null)
        {
            _logger.LogInformation($"Not found sale: {id}");
            return NotFound();
        }
        else
        {
            _pharmacyCityNetworkRepository.Sale.Remove(sale);
            return Ok();
        }
    }
}