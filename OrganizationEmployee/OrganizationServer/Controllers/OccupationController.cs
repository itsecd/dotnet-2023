using AutoMapper;
using EmployeeDomain;
using Microsoft.AspNetCore.Mvc;
using OrganizationServer.DTO;

namespace OrganizationServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OccupationController : Controller
{
    private OrganizationRepository _organizationRepository;
    private IMapper _mapper;

    public OccupationController(OrganizationRepository organizationRepository, IMapper mapper)
    {
        _organizationRepository = organizationRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<Occupation> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        return _organizationRepository.Occupations;
    }

    [HttpGet("{id}")]
    public ActionResult<Occupation> Get(int id)
    {
        var occupation = _organizationRepository.Occupations.FirstOrDefault(occupation => occupation.Id == id);
        if (occupation == null) return NotFound();
        return Ok(occupation);
    }

    [HttpPost]
    public void Post([FromBody] OccupationDTO occupation)
    {
        var mappedOccupation = _mapper.Map<Occupation>(occupation);
        _organizationRepository.Occupations.Add(mappedOccupation);
    }


    [HttpPut("{id}")]
    public ActionResult<Occupation> Put(int id, [FromBody] OccupationDTO newDepartment)
    {
        var occupation = _organizationRepository.Occupations.FirstOrDefault(occupation => occupation.Id == id);
        if (occupation == null) return NotFound();
        _organizationRepository.Occupations.Remove(occupation);
        var mappedOccupation = _mapper.Map<Occupation>(occupation);
        _organizationRepository.Occupations.Add(mappedOccupation);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult<Occupation> Delete(int id)
    {
        var occupation = _organizationRepository.Occupations.FirstOrDefault(occupation => occupation.Id == id);
        if (occupation == null) return NotFound();
        _organizationRepository.Occupations.Remove(occupation);
        return Ok();
    }
}
