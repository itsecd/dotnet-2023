using AutoMapper;
using FluentValidation;
using LibrarySchool;
using LibrarySchool.Domain;
using LibrarySchool.Server.Exceptions;
using LibrarySchoolServer.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace LibrarySchoolServer.Controllers;
/// <summary>
/// Controler for class Students. Defined methods: Post, Put, Get, Delete
/// </summary>

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly ILogger<ClassTypeController> _logger;
    private readonly IDbContextFactory<LibrarySchoolContext> _contextFactory;
    private readonly IMapper _mapper;
    private readonly IValidator<StudentPostDto> _validator;
    /// <summary>
    /// Constructor of controller Students
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="contextFactory"></param>
    /// <param name="mapper"></param>
    /// <param name="validator"></param>
    public StudentController(ILogger<ClassTypeController> logger, IDbContextFactory<LibrarySchoolContext> contextFactory, IMapper mapper, IValidator<StudentPostDto> validator)
   {
        _logger = logger;
        _mapper = mapper;
        _contextFactory = contextFactory;
        _validator = validator;
   }
    /// <summary>
    /// Get list student
    /// </summary>
    /// <returns>
    /// Return: list student type StudentGetDto
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<StudentGetDto>> Get()
    {
        var ctx =  await _contextFactory.CreateDbContextAsync();
        var users = await ctx.Students.ToArrayAsync();
        _logger.LogInformation("Get list students");
        return _mapper.Map<IEnumerable<StudentGetDto>>(users);
    }

    /// <summary>
    /// Get Students by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<StudentGetDto>> Get(int id)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get student by id");
        var foundStudent = await ctx.Students.FirstOrDefaultAsync(student => student.StudentId == id);
        if (foundStudent == null)
            throw new NotFoundException("Not found student");
        return Ok(_mapper.Map<StudentGetDto>(foundStudent));
    }

    /// <summary>
    /// Add new student
    /// </summary>
    /// <param name="studentPostDto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] StudentPostDto studentPostDto)
    {
        var validationResult = await _validator.ValidateAsync(studentPostDto);
        if (!validationResult.IsValid)
            throw new BadRequestException(validationResult.Errors.First().ErrorMessage);
        var ctx = await _contextFactory.CreateDbContextAsync();
        var founClassType = await ctx.ClassTypes.FirstOrDefaultAsync(classType => classType.ClassId == studentPostDto.ClassId);
        if (founClassType == null)
            throw new NotFoundException($"Not found class id: {studentPostDto.ClassId}");
        await ctx.Students.AddAsync(_mapper.Map<Student>(studentPostDto));
        await ctx.SaveChangesAsync();
        _logger.LogInformation("Successfuly add new student");
        return Ok();
    }

    /// <summary>
    /// Delete student by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var foundStudent = await ctx.Students.Include(student => student.Marks)
                                             .Include(student => student.ClassType)
                                             .FirstOrDefaultAsync(student => student.StudentId == id);
        if (foundStudent == null)
        {
            _logger.LogInformation("Not found student id: {id}", id);
            throw new NotFoundException($"Not found student {id}");
        }
        ctx.Students.Remove(foundStudent);
        await ctx.SaveChangesAsync();
        _logger.LogInformation("Successfuly delete student id: {id}", id);
        return Ok();
    }

    /// <summary>
    /// Change information student by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="studentPostDto"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Put(int id, [FromBody] StudentPostDto studentPostDto)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var foundStudent = await ctx.Students.FirstOrDefaultAsync(student => student.StudentId == id);
        if (foundStudent == null)
        {
            _logger.LogInformation("Not found student id: {id}", id);
            throw new NotFoundException($"Not found student {id}");
        }
        var founClassType = await ctx.ClassTypes.FirstOrDefaultAsync(classType => classType.ClassId == studentPostDto.ClassId);
        if (founClassType == null)
            throw new Exception($"Not found class id: {studentPostDto.ClassId}");
        _mapper.Map(studentPostDto, foundStudent);
        ctx.Students.Update(_mapper.Map<Student>(foundStudent));
        await ctx.SaveChangesAsync();
        _logger.LogInformation("Successfuly change student id: {id}", id);
        return Ok();    
    }

}
