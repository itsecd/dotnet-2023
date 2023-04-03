using AutoMapper;
using Fabrics.Domain;
using Fabrics.Server.Dto;
using Fabrics.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fabrics.Server.Controllers;
/// <summary>
/// Provider controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProviderController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<ProviderController> _logger;
    /// <summary>
    /// Used to store repository
    /// </summary>
    private readonly IFabricsRepository _fabricsRepository;
    /// <summary>
    /// Used to store map-object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// ProviderController constructor
    /// </summary>
    /// <param name="logger">Logger</param>
    /// <param name="fabricsRepository">Repository</param>
    /// <param name="mapper">Map-object</param>
    public ProviderController(ILogger<ProviderController> logger, IFabricsRepository fabricsRepository, IMapper mapper)
    {
        _logger =  logger;
        _fabricsRepository = fabricsRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Get list of all providers.
    /// </summary>
    /// <returns>List of providers</returns>
    [HttpGet]
    public IEnumerable<ProviderGetDto> Get()
    {
        _logger.LogInformation("Get provider");
        return _fabricsRepository.Providers.Select(provider => _mapper.Map<ProviderGetDto>(provider));
    }
    /// <summary>
    /// Get provider by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Provider</returns>
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
    /// <summary>
    /// Post new provider
    /// </summary>
    /// <param name="provider"></param>
    [HttpPost]
    public void Post([FromBody] ProviderPostDto provider)
    {
        _fabricsRepository.Providers.Add(_mapper.Map<Provider>(provider));
    }
    /// <summary>
    /// Put provider
    /// </summary>
    /// <param name="id"></param>
    /// <param name="providerToPut"></param>
    /// <returns></returns>
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
    /// <summary>
    /// Delete provider
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
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
