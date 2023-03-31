using AutoMapper;
using EmployeeDomain;
using Microsoft.AspNetCore.Mvc;
using OrganizationServer.DTO;
using System.Collections.Generic;

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
    public IEnumerable<OccupationDTO> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        return _mapper.Map<IEnumerable<OccupationDTO>>(_organizationRepository.Occupations);
    }

    [HttpGet("{id}")]
    public ActionResult<OccupationDTO> Get(int id)
    {
        var occupation = _organizationRepository.Occupations.FirstOrDefault(occupation => occupation.Id == id);
        if (occupation == null) return NotFound();
        var mappedOccupation = _mapper.Map<OccupationDTO>(occupation);
        return Ok(mappedOccupation);
    }

    [HttpPost]
    public ActionResult<OccupationDTO> Post([FromBody] OccupationDTO occupation)
    {
        var mappedOccupation = _mapper.Map<Occupation>(occupation);
        _organizationRepository.Occupations.Add(mappedOccupation);
        return Ok(occupation);
    }


    [HttpPut("{id}")]
    public ActionResult<OccupationDTO> Put(int id, [FromBody] OccupationDTO newDepartment)
    {
        var occupation = _organizationRepository.Occupations.FirstOrDefault(occupation => occupation.Id == id);
        if (occupation == null) return NotFound();
        _organizationRepository.Occupations.Remove(occupation);
        var mappedOccupation = _mapper.Map<Occupation>(occupation);
        _organizationRepository.Occupations.Add(mappedOccupation);
        return Ok(newDepartment);
    }

    [HttpDelete("{id}")]
    public ActionResult<OccupationDTO> Delete(int id)
    {
        var occupation = _organizationRepository.Occupations.FirstOrDefault(occupation => occupation.Id == id);
        if (occupation == null) return NotFound();
        _organizationRepository.Occupations.Remove(occupation);
        return Ok();
    }
}
