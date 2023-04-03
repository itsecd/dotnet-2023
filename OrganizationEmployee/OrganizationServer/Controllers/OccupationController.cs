using AutoMapper;
using EmployeeDomain;
using Microsoft.AspNetCore.Mvc;
using OrganizationServer.Dto;

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
    public IEnumerable<OccupationDto> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        return _mapper.Map<IEnumerable<OccupationDto>>(_organizationRepository.Occupations);
    }

    [HttpGet("{id}")]
    public ActionResult<OccupationDto> Get(int id)
    {
        var occupation = _organizationRepository.Occupations.FirstOrDefault(occupation => occupation.Id == id);
        if (occupation == null) return NotFound();
        var mappedOccupation = _mapper.Map<OccupationDto>(occupation);
        return Ok(mappedOccupation);
    }

    [HttpPost]
    public ActionResult<OccupationDto> Post([FromBody] OccupationDto occupation)
    {
        var mappedOccupation = _mapper.Map<Occupation>(occupation);
        _organizationRepository.Occupations.Add(mappedOccupation);
        return Ok(occupation);
    }


    [HttpPut("{id}")]
    public ActionResult<OccupationDto> Put(int id, [FromBody] OccupationDto newDepartment)
    {
        var occupation = _organizationRepository.Occupations.FirstOrDefault(occupation => occupation.Id == id);
        if (occupation == null) return NotFound();
        _organizationRepository.Occupations.Remove(occupation);
        var mappedOccupation = _mapper.Map<Occupation>(occupation);
        _organizationRepository.Occupations.Add(mappedOccupation);
        return Ok(newDepartment);
    }

    [HttpDelete("{id}")]
    public ActionResult<OccupationDto> Delete(int id)
    {
        var occupation = _organizationRepository.Occupations.FirstOrDefault(occupation => occupation.Id == id);
        if (occupation == null) return NotFound();
        _organizationRepository.Occupations.Remove(occupation);
        return Ok();
    }
}
