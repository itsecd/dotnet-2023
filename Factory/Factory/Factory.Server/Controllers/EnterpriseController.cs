using Factory.Domain;
using Factory.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Xml.Linq;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Factory.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EnterpriseController : ControllerBase
{
    private readonly ILogger<EnterpriseController> _logger;

    private readonly FactoryRepository _factoryRepository;

    public EnterpriseController(ILogger<EnterpriseController> logger, FactoryRepository factoryRepository)
    {
        _logger = logger;
        _factoryRepository = factoryRepository;
    }

    // GET: api/<EnterpriseController>
    [HttpGet]
    public IEnumerable<EnterpriseGetDto> Get()
    {
        _logger.LogInformation("Get Enterprises");
        return _factoryRepository.Enterprises.Select(enterprise =>
            new EnterpriseGetDto
            {
                EnterpriseID = enterprise.EnterpriseID,
                RegistrationNumber = enterprise.RegistrationNumber,
                TypeID = enterprise.TypeID,
                Name = enterprise.Name,
                Address = enterprise.Address,
                TelephoneNumber = enterprise.TelephoneNumber,
                OwnershipFormID = enterprise.OwnershipFormID,
                EmployeesCount  = enterprise.EmployeesCount,
                TotalArea = enterprise.TotalArea
            }
        );
    }

    // GET api/<EnterpriseController>/5
    [HttpGet("{id}")]
    public ActionResult<EnterpriseGetDto> Get(int id)
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
            return Ok(new EnterpriseGetDto
            {
                EnterpriseID = enterprise.EnterpriseID,
                RegistrationNumber = enterprise.RegistrationNumber,
                TypeID = enterprise.TypeID,
                Name = enterprise.Name,
                Address = enterprise.Address,
                TelephoneNumber = enterprise.TelephoneNumber,
                OwnershipFormID = enterprise.OwnershipFormID,
                EmployeesCount = enterprise.EmployeesCount,
                TotalArea = enterprise.TotalArea
            });
        }
    }

    // POST api/<EnterpriseController>
    [HttpPost]
    public void Post([FromBody] EnterprisePostDto enterprise)
    {
        _factoryRepository.Enterprises.Add(new Enterprise()
        {
            RegistrationNumber = enterprise.RegistrationNumber,
            TypeID = enterprise.TypeID,
            Name = enterprise.Name,
            Address = enterprise.Address,
            TelephoneNumber = enterprise.TelephoneNumber,
            OwnershipFormID = enterprise.OwnershipFormID,
            EmployeesCount = enterprise.EmployeesCount,
            TotalArea = enterprise.TotalArea
        });
    }

    // PUT api/<EnterpriseController>/5
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
            enterprise.RegistrationNumber = enterpriseToPut.RegistrationNumber;
            enterprise.TypeID = enterpriseToPut.TypeID;
            enterprise.Name = enterpriseToPut.Name;
            enterprise.Address = enterpriseToPut.Address;
            enterprise.TelephoneNumber = enterpriseToPut.TelephoneNumber;
            enterprise.OwnershipFormID = enterpriseToPut.OwnershipFormID;
            enterprise.EmployeesCount = enterpriseToPut.EmployeesCount;
            enterprise.TotalArea = enterpriseToPut.TotalArea;
            return Ok();
        }
    }

    // DELETE api/<EnterpriseController>/5
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
