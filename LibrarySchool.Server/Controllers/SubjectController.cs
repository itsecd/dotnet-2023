using AutoMapper;
using FluentValidation;
using LibrarySchool;
using LibrarySchool.Domain;
using LibrarySchoolServer.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySchoolServer.Controllers;
/// <summary>
/// Controler for class Subjects. Defined methods: Get
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SubjectController : ControllerBase
{
    private readonly ILogger<SubjectController> _logger;
    private readonly IDbContextFactory<LibrarySchoolContext> _contextFactory;
    private readonly IMapper _mapper;
    private readonly IValidator<SubjectPostDto> _validator;
    /// <summary>
    /// Contructor controller
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="contextFactory"></param>
    /// <param name="mapper"></param>
    /// <param name="validator"></param>
    public SubjectController(ILogger<SubjectController> logger, IDbContextFactory<LibrarySchoolContext> contextFactory, IMapper mapper, IValidator<SubjectPostDto> validator)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
        _validator = validator;
    }

    /// <summary>
    /// Get list subject
    /// </summary>
    /// <returns>
    /// Return list subject
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<SubjectGetDto>> Get()
    {
        _logger.LogInformation("Get list subjects");
        var ctx = await _contextFactory.CreateDbContextAsync();
        return _mapper.Map<IEnumerable<SubjectGetDto>>(ctx.Subjects);
    }

    /// <summary>
    /// Get subject with certain Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// Return: Subjects with certain Id
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<SubjectGetDto>> Get(int id)
    {
        _logger.LogInformation("Get subject by id");
        var ctx = await _contextFactory.CreateDbContextAsync();
        var foundSubject = await ctx.Subjects.FirstOrDefaultAsync(subject => subject.SubjectId == id); 
        if (foundSubject == null)
        {
            _logger.LogInformation("Not found subject {id}", id);
            return NotFound();
        }
        return Ok(_mapper.Map<SubjectGetDto>(foundSubject));
    }

    /// <summary>
    /// Create new Subjects
    /// </summary>
    /// <param name="subjectPostDto"></param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SubjectPostDto subjectPostDto)
    {
        var validationResult = _validator.Validate(subjectPostDto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors.First().ErrorMessage);
        var ctx = await _contextFactory.CreateDbContextAsync();
        await ctx.Subjects.AddAsync(_mapper.Map<Subject>(subjectPostDto));
        await ctx.SaveChangesAsync();
        _logger.LogInformation("Successfuly add new subject");
        return Ok();
    }

    /// <summary>
    /// Change information of a Subjects by Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="subjectPostDto"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] SubjectPostDto subjectPostDto)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var foundSubject = await ctx.Subjects.FirstOrDefaultAsync(subject => subject.SubjectId == id); 
        if (foundSubject == null)
        {
            _logger.LogInformation("Not found subject id: {id}", id);
            return NotFound();
        }
        _mapper.Map(subjectPostDto, foundSubject);
        ctx.Subjects.Update(foundSubject);
        await ctx.SaveChangesAsync();
        _logger.LogInformation("Successfuly change subject id: {id}", id);
        return Ok();
    }

    /// <summary>
    /// Delete a subject by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var foundSubject = await ctx.Subjects.Include(subject => subject.Marks)
                                             .FirstOrDefaultAsync(subject => subject.SubjectId == id);
        if (foundSubject == null)
        {
            _logger.LogInformation("Not found subject id: {id}", id);
            return NotFound();
        }
        ctx.Subjects.Remove(foundSubject);
        await ctx.SaveChangesAsync();
        _logger.LogInformation("Successfuly delete subject id: {id}", id);
        return Ok();
    }
}
