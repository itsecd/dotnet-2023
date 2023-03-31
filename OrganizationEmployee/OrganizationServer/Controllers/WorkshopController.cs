﻿using AutoMapper;
using EmployeeDomain;
using Microsoft.AspNetCore.Mvc;
using OrganizationServer.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrganizationServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WorkshopController : ControllerBase
{
    private OrganizationRepository _organizationRepository;
    private IMapper _mapper;

    public WorkshopController(OrganizationRepository organizationRepository, IMapper mapper)
    {
        _organizationRepository = organizationRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<WorkshopDTO> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)  //здесь можно сделать page-nation, он принимает
                                                                                            //номер страницы и размер страницы (чтобы если у нас очень много данных - выводить их страницами)
    {
        return _mapper.Map<IEnumerable<WorkshopDTO>>(_organizationRepository.Workshops); // использовать Take() и Skip()
    }

    [HttpGet("{id}")]
    public ActionResult<WorkshopDTO> Get(int id)
    {
        var workshop = _organizationRepository.Workshops.FirstOrDefault(workshop => workshop.Id == id);
        if (workshop == null) return NotFound();
        var mappedWorkshop = _mapper.Map<WorkshopDTO>(workshop);
        return Ok(mappedWorkshop);
    }

    [HttpPost]
    public ActionResult<WorkshopDTO> Post([FromBody] WorkshopDTO workshop)
    {
        var mappedWorkshop = _mapper.Map<Workshop>(workshop);
        _organizationRepository.Workshops.Add(mappedWorkshop);
        return Ok(workshop);
    }

    [HttpPut("{id}")]
    public ActionResult<WorkshopDTO> Put(int id, [FromBody] WorkshopDTO newWorkshop)
    {
        var workshop = _organizationRepository.Workshops.FirstOrDefault(workshop => workshop.Id == id);
        if (workshop == null) return NotFound();
        _organizationRepository.Workshops.Remove(workshop);
        var mappedWorkshop = _mapper.Map<Workshop>(newWorkshop);
        _organizationRepository.Workshops.Add(mappedWorkshop);
        return Ok(newWorkshop);
    }

    [HttpDelete("{id}")]
    public ActionResult<WorkshopDTO> Delete(int id)
    {
        var workshop = _organizationRepository.Workshops.FirstOrDefault(workshop => workshop.Id == id);
        if (workshop == null) return NotFound();
        _organizationRepository.Workshops.Remove(workshop);
        return Ok();
    }
}
