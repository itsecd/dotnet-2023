using AutoMapper;
using FluentValidation;
using LibrarySchool;
using LibrarySchool.Domain;
using LibrarySchool.Server.Dto.Validator;
using LibrarySchoolServer.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySchoolServer.Controllers;

/// <summary>
/// Controller for class ClassTypes. Define method: Get
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ClassTypeController : Controller
{
    private readonly ILogger<ClassTypeController> _logger;
    private readonly IDbContextFactory<LibrarySchoolContext> _contextFactory;
    private readonly IMapper _mapper;
    private readonly IValidator<ClassTypePostDto> _validator;
    /// <summary>
    /// Contructor for controller
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="contextFactory"></param>
    /// <param name="mapper"></param>
    /// <param name="validator"></param>
    public ClassTypeController(ILogger<ClassTypeController> logger, IDbContextFactory<LibrarySchoolContext> contextFactory, IMapper mapper, IValidator<ClassTypePostDto> validator)
    {
        _logger = logger;
        _mapper = mapper;
        _contextFactory = contextFactory;
        _validator = validator;
    }

    /// <summary>
    /// Get list Class
    /// </summary>
    /// <returns>
    /// Return: list class type ClassTypeGetDto
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<ClassTypeGetDto>> Get()
    {
        _logger.LogInformation("Get list classes");
        var ctx = await _contextFactory.CreateDbContextAsync();
        return _mapper.Map<IEnumerable<ClassTypeGetDto>>(ctx.ClassTypes);
    }

    /// <summary>
    /// Get class by certain Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// Class with certain Id
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ClassTypeGetDto>> Get(int id)
    {
        _logger.LogInformation("Get class by id");
        var ctx = await _contextFactory.CreateDbContextAsync();
        var foundClassType = await ctx.ClassTypes.FirstOrDefaultAsync(classType => classType.ClassId== id);
        if (foundClassType == null)
        {
            _logger.LogInformation("Not found class-type {id}", id);
            return NotFound();
        }
        return Ok(_mapper.Map<ClassTypeGetDto>(foundClassType));
    }

    /// <summary>
    /// Create new class
    /// </summary>
    /// <param name="classTypeToPost"></param>
    /// <returns>
    /// Class with certain Id
    /// </returns>
    [HttpPost]
    public async Task<IActionResult> Post(ClassTypePostDto classTypeToPost)
    {
        var validationResult = await _validator.ValidateAsync(classTypeToPost);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors.First().ErrorMessage);
        var ctx = await _contextFactory.CreateDbContextAsync();
        await ctx.ClassTypes.AddAsync(_mapper.Map<ClassType>(classTypeToPost));
        await ctx.SaveChangesAsync();
        _logger.LogInformation("Successfuly add new class-type");
        return Ok();
    }

    /// <summary>
    ///  Change information of class by Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="fixedClassType"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ClassTypePostDto fixedClassType)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var foundClassType = await ctx.ClassTypes.FirstOrDefaultAsync(classType => classType.ClassId == id);
        if (foundClassType == null)
        {
            _logger.LogInformation("Not found class-type id: {id}", id);
            return NotFound();
        }
        _mapper.Map(fixedClassType, foundClassType);
        ctx.Update(_mapper.Map<ClassType>(foundClassType));

        await Task.Run(() => ctx.Update(_mapper.Map<ClassType>(foundClassType)));
        await ctx.SaveChangesAsync();
        _logger.LogInformation("Successfuly change class id: {id}", id);
        return Ok();
    }

    /// <summary>
    /// Delete class by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var foundClassType = await ctx.ClassTypes.Include(classType => classType.Students)
                                                 .FirstOrDefaultAsync(classType => classType.ClassId == id);
                                                 
        if (foundClassType == null)
        {
            _logger.LogInformation("Not found class-type id: {id}", id);
            return NotFound();
        }
        ctx.ClassTypes.Remove(foundClassType);
        await ctx.SaveChangesAsync();
        _logger.LogInformation("Successfuly delete class id: {id}", id);
        return Ok();
    }
}
