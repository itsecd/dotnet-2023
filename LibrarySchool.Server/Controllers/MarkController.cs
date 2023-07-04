using AutoMapper;
using FluentValidation;
using LibrarySchool;
using LibrarySchool.Domain;
using LibrarySchool.Server.Exceptions;
using LibrarySchoolServer.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySchoolServer.Controllers;
/// <summary>
/// Controler for class Marks. Defined methods: Post, Put, Get, Delete
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class MarkController : Controller
{
    private readonly ILogger<ClassTypeController> _logger;
    private readonly IDbContextFactory<LibrarySchoolContext> _contextFactory;
    private readonly IMapper _mapper;
    private readonly IValidator<MarkPostDto> _validator;

    /// <summary>
    /// Constructor for class MakrController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="contextFactory"></param>
    /// <param name="mapper"></param>
    /// <param name="validator"></param>
    public MarkController(ILogger<ClassTypeController> logger, IDbContextFactory<LibrarySchoolContext> contextFactory, IMapper mapper, IValidator<MarkPostDto> validator)
    {
        _logger = logger;
        _mapper = mapper;
        _contextFactory = contextFactory;
        _validator= validator;
    }
    /// <summary>
    /// Get list mark
    /// </summary>
    /// <returns>
    /// Return: list mark
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<MarkGetDto>> Get()
    {
        _logger.LogInformation("Get list marks");
        var ctx = await _contextFactory.CreateDbContextAsync();
        return _mapper.Map<IEnumerable<MarkGetDto>>(ctx.Marks);
    }
    /// <summary>
    /// Get mark with certain id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// Return: Ation result Ok if mark exist, NotFound if not exist
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<MarkGetDto>> Get(int id)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var foundMark = await ctx.Marks.FirstOrDefaultAsync(mark => mark.MarkId == id);
        if (foundMark == null)
        {
            _logger.LogInformation("Not found mark id: {id}", id);
            return NotFound();
        }
        return Ok(_mapper.Map<MarkGetDto>(foundMark));
    }

    /// <summary>
    /// Add new mark to respository
    /// </summary>
    /// <param name="markToPost"></param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] MarkPostDto markToPost)
    {
        var validationResult = await _validator.ValidateAsync(markToPost);
        if (!validationResult.IsValid)
        {
            throw new BadRequestException(validationResult.Errors.First().ErrorMessage);
        }
        var ctx = await _contextFactory.CreateDbContextAsync();  
        var foundStudent = await ctx.Students.FirstOrDefaultAsync(student => student.StudentId == markToPost.StudentId);
        if (foundStudent == null)
           throw new Exception($"Not found student id: {markToPost.StudentId}");
        var foundSubject = await ctx.Subjects.FirstOrDefaultAsync(subject => subject.SubjectId == markToPost.SubjectId);
        if (foundSubject == null)
            throw new Exception ($"Not found subject id: {markToPost.SubjectId}");
        await ctx.Marks.AddAsync(_mapper.Map<Mark>(markToPost));
        await ctx.SaveChangesAsync();
        _logger.LogInformation("Successfuly add new mark");
        return Ok();
    }

    /// <summary>
    /// Change information of mark with certain Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="fixedMark"></param>
    /// <returns>
    /// Return: IActionResult NotFound if not exist or Ok if exist
    /// </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] MarkPostDto fixedMark)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var markToFix = await ctx.Marks.FirstOrDefaultAsync(mark => mark.MarkId == id);
        if (markToFix == null)
        {
            _logger.LogInformation("Not found mark {id}", id);
            throw new NotFoundException($"Not found mark {id}");
        }
        var foundStudent = await ctx.Students.FirstOrDefaultAsync(student => student.StudentId == fixedMark.StudentId);
        if (foundStudent == null)
            throw new Exception($"Not found student id: {fixedMark.StudentId}");
        var foundSubject = await ctx.Subjects.FirstOrDefaultAsync(subject => subject.SubjectId == fixedMark.SubjectId);
        if (foundSubject == null)
            throw new Exception ($"Not found subject id: {fixedMark.SubjectId}");
        _mapper.Map(fixedMark, markToFix);
        ctx.Update(_mapper.Map<Mark>(markToFix));
        await ctx.SaveChangesAsync();
        _logger.LogInformation("Successfuly update mark id: {id}", id);
        return Ok();
    }

    /// <summary>
    /// Delete a mark with certain Id 
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// Return: IActionResult NotFound if not exist or Ok if student deleted
    /// </returns>

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var foundMark = await ctx.Marks.FirstOrDefaultAsync(mark => mark.MarkId == id);
        if (foundMark == null)
        {
            _logger.LogInformation("Not found mark id: {id}", id);
            throw new NotFoundException($"Not found mark id: {id}");
        }
        ctx.Remove(foundMark);
        await ctx.SaveChangesAsync();
        _logger.LogInformation("Successfuly delete mark id: {id}", id);
        return Ok();
    }
}
