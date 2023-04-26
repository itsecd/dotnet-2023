using Factory.Domain;
using Factory.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Xml.Linq;
using System;
using Factory.Server.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Org.BouncyCastle.Crypto.Signers;

namespace Factory.Server.Controllers;

/// <summary>
/// Enterprise controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class EnterpriseController : ControllerBase
{
    private readonly IDbContextFactory<FactoryContext> _contextFactory;

    private readonly ILogger<EnterpriseController> _logger;

    private readonly IMapper _mapper;
    public EnterpriseController(IDbContextFactory<FactoryContext> contextFactory, ILogger<EnterpriseController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
      //  using var ctx = _contextFactory.CreateDbContext();
    }

    /// <summary>
    /// Get enterprises
    /// </summary>
    /// <returns>enterprises</returns>
    [HttpGet]
    public IEnumerable<EnterpriseGetDto> Get()
    {
        using var ctx = _contextFactory.CreateDbContext();
        _logger.LogInformation("Get Enterprises");
        return _mapper.Map<IEnumerable<EnterpriseGetDto>>(ctx.Enterprises) ;
    }

    /// <summary>
    /// Get enterprise by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>enterprise</returns>
    [HttpGet("{id}")]
    public ActionResult<EnterpriseGetDto> Get(int id)
    {
        using var ctx = _contextFactory.CreateDbContext();
        var enterprise = ctx.Find<EnterpriseGetDto>(id);
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
        using var ctx = _contextFactory.CreateDbContext();
        _logger.LogInformation("Post enterprise");
        ctx.Enterprises.Add(_mapper.Map<Enterprise>(enterprise));
        ctx.SaveChanges();
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
        using var ctx = _contextFactory.CreateDbContext();
        var enterprise = ctx.Find<Enterprise>(id);
        if (enterprise == null)
        {
            _logger.LogInformation($"Not found enterprise: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put enterprise with id {id}");
            _mapper.Map(enterpriseToPut, enterprise);
            ctx.SaveChanges();
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
        using var ctx = _contextFactory.CreateDbContext();
        var enterprise = ctx.Find<Enterprise>(id);
        if (enterprise == null)
        {
            _logger.LogInformation($"Not found enterprise: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get enterprise with id {id}");
            ctx.Enterprises.Remove(enterprise);
            ctx.SaveChanges();
            return Ok();
        }
    }
}
