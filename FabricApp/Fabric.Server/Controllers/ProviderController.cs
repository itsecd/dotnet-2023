using AutoMapper;
using Fabrics.Domain;
using Fabrics.Server.Dto;
using Fabrics.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fabrics.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProviderController : ControllerBase
{
    private readonly ILogger<ProviderController> _logger;

    private readonly IFabricsRepository _fabricsRepository;

    private readonly IMapper _mapper;
    public ProviderController(ILogger<ProviderController> logger, IFabricsRepository fabricsRepository, IMapper mapper)
    {
        _logger = logger;
        _fabricsRepository = fabricsRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Returns list of all providers.
    /// </summary>
    /// <returns>List of providers</returns>
    [HttpGet]
    public IEnumerable<ProviderGetDto> Get()
    {
        _logger.LogInformation("Get provider");
        return _fabricsRepository.Providers.Select(provider => _mapper.Map<ProviderGetDto>(provider));
    }

    [HttpGet("{id}")]
    public ActionResult<ProviderGetDto> Get(int id)
    {
        var provider = _fabricsRepository.Providers.FirstOrDefault(provider => provider.Id == id);
        if (provider == null)
        {
            _logger.LogInformation("Not found provider:{id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<ProviderGetDto>(provider));
        }
    }

    [HttpPost]
    public void Post([FromBody] ProviderPostDto provider)
    {
        _fabricsRepository.Providers.Add(_mapper.Map<Provider>(provider));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ProviderPostDto providerToPut)
    {
        var provider = _fabricsRepository.Providers.FirstOrDefault(provider => provider.Id == id);
        if (provider == null)
        {
            _logger.LogInformation("Not found provider:{id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(providerToPut, provider);
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var provider = _fabricsRepository.Providers.FirstOrDefault(provider => provider.Id == id);
        if (provider == null)
        {
            _logger.LogInformation("Not found provider:{id}", id);
            return NotFound();
        }
        else
        {
            _fabricsRepository.Providers.Remove(provider);
            return Ok();
        }
    }
}
