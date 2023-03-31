using Factory.Domain;
using Factory.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Xml.Linq;
using System;
using Factory.Server.Repository;
using AutoMapper;

namespace Factory.Server.Controllers;

/// <summary>
/// Enterprise controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class EnterpriseController : ControllerBase
{
    private readonly ILogger<EnterpriseController> _logger;

    private readonly IFactoryRepository _factoryRepository;

    private readonly IMapper _mapper;
    public EnterpriseController(ILogger<EnterpriseController> logger, IFactoryRepository factoryRepository, IMapper mapper)
    {
        _logger = logger;
        _factoryRepository = factoryRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get enterprises
    /// </summary>
    /// <returns>enterprises</returns>
    [HttpGet]
    public IEnumerable<EnterpriseGetDto> Get()
    {
        _logger.LogInformation("Get Enterprises");
        return _factoryRepository.Enterprises.Select(enterprise =>
            _mapper.Map<EnterpriseGetDto>(enterprise)) ;
    }

    /// <summary>
    /// Get enterprise by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>enterprise</returns>
    [HttpGet("{id}")]
    public ActionResult<EnterpriseGetDto> Get(int id)
    {
        var enterprise = _factoryRepository.Enterprises.FirstOrDefault(enterprise => enterprise.EnterpriseID == id);
        if (enterprise == null)
        {
            _logger.LogInformation("Not found enterprise: {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get enterprise with id {id}");
            return Ok(_mapper.Map<EnterpriseGetDto>(enterprise));
        }
    }

    /// <summary>
    /// Post enterprise
    /// </summary>
    /// <param name="enterprise"></param>
    [HttpPost]
    public void Post([FromBody] EnterprisePostDto enterprise)
    {
        _factoryRepository.Enterprises.Add(_mapper.Map<Enterprise>(enterprise));
    }

    /// <summary>
    /// Put enterprise by ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="enterpriseToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] EnterprisePostDto enterpriseToPut)
    {
        var enterprise = _factoryRepository.Enterprises.FirstOrDefault(enterprise => enterprise.EnterpriseID == id);
        if (enterprise == null)
        {
            _logger.LogInformation($"Not found enterprise: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put enterprise with id {id}");
            _mapper.Map(enterpriseToPut, enterprise);
            return Ok();
        }
    }

    /// <summary>
    /// Delete enterprise by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var enterprise = _factoryRepository.Enterprises.FirstOrDefault(enterprise => enterprise.EnterpriseID == id);
        if (enterprise == null)
        {
            _logger.LogInformation($"Not found enterprise: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get enterprise with id {id}");
            _factoryRepository.Enterprises.Remove(enterprise);
            return Ok();
        }
    }
}
