using DotNet2023.Domain.Organization;
using DotNet2023.WebApi.Interfaces.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DotNet2023.WebApi.Controllers.Queries;

[Route("api/[controller]")]
[ApiController]
public class QueriesController : Controller
{
    private readonly IQueries _repository;

    public QueriesController(IQueries repository) => 
        _repository = repository;

    [HttpGet("GetInstitutionById")]
    public IActionResult GetInstitutionById(string id)
    {
        var result = _repository.GetInstitutionById(id);
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(result);
    }

    [HttpGet("GetInstitutionByInitials")]
    public IActionResult GetInstitutionByInitials(string initials)
    {
        var result = _repository.GetInstitutionByInitials(initials);
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(result);
    }

    [HttpGet("GetInstitutionStruct")]
    public IActionResult GetInstitutionStruct(
        InstitutionalProperty institutionalProperty,
        BuildingProperty buildingProperty)
    {
        var result = _repository
            .GetInstitutionStruct(institutionalProperty, buildingProperty);
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(result);
    }

    [HttpGet("GetInstitutionStructByInitials")]
    public IActionResult GetInstitutionStructByInitials(string initials)
    {
        var result = _repository
            .GetInstitutionStructByInitials(initials);
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(result);
    }

    [HttpGet("GetInstitutionsWithMaxDepartments")]
    public IActionResult GetInstitutionsWithMaxDepartments()
    {
        var result = _repository
            .GetInstitutionsWithMaxDepartments();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(result);
    }

    [HttpGet("GetOwnershipInstitutionAndGroup")]
    public IActionResult GetOwnershipInstitutionAndGroup(InstitutionalProperty property)
    {
        var result = _repository
            .GetOwnershipInstitutionAndGroup(property);
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(result);
    }

    [HttpGet("GetPopularSpeciality")]
    public IActionResult GetPopularSpeciality()
    {
        var result = _repository.GetPopularSpeciality();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(result);
    }
}
